/*****************************
* Yao,Zhaoyuan 创建于 2018/12/15
* 上一次修改时间：2018/12/16
* GitHub:https://github.com/yzyGitHuub/
* 保留所有权利
* **************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// 是否处于绘制状态
        /// </summary>
        bool isDrawFinished = true;

        /// <summary>
        /// 贝塞尔曲线控制多边形是否可见
        /// </summary>
        bool isBorderVisible = true;

        /// <summary>
        /// 是否选中画板中的对象
        /// </summary>
        bool isCheck = false;
        
        /// <summary>
        /// 绘制完成的贝塞尔曲线对象集合
        /// </summary>
        List<Bezier> madeBezierList = new List<Bezier> { };

        /// <summary>
        /// 当前绘制的贝塞尔曲线对象时输入的点序列
        /// </summary>
        List<Point> inputPoiList = new List<Point> { };

        /// <summary>
        /// 鼠标位置
        /// </summary>
        Point poiCursor = new Point(0, 0);

        /// <summary>
        /// 鼠标移动前的位置
        /// </summary>
        Point poiStart  = new Point(0, 0);

        /// <summary>
        /// 引力场的源点的坐标
        /// </summary>
        PointF poiGravitation = new Point();

        /// <summary>
        /// 是否被捕获
        /// -1 表示不被捕获
        /// 正数表示被 第 i 个已完成元素捕获
        /// 第 madeBezierList.Count() 个元素表示 inputList
        /// </summary>
        int isGravitationCaptured = -1;

        /// <summary>
        /// 捕获鼠标的元素内的元素编号
        /// -1 表示不存在
        /// </summary>
        int CatchID = -1;

        /// <summary>
        /// 新建贝塞尔曲线演示程序窗口
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绘制画布事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ///鼠标位置输出
            label1.Text = "( " + poiCursor.X + ", " + poiCursor.Y + ") pixel";

            ///鼠标位置被引力场捕获，绘制引力场
            if (isGravitationCaptured != -1)
            {
                Graphics g = e.Graphics;
                if (isGravitationCaptured == madeBezierList.Count())
                {
                    ///当前是被 inputList 吸引
                    ///显示该点的引力场
                    g.DrawEllipse(new Pen(Color.Yellow), poiGravitation.X - myStatic.poi2poiDistMin, poiGravitation.Y - myStatic.poi2poiDistMin, myStatic.poi2poiDistMin * 2, myStatic.poi2poiDistMin * 2);
                    g.FillRectangle(new SolidBrush(Color.Yellow), inputPoiList[CatchID].X - 2, inputPoiList[CatchID].Y - 2, 4, 4);
                }
                else
                {
                    ///被 madeBezierList[isGravitationCaptured] 吸引
                    ///可能是被点或边捕获
                    if (CatchID < madeBezierList[isGravitationCaptured].P.poiList.Count())
                        ///被点捕获，显示点的引力场
                        g.DrawEllipse(new Pen(Color.Yellow), poiGravitation.X - myStatic.poi2poiDistMin, poiGravitation.Y - myStatic.poi2poiDistMin, myStatic.poi2poiDistMin * 2, myStatic.poi2poiDistMin * 2);
                    else
                    {
                        ///被边捕获，显示边的引力场，画一个矩形+俩圆
                        int cou = CatchID - madeBezierList[isGravitationCaptured].P.poiList.Count();
                        Edge edge = new Edge(madeBezierList[isGravitationCaptured].P.poiList[cou], madeBezierList[isGravitationCaptured].P.poiList[cou + 1]);
                        ///竖直的线段
                        if (edge.poi1.X == edge.poi2.X)
                        {
                            if (edge.poi1.Y > edge.poi2.Y)
                            {
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin, edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin, edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin, edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin, edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin);
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin, edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin, edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin, edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin, edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin);
                            }
                        }
                        //水平的线段
                        else if (edge.poi1.Y == edge.poi2.Y)
                        {
                            if (edge.poi1.X > edge.poi2.X)
                            {
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin, edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin, edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin, edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin, edge.poi1.X + myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin);
                            }
                            else
                            {
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin, edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin, edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin, edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin);
                                g.DrawLine(new Pen(Color.Yellow), edge.poi2.X + myStatic.poi2edgeDistMin, edge.poi2.Y + myStatic.poi2edgeDistMin, edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y + myStatic.poi2edgeDistMin);
                            }
                        }
                        ///倾斜的线段
                        else
                        {
                            ///边的缓冲区边界
                            g.DrawLine(new Pen(Color.Yellow, myStatic.poi2edgeDistMin * 2), edge.poi1, edge.poi2);
                            g.DrawLine(new Pen(Color.White, (myStatic.poi2edgeDistMin - 1) * 2), edge.poi1, edge.poi2);
                            ///端点的缓冲区边界
                            ///端点的缓冲区用的是边的引力大小
                            g.DrawEllipse(new Pen(Color.Yellow), edge.poi1.X - myStatic.poi2edgeDistMin, edge.poi1.Y - myStatic.poi2edgeDistMin, myStatic.poi2edgeDistMin * 2, myStatic.poi2edgeDistMin * 2);
                            g.DrawEllipse(new Pen(Color.Yellow), edge.poi2.X - myStatic.poi2edgeDistMin, edge.poi2.Y - myStatic.poi2edgeDistMin, myStatic.poi2edgeDistMin * 2, myStatic.poi2edgeDistMin * 2);
                        }
                    }
                }
            }

            ///绘制已完成贝塞尔曲线对象
            if (madeBezierList.Count() != 0)
                foreach (Bezier bezier in madeBezierList)
                {
                    if (isBorderVisible)
                        bezier.P.drawMyself(e, Color.Black);
                    bezier.drawMyself(e, Color.Blue);
                }

            ///绘制当前绘制中的图形
            if (!isDrawFinished)
            { 
                Bezier bezierTemp = new Bezier(new Polyline(inputPoiList));
                if (isBorderVisible)
                    bezierTemp.P.drawMyself(e, poiCursor);
                bezierTemp.drawMyself(e, Color.Blue);
            }

            ///若有选中正在拖动，叠加显示
            if(isCheck)
            {
                Graphics g = e.Graphics;
                ///选中的是点
                ///绘制一个巨大的圆形，大小是点的引力场大小
                if (CatchID < madeBezierList[isGravitationCaptured].P.poiList.Count())
                    g.FillEllipse(new SolidBrush(Color.LightGreen), madeBezierList[isGravitationCaptured].P.poiList[CatchID].X - myStatic.poi2poiDistMin, madeBezierList[isGravitationCaptured].P.poiList[CatchID].Y - myStatic.poi2poiDistMin, myStatic.poi2poiDistMin * 2, myStatic.poi2poiDistMin * 2);
                ///选中边
                ///被选中的贝塞尔曲线的控制多边形变色
                else
                    madeBezierList[isGravitationCaptured].P.drawMyself(e, Color.LightGreen);
            }
        }

        /// <summary>
        /// 移动画布中选中对象
        /// </summary>
        /// <param name="deltax">移动矢量的 x 方向分量</param>
        /// <param name="deltay">移动矢量的 y 方向分量</param>
        private void moveIt(int deltax, int deltay)
        {
            if (CatchID == -1)
                return;
            int num = madeBezierList[isGravitationCaptured].P.poiList.Count();
            if (CatchID < num)
            {
                ///移动点
                int _end = madeBezierList[isGravitationCaptured].P.poiList.Count() - 1;
                if (CatchID == 0 && madeBezierList[isGravitationCaptured].P.poiList[0].Equals(madeBezierList[isGravitationCaptured].P.poiList[_end]))
                {
                    ///起始点
                    madeBezierList[isGravitationCaptured].P.poiList[0] = new PointF(madeBezierList[isGravitationCaptured].P.poiList[0].X + deltax, madeBezierList[isGravitationCaptured].P.poiList[0].Y + deltay);
                    madeBezierList[isGravitationCaptured].P.poiList[_end] = new PointF(madeBezierList[isGravitationCaptured].P.poiList[_end].X + deltax, madeBezierList[isGravitationCaptured].P.poiList[_end].Y + deltay);
                }
                else
                    madeBezierList[isGravitationCaptured].P.poiList[CatchID] = new PointF(madeBezierList[isGravitationCaptured].P.poiList[CatchID].X + deltax, madeBezierList[isGravitationCaptured].P.poiList[CatchID].Y + deltay);
            }
            else
                ///移动整体
                madeBezierList[isGravitationCaptured].P.move(deltax, deltay);
            pictureBox1.Refresh();
        }

        /// <summary>
        /// 鼠标移动触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawFinished && !isCheck)
            {
                if(isGravitationCaptured != -1)
                    pictureBox1.Cursor = Cursors.SizeAll;
                else
                    pictureBox1.Cursor = Cursors.Cross;
            }
            if (isGravitationCaptured != -1 && isCheck && isDrawFinished)
            {
                moveIt(e.Location.X - poiStart.X, e.Location.Y - poiStart.Y);
                poiGravitation = e.Location;
                poiCursor = e.Location;
                poiStart = poiCursor;
                return;
            }
            
            ///边界可见时查找引力场
            if(isBorderVisible)
            {
                ///先匹配已完成的贝塞尔曲线对象的控制多边形
                int madeNum = madeBezierList.Count();
                if (madeNum != 0)
                {
                    for (int i = 0; i < madeNum; i++)
                    {
                        ///尝试捕获
                        int catchNum = madeBezierList[i].P.catchPoint(e.Location);
                        if (catchNum != -1)
                        {
                            isGravitationCaptured = i;
                            CatchID = catchNum;
                            if (CatchID < madeBezierList[i].P.poiList.Count())
                                ///被一点捕获
                                poiGravitation = new Point((int)madeBezierList[i].P.poiList[CatchID].X, (int)madeBezierList[i].P.poiList[CatchID].Y);
                            else
                                ///此时是被某条边捕获
                                poiGravitation = myStatic.getPedal(e.Location, new Edge(madeBezierList[i].P.poiList[CatchID - madeBezierList[i].P.poiList.Count()], madeBezierList[i].P.poiList[CatchID - madeBezierList[i].P.poiList.Count() + 1]));

                            poiCursor = new Point((int)poiGravitation.X, (int)poiGravitation.Y);
                            pictureBox1.Refresh();
                            return;
                        }
                        else
                            isGravitationCaptured = -1;
                    }
                }
                ///已完成对象集合捕获失败，开始在当前输入点集合中尝试捕获
                int inputNum = inputPoiList.Count();
                if (inputNum != 0)
                {
                    for (int i = 0; i < inputNum; i++)
                        if (myStatic.getDistance(inputPoiList[i], e.Location) < myStatic.poi2poiDistMin)
                        {
                            ///在引力场范围内，捕获成功
                            isGravitationCaptured = madeNum;
                            CatchID = i;
                            poiGravitation = inputPoiList[i];
                            poiCursor = inputPoiList[i];
                            pictureBox1.Refresh();
                            return;
                        }
                }
            }
            poiCursor = e.Location;
            ///执行到这里就是说明没有找到引力场，设置引力场为不可见
            isGravitationCaptured = -1;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// 鼠标按键事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isGravitationCaptured == -1)
                    poiCursor = e.Location;
                poiStart = poiCursor;
                ///无当前绘制对象，且被捕获
                ///如此则可以进行拖动
                if(isDrawFinished && isGravitationCaptured != -1)
                {
                    pictureBox1.Cursor = Cursors.SizeAll;
                    isCheck = true;
                }
                else
                {
                    ///当前未被捕获或正在绘制新贝塞尔曲线对象
                    ///将点击的点加入绘制的点集合中去
                    isDrawFinished = false;
                    if (inputPoiList.Count() != 0)
                        ///若和上一个点相同，拒绝此输入
                        if (inputPoiList[inputPoiList.Count() - 1].Equals(poiCursor))
                            return;
                    inputPoiList.Add(poiCursor);
                }                
            }
            else if (e.Button == MouseButtons.Right)
            {

            }

            pictureBox1.Refresh();
        }

        /// <summary>
        /// 鼠标双击事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ///若当前正在绘制新贝塞尔曲线对象，结束绘制
            ///必须至少满足两个点时才能完成绘制
            if (!isDrawFinished)
            {
                if (inputPoiList.Count() <= 1)
                    return;
                isDrawFinished = true;
                Polyline temp = new Polyline(inputPoiList);
                madeBezierList.Add(new Bezier(temp));
                inputPoiList = new List<Point> { };

                pictureBox1.Refresh();
            }
            ///已经选中边
            ///添加点
            else if(isCheck && CatchID >= madeBezierList[isGravitationCaptured].P.poiList.Count())
            {
                List<PointF> newPolyline = madeBezierList[isGravitationCaptured].P.poiList;
                int index = CatchID - madeBezierList[isGravitationCaptured].P.poiList.Count();
                newPolyline.Insert(index + 1, myStatic.getPedal(e.Location,new Edge(madeBezierList[isGravitationCaptured].P.poiList[index], madeBezierList[isGravitationCaptured].P.poiList[index + 1])));
                madeBezierList[isGravitationCaptured].P.poiList = newPolyline;
                pictureBox1.Refresh();
            }
        }

        /// <summary>
        /// 键盘按键事件
        /// 支持撤销功能，删无可删时发出警示音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (inputPoiList.Count() == 0)
                {
                    ///无当前绘制对象，进入已完成集合判断
                    if (madeBezierList.Count() == 0)
                        ///已完成集合也为空，发出警示音
                        System.Media.SystemSounds.Beep.Play();
                    else
                        ///删除上一个图形
                        madeBezierList.RemoveAt(madeBezierList.Count() - 1);
                }
                else
                    ///删除上一个点
                    inputPoiList.RemoveAt(inputPoiList.Count() - 1);
                pictureBox1.Refresh();
            }
        }

        /// <summary>
        /// 鼠标按键取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //左键抬起取消选中
            if(e.Button == MouseButtons.Left)
                isCheck = false;
            //pictureBox1.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// 显示帮助信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "作者：Yao, Zhaoyuan\nGitHub:https://github.com/yzyGitHuub/ \n\n";
            str += "猜猜看我会怎么样工作~~~：\n\n";
            str += "快捷键说明：\n\n";
            str += "*** Ctrl + Z ： 撤销上一个输入；\n";
            str += "        # 完成绘制的曲线被视为一个整体进行撤销.\n";
            str += "        # 没有可撤销对象时出现 beep 的警告提示音.\n";
            str += "        # 没有实现撤销移动.\n";
            str += "        # 没有实现 redo 功能.\n\n";
            str += "鼠标按键说明：\n\n";
            str += "*** 鼠标左键单击：添加点.\n";
            str += "        # 与上一个点不同时才算是新添加的点.\n";
            str += "*** 鼠标左键单击 + 拖动：移动形状\n";
            str += "        # 拖动点时移动点.\n";
            str += "        # 拖动边时整体移动.\n";
            str += "*** 鼠标左键双击：\n";
            str += "        # 只有当绘制的图形至少有俩点时才可以结束.\n";
            str += "        # 双击边界可以添加点.\n\n";
            str += "其他说明：\n\n";
            str += "*** 写了很认真的注释.\n";
            str += "*** 实现了橡皮筋功能.\n";
            str += "        # 同时刷新当前曲线形状，与绝大部分软件一致.\n";
            str += "*** 支持多条曲线的同时显示.\n";
            str += "*** 贝塞尔曲线阈值默认为0.1，可以在 myStatic.bezierThreshold 修改.\n";
            str += "*** 实现了点和线段的引力场.\n";
            str += "        # 因为不支持放大缩小，所以引力场比较小,只有 10 个像素大小.\n";
            str += "        # 但是在程序里修改很容易，因为引力场大小是 myStatic 类里公用的变量.\n\n";
            str += "BUG：无明显可见 bug .\n";
            MessageBox.Show(str, "帮助");
        }

        /// <summary>
        /// 用户选择是否显示贝塞尔曲线的控制多边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isBorderVisible = !isBorderVisible;
            pictureBox1.Refresh();
        }
    }
}
