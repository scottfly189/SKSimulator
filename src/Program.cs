using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using SKM;


//注意：在项目文件中需要配置复制DLL到输出目录，否则无法找到DLL文件
//x64环境需要复制x64\skm.dll，x86环境需要复制x86\skm.dll 到当前目录，意思是：x64环境需要使用x64\skm.dll，x86环境需要使用x86\skm.dll
//使用KMSimulatorService服务类可以无感知使用，会自动根据当前环境复制DLL到当前目录

IntPtr HKMData = IntPtr.Zero;

//查找设备,这个只是例子,参数中的VID和PID要改成实际值
KMSimulatorService.Init(Config.KMDeiviceVID, Config.KMDeivicePID, Config.KMVerifyUserData);
HKMData = KMSimulatorService.DeviceData;



//设置模式
//OutputString函数输出Unicode字符串，默认输出Asni字符串
SkmCore.HKMSetMode(HKMData, 4, 4);

//Console.WriteLine("开始执行操作");

//打开资源管理器快捷键Win+E
// hkm.HKMKeyDown(HKMData, "WIN");
// hkm.HKMDelayRnd(HKMData, 100, 150);
// hkm.HKMKeyPress(HKMData, "E");
// hkm.HKMDelayRnd(HKMData, 100, 150);
// hkm.HKMKeyUp(HKMData, "WIN");

// hkm.HKMDelayRnd(HKMData, 100, 150);

//直接使用组合键
// hkm.HKMKeyPress(HKMData, "WIN+E");

//hkm.HKMDelayRnd(HKMData, 100, 150);

//打开记事本
System.Diagnostics.Process.Start("notepad.exe");
SkmCore.HKMDelayRnd(HKMData, 500, 600);
//输出字符串
//如果中文部分出现乱码，用HKMSetMode改变输出字符串编码
SkmCore.HKMOutputString(HKMData, "ABC中文，可以打成全部是中文吗？");
SkmCore.HKMDelayRnd(HKMData, 1000, 1500);
SkmCore.HKMOutputString(HKMData, "\r\n换行测试，Hello World!");
SkmCore.HKMDelayRnd(HKMData, 1000, 1500);
SkmCore.HKMKeyPress(HKMData, "Ctrl+A");
SkmCore.HKMKeyPress(HKMData,"Backspace");

//鼠标相对移动
SkmCore.HKMMoveR(HKMData, 100, 50);

SkmCore.HKMDelayRnd(HKMData, 1000, 1500);

//鼠标绝对移动
SkmCore.HKMMoveTo(HKMData, 200, 100);

SkmCore.HKMDelayRnd(HKMData, 1000, 1500);

//鼠标左键单击
SkmCore.HKMLeftClick(HKMData);

//关闭设备
KMSimulatorService.CloseDevice();

Console.WriteLine("程序已执行到最后，按回车键结束程序");
Console.ReadLine();