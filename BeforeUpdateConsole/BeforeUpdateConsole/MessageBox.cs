using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace BeforeUpdateConsole
{
    public class MessageBox
    {
        /// <summary>
        /// 原生方法
        /// </summary>
        /// <param name="h"></param>
        /// <param name="msg">显示提示</param>
        /// <param name="caption">标题</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode)]
        private static extern int MsgBox(IntPtr h, string msg, string caption, uint type);

        public static MessageBoxResult Show(string text)
        {
            return (MessageBoxResult)MsgBox(IntPtr.Zero, text, "\0", (uint)MessageBoxButtons.Ok);
        }

        public static MessageBoxResult Show(string text, string caption)
        {
            return (MessageBoxResult)MsgBox(IntPtr.Zero, text, caption, (uint)MessageBoxButtons.Ok);
        }

        public static MessageBoxResult Show(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.Ok)
        {
            return (MessageBoxResult)MsgBox(IntPtr.Zero, text, caption, (uint)buttons);
        }

        public static MessageBoxResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
           return (MessageBoxResult)MsgBox(IntPtr.Zero, text, caption, ((uint)buttons) | ((uint)icon));
        }

        public static MessageBoxResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button)
        {
            return (MessageBoxResult)MsgBox(IntPtr.Zero, text, caption, ((uint)buttons) | ((uint)icon) | ((uint)button));
        }

        public static MessageBoxResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton button, MessageBoxModal modal)
        {
            return (MessageBoxResult)MsgBox(IntPtr.Zero, text, caption, ((uint)buttons) | ((uint)icon) | ((uint)button) | ((uint)modal));
        }
    }
}
