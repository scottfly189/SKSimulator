# HKMOpen2 打开设备

---

## 功能

打开两个键鼠模拟器（一个键盘模式、一个鼠标模式），以便对它们进行操作。

## 参数
- 参数1  第一个设备ID：无符号32位整型数。使用[HKMSearchDevice](HKMSearchDevice.md)或者[HKMSearchDevice2](HKMSearchDevice2)可以获得它。
- 参数1  第二个设备ID：无符号32位整型数。使用[HKMSearchDevice](HKMSearchDevice.md)或者[HKMSearchDevice2](HKMSearchDevice2)可以获得它。
- 参数3　DPI模式：无符号32位整型数。
用于设置鼠标移动（HKMMoveTo和HKMMoveR2）和获得鼠标坐标（HKMGetCursorPos和HKMGetCursorPos2）时使用的坐标的DPI模式。
WINDOW系统为了支持程序界面缩放，使用了不同坐标，不同DPI模式对应不同坐标计算方式,可取值如下:
  - 0: 每个显示器DPI感知，此模式不受系统DPI设置和显示器DPI设置影响，每个坐标与显示器像素是一一对应的，windows系统从WIN8.1开始支持此模式，WIN8.1以前等效于系统DPI感知,一般应该设置为该值。
  - 1: 主显示器DPI感知。在WIN8.1以前的系统中每个坐标与显示器像素是一一对应的,适用于旧系统
  - 2: 无DPI感知
  - 3: DPI不可
  - 4: 当前上下文的DPI感知。根据当前上下文决定DPI感知。

## 返回值:
无类型指针。创建的设备句柄。失败返回NULL。不再使用它时用HKMClose可以关闭它以释放资源。

## C# 示例代码

```csharp
uint dwDevId1, dwDevId2;
IntPtr lpDev;
dwDevId1 = SkmCore.HKMSearchDevice(0x1234, 0xABCD, 2);
if (dwDevId1 == 0xFFFFFFFF)
{
    Console.WriteLine("未找到键鼠模拟器(键盘模式)");
    return;
}
dwDevId2 = SkmCore.HKMSearchDevice(0x1234, 0xABCD, 3);
if (dwDevId2 == 0xFFFFFFFF)
{
    Console.WriteLine("未找到键鼠模拟器(鼠标模式)");
    return;
}
lpDev = SkmCore.HKMOpen2(dwDevId1, dwDevId2, 0);
if (lpDev == IntPtr.Zero)
{
    Console.WriteLine("打开无涯键鼠模拟器失败");
    return;
}
//执行操作
SkmCore.HKMClose(lpDev);
```

## C语言例子
```
DWORD dwDevId1,dwDevId2;
LPVOID lpDev;
dwDevId1=HKMSearchDevice(0x1234,0xABCD,2);
if(dwDevId1==0xFFFFFFFF)
{
    printf("未找到键鼠模拟器(键盘模式)\n");
    return 0;
}
dwDevId2=HKMSearchDevice(0x1234,0xABCD,3);
if(dwDevId2==0xFFFFFFFF)
{
    printf("未找到键鼠模拟器(鼠标模式)\n");
    return 0;
} 
lpDev=HKMOpen2(dwDevId1,dwDevId2,0);
if(lpDev==NULL)
{
    printf("打开无涯键鼠模拟器失败\n");
    return 0;
}
//执行操作
HKMClose(lpDev);
```




