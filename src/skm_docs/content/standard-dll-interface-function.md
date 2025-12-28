# 标准DLL接口函数

---

> **说明**  

> 本文档汇总“标准DLL接口函数”,大部分情况下建议使用默认参数，注意鼠标坐标最大偏移、系统DPI缩放下鼠标精度等设置。

> **查找设备时需使用真实PID/VID，不操作时应释放所有按键，否则会长按。**

## 查找设备

| 函数名(标准dll接口)                  | 说明     |
| ------------------------------------- | -------- |
| [HKMSearchDevice](standard_fun/HKMSearchDevice.md) | 查找设备 |
| [HKMSearchDevice2](standard_fun/HKMSearchDevice2.md) | 查找设备 |
| [HKMSearchDeviceAll](standard_fun/HKMSearchDeviceAll.md) | 查找全部设备 |

---

## 访问设备

| 函数名(标准dll接口)         | 说明         |
| --------------------------- | ------------ |
| [HKMOpen](standard_fun/HKMOpen.md) | 打开设备     |
| [HKMOpen2](standard_fun/HKMOpen2.md) | 打开设备   |
| [HKMIsOpen](standard_fun/HKMIsOpen.md) | 判断设备是否打开 |
| [HKMClose](standard_fun/HKMClose.md) | 关闭设备   |

---

## 获得设备信息

| 函数名(标准dll接口)                   | 说明                 |
| -------------------------------------- | -------------------- |
| [HKMGetDevInfo](standard_fun/HKMGetDevInfo.html) | 获得设备信息         |
| [HKMGetDevString](standard_fun/HKMGetDevString.html) | 获得设备字符串     |
| [HKMGetSerialNumber](standard_fun/HKMGetSerialNumber.html) | 获得序列号        |
| [HKMGetKeyboardMode](standard_fun/HKMGetKeyboardMode.html) | 获得键盘模式    |
| [HKMGetMouseMode](standard_fun/HKMGetMouseMode.html) | 获得鼠标模式       |
| [HKMGetKeyboardLEDState](standard_fun/HKMGetKeyboardLEDState.html) | 获得键盘LED灯状态 |
| [HKMIsKeyBusy](standard_fun/HKMIsKeyBusy.html) | 判断键盘是否繁忙   |
| [HKMIsMouseBusy](standard_fun/HKMIsMouseBusy.html) | 判断鼠标是否繁忙   |
| [HKMIsKeyDown](standard_fun/HKMIsKeyDown.html) | 判断键盘是否按下   |
| [HKMIsMouseButtonDown](standard_fun/HKMIsMouseButtonDown.html) | 判断鼠标键是否按下 |
| [HKMGetCursorPos](standard_fun/HKMGetCursorPos.html) | 获得鼠标坐标 |
| [HKMGetCursorPos2](standard_fun/HKMGetCursorPos2.html) | 获得鼠标坐标 |

---

## 设置属性

| 函数名(标准dll接口)                   | 说明                 |
| -------------------------------------- | -------------------- |
| [HKMSetMode](standard_fun/HKMSetMode.html)             | 设置模式         |
| [HKMSetKeyInterval](standard_fun/HKMSetKeyInterval.html) | 设置按键时间间隔 |
| [HKMSetMouseInterval](standard_fun/HKMSetMouseInterval.html) | 设置鼠标时间间隔 |
| [HKMSetAbsMouseScrnRes](standard_fun/HKMSetAbsMouseScrnRes.html) | 设置绝对鼠标屏幕分辨率 |
| [HKMSetMouseMoveTimeout](standard_fun/HKMSetMouseMoveTimeout.html) | 设置鼠标移动超时时间 |
| [HKMSetMousePosMaxOffset](standard_fun/HKMSetMousePosMaxOffset.html) | 设置鼠标坐标最大偏移 |
| [HKMSetMousePosPrecision](standard_fun/HKMSetMousePosPrecision.html) | 设置鼠标坐标精度 |
| [HKMSetMouseSpeed](standard_fun/HKMSetMouseSpeed.html)               | 设置鼠标速度   |

---

## 操作键盘和鼠标

