# HKMIsOpen 判断设备是否打开

## 功能
判断设备是否已经用[HKMOpen](HKMOpen.md)打开。

## 参数
- 参数1　设备对象：无类型指针。使用[HKMOpen](HKMOpen.md)可以创建它。
- 参数2　方法：无符号32位整型数,取值可以是下面的一个或多个,如果要同时使用多个值，可将多个值做或运算,可取值如下：
  - 0: 判断设备是否被打开（键鼠、键盘或鼠标模式的设备都可以，不可与其它值同时使用）
  - 1: 判断键盘是否被打开（键鼠或者键盘模式的设备）
  - 2: 判断鼠标是否被打开（键鼠或者鼠标模式的设备）

## 返回值
布尔值

True: 设备已打开
False: 设备没有打开

## C# 例子

```csharp
uint dwDevId;
IntPtr lpDev;
dwDevId = SkmCore.HKMSearchDevice(0x1234, 0xABCD, 0);
if (dwDevId == 0xFFFFFFFF)
{
    Console.WriteLine("未找到键鼠模拟器");
    return;
}
lpDev = SkmCore.HKMOpen(dwDevId, 0);
if (lpDev == IntPtr.Zero)
{
    Console.WriteLine("打开键鼠模拟器失败");
    return;
}
if (SkmCore.HKMIsOpen(lpDev, 0))
    Console.WriteLine("键鼠模拟器已打开");
else
    Console.WriteLine("键鼠模拟器未打开");
SkmCore.HKMClose(lpDev);
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
if(HKMIsOpen(lpDev,0))
    printf("键鼠模拟器已打开");
else
    printf("键鼠模拟器未打开");
HKMClose(lpDev);
```



