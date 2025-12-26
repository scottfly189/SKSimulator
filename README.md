# SKSimulator - 键鼠模拟器 SDK

键鼠模拟器是一类专用硬件设备，能够通过底层信号模拟真实的键盘与鼠标输入操作。相比于传统的 PostMessage、SendInput、SetWindowsHookEx 等 Windows API 注入方式，软件模拟常常会被安全监控系统检测到（如获取窗口焦点、输入来源判别、消息钩子分析等），从而被微信、企业微信等主流应用识别为自动化行为，存在较高的风控和封号风险。而采用硬件级别的信号注入，输入几乎等同于真实用户操作，不会留下易被检测的 API 调用特征，具备极高的隐蔽性和安全性，非常适合需要高安全性的自动化场景。

### 🔄 工作原理对比

```
┌─────────────────────────────────────────────────────────────────────────┐
│                        传统软件模拟方式                                  │
└─────────────────────────────────────────────────────────────────────────┘

    应用程序
        │
        ├─→ PostMessage/SendInput/SetWindowsHookEx
        │         │
        │         ├─→ Windows API 调用
        │         │         │
        │         │         ├─→ ⚠️ 可被检测特征
        │         │         │   ├─ 窗口焦点获取
        │         │         │   ├─ 输入来源判别
        │         │         │   └─ 消息钩子分析
        │         │         │
        │         │         └─→ 安全监控系统
        │         │                 │
        │         │                 └─→ ❌ 识别为自动化行为
        │         │                       └─→ 风控/封号风险
        │         │
        └─────────┴─────────────────────────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────────────┐
│                         硬件键鼠模拟器方式                               │
└─────────────────────────────────────────────────────────────────────────┘

    应用程序
        │
        ├─→ SKSimulator SDK
        │         │
        │         ├─→ skm.dll (硬件驱动)
        │         │         │
        │         │         └─→ 🔌 硬件设备 (USB HID)
        │         │                 │
        │         │                 ├─→ ✅ 底层信号注入
        │         │                 │   ├─ 硬件级别输入
        │         │                 │   ├─ 无 API 调用特征
        │         │                 │   └─ 等同于真实用户操作
        │         │                 │
        │         │                 └─→ 操作系统
        │         │                         │
        │         │                         └─→ ✅ 识别为真实输入
        │         │                               └─→ 高隐蔽性/安全性
        │         │
        └─────────┴─────────────────────────────────────────────────────┘


┌─────────────────────────────────────────────────────────────────────────┐
│                            对比总结                                      │
├─────────────────────────────────────────────────────────────────────────┤
│                                                                         │
│  传统软件模拟              │  硬件键鼠模拟器                              │
│  ─────────────            │  ─────────────                              │
│  ❌ 易被检测              │  ✅ 高隐蔽性                                │
│  ❌ API 调用特征          │  ✅ 无 API 特征                             │
│  ❌ 风控风险高            │  ✅ 安全性高                                │
│  ❌ 可能被封号            │  ✅ 等同于真实操作                          │
│                                                                         │
└─────────────────────────────────────────────────────────────────────────┘
```

本 SDK 采用 C# 实现，完整支持键盘和鼠标的各类操作，同时兼容 x86 与 x64 架构，自动管理 DLL 加载和依赖，无需手动干预。

## ✨ 功能特性

- 🎯 **完整的键鼠模拟功能** - 支持键盘按键、鼠标移动、点击等所有操作
- 🔧 **自动 DLL 管理** - 自动根据运行环境（x86/x64）复制对应的 DLL 文件
- 📝 **字符串输出** - 支持 Unicode 和 ANSI 编码，支持中文输入
- 🖱️ **DPI 感知** - 支持多显示器 DPI 感知，确保坐标精度
- ⚙️ **灵活配置** - 可配置设备参数、输出模式、鼠标移动模式等
- 🔒 **设备验证** - 内置校验机制，提升安全性，支持硬件分发与授权管理
- ⏱️ **随机延时** - 内置随机延时功能，模拟更真实的操作

## 📋 系统要求

- Windows 操作系统
- 键鼠模拟器硬件设备,本SDK需要配合硬件使用，如果需要键鼠模拟器硬件设备,请联系我

## 🚀 快速开始

### 1. 克隆项目

```bash
git clone https://github.com/scottfly189/SKSimulator.git
cd src
```

### 2. 配置设备参数

在 `Config.cs` 中配置您的设备参数：

```csharp
public static int KMDeiviceVID { get; set; } = 0x2612;  // 设备 VID
public static int KMDeivicePID { get; set; } = 0x1701;  // 设备 PID
public static string KMVerifyUserData { get; set; } = "您的校验数据";
```

### 3. 准备 DLL 文件

确保 `x64/skm.dll` 和 `x86/skm.dll` 文件存在于项目中。项目会自动根据运行环境复制对应的 DLL。

如下所示将dll文件包含在项目中:

```
  <!-- 复制DLL到输出目录 -->
  <ItemGroup>
    <None Include="x64\skm.dll">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
       <TargetPath>x64\skm.dll</TargetPath>
    </None>
    <None Include="x86\skm.dll">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      <TargetPath>x86\skm.dll</TargetPath>
    </None>
  </ItemGroup>
```

### 4. 编译运行

```bash
dotnet build
dotnet run
```

## 📖 使用示例

### 基本使用

