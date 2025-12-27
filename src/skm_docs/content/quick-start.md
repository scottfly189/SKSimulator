# 👉 快速开始
---

## 1. 克隆项目

```bash
git clone https://github.com/scottfly189/SKSimulator.git
cd src
```

## 2. 配置设备参数

在 `Config.cs` 中配置您的设备参数：

```csharp
public static int KMDeiviceVID { get; set; } = 0x2612;  // 设备 VID
public static int KMDeivicePID { get; set; } = 0x1701;  // 设备 PID
public static string KMVerifyUserData { get; set; } = "您的校验数据";
```

## 3. 准备 DLL 文件

确保 `x64/skm.dll` 和 `x86/skm.dll` 文件存在于项目中。项目会自动根据运行环境复制对应的 DLL。

如下所示将 DLL 文件包含在项目中：

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

## 4. 编译运行

```bash
dotnet build
dotnet run
```

## 5. 📖 使用示例

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
键鼠模拟器受 DPI 感知影响，请正确设置 DPI。本 SDK 中也提供了 `DpiAwareness` 类供设置 DPI。
