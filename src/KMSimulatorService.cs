using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;


namespace SKM
{
    /// <summary>
    /// 键鼠模拟器服务
    /// 封装skm.dll的函数，提供键鼠模拟器服务
    /// x64环境需要复制x64\skm.dll，x86环境需要复制x86\skm.dll到当前目录，意思是：x64环境需要使用x64\skm.dll，x86环境需要使用x86\skm.dll
    /// 本服务类会自动根据当前环境复制DLL到当前目录，可以无感知使用
    /// </summary>
    public static class KMSimulatorService
    {
        private static IntPtr _deviceData = IntPtr.Zero;
        public static IntPtr DeviceData => _deviceData;
        #region 设备初始化
        public static void Init(int deviceVID, int devicePID, string verifyUserData)
        {
            CopyDllToCurrentDirectory();
            Thread.Sleep(600);
            var deviceId = SearchDevice(deviceVID, devicePID);
            OpenDevice(deviceId);
            VerifyUserData(verifyUserData);
        }
        private static void VerifyUserData(string verifyUserData)
        {
            if (string.IsNullOrEmpty(verifyUserData))
            {
                throw new Exception("键鼠模拟器校验数据不能为空!");
            }
            if (SkmCore.HKMVerifyUserData2(_deviceData, verifyUserData, false) != SkmCore.HKMGetSerialNumber(_deviceData, false))
            {
                throw new Exception("键鼠模拟器校验数据错误!");
            }
        }
        /// <summary>
        /// 复制DLL到当前目录
        /// </summary>
        /// <exception cref="Exception"></exception>
        private static void CopyDllToCurrentDirectory()
        {
            var path = Environment.Is64BitProcess ? "x64" : "x86";
            path = Path.Combine(AppContext.BaseDirectory, path, "skm.dll");
            if (!File.Exists(path))
            {
                throw new Exception("未找到键鼠模拟器DLL文件,请检查文件是否存在!");
            }
            if (!File.Exists(Path.Combine(AppContext.BaseDirectory, "skm.dll")))
            {
                File.Copy(path, Path.Combine(AppContext.BaseDirectory, "skm.dll"), true);
            }
        }

        /// <summary>
        /// 搜索设备
        /// </summary>
        /// <param name="deviceVID">设备VID</param>
        /// <param name="devicePID">设备PID</param>
        /// <returns>设备ID</returns>
        public static UInt32 SearchDevice(int deviceVID, int devicePID)
        {
            var deviceId = SkmCore.HKMSearchDevice((UInt32)deviceVID, (UInt32)devicePID, 0);
            if (deviceId == 0xFFFFFFFF)
            {
                throw new Exception("未找到键鼠模拟器设备,请检查设备是否连接好!");
            }

            return deviceId;
        }
        /// <summary>
        /// 打开设备
        /// </summary>
        /// <param name="deviceID">设备ID</param>
        public static void OpenDevice(UInt32 deviceID)
        {
            _deviceData = SkmCore.HKMOpen(deviceID, 0);
            if (_deviceData == IntPtr.Zero)
            {
                throw new Exception("打开键鼠模拟器设备失败!");
            }
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        public static void CloseDevice()
        {
            if (_deviceData == IntPtr.Zero)
            {
                return;
            }
            SkmCore.HKMClose(_deviceData);
            _deviceData = IntPtr.Zero;
        }
        /// <summary>
        /// 判断设备是否打开
        /// </summary>
        /// <returns>是否打开</returns>
        public static bool IsDeviceOpen() => SkmCore.HKMIsOpen(_deviceData, 0);

        #endregion
    }
}