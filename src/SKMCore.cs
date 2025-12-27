using System;
using System.Runtime.InteropServices;

namespace SKM
{
    /// <summary>
    /// 注意: x86 和 x64 的 dll 是不同的，需要根据实际情况选择  
    /// x86 的 dll 是 x86\skm.dll，x64 的 dll 是 x64\skm.dll  
    /// 使用 <c>KMSimulatorService</c> 服务类可以无感知使用，会自动根据当前环境复制 DLL 到当前目录  
    /// 具体 <c>KMSimulatorService</c> 类使用请参考 <see cref="KMSimulatorService"/>
    /// </summary>
    public class SkmCore
    {
        /// <summary>
        /// 查找设备
        /// </summary>
        /// <param name="Vid">VID：无符号32位整型数。值为65536时忽略此搜索条件</param>
        /// <param name="Pid">设备PID</param>
        /// <param name="DeviceType">设备模式：无符号32位整型数。用于设置查找的键鼠模拟器的模式。可取值如下：
        /// <list type="bullet">
        /// <item>0 所有模式</item>
        /// <item>1 键鼠模式</item>
        /// <item>2 键盘模式</item>
        /// <item>3 鼠标模式</item>
        /// </list>
        /// </param>
        /// <returns>一个临时的设备ID号，只对当前应用有效,设备ID号会被打开设备函数<c>HKMOpen</c>使用到。
        /// 没找到或者失败返回0xFFFFFFFF。</returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMSearchDevice(UInt32 Vid, UInt32 Pid, UInt32 DeviceType);//查找设备
        /// <summary>
        /// 查找设备
        /// </summary>
        /// <param name="Vid">VID：无符号32位整型数。值为65536时忽略此搜索条件</param>
        /// <param name="Pid">设备PID</param>
        /// <param name="SN">序列号：无符号32位整型数。每个键鼠模拟器的值都不一样，购买盒子时会提供</param>
        /// <param name="DeviceType">设备模式：无符号32位整型数。用于设置查找的键鼠模拟器的模式。可取值如下：
        /// <list type="bullet">
        /// <item>0 所有模式</item>
        /// <item>1 键鼠模式</item>
        /// <item>2 键盘模式</item>
        /// <item>3 鼠标模式</item>
        /// </list>
        /// </param>
        /// <returns>一个临时的设备ID号，只对当前应用有效,设备ID号会被打开设备函数<c>HKMOpen</c>使用到。
        /// 没找到或者失败返回0xFFFFFFFF。</returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMSearchDevice2(UInt32 Vid, UInt32 Pid, UInt32 SN, UInt32 DeviceType);//查找设备
        [DllImport("skm.dll")]
        public static extern IntPtr HKMSearchDeviceAll(UInt32 Vid, UInt32 Pid, UInt32 DeviceType);//查找全部设备
        [DllImport("skm.dll")]
        public static extern IntPtr HKMOpen(UInt32 DeviceId, UInt32 DpiMode);//打开设备
        [DllImport("skm.dll")]
        public static extern IntPtr HKMOpen2(UInt32 DeviceId1, UInt32 DeviceId2, UInt32 DpiMode);//打开设备
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsOpen(IntPtr HKMData, UInt32 Flags);//判断设备是否打开
        [DllImport("skm.dll")]
        public static extern Boolean HKMClose(IntPtr HKMData);//关闭设备
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetDevInfo(IntPtr HKMData, UInt32 Index, Boolean Mouse);//获得设备信息
        [DllImport("skm.dll")]
        public static extern IntPtr HKMGetDevString(IntPtr HKMData, UInt32 Index, Boolean Mouse, ref UInt32 Length);//获得设备字符串
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetSerialNumber(IntPtr HKMData, Boolean Mouse);//获得序列号
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetKeyboardMode(IntPtr HKMData);//获得键盘模式
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetMouseMode(IntPtr HKMData);//获得鼠标模式
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsKeyBusy(IntPtr HKMData);//判断键盘是否繁忙
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsMouseBusy(IntPtr HKMData);//判断鼠标是否繁忙
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMIsKeyDown(IntPtr HKMData, String KeyName);//判断键盘是否按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsMouseButtonDown(IntPtr HKMData, UInt32 Index);//判断鼠标键是否按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMGetKeyboardLEDState(IntPtr HKMData, UInt32 Index);//获得键盘LED灯状态
        [DllImport("skm.dll")]
        public static extern Boolean HKMGetCursorPos(IntPtr HKMData, ref Int32 X, ref Int32 Y);//获得鼠标坐标
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetCursorPos2(IntPtr HKMData);//获得鼠标坐标
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMode(IntPtr HKMData, UInt32 Index, UInt32 Mode);//设置模式
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetKeyInterval(IntPtr HKMData, UInt32 MinTime, UInt32 MaxTime);//设置按键时间间隔
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMouseInterval(IntPtr HKMData, UInt32 MinTime, UInt32 MaxTime);//设置鼠标时间间隔
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetAbsMouseScrnRes(IntPtr HKMData, Int32 Width, Int32 Height);//设置绝对鼠标屏幕分辨率
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMousePosPrecision(IntPtr HKMData, UInt32 Precision);//设置鼠标坐标精度
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMouseSpeed(IntPtr HKMData, UInt32 MouseSpeed);//设置鼠标速度
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMouseMoveTimeout(IntPtr HKMData, UInt32 Timeout);//设置鼠标移动超时时间
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetMousePosMaxOffset(IntPtr HKMData, UInt32 dwOffset);//设置鼠标坐标最大偏移
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMKeyPress(IntPtr HKMData, String KeyName);//键盘按键
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMKeyDown(IntPtr HKMData, String KeyName);//键盘按下
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMKeyUp(IntPtr HKMData, String KeyName);//键盘弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMMoveTo(IntPtr HKMData, Int32 X, Int32 Y);//鼠标移动
        [DllImport("skm.dll")]
        public static extern Boolean HKMMoveR(IntPtr HKMData, Int32 X, Int32 Y);//鼠标相对移动
        [DllImport("skm.dll")]
        public static extern Boolean HKMMoveR2(IntPtr HKMData, Int32 X, Int32 Y);//鼠标相对移动
        [DllImport("skm.dll")]
        public static extern Boolean HKMMoveRP(IntPtr HKMData, Int32 X, Int32 Y);//鼠标相对移动
        [DllImport("skm.dll")]
        public static extern Boolean HKMLeftClick(IntPtr HKMData);//鼠标左键单击
        [DllImport("skm.dll")]
        public static extern Boolean HKMRightClick(IntPtr HKMData);//鼠标右键单击
        [DllImport("skm.dll")]
        public static extern Boolean HKMMiddleClick(IntPtr HKMData);//鼠标中键单击
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn1Click(IntPtr HKMData);//鼠标XButton1键单击
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn2Click(IntPtr HKMData);//鼠标XButton2键单击
        [DllImport("skm.dll")]
        public static extern Boolean HKMLeftDoubleClick(IntPtr HKMData);//鼠标左键双击
        [DllImport("skm.dll")]
        public static extern Boolean HKMRightDoubleClick(IntPtr HKMData);//鼠标右键双击
        [DllImport("skm.dll")]
        public static extern Boolean HKMMiddleDoubleClick(IntPtr HKMData);//鼠标中键双击
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn1DoubleClick(IntPtr HKMData);//鼠标XButton1键双击
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn2DoubleClick(IntPtr HKMData);//鼠标XButton2键双击
        [DllImport("skm.dll")]
        public static extern Boolean HKMLeftDown(IntPtr HKMData);//鼠标左键按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMRightDown(IntPtr HKMData);//鼠标右键按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMMiddleDown(IntPtr HKMData);//鼠标中键按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn1Down(IntPtr HKMData);//鼠标XButton1键按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn2Down(IntPtr HKMData);//鼠标XButton2键按下
        [DllImport("skm.dll")]
        public static extern Boolean HKMLeftUp(IntPtr HKMData);//鼠标左键弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMRightUp(IntPtr HKMData);//鼠标右键弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMMiddleUp(IntPtr HKMData);//鼠标中键弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn1Up(IntPtr HKMData);//鼠标XButton1键弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMXBtn2Up(IntPtr HKMData);//鼠标XButton2键弹起
        [DllImport("skm.dll")]
        public static extern Boolean HKMMouseWheel(IntPtr HKMData, Int32 Count);//鼠标滚轮
        [DllImport("skm.dll")]
        public static extern Boolean HKMMouseWheelP(IntPtr HKMData, Int32 Count);//鼠标滚轮
        [DllImport("skm.dll")]
        public static extern Boolean HKMReleaseKeyboard(IntPtr HKMData);//释放键盘按键
        [DllImport("skm.dll")]
        public static extern Boolean HKMReleaseMouse(IntPtr HKMData);//释放鼠标按键
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMOutputString(IntPtr HKMData, String Str);//输出字符串
        [DllImport("skm.dll")]
        public static extern Boolean HKMDelayRnd(IntPtr HKMData, UInt32 MinTime, UInt32 MaxTime);//随机延时
        [DllImport("skm.dll")]
        private static extern IntPtr HKMCheckPressedKeys(UInt32 Flags, ref UInt32 Length);//检查按键
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMVerifyUserData(IntPtr HKMData, String Str, Boolean Mouse);//验证用户数据
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 HKMVerifyUserData2(IntPtr HKMData, String Str, Boolean Mouse);//验证用户数据2
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetResetMode(IntPtr HKMData, UInt32 Mode, Boolean Mouse);//设置复位模式
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetResetTime(IntPtr HKMData, UInt32 Time, Boolean Mouse);//设置复位时间
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetLightMode(IntPtr HKMData, UInt32 Mode, Boolean Mouse);//设置指示灯模式
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsOSMouseAccelerateEnabled();//判断是否开启系统鼠标加速
        [DllImport("skm.dll")]
        public static extern Boolean HKMEnableOSMouseAccelerate(Boolean Enable, Boolean Save);//启停系统鼠标加速
        [DllImport("skm.dll")]
        public static extern Int32 HKMGetOSMouseSpeed();//获得系统鼠标速度
        [DllImport("skm.dll")]
        public static extern Boolean HKMSetOSMouseSpeed(Int32 Speed, Boolean Save);//设置系统鼠标速度
        [DllImport("skm.dll")]
        public static extern Boolean HKMFreeData(IntPtr Data);//释放数据
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetDataCount(IntPtr Data);//获得数据数量
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetDataUnitInt(IntPtr Data, UInt32 Index);//获得数据单元整数值

        public static String HKMCheckPressedKeysCS(UInt32 Flags)//检查按键
        {
            IntPtr str_ptr;
            UInt32 Len = 0;
            String str;

            str_ptr = HKMCheckPressedKeys(Flags, ref Len);
            if (str_ptr == IntPtr.Zero)
                return null;
            str = Marshal.PtrToStringUni(str_ptr);
            HKMFreeData(str_ptr);
            return str;
        }

        public static String HKMGetDevStringCS(IntPtr HKMData, UInt32 Index, Boolean Mouse)//检查按键
        {
            IntPtr str_ptr;
            UInt32 Len = 0;
            String str;

            str_ptr = HKMGetDevString(HKMData, Index, Mouse, ref Len);
            if (str_ptr == IntPtr.Zero)
                return null;
            str = Marshal.PtrToStringUni(str_ptr);
            return str;
        }
    }
}
