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
        /// <summary>
        /// 查找全部设备
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
        /// <returns>设备ID的数组，可用<c>HKMGetDataCount</c>函数获取数组元素数量。失败返回NULL。当不再使用这个字符串时，使用<c>HKMFreeData</c>释放数组所占用的资源。</returns>
        [DllImport("skm.dll")]
        public static extern IntPtr HKMSearchDeviceAll(UInt32 Vid, UInt32 Pid, UInt32 DeviceType);//查找全部设备
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="DeviceId">设备ID：无符号32位整型数。使用<c>HKMSearchDevice</c>或者<c>HKMSearchDevice2</c>可以获得它。</param>
        /// <param name="DpiMode">DPI模式：无符号32位整型数。用于设置鼠标移动(<c>HKMMoveTo</c>和<c>HKMMoveR2</c>)和获得鼠标坐标(<c>HKMGetCursorPos</c>和<c>HKMGetCursorPos2</c>)时使用的坐标的DPI模式,可取值如下：
        /// <list type="bullet">
        /// <item>0 每个显示器DPI感知</item>
        /// <item>1 主显示器DPI感知</item>
        /// <item>2 键鼠模拟器DPI感知</item>
        /// <item>3 DPI不可</item>
        /// <item>4 当前上下文的DPI感知</item>
        /// </list>
        /// </param>
        /// <returns>设备对象：无类型指针。创建的设备句柄。失败返回NULL。不再使用它时用<c>HKMClose</c>可以关闭它以释放资源。</returns>
        [DllImport("skm.dll")]
        public static extern IntPtr HKMOpen(UInt32 DeviceId, UInt32 DpiMode);//打开设备
        /// <summary>
        /// 打开两个键鼠模拟器（一个键盘模式、一个鼠标模式），以便对它们进行操作。
        /// </summary>
        /// <param name="DeviceId1">第一个设备ID：无符号32位整型数。使用<c>HKMSearchDevice</c>或者<c>HKMSearchDevice2</c>可以获得它。</param>
        /// <param name="DeviceId2">第二个设备ID：无符号32位整型数。使用<c>HKMSearchDevice</c>或者<c>HKMSearchDevice2</c>可以获得它。</param>
        /// <param name="DpiMode">DPI模式：无符号32位整型数。用于设置鼠标移动(<c>HKMMoveTo</c>和<c>HKMMoveR2</c>)和获得鼠标坐标(<c>HKMGetCursorPos</c>和<c>HKMGetCursorPos2</c>)时使用的坐标的DPI模式,可取值如下：
        /// <list type="bullet">
        /// <item>0 每个显示器DPI感知</item>
        /// <item>1 主显示器DPI感知</item>
        /// <item>2 无DPI感知</item>
        /// <item>3 DPI不可</item>
        /// <item>4 当前上下文的DPI感知</item>
        /// </list>
        /// </param>
        /// <returns>设备对象：无类型指针。创建的设备句柄。失败返回NULL。不再使用它时用<c>HKMClose</c>可以关闭它以释放资源。</returns>
        [DllImport("skm.dll")]
        public static extern IntPtr HKMOpen2(UInt32 DeviceId1, UInt32 DeviceId2, UInt32 DpiMode);//打开设备
        /// <summary>
        /// 判断设备是否打开
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Flags">无符号32位整型数,取值可以是下面的一个或多个,如果要同时使用多个值，可将多个值做或运算,可取值如下：
        /// <list type="bullet">
        /// <item>0 判断设备是否被打开（键鼠、键盘或鼠标模式的设备都可以，不可与其它值同时使用）</item>
        /// <item>1 判断键盘是否被打开（键鼠或者键盘模式的设备）</item>
        /// <item>2 判断鼠标是否被打开（键鼠或者鼠标模式的设备）</item>
        /// </list>
        /// </param>
        /// <returns>布尔值。True: 设备已打开。False: 设备没有打开。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsOpen(IntPtr HKMData, UInt32 Flags);//判断设备是否打开
        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <returns>布尔值。True: 设备已关闭。False: 设备没有关闭。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMClose(IntPtr HKMData);//关闭设备
        /// <summary>
        /// 获得键鼠模拟器的设备信息
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Index">序号,可取值如下:
        /// <list type="bullet">
        /// <item>1: 设备类型，最新版返回2</item>
        /// <item>2: 固件版本,返回值中，0-15位是修订号，16-23位是副版本号，24-31位是主版本号。</item>
        /// <item>3: 运行时间,返回值是从通电或者复位开始运行的毫秒数，断电和复位都会归零。系统休眠时不计时。这个时间精度不高，有误差。</item>
        /// <item>4: 通电时间。返回值是从通电开始运行的毫秒数，断电会归零，复位不会归零。系统休眠时不计时。这个时间精度不高，有误差。</item>
        /// <item>6: 复位次数。</item>
        /// <item>7: 运行状态。设备未连接返回0xFFFFFFFF，设备准备中返回0，正常工作状态返回1，编辑状态返回2，禁止操作状态返回3。</item>
        /// <item>8: USB设备接口的VID值</item>
        /// <item>9: USB设备接口的PID值</item>
        /// <item>10: USB设备接口的设备版本值</item>
        /// </list>
        /// </param>
        /// <param name="Mouse">是否鼠标：布尔值
        /// <list type="bullet">
        /// <item>True: 获得鼠标模式的设备信息</item>
        /// <item>False: 获得键盘模式的设备信息</item>
        /// </list>
        /// </param>
        /// <returns>无符号32位整型数,返回值由参数2决定。
        /// 没找到或者失败返回0xFFFFFFFF。</returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetDevInfo(IntPtr HKMData, UInt32 Index, Boolean Mouse);//获得设备信息
        /// <summary>
        /// 获得设备字符串
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Index">序号：无符号32位整型数。用于指定要获取的字符串序号，可取值如下：
        /// <list type="bullet">
        /// <item>1: 制造商</item>
        /// <item>2: 产品名</item>
        /// </list>
        /// </param>
        /// <param name="Mouse">是否鼠标：布尔值
        /// <list type="bullet">
        /// <item>True: 获得鼠标模式的设备字符串</item>
        /// <item>False: 获得键盘模式的设备字符串</item>
        /// </list>
        /// </param>
        /// <param name="Length">字符串长度：无符号32位整型数指针。用于接收返回值为非NULL时的字符串长度（字符串长度包含'\0'）。需要时可将取值设为NULL。</param>
        /// <returns>字符串(Unicode/Ansi)。失败返回NULL。成功返回字符串指针，字符串默认为Unicode字符串，也可以通过<c>HKMSetMode</c>修改为Ansi字符串。字符串指针在设备关闭时会被释放，不需要单独释放，但需要注意数据可能会被后续调用此函数的数据覆盖。</returns>
        [DllImport("skm.dll")]
        public static extern IntPtr HKMGetDevString(IntPtr HKMData, UInt32 Index, Boolean Mouse, ref UInt32 Length);//获得设备字符串
        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Mouse">是否鼠标：布尔值
        /// <list type="bullet">
        /// <item>True: 获得鼠标模式的序列号</item>
        /// <item>False: 获得键盘模式的序列号</item>
        /// </list>
        /// </param>
        /// <returns>无符号32位整型数。失败返回0xFFFFFFFF。</returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetSerialNumber(IntPtr HKMData, Boolean Mouse);//获得序列号
        /// <summary>
        /// 获得键盘模式
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <returns>无符号32位整型数。成功返回键盘模式。失败返回0xFFFFFFFF
        /// <list type="bullet">
        /// <item>0: 无键盘</item>
        /// <item>1: 普通键盘</item>
        /// <item>5: 游戏键盘</item>
        /// </list>
        /// </returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetKeyboardMode(IntPtr HKMData);//获得键盘模式
        /// <summary>
        /// 获得鼠标模式
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <returns>无符号32位整型数。成功返回鼠标模式。失败返回0xFFFFFFFF
        /// <list type="bullet">
        /// <item>0: 无鼠标</item>
        /// <item>1: 相对坐标鼠标</item>
        /// <item>2: 绝对坐标鼠标</item>
        /// <item>3: 相对坐标鼠标+绝对坐标鼠标</item>
        /// <item>5: 相对坐标游戏鼠标</item>
        /// <item>7: 相对坐标游戏鼠标+绝对坐标鼠标</item>
        /// </list>
        /// </returns>
        [DllImport("skm.dll")]
        public static extern UInt32 HKMGetMouseMode(IntPtr HKMData);//获得鼠标模式
        /// <summary>
        /// 判断键盘是否繁忙
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <returns>布尔值。True: 键盘繁忙。False: 键盘不繁忙。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsKeyBusy(IntPtr HKMData);//判断键盘是否繁忙
        /// <summary>
        /// 判断鼠标是否繁忙
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <returns>布尔值。True: 鼠标繁忙。False: 鼠标不繁忙。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsMouseBusy(IntPtr HKMData);//判断鼠标是否繁忙
        /// <summary>
        /// 判断键盘是否按下
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="KeyName">键名：字符串(Unicode/Ansi)，或者无符号32/64位整数(32位模式使用32位整数，64位模式使用64位整数)。可以使用字符串(默认为Unicode字符串，也可以通过<c>HKMSetMode</c>修改为Ansi字符串)，也可以使用无符号32/64位整数。键名和整数对应关系可以查看<c>VirtualKeyTable</c>。</param>
        /// <returns>布尔值。True: 键盘按下。False: 键盘没按下。</returns>
        [DllImport("skm.dll", CharSet = CharSet.Unicode)]
        public static extern Boolean HKMIsKeyDown(IntPtr HKMData, String KeyName);//判断键盘是否按下
        /// <summary>
        /// 判断鼠标键是否按下
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Index">序号：无符号32位整型数。用于指定要获取的鼠标键序号，可取值如下：
        /// <list type="bullet">
        /// <item>0: 鼠标左键</item>
        /// <item>1: 鼠标右键</item>
        /// <item>2: 鼠标中键</item>
        /// </list>
        /// </param>
        /// <returns>布尔值。True: 鼠标键按下。False: 鼠标键没按下。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMIsMouseButtonDown(IntPtr HKMData, UInt32 Index);//判断鼠标键是否按下
        /// <summary>
        /// 获得键盘LED灯状态
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="Index">序号：无符号32位整型数。用于指定要获取的LED灯状态序号，可取值如下：
        /// <list type="bullet">
        /// <item>0: Num Lock灯</item>
        /// <item>1: Caps Lock灯</item>
        /// <item>2: Scroll Lock灯</item>
        /// </list>
        /// </param>
        /// <returns>布尔值。True: 键盘LED灯亮。False: 键盘LED灯灭。</returns>
        [DllImport("skm.dll")]
        public static extern Boolean HKMGetKeyboardLEDState(IntPtr HKMData, UInt32 Index);//获得键盘LED灯状态
        /// <summary>
        /// 获得鼠标坐标
        /// </summary>
        /// <param name="HKMData">设备对象：无类型指针。使用<c>HKMOpen</c>或者<c>HKMOpen2</c>可以创建它。</param>
        /// <param name="X">X坐标：整型数指针。用于接收返回值为非NULL时的X坐标。需要时可将取值设为NULL。</param>
        /// <param name="Y">Y坐标：整型数指针。用于接收返回值为非NULL时的Y坐标。需要时可将取值设为NULL。</param>
        /// <returns>布尔值。True: 成功。False: 失败。</returns>
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
