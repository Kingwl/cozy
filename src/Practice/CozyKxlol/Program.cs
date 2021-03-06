﻿using System;

namespace CozyKxlol
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DebugHelper.ShowDebugPrint();
            DebugHelper.Print("Cozy!");

            using (var game = new KxlolGame())
                game.Run();

            DebugHelper.HideDebugPrint();
        }
    }
#endif
}
