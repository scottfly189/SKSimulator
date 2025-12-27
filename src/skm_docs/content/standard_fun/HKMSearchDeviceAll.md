# 查找全部设备 HKMSearchDeviceAll

## 功能:
找符合条件的全部键鼠盒子

## 参数:
- 参数1　VID：无符号32位整型数。值为65536时忽略此搜索条件。
- 参数2　PID：无符号32位整型数。值为65536时忽略此搜索条件。
- 参数3　设备模式：无符号32位整型数。用于设置查找的键鼠盒子的模式。可取值如下：
  - 0 所有模式 
  - 1 键鼠模式 
  - 2 键盘模式 
  - 3 鼠标模式 

## 返回值:
无符号32位整型数地址。成功返回设备ID的数组，可用HKMGetDataCount函数获取数组元素数量。失败返回NULL。当不再使用这个字符串时，使用HKMFreeData释放数组所占用的资源。

## C#例子
```csharp
IntPtr pDevId = SkmCore.HKMSearchDeviceAll(0x1234, 0xABCD, 0);
if (pDevId == IntPtr.Zero)
{
    Console.WriteLine("查找设备失败");
    return;
}
uint dwCount = SkmCore.HKMGetDataCount(pDevId);
Console.WriteLine($"找到的设备数量:{dwCount}");
for (uint i = 0; i < dwCount; i++)
{
    uint deviceId = SkmCore.HKMGetDataUnitInt(pDevId, i);
    Console.WriteLine($"{deviceId:X8}");
}
SkmCore.HKMFreeData(pDevId);
```

## C语言例子
```
LPDWORD pDevId;
DWORD dwCount,i;
pDevId=HKMSearchDeviceAll(0x1234,0xABCD,0);
if(pDevId==NULL)
{
    printf("查找设备失败\n");
    return 0;
}
dwCount=HKMGetDataCount(pDevId);
printf("找到的设备数量:%u\n",dwCount);
for(i=0;i<dwCount;i++)
{
    printf("%08X\n",pDevId[i]);
}
HKMFreeData(pDevId);
```