﻿using CozyRSS.Resources.Dialog;
using CozyRSS.ViewModel;
using CozyRSS.ViewModel.Dialog;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace CozyRSS.Actions
{
    public class MainWindowActions
    {
        public MainWindowActions()
        {
            MoveWindowAction = (w) =>
            {
                Window window = w as Window;
                window?.DragMove();
            };

            DoubleClickAction = (w) =>
            {
                Window window = w as Window;
                if (window != null)
                {
                    if (window.WindowState == WindowState.Maximized)
                        window.WindowState = WindowState.Normal;
                    else
                        window.WindowState = WindowState.Maximized;
                }
            };

            OpenAddFeedDialogAction = () =>
            {
                AddFeedDialog dlg = new AddFeedDialog() { DataContext = new AddFeedDialogViewModel() };
                DialogHost.Show(dlg, "RootDialog", ClosingEventHandler);
            };
        }
        public readonly Action<object> MoveWindowAction;
        public readonly Action<object> DoubleClickAction;
        public readonly Action OpenAddFeedDialogAction; 

        public RSSListFrameViewModel RSSListFrameViewModel;
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is string)
            {
                RSSListFrameViewModel?.AddFeed(eventArgs.Parameter as string);
            }
        }
    }
}
