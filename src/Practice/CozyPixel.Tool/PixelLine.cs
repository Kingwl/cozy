﻿using CozyPixel.Command;
using CozyPixel.Draw;
using CozyPixel.Helper;
using CozyPixel.Interface;
using System.Collections.Generic;
using System.Drawing;

namespace CozyPixel.Tool
{
    public class PixelLine : PixelToolBase
    {
        public override bool WillModify { get { return true; } }

        public int Width { get; set; } = 2;

        private Point BeginPoint { get; set; }

        public PixelLine(Color holder)
            :base(holder)
        {

        }

        protected override void OnBegin(Point p)
        {
            base.OnBegin(p);

            if(Target != null && Target.IsReady)
            {
                BeginPoint = p.ToMap(Target.GridWidth);
            }
        }

        protected override void OnMove(Point p)
        {
            base.OnMove(p);

            if(Target != null && ColorHolder != null && Target.IsReady)
            {
                Target.UpdateDrawable();
                var points = new Dictionary<Point, Color>();
                GenericDraw.Line(BeginPoint, p.ToMap(Target.GridWidth), ColorHolder, points);
                Target.FakeDrawPixel(points.GetDistributionColor(Target, Width));
            }
        }

        protected override bool OnEnd(Point p)
        {
            base.OnEnd(p);

            if (Target != null && ColorHolder != null && Target.IsReady)
            {
                var points = new Dictionary<Point, Color>();
                GenericDraw.Line(BeginPoint, p.ToMap(Target.GridWidth), ColorHolder, points);
                var command = new DrawPixelCommand()
                {
                    Points  = points.GetDistributionColor(Target, Width),
                    Target  = Target,
                };
                CommandManager.Instance.Do(command);

                Target.UpdateDrawable();
                return true;
            }
            return false;
        }
    }
}
