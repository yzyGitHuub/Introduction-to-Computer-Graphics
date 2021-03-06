﻿/*****************************
* 姚照原创建于 2018/10/29
* 上一次修改时间：2018/10/29
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

namespace BresenhamDemo
{
    public partial class BresenhamDemo : Form
    {
        public BresenhamDemo()
        {
            InitializeComponent();
            formTextRebuild();
        }


        /*****************************
         * 以下是一些控制软件编辑状态的变量，以及存储绘图关键信息的存储集合
         * 当然显得十分暴力，我也不想写全局变量一大堆来着，无奈水平还是不够
         * 此之谓 书到用时方恨少，想要干啥都不会
         * **************************/
        private int drawIn = 0;
        private bool drawFinished = true;
        private bool lineDrawing = true, polylineDrawing = false, circleDrawing = false;
        private bool multiDrawing = false, realTime = false, mixShow = false, assistShow = true;
        private List<MyLine> lineList = new List<MyLine> { };
        private List<MyCircle> circleList = new List<MyCircle> { };
        private List<MyPolyline> polylineList = new List<MyPolyline> { };


        private Point realTimePoint;


        /// <summary>
        /// 绘制网格.
        /// </summary>
        private void drawGrids(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = Pens.Black;
            int lineWidth = this.pictureBox1.Width / 10 * 10, lineHeight = this.pictureBox1.Height / 10 * 10;

            /*****************************************************
            * 分别绘制纵线和横线
            * 在绘制时注意了网格的边界，即是完整的网格，边缘光滑
            * 如果在修改边框大小是发现有一瞬间是不光滑的，这只能说明刚好边界的那一行或列刚好就是被制裁了，因为用户电脑显示屏也是离散的
            * 此天要亡我，非战之罪也
            * ****************************************************/
            for (int i = 0; i <= lineWidth;)
            {
                g.DrawLine(myPen, new Point(i, 0), new Point(i, lineHeight));
                i += 10;
            }

            for (int j = 0; j <= lineHeight;)
            {
                g.DrawLine(myPen, new Point(0, j), new Point(lineWidth, j));
                j += 10;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            drawGrids(e);
            drawAll(e);
            if(realTime)
            {
                Graphics g = e.Graphics;
                if (drawFinished)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(122,122,122)),realTimePoint.X, realTimePoint.Y , 10, 10);
                }
                else
                {
                    if(lineDrawing)
                    {
                        if (0 == lineList.Count())
                            return;
                        Point from = lineList[lineList.Count() - 1].toNode;
                        MyLine line = new MyLine(from, realTimePoint);
                        line.setDrawIn(drawIn);
                        line.drawMyself(e, Color.FromArgb(122, 122, 122), assistShow);
                    }
                    else if(polylineDrawing)
                    {
                        if (0 == polylineList.Count())
                            return;
                        Point from = polylineList[polylineList.Count() - 1].containList[polylineList[polylineList.Count() - 1].containList.Count() - 1];
                        MyLine line = new MyLine(from, realTimePoint);
                        line.setDrawIn(drawIn);
                        line.drawMyself(e, Color.FromArgb(122, 122, 122), assistShow);
                    }
                    else if(circleDrawing)
                    {
                        if (0 == circleList.Count())
                            return;
                        int r = Convert.ToInt32(circleList[circleList.Count() - 1].getDistance(realTimePoint)) / 10 * 10;
                        MyCircle circle = new MyCircle(circleList[circleList.Count() - 1].center, r);
                        circle.setDrawIn(drawIn);
                        circle.drawMyself(e, Color.FromArgb(122, 122, 122), assistShow);
                    }
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void dDA方法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineDrawing = true;
            circleDrawing = false;
            polylineDrawing = false;
            drawFinished = true;
            drawIn = 0;
            formTextRebuild();
        }

        private void bresenham方法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineDrawing = true;
            circleDrawing = false;
            polylineDrawing = false;
            drawFinished = true;
            drawIn = 1;
            formTextRebuild();
        }

        private void 错误画法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineDrawing = true;
            circleDrawing = false;
            polylineDrawing = false;
            drawFinished = true;
            drawIn = 2;
            formTextRebuild();
        }
        
        private void newAdd(Point p)
        {
            if(multiDrawing)
            {
                if(mixShow)
                {
                    if (drawFinished)
                    {
                        drawFinished = false;
                        if (lineDrawing)
                        {
                            MyLine newline = new MyLine(p, p);
                            newline.setDrawIn(drawIn);
                            lineList.Add(newline);

                        }
                        else if (polylineDrawing)
                        {
                            MyPolyline newpolyline = new MyPolyline(new List<Point> { });
                            newpolyline.setDrawIn(drawIn);
                            newpolyline.Add(p);
                            polylineList.Add(newpolyline);
                            //polylineList[polylineList.Count() - 1].Add(p);
                        }
                        else if (circleDrawing)
                        {
                            MyCircle newcircle = new MyCircle(p);
                            newcircle.setDrawIn(drawIn);
                            circleList.Add(newcircle);
                        }
                    }
                    else
                    {
                        if (lineDrawing)
                        {
                            drawFinished = true;

                            MyLine newline = new MyLine(lineList[lineList.Count() - 1].fromNode, p);
                            newline.setDrawIn(drawIn);
                            lineList[lineList.Count() - 1] = newline;
                        }
                        else if (polylineDrawing)
                        {
                            polylineList[polylineList.Count() - 1].Add(p);
                        }
                        else if (circleDrawing)
                        {
                            drawFinished = true;
                            int r = Convert.ToInt32(circleList[circleList.Count() - 1].getDistance(p)) / 10 * 10;
                            MyCircle newcircle = new MyCircle(circleList[circleList.Count() - 1].center, r);
                            newcircle.setDrawIn(drawIn);
                            circleList[circleList.Count() - 1] = newcircle;
                        }
                    }
                }
                else
                {
                    if (drawFinished)
                    {
                        drawFinished = false;
                        if (lineDrawing)
                        {
                            MyLine newline = new MyLine(p, p);
                            newline.setDrawIn(drawIn);
                            lineList.Add(newline);
                            circleList.Clear();
                            polylineList.Clear();
                        }
                        else if (polylineDrawing)
                        {
                            MyPolyline newpolyline = new MyPolyline(new List<Point> { });
                            newpolyline.setDrawIn(drawIn);
                            newpolyline.Add(p);
                            polylineList.Add(newpolyline);
                            lineList.Clear();
                            circleList.Clear();
                        }
                        else if (circleDrawing)
                        {
                            MyCircle newcircle = new MyCircle(p);
                            newcircle.setDrawIn(drawIn);
                            circleList.Add(newcircle);
                            lineList.Clear();
                            polylineList.Clear();
                        }
                    }
                    else
                    {
                        if (lineDrawing)
                        {
                            drawFinished = true;
                            circleList.Clear();
                            polylineList.Clear();
                            MyLine newer = new MyLine(lineList[lineList.Count() - 1].fromNode, p);
                            newer.setDrawIn(drawIn);
                            lineList[lineList.Count() - 1] = newer;
                        }
                        else if (polylineDrawing)
                        {
                            polylineList[polylineList.Count() - 1].Add(p);
                            lineList.Clear();
                            circleList.Clear();
                        }
                        else if (circleDrawing)
                        {
                            drawFinished = true;
                            lineList.Clear();
                            polylineList.Clear();
                            int r = Convert.ToInt32(circleList[circleList.Count() - 1].getDistance(p)) / 10 * 10;
                            MyCircle newer = new MyCircle(circleList[circleList.Count() - 1].center, r);
                            newer.setDrawIn(drawIn);
                            circleList[circleList.Count() - 1] = newer;
                        }
                    }
                }
            }
            else
            {
                if (drawFinished)
                {
                    lineList.Clear();
                    polylineList.Clear();
                    circleList.Clear();
                    drawFinished = false;
                    if (lineDrawing)
                    {
                        MyLine newline = new MyLine(p, p);
                        newline.setDrawIn(drawIn);
                        lineList.Add(newline);
                    }
                    else if (polylineDrawing)
                    {
                        MyPolyline newpolyline = new MyPolyline(new List<Point> { });
                        newpolyline.setDrawIn(drawIn);
                        newpolyline.Add(p);
                        polylineList.Add(newpolyline);
                    }
                    else if (circleDrawing)
                    {
                        MyCircle newcircle = new MyCircle(p);
                        newcircle.setDrawIn(drawIn);
                        circleList.Add(newcircle);
                    }
                }
                else
                {
                    if (lineDrawing)
                    {
                        drawFinished = true;
                        MyLine newer = new MyLine(lineList[0].fromNode, p);
                        newer.setDrawIn(drawIn);
                        lineList[0] = newer;
                    }
                    else if (polylineDrawing)
                    {
                        polylineList[0].Add(p);
                    }
                    else if (circleDrawing)
                    {
                        drawFinished = true;
                        int r = Convert.ToInt32(circleList[0].getDistance(p)) / 10 * 10;
                        MyCircle newer = new MyCircle(circleList[0].center, r);
                        newer.setDrawIn(drawIn);
                        circleList[0] = newer;
                    }
                }
            }
        }
        
        private void drawAll(PaintEventArgs e)
        {
            if (0 != lineList.Count())
            {
                    foreach (MyLine line in lineList)
                        line.drawMyself(e, Color.FromArgb(255, 0, 0), assistShow);
            }
            if (0 != polylineList.Count())
            {
                    foreach (MyPolyline polyline in polylineList)
                        polyline.drawMyself(e, Color.FromArgb(0, 255, 0), assistShow);
            }
            if (0 != circleList.Count())
            {
                    foreach (MyCircle circle in circleList)
                        circle.drawMyself(e, Color.FromArgb(0, 0, 255), assistShow);

            }
        }
        
        private void formTextRebuild()
        {
            string str = "姚照原-1600012406";
            if (multiDrawing)
            {
                if (mixShow)
                    str += "-混合";
                else
                    str += "-多图";
            }
            else
                str += "-单图";
            if (realTime)
                str += "-实时";
            else
                str += "-延迟";
            if (lineDrawing)
            {
                str += "-线段绘制";
                if (0 == drawIn)
                    str += "-DDA方法";
                else if (1 == drawIn)
                    str += "-Bresenham算法";
                else if (2 == drawIn)
                    str += "-错误画法";
                else
                    str += "-鬼知道现在是什么方法";
            }
            else if (polylineDrawing)
            {
                str += "-折线绘制";
                if (0 == drawIn)
                    str += "-DDA方法";
                else if (1 == drawIn)
                    str += "-Bresenham算法";
                else if (2 == drawIn)
                    str += "-错误画法";
                else
                    str += "-鬼知道现在是什么方法";
            }

            else if (circleDrawing)
            {
                str += "-圆形绘制";
                if (1 == drawIn)
                    str += "-Bresenham算法";
                else if (0 == drawIn)
                    str += "-正负法";
                else
                    str += "-鬼知道现在是什么方法";
            }
            else
                str += "-我现在出于一种奇妙的状态";
            this.Text = str;


        }

        private void dDA方法ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            polylineDrawing = true;
            lineDrawing = false;
            circleDrawing = false;
            drawFinished = true;
            drawIn = 0;
            formTextRebuild();
        }

        private void bresenham算法ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            polylineDrawing = true;
            lineDrawing = false;
            circleDrawing = false;
            drawFinished = true;
            drawIn = 1;
            formTextRebuild();
        }

        private void 错误画法ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            polylineDrawing = true;
            lineDrawing = false;
            circleDrawing = false;
            drawFinished = true;
            drawIn = 2;
            formTextRebuild();
        }

        private void bresenham算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleDrawing = true;
            lineDrawing = false;
            polylineDrawing = false;
            drawFinished = true;
            drawIn = 1;
            formTextRebuild();
        }

        private void 正负法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            circleDrawing = true;
            lineDrawing = false;
            polylineDrawing = false;
            drawFinished = true;
            drawIn = 0;
            formTextRebuild();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            //必须点在网格里边才能生效
            int lineWidth = pictureBox1.Width / 10 * 10, lineHeight = pictureBox1.Height / 10 * 10;
            if (p.X >= lineWidth || p.Y >= lineHeight)
                return;
            清空画布ToolStripMenuItem.Enabled = true;
            int new_X = p.X / 10 * 10;
            int new_Y = p.Y / 10 * 10;
            Point newPoi = new Point(new_X, new_Y);
            newAdd(newPoi);
            pictureBox1.Refresh();
        }



        private void clearScreen()
        {
            lineList.Clear();
            polylineList.Clear();
            circleList.Clear();
            pictureBox1.Refresh();
            清空画布ToolStripMenuItem.Enabled = false;
            drawFinished = true;
            pictureBox1.Refresh();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "作者：姚照原\t时间：2018/10/29\nGitHub:https://github.com/yzyGitHuub/\n\n项目内容：生成直线和圆弧的算法\n\n版权所有，盗版必究。\n";
            string cap = "关于";
            MessageBox.Show(str,cap);
        }

        private void 使用说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "姚照原创建于 2018/10/29 \t上一次修改时间：2018/10/29\nGitHub:https://github.com/yzyGitHuub/\n\n";
            str += "使用说明：\n";
            str += " * 菜单栏主要是绘制选项，标志了要画什么东西;\n";
            str += "    @ 线段有Bresenham算法，DDA方法，错误画法三种;\n";
            str += "    @ 折线有Bresenham算法，DDA方法，错误画法三种;\n";
            str += "    @ 圆形有Bresenham算法，正负法两种;\n";
            str += "    - 错误画法指的是选择 delta 小的一侧可能会出现的漏点的情况;\n";
            str += " * 绘制状态栏设置了一些显示参数.\n";
            str += "    - 可以选择 单个/ 多个 / 混合显示， 实时 / 延迟显示， 是否显示辅助线;\n";
            str += "\nTIPS:\n";
            str += " * 双击可结束折线的绘制;\n";
            str += " * 在窗体左上角也有对当前绘图状态的提示;\n";
            str += " * 支持同一界面显示同一种要素的不同画法.\n";
            str += " * 混合显示可以同时显示多种对象，而多个显示必须是同一种对象;\n";
            string cap = "使用说明";
            MessageBox.Show(str,cap);
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (realTime)
                realTimePoint = new Point(e.Location.X / 10 * 10, e.Location.Y / 10 * 10);
            pictureBox1.Refresh();
        }

        private void pictureBox1_DoubleClick_1(object sender, EventArgs e)
        {
            if (polylineDrawing)
                drawFinished = true;
            pictureBox1.Refresh();
        }

        private void 清空画布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearScreen();
        }

        private void 多个显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            多个显示ToolStripMenuItem.Checked = !多个显示ToolStripMenuItem.Checked;
            multiDrawing = !multiDrawing;
            if (multiDrawing)
            {
                //多图模式下可以开启混合显示
                混合显示ToolStripMenuItem.Enabled = true;
                混合显示ToolStripMenuItem.Checked = false;
                mixShow = false;
            }
            else
            {
                //单图模式下必须关闭混合显示
                混合显示ToolStripMenuItem.Enabled = false;
                混合显示ToolStripMenuItem.Checked = false;
                mixShow = false;
            }
            clearScreen();
            formTextRebuild();
        }

        private void 实时显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            实时显示ToolStripMenuItem.Checked = !实时显示ToolStripMenuItem.Checked;
            realTime = !realTime;
            formTextRebuild();
        }

        private void 混合显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            混合显示ToolStripMenuItem.Checked = !混合显示ToolStripMenuItem.Checked;
            mixShow = !mixShow;
            formTextRebuild();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assistShow = !assistShow;
            关闭ToolStripMenuItem.Checked = !关闭ToolStripMenuItem.Checked;
            formTextRebuild();
            pictureBox1.Refresh();
        }

    }
}
