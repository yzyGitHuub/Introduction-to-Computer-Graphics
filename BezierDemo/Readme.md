# BezierDemo
#### 计算机图形学作业基础第四次作业，贝塞尔曲线的生成和显示
#### 作者：Yao, Zhaoyuan
#### GitHub:https://github.com/yzyGitHuub/ 
## 猜猜看我会怎么样工作~~~：
## 快捷键说明：
#### Ctrl + Z ： 撤销上一个输入；
* 完成绘制的曲线被视为一个整体进行撤销.
* 没有可撤销对象时出现 beep 的警告提示音.
* 没有实现撤销移动.
* 没有实现 redo 功能.
## 鼠标按键说明：
#### 鼠标左键单击：添加点.
* 与上一个点不同时才算是新添加的点.
#### 鼠标左键单击 + 拖动：移动形状
* 拖动点时移动点.
* 拖动边时整体移动.
#### 鼠标左键双击：
* 只有当绘制的图形至少有俩点时才可以结束.
* 双击边界可以添加点.
## 其他说明
#### 写了很认真的注释.
#### 实现了橡皮筋功能.
#### 同时刷新当前曲线形状，与 绝大部分软件一致.
#### 支持多条曲线的同时显示.
#### 贝塞尔曲线阈值是 0.1 ，在 myStatic.bezierThreshold 里设置.
#### 实现了点和线段的引力场.
* 因为不支持放大缩小，所以引力场比较小,只有 10 个像素大小.
* 但是在程序里修改很容易，因为引力场大小是一个公用的变量.