| 函数名(标准dll接口)           | 说明             |
| ----------------------------- | ---------------- |
| [HKMKeyPress](standard_fun/HKMKeyPress.html)             | 键盘按键         |
| [HKMKeyDown](standard_fun/HKMKeyDown.html)               | 键盘按下         |
| [HKMKeyUp](standard_fun/HKMKeyUp.html)                   | 键盘弹起         |
| [HKMReleaseKeyboard](standard_fun/HKMReleaseKeyboard.html) | 释放键盘按键     |
| [HKMLeftClick](standard_fun/HKMLeftClick.html)           | 鼠标左键单击     |
| [HKMRightClick](standard_fun/HKMRightClick.html)         | 鼠标右键单击     |
| [HKMMiddleClick](standard_fun/HKMMiddleClick.html)       | 鼠标中键单击     |
| [HKMXBtn1Click](standard_fun/HKMXBtn1Click.html)         | 鼠标XButton1键单击 |
| [HKMXBtn2Click](standard_fun/HKMXBtn2Click.html)         | 鼠标XButton2键单击 |
| [HKMLeftDoubleClick](standard_fun/HKMLeftDoubleClick.html)         | 鼠标左键双击     |
| [HKMRightDoubleClick](standard_fun/HKMRightDoubleClick.html)         | 鼠标右键双击     |
| [HKMMiddleDoubleClick](standard_fun/HKMMiddleDoubleClick.html)       | 鼠标中键双击     |
| [HKMXBtn1DoubleClick](standard_fun/HKMXBtn1DoubleClick.html)         | 鼠标XButton1键双击 |
| [HKMXBtn2DoubleClick](standard_fun/HKMXBtn2DoubleClick.html)         | 鼠标XButton2键双击 |
| [HKMLeftDown](standard_fun/HKMLeftDown.html) | 鼠标左键按下 |
| [HKMRightDown](standard_fun/HKMRightDown.html) | 鼠标右键按下 |
| [HKMMiddleDown](standard_fun/HKMMiddleDown.html) | 鼠标中键按下 |
| [HKMXBtn1Down](standard_fun/HKMXBtn1Down.html) | 鼠标XButton1键按下 |
| [HKMXBtn2Down](standard_fun/HKMXBtn2Down.html) | 鼠标XButton2键按下 |
| [HKMLeftUp](standard_fun/HKMLeftUp.html) | 鼠标左键弹起 |
| [HKMRightUp](standard_fun/HKMRightUp.html) | 鼠标右键弹起 |
| [HKMMiddleUp](standard_fun/HKMMiddleUp.html) | 鼠标中键弹起 |
| [HKMXBtn1Up](standard_fun/HKMXBtn1Up.html) | 鼠标XButton1键弹起 |
| [HKMXBtn2Up](standard_fun/HKMXBtn2Up.html) | 鼠标XButton2键弹起 |
| [HKMReleaseMouse](standard_fun/HKMReleaseMouse.html) | 释放鼠标按键 |
| [HKMMoveTo](standard_fun/HKMMoveTo.html) | 鼠标移动 |
| [HKMMoveR](standard_fun/HKMMoveR.html) | 鼠标相对移动 |
| [HKMMoveR2](standard_fun/HKMMoveR2.html) | 鼠标相对移动 |
| [HKMMoveRP](standard_fun/HKMMoveRP.html) | 鼠标相对移动 |
| [HKMMouseWheel](standard_fun/HKMMouseWheel.html) | 鼠标滚轮 |
| [HKMMouseWheelP](standard_fun/HKMMouseWheelP.html) | 鼠标滚轮 |
| [HKMOutputString](standard_fun/HKMOutputString.html) | 输出字符串 |

---

## 数据处理

| 函数名(标准dll接口)                   | 说明                 |
| -------------------------------------- | -------------------- |
| [HKMFreeData](standard_fun/HKMFreeData.html) | 释放数据         |
| [HKMGetDataCount](standard_fun/HKMGetDataCount.html) | 获得数据数量 |
| [HKMGetDataUnitInt](standard_fun/HKMGetDataUnitInt.html) | 获得数据单元整数值 |

---

## 其他

| 函数名(标准dll接口)                   | 说明                 |
| -------------------------------------- | -------------------- |
| [HKMDelayRnd](standard_fun/HKMDelayRnd.html) | 随机延时         |
| [HKMCheckPressedKeys](standard_fun/HKMCheckPressedKeys.html) | 检查按键 |
| [HKMVerifyUserData2](standard_fun/HKMVerifyUserData2.html) | 验证用户数据2 |
| [HKMSetResetMode](standard_fun/HKMSetResetMode.html) | 设置延时复位模式 |
| [HKMSetResetTime](standard_fun/HKMSetResetTime.html) | 设置复位时间 |
| [HKMSetLightMode](standard_fun/HKMSetLightMode.html) | 设置指示灯模式 |
| [HKMIsOSMouseAccelerateEnabled](standard_fun/HKMIsOSMouseAccelerateEnabled.html) | 判断是否开启系统鼠标加速 |
| [HKMEnableOSMouseAccelerate](standard_fun/HKMEnableOSMouseAccelerate.html) | 启停系统鼠标加速 |
| [HKMGetOSMouseSpeed](standard_fun/HKMGetOSMouseSpeed.html) | 获得系统鼠标速度 |
| [HKMSetOSMouseSpeed](standard_fun/HKMSetOSMouseSpeed.html) | 设置系统鼠标速度 |
| [HKMGetError](standard_fun/HKMGetError.html) | 获得错误代码 |