```csharp
using SKM;

// 初始化设备
KMSimulatorService.Init(Config.KMDeiviceVID, Config.KMDeivicePID, Config.KMVerifyUserData);
IntPtr HKMData = KMSimulatorService.DeviceData;

// 设置模式（输出字符串编码、鼠标移动模式）
SkmCore.HKMSetMode(HKMData, 4, 4);

// 键盘操作示例
SkmCore.HKMKeyPress(HKMData, "WIN+E");  // 组合键
SkmCore.HKMKeyDown(HKMData, "Ctrl");
SkmCore.HKMKeyPress(HKMData, "A");
SkmCore.HKMKeyUp(HKMData, "Ctrl");

// 输出字符串（支持中文）
SkmCore.HKMOutputString(HKMData, "ABC中文，可以打成全部是中文吗？");
SkmCore.HKMOutputString(HKMData, "\r\n换行测试，Hello World!");

// 鼠标操作示例
SkmCore.HKMMoveR(HKMData, 100, 50);     // 相对移动
SkmCore.HKMMoveTo(HKMData, 200, 100);   // 绝对移动
SkmCore.HKMLeftClick(HKMData);          // 左键单击
SkmCore.HKMRightClick(HKMData);         // 右键单击
SkmCore.HKMLeftDoubleClick(HKMData);    // 左键双击

// 随机延时
SkmCore.HKMDelayRnd(HKMData, 100, 150);

// 关闭设备
KMSimulatorService.CloseDevice();
```

### 完整示例

参考 `Program.cs` 中的完整示例代码。

## 🔧 配置说明

### Config 类配置项

| 配置项 | 类型 | 默认值 | 说明 |
|--------|------|--------|------|
| `KMDeiviceVID` | int | 0x2612 | 键鼠模拟器设备 VID |
| `KMDeivicePID` | int | 0x1701 | 键鼠模拟器设备 PID |
| `KMVerifyUserData` | string | - | 键鼠模拟器校验数据 |
| `KMOffsetOfClick` | int | 5 | 点击偏移量（像素） |
| `KMOutputStringType` | int | 4 | 输出字符串编码类型 |
| `KMMouseMoveMode` | int | 0 | 鼠标移动模式 |
| `ProcessDpiAwareness` | int | 1 | 进程 DPI 感知值 |

### DPI 感知配置

- `0`: 不设置 DPI 感知
- `1`: `PROCESS_SYSTEM_DPI_AWARE` - 根据主显示器 DPI（默认）
- `2`: `PROCESS_PER_MONITOR_DPI_AWARE` - 根据每个显示器 DPI

**注意**:
键鼠模拟器受DPI 感知影响，请正确设置DPI,本SDK中也提供了```DpiAwareness```类供设置DPI

## 📚 API 文档

### KMSimulatorService 类

设备管理服务类，提供设备初始化、搜索、打开、关闭等功能。

#### 主要方法

- `Init(int deviceVID, int devicePID, string verifyUserData)` - 初始化设备
- `SearchDevice(int deviceVID, int devicePID)` - 搜索设备
- `OpenDevice(UInt32 deviceID)` - 打开设备
- `CloseDevice()` - 关闭设备
- `IsDeviceOpen()` - 判断设备是否打开

### SkmCore 类

`skm.dll` 的封装类，提供所有底层 API。

#### 键盘操作

- `HKMKeyPress(IntPtr HKMData, string KeyName)` - 按键
- `HKMKeyDown(IntPtr HKMData, string KeyName)` - 按下
- `HKMKeyUp(IntPtr HKMData, string KeyName)` - 弹起
- `HKMOutputString(IntPtr HKMData, string Str)` - 输出字符串
- `HKMReleaseKeyboard(IntPtr HKMData)` - 释放所有按键

#### 鼠标操作

- `HKMMoveTo(IntPtr HKMData, int X, int Y)` - 绝对移动
- `HKMMoveR(IntPtr HKMData, int X, int Y)` - 相对移动
- `HKMLeftClick(IntPtr HKMData)` - 左键单击
- `HKMRightClick(IntPtr HKMData)` - 右键单击
- `HKMMiddleClick(IntPtr HKMData)` - 中键单击
- `HKMLeftDoubleClick(IntPtr HKMData)` - 左键双击
- `HKMMouseWheel(IntPtr HKMData, int Count)` - 滚轮滚动

#### 设备管理

- `HKMSearchDevice(UInt32 Vid, UInt32 Pid, UInt32 DeviceType)` - 搜索设备
- `HKMOpen(UInt32 DeviceId, UInt32 DpiMode)` - 打开设备
- `HKMClose(IntPtr HKMData)` - 关闭设备
- `HKMSetMode(IntPtr HKMData, UInt32 Index, UInt32 Mode)` - 设置模式

#### 工具方法

- `HKMDelayRnd(IntPtr HKMData, UInt32 MinTime, UInt32 MaxTime)` - 随机延时
- `HKMGetCursorPos(IntPtr HKMData, ref int X, ref int Y)` - 获取鼠标坐标

更多 API 请参考 `SKMCore.cs` 文件。

## ⚠️ 注意事项

1. **DLL 文件**: 
   - x64 环境需要使用 `x64/skm.dll`
   - x86 环境需要使用 `x86/skm.dll`
   - `KMSimulatorService` 会自动根据当前环境复制 DLL，无需手动处理

2. **DPI 感知**: 
   - DPI 感知设置必须在任何窗口创建之前调用
   - 如果应用程序已经设置了 DPI 感知，库的设置将无效

3. **设备连接**: 
   - 使用前请确保键鼠模拟器设备已正确连接
   - 检查设备 VID 和 PID 是否正确配置

4. **字符串编码**: 
   - 如果中文出现乱码，使用 `HKMSetMode` 改变输出字符串编码
   - 默认使用剪贴板粘贴方式输出字符串，速度快且不受输入法影响

5. **线程安全**: 
   - 请确保设备操作在同一线程中进行，避免并发访问


## 🔗 相关链接

- [SKSimulator 官方文档](如有)

---

**注意**: 本项目仅用于学习和合法用途，请勿用于任何非法活动。

