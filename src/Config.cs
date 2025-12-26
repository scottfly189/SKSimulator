using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace SKM
{
    /// <summary>
    /// 参数配置类
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 键鼠模拟器设备VID
        /// </summary>
        public static int KMDeiviceVID { get; set; } = 0x2612;
        /// <summary>
        /// 键鼠模拟器设备PID
        /// </summary>
        public static int KMDeivicePID { get; set; } = 0x1701;
        /// <summary>
        /// 键鼠模拟器校验数据
        /// </summary>
        public static string KMVerifyUserData { get; set; } = "4F6A21981BE675822DEE7B9BC39F3791";
        /// <summary>
        /// 点击偏移量,单位像素
        /// 为了避免每次点击都点击到同一个位置，可以设置一个偏移量，实际点击位置为点击位置减去偏移量的一个随机值
        /// </summary>
        public static int KMOffsetOfClick { get; set; } = 5;
        /// <summary>
        /// 输出字符串编码类型,默认使用剪贴板粘贴输出字符串。优点是输出字符多时速度更快且不受输入法影响
        /// </summary>
        public static int KMOutputStringType { get; set; } = 4;
        /// <summary>
        /// 鼠标移动模式
        /// </summary>
        public static int KMMouseMoveMode { get; set; } = 0;
        /// <summary>
        /// 进程DPI感知值,如果使用库的应用已经设置DPI感知，此参数无效。
        /// 0: 不设置,进程对DPI完全不知晓，按逻辑像素绘制，可能会出现点击不准确的情况。
        /// 1: PROCESS_SYSTEM_DPI_AWARE 默认值,进程只根据主显示器DPI绘制，DPI感知生效。
        /// 2: PROCESS_PER_MONITOR_DPI_AWARE，进程根据每个显示器DPI绘制,DPI感知生效。
        /// </summary>
        public static int ProcessDpiAwareness { get; set; } = 1;
    }
}