using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace BeforeUpdateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 获取配置的进程名
            var programName = ConfigurationManager.AppSettings["ProgramName"]; // 进程名
            var programChineseName = ConfigurationManager.AppSettings["ProgramChineseName"] ?? programName; // 进程中文名

            if (string.IsNullOrEmpty(programName)) // 没有配置进程名字，退出
            {
                return;
            }

            // 2. 检测系统进程中 程序是正在运行
            var processes = Process.GetProcessesByName(programName);
            if (processes.Length != 0) // 程序已经在运行进行提示，并退出
            {
                var dialogResult = MessageBox.Show($"“{programChineseName}”程序正在运行，无法进行更新，请手动关闭“{programChineseName}”程序！",
                    "警告",
                    MessageBoxButtons.Ok,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxModal.Application);
                return;
            }
            // 3. 启动安装程序
            string setupFile = "setup.exe";
            if (File.Exists(setupFile))
            {
                Process.Start(setupFile);
            }
        }
    }
}
