# 查找设备 HKMSearchDevice

## 功能:
查找设备

## 参数:
- 参数1　VID：无符号32位整型数。值为65536时忽略此搜索条件。
- 参数2　PID：无符号32位整型数。值为65536时忽略此搜索条件。
- 参数3　设备模式：无符号32位整型数。用于设置查找的键鼠盒子的模式。可取值如下：
  - 0 所有模式 
  - 1 键鼠模式 
  - 2 键盘模式 
  - 3 鼠标模式 

## 返回值:
无符号32位整型数。一个临时的设备ID号，只对当前应用有效,设备ID号会被打开设备函数```HKMOpen```使用到。

没找到或者失败返回0xFFFFFFFF。

## C#例子
```csharp
uint deviceId = SkmCore.HKMSearchDevice(0x1234, 0xABCD, 0);
Console.WriteLine($"设备ID号:{deviceId:X8}");
```

## C语言例子
```
printf("设备ID号:%08X\n",HKMSearchDevice(0x1234,0xABCD,0));
```







