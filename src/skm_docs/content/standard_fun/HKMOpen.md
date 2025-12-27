# HKMOpen 打开设备

---

## 功能

打开键鼠模拟器，以便对它进行操作

## 参数
- 参数1  设备ID：无符号32位整型数。使用[HKMSearchDevice](HKMSearchDevice)或者[HKMSearchDevice2](HKMSearchDevice2)可以获得它。
- 参数2　DPI模式：无符号32位整型数。
用于设置鼠标移动（HKMMoveTo和HKMMoveR2）和获得鼠标坐标（HKMGetCursorPos和HKMGetCursorPos2）时使用的坐标的DPI模式。
WINDOW系统为了支持程序界面缩放，使用了不同坐标，不同DPI模式对应不同坐标计算方式,可取值如下:
  - 0: 每个显示器DPI感知，此模式不受系统DPI设置和显示器DPI设置影响，每个坐标与显示器像素是一一对应的，windows系统从WIN8.1开始支持此模式，WIN8.1以前等效于系统DPI感知,一般应该设置为该值。
  - 1: 主显示器DPI感知。在WIN8.1以前的系统中每个坐标与显示器像素是一一对应的,适用于旧系统
  - 2: 无DPI感知
  - 3: DPI不可
  - 4: 当前上下文的DPI感知。根据当前上下文决定DPI感知。

## 返回值:
无类型指针。创建的设备句柄。失败返回NULL。不再使用它时用HKMClose可以关闭它以释放资源。

在本文档中我们有时候也称之为"设备对象"

## C# 示例代码
```csharp

UInt32 dwDevId;
IntPtr lpDev;

// 查找设备（此处以VID=0x1234，PID=0xABCD为例，DeviceType=0）
dwDevId = SKM.SkmCore.HKMSearchDevice(0x1234, 0xABCD, 0);
if (dwDevId == 0xFFFFFFFF)
{
    Console.WriteLine("未找到键鼠模拟器");
    return;
}

// 打开设备，DpiMode=0
lpDev = SKM.SkmCore.HKMOpen(dwDevId, 0);
if (lpDev == IntPtr.Zero)
{
    Console.WriteLine("打开键鼠模拟器失败");
    return;
}

// 执行其它操作...

// 关闭设备
SKM.SkmCore.HKMClose(lpDev);

```

## C语言例子
```
DWORD dwDevId;
LPVOID lpDev;
dwDevId=HKMSearchDevice(0x1234,0xABCD,0);
if(dwDevId==0xFFFFFFFF)
{
    printf("未找到键鼠模拟器\n");
    return 0;
}
lpDev=HKMOpen(dwDevId,0);
if(lpDev==NULL)
{
    printf("打开键鼠模拟器失败\n");
    return 0;
}
//执行操作
HKMClose(lpDev);
```




