using System;
using System.Runtime.InteropServices;

namespace SKM
{
    public static class DpiAwareness
    {
        /// <summary>
        /// 设置进程DPI感知(旧方法)
        /// 注意：此方法必须在任何窗口创建之前调用，如果使用库的应用已经设置DPI感知，调用此方法无效
        /// </summary>
        /// <returns>是否成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProcessDPIAware();
        /// <summary>
        /// 设置进程DPI感知(新方法)
        /// 注意：此方法必须在任何窗口创建之前调用
        /// </summary>
        /// <param name="value">DPI感知值</param>
        /// <returns>是否成功</returns>
        [DllImport("Shcore.dll")]
        public static extern int SetProcessDpiAwarenessContext(int value);

        /// <summary>
        /// 设置进程DPI感知,如果使用库的应用已经设置DPI感知，此方法无效。
        /// 此方法必须在任何窗口创建之前调用
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void SetProcessDpiAwareness(int processDpiAwareness)
        {
            switch (processDpiAwareness)
            {
                case 0:
                    return;
                case 1:
                    DpiAwareness.SetProcessDPIAware(); //设置进程DPI感知
                    break;
                case 2:
                    DpiAwareness.SetProcessDpiAwarenessContext(2); //设置进程DPI感知
                    break;
                default:
                    throw new Exception("无效的DPI感知值");
            }
        }
    }
}