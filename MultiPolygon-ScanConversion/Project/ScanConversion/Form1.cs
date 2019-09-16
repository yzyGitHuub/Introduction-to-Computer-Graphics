/*****************************
* Yao,Zhaoyuan 创建于 2018/11/28
* 上一次修改时间：2018/12/01
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
using System.Media;

namespace ScanConversion
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        List<MultiPolygon> madePolygonList = new List<MultiPolygon> { };
        Stack<Point> inputPoiList = new Stack<Point> { };
        MultiPolygon currentPolygon = new MultiPolygon();
        Point poiCursor = new Point(0, 0);
        bool isDrawFinished = true;
        bool isGravitationCaptured = false;
        Point poiGravitation = new Point();

        private void mainWindow_Resize(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (madePolygonList.Count() != 0)
                foreach (MultiPolygon pol in madePolygonList)
                {
                    pol.fillMyself(e);
                    pol.drawMyself(e);
                }
            if (!isDrawFinished)
            {
                Polygon polTemp = new Polygon(inputPoiList);
                currentPolygon.Add(polTemp);
                currentPolygon.fillMyself(e, poiCursor);
                currentPolygon.drawMyself(e, poiCursor);
                //currentPolygon.fillMyself(e);
                //currentPolygon.drawMyself(e);
                //polTemp.fillMyself(e, poiCursor);
                //polTemp.drawMyself(e, poiCursor);
            }
            if(isGravitationCaptured)
            {
                Graphics g = e.Graphics;
                g.DrawEllipse(new Pen(Color.Black), poiGravitation.X - 4, poiGravitation.Y - 4, 8, 8);
            }
            label1.Text = "( " + poiCursor.X + ", " + poiCursor.Y + ") pixel";
        }

        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (inputPoiList.Count() == 0)
                    if(currentPolygon.edgeCollection.Count() == 0)
                        if (madePolygonList.Count() == 0)
                            System.Media.SystemSounds.Beep.Play();
                        else
                            madePolygonList.RemoveAt(madePolygonList.Count() - 1);
                    else
                        currentPolygon.edgeCollection.Pop();
                else
                    inputPoiList.Pop();
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (madePolygonList.Count() != 0)
            {
                foreach(MultiPolygon multipol in madePolygonList)
                    if(multipol.catchPoint(e.Location) != new Point(-1,-1))
                    {
                        isGravitationCaptured = true;
                        poiGravitation = multipol.catchPoint(e.Location);
                        poiCursor = poiGravitation;
                        pictureBox1.Refresh();
                        return;
                    }
            }
            if (currentPolygon.edgeCollection.Count() != 0)
            {
                foreach(Polygon pol in currentPolygon.edgeCollection)
                    if (pol.catchPoint(e.Location) != new Point(-1, -1))
                    {
                        isGravitationCaptured = true;
                        poiGravitation = pol.catchPoint(e.Location);
                        poiCursor = poiGravitation;
                        pictureBox1.Refresh();
                        return;
                    }
            }
            if (inputPoiList.Count() != 0)
            {
                foreach(Point poi in inputPoiList)
                    if(Math.Sqrt((poi.X - e.Location.X) * (poi.X - e.Location.X) + (poi.Y - e.Location.Y) * (poi.Y - e.Location.Y)) < 4)
                    {
                        isGravitationCaptured = true;
                        poiGravitation = poi;
                        poiCursor = poiGravitation;
                        pictureBox1.Refresh();
                        return;
                    }
            }
            poiCursor = e.Location;
            isGravitationCaptured = false;
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(!isGravitationCaptured)
                    poiCursor = e.Location;
                isDrawFinished = false;
                if (inputPoiList.Count() != 0)
                    if (inputPoiList.Peek() == poiCursor)
                        return;
                inputPoiList.Push(poiCursor);
                if (inputPoiList.Count() <= 2)
                    finishPartToolStripMenuItem.Enabled = false;
                else
                    finishPartToolStripMenuItem.Enabled = true;
                if (inputPoiList.Count() > 2 || currentPolygon.edgeCollection.Count() != 0)
                    finishSketchToolStripMenuItem.Enabled = true;
                else
                    finishSketchToolStripMenuItem.Enabled = false;
            }
            else if(e.Button == MouseButtons.Right)
            {

            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!isDrawFinished)
            {
                if (inputPoiList.Count() <= 2)
                    return;
                isDrawFinished = true;
                Polygon temp = new Polygon(inputPoiList);
                currentPolygon.Add(temp);
                madePolygonList.Add(currentPolygon);
                inputPoiList = new Stack<Point> { };
                currentPolygon = new MultiPolygon();
                finishSketchToolStripMenuItem.Enabled = false;
                finishPartToolStripMenuItem.Enabled = false;
                pictureBox1.Refresh();
            }
        }

        private void finishPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isDrawFinished)
            {
                isDrawFinished = false;
                Polygon temp = new Polygon(inputPoiList);
                currentPolygon.Add(temp);
                inputPoiList = new Stack<Point> { };
                finishPartToolStripMenuItem.Enabled = false;
                pictureBox1.Refresh();
            }
        }

        private void finishSketchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawFinished = true;
            if (inputPoiList.Count() > 2)
            {
                Polygon temp = new Polygon(inputPoiList);
                currentPolygon.Add(temp);
            }
            madePolygonList.Add(currentPolygon);
            inputPoiList = new Stack<Point> { };
            currentPolygon = new MultiPolygon();
            finishSketchToolStripMenuItem.Enabled = false;
            finishPartToolStripMenuItem.Enabled = false;
            pictureBox1.Refresh();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "作者：Yao, Zhaoyuan\nGitHub:https://github.com/yzyGitHuub/ \n\n";
            str += "像用 ArcGIS 一样开始工作吧~~~：\n\n";
            str += "快捷键说明：\n\n";
            str += "*** Ctrl + Z ： 撤销上一个操作；\n";
            str += "        # 完成绘制的多边形被视为一个整体进行撤销.\n";
            str += "        # 没有可撤销对象时出现 beep 的警告提示音.\n";
            str += "        # 没有实现 redo 功能.\n\n";
            str += "鼠标按键说明：\n\n";
            str += "*** 鼠标左键单击：添加点.\n";
            str += "*** 鼠标左键双击：结束绘制多边形.\n";
            str += "        # 只有当绘制的图形是多边形时才可以结束.\n";
            str += "        # 如果只有一个点或者线是无法通过双击结束绘制.\n";
            str += "*** 鼠标右键单击：显示右键菜单.\n";
            str += "        # Finish Part:   结束当前轮廓的绘制.\n";
            str += "        # Finish Sketch: 结束当前多边形的绘制.\n\n";
            str += "附加功能说明：\n\n";
            str += "*** 实现了橡皮筋功能.\n";
            str += "        # 同时刷新当前多边形形状，与 ArcGIS 一致.\n";
            str += "*** 支持 MultiPolygon 类型对象的创建.\n";
            str += "*** 实现了点的引力场.\n";
            str += "        # 因为不支持放大缩小，所以引力场比较小，只有四个像素大小.\n\n";
            str += "BUG：悬挂点不能判断，即多边形的一顶点上延申出去的线段无法消除.\n";
            str += "     没有面积的多边形也不能消除，即折返的线不能消除.\n";
            MessageBox.Show(str, "帮助");
        }
    }
}
