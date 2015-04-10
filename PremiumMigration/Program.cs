﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PremiumMigration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PremiumMigrationForm());
        }
    }
}
