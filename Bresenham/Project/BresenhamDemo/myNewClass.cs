/*****************************
* 姚照原创建于 2018/10/29
* 上一次修改时间：2018/10/29
* GitHub:https://github.com/yzyGitHuub/
* 保留所有权利
* **************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BresenhamDemo
{
    /// <summary>
    /// 自定义线段类
    /// </summary>
    public struct MyLine
    {
        public Point fromNode;
        public Point toNode;
        public int drawIn;
        public MyLine(Point p1, Point p2)
        {
            fromNode = p1;
            toNode = p2;
            drawIn = 0;
        }
        public void setDrawIn(int method)
        {
            drawIn = method;
        }
        public void drawMyself(PaintEventArgs e, Color color, bool assist)
        {
            if (0 == drawIn)
                paintDDA(e, color, assist);
            else if (1 == drawIn)
                paintBresenham(e, color, assist);
            else if (2 == drawIn)
                paintWrong(e, color, assist);
            else
            {
                string str = "似乎出错了呢 ╥﹏╥...";
                MessageBox.Show(str);
            }

        }
        public void Reverse()
        {
            Point p = fromNode;
            fromNode = toNode;
            toNode = p;
        }

        /// <summary>
        /// 如你所见，画线段，用的是 Bresenham算法
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintBresenham(PaintEventArgs e, Color color, bool assist)
        {
            Graphics g = e.Graphics;
            //开始先将 deltax 转换成正数，这样可以少些一些代码
            if ((toNode.X - fromNode.X) < 0)
                Reverse();
            //下面是 Bresenham算法的实现
            int deltax = toNode.X - fromNode.X, deltay = toNode.Y - fromNode.Y;
            int x = fromNode.X, y = fromNode.Y;
            if (deltay >= 0)
            {
                //在左下坐标系中，线段矢量呈水平或斜向上状
                if (deltax >= deltay)
                {
                    //当横坐标变化更大时，沿着 x 轴取点
                    int f = 2 * deltay - deltax;
                    for (int i = 0; i <= deltax;)
                    {
                        g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, 10, 10));
                        if (f >= 0)
                        {
                            y += 10;
                            f = f - 2 * deltax;
                        }
                        x += 10;
                        f += 2 * deltay;
                        i += 10;
                    }
                }
                else
                {
                    //当纵坐标变化更大时，沿着 y 轴取点，与上相比，基本上是 x 和 y 地位交换
                    int f = 2 * deltax - deltay;
                    for (int i = 0; i <= deltay;)
                    {
                        g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, 10, 10));
                        if (f >= 0)
                        {
                            x += 10;
                            f = f - 2 * deltay;
                        }
                        y += 10;
                        f += 2 * deltax;
                        i += 10;
                    }
                }
            }
            else
            {
                /**********************************************************
                * 这里之所以要乘 -1 是为了维护可爱的 f，没得办法，课件里边似乎少写了一两句话
                * 那就是 当 deltay < 0 时，也即线段在左下坐标系中自左上向左下时
                * f 本身就小于 0 时，再通过 f += 2 * deltay; 维护 f 的值，只能越走越偏；
                * 由此可见，deltay 和 deltax 都应该是非负数
                * ***********************************************************/
                deltay *= -1;
                if (deltax >= deltay)
                {
                    int f = 2 * deltay - deltax;
                    for (int i = 0; i <= deltax;)
                    {
                        g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, 10, 10));
                        if (f >= 0)
                        {
                            //deltay 小于 0 时 y 要减去单位长度才能从左下坐标系中左上的起点走向右下的终点，下同
                            y -= 10;
                            f = f - 2 * deltax;
                        }
                        //deltax 一直大于 0 所以 x 就是一直加上单位步长就好了
                        x += 10;
                        f += 2 * deltay;
                        i += 10;
                    }
                }
                else
                {
                    int f = 2 * deltax - deltay;
                    for (int i = 0; i <= deltay;)
                    {
                        g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, 10, 10));
                        if (f >= 0)
                        {
                            x += 10;
                            f = f - 2 * deltay;
                        }
                        //deltay 小于 0 时 y 要减去单位长度才能从左下坐标系中左上的起点走向右下的终点，同上
                        y -= 10;
                        f += 2 * deltax;
                        i += 10;
                    }
                }
            }

            //最后把我们要离散化的直线画出来，当然这个要离散的直线其实也是离散的，谁叫用户的电脑屏幕也是离散的呢
            //此之谓 再现，可算是一门高深的艺术，以离散表示离散，某种意义上实现了一种自指，无穷尽也
            if(assist)
                g.DrawLine(Pens.Black, fromNode.X + 5, fromNode.Y + 5, toNode.X + 5, toNode.Y + 5);

        }

        /// <summary>
        /// 如你所见，画线段，用的是 DDA方法
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintDDA(PaintEventArgs e, Color color, bool assist)
        {
            Graphics g = e.Graphics;
            //开始先将 deltax 转换成正数，这样不一定可以少些一些代码，但是方便思考
            if ((toNode.X - fromNode.X) < 0)
                Reverse();
            int k, i;
            double x, y, xincre, yincre;
            k = Math.Abs(toNode.X - fromNode.X);
            if (Math.Abs(toNode.Y - fromNode.Y) > k )
                k = Math.Abs(toNode.Y - fromNode.Y);
            if(0 == k)
            {
                //这里是因为当一直点一个方格时相当于没画啊，避免后面的被零除错误
                g.FillRectangle(new SolidBrush(color), fromNode.X, fromNode.Y, 10, 10);
                return;
            }
            xincre = 10.0 * (toNode.X - fromNode.X) / k;
            yincre = 10.0 * (toNode.Y - fromNode.Y) / k;
            x = fromNode.X;
            y = fromNode.Y;
            for(i = 0;i <= k;)
            {
                g.FillRectangle(new SolidBrush(color), trun(x), trun(y), 10, 10);
                x = x + xincre;
                y = y + yincre;
                i += 10;
            }
            //最后把我们要离散化的直线画出来，当然这个要离散的直线其实也是离散的，谁叫用户的电脑屏幕也是离散的呢
            //此之谓 再现，可算是一门高深的艺术，以离散表示离散，某种意义上实现了一种自指，无穷尽也
            if (assist)
                g.DrawLine(Pens.Black, fromNode.X + 5, fromNode.Y + 5, toNode.X + 5, toNode.Y + 5);
        }

        /// <summary>
        /// 如你所见，画线段，错误的画法，主要是要演示选择 delta 小的一侧时会出现的缺点现象，算法还是 DDA方法
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintWrong(PaintEventArgs e, Color color, bool assist)
        {
            Graphics g = e.Graphics;
            int k, i;
            double x, y, xincre, yincre;
            k = Math.Abs(toNode.X - fromNode.X);
            if (Math.Abs(toNode.Y - fromNode.Y) < k)
                k = Math.Abs(toNode.Y - fromNode.Y);
            if (0 == k)
            {
                //这里是因为当一直点一个方格时相当于没画啊，避免后面的被零除错误
                //如果刚好点的线段是平行于坐标轴的，那按照这个方法画的也应该只是起点，因为只能选一个像素以后下一个待选的就垂直于直线了，显然不可能有交点了
                g.FillRectangle(new SolidBrush(color), fromNode.X, fromNode.Y, 10, 10);
                return;
            }
            xincre = 10.0 * (toNode.X - fromNode.X) / k;
            yincre = 10.0 * (toNode.Y - fromNode.Y) / k;
            x = fromNode.X;
            y = fromNode.Y;
            for (i = 0; i <= k;)
            {
                g.FillRectangle(new SolidBrush(color), trun(x), trun(y), 10, 10);
                x = x + xincre;
                y = y + yincre;
                i += 10;
            }
            //最后把我们要离散化的直线画出来，当然这个要离散的直线其实也是离散的，谁叫用户的电脑屏幕也是离散的呢
            //此之谓 再现，可算是一门高深的艺术，以离散表示离散，某种意义上实现了一种自指，无穷尽也
            if (assist)
                g.DrawLine(Pens.Black, fromNode.X + 5, fromNode.Y + 5, toNode.X + 5, toNode.Y + 5);
        }
        /*************************************
        * 下面是几个在绘制线段中常用到的函数
        * ***********************************/
        private int getSign(int num)
        {
            if (0 == num)
                return 1;
            else
                return Math.Sign(num);
        }
        private int trun(double num)
        {
            double temp = num % 10;
            if (temp < 5)
                return (int)num / 10 * 10;
            else
                return (int)num / 10 * 10 + 10;
        }

    }


    /// <summary>
    /// 自定义折线类
    /// </summary>
    public struct MyPolyline
    {
        public List<Point> containList;
        public int drawIn;
        public void setDrawIn(int method)
        {
            drawIn = method;
        }
        public MyPolyline(List<Point> pList)
        {
            drawIn = 0;
            containList = pList;
        }
        public void Add(Point p)
        {
            containList.Add(p);
        }
        public void reverseLine()
        {
            containList.Reverse();
        }
        public void drawMyself(PaintEventArgs e, Color color, bool assist)
        {
            if (0 == drawIn)
                paintDDA(e, color, assist);
            else if (1 == drawIn)
                paintBresenham(e, color, assist);
            else if (2 == drawIn)
                paintWrong(e, color, assist);
            else
            {
                string str = "似乎出错了呢 ╥﹏╥...";
                MessageBox.Show(str);
            }
        }
        /// <summary>
        /// 如你所见，画折线
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintBresenham(PaintEventArgs e, Color color, bool assist)
        {
            int count = containList.Count();
            if(1 == count)
            {
                MyLine tempLine = new MyLine(containList[0], containList[0]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
                return;
            }
            for (int i = 1; i < count; i++)
            {
                MyLine tempLine = new MyLine(containList[i - 1], containList[i]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
            }
        }
        private void paintDDA(PaintEventArgs e, Color color, bool assist)
        {
            int count = containList.Count();
            if (1 == count)
            {
                MyLine tempLine = new MyLine(containList[0], containList[0]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
                return;
            }
            for (int i = 1; i < count; i++)
            {
                MyLine tempLine = new MyLine(containList[i - 1], containList[i]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
            }
        }
        private void paintWrong(PaintEventArgs e, Color color, bool assist)
        {
            int count = containList.Count();
            if (1 == count)
            {
                MyLine tempLine = new MyLine(containList[0], containList[0]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
                return;
            }
            for (int i = 1; i < count; i++)
            {
                MyLine tempLine = new MyLine(containList[i - 1], containList[i]);
                tempLine.setDrawIn(drawIn);
                tempLine.drawMyself(e, color, assist);
            }
        }
    }



    /// <summary>
    /// 自定义圆类
    /// </summary>
    public struct MyCircle
    {
        public Point center;
        public int radius;
        public int drawIn;
        public MyCircle(Point p)
        {
            drawIn = 0;
            center = p;
            radius = 0;
        }
        public MyCircle(Point p, int r)
        {
            drawIn = 0;
            center = p;
            radius = r;
        }
        public void setDrawIn(int method)
        {
            drawIn = method;
        }
        public void drawMyself(PaintEventArgs e, Color color, bool assist)
        {
            if (0 == drawIn)
                paintInOut(e, color, assist);
            else if (1 == drawIn)
                paintBresenham(e, color, assist);
            else
            {
                string str = "似乎出错了呢 ╥﹏╥...";
                MessageBox.Show(str);
            }
        }

        //得到给的点距离圆心的距离
        public double getDistance(Point p)
        {
            return Math.Sqrt((p.X - center.X) * (p.X - center.X) + (p.Y - center.Y) * (p.Y - center.Y));
        }
        /// <summary>
        /// 如你所见，画圆，用的是 Bresenham算法
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintBresenham(PaintEventArgs e, Color color, bool assist)
        {
            Graphics g = e.Graphics;
            //绘制圆心
            g.FillRectangle(new SolidBrush(color), new Rectangle(center, new Size(10, 10)));
            if (0 == radius)
                return;
            int x = 0, y = radius, d = 3 - 2 * radius / 10;
            while (x < y)
            {
                //注意本处的矩形格式，必须是将 x, y 的正负号组合之后再平移
                //而不是平移以后再直接交换，那样画只能画对一部分的点，十分玄学
                //不要问我为什么，厂长是我表锅
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + y, center.Y + x, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + y, center.Y - x, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y - y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - y, center.Y + x, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y - y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - y, center.Y - x, 10, 10));
                if (d < 0)
                    d = d + 4 * x / 10 + 6;
                else
                {
                    d = d + 4 * (x - y) / 10 + 10;
                    y = y - 10;
                }
                x += 10;
            }
            if (x == y)
            {
                //其实窗体应用程序效率本来就不高，这么个窗体也是演示作用，不用考虑这些细枝末节的东西
                //所以直接合并到上面的循环中也没啥不可以的
                //但是田原老师总是唠叨 6000万 的事情，也只好能抓的地方抓一下好了
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y - y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y - y, 10, 10));
            }
            //最后把我们要离散化的圆画出来，当然这个要离散的圆其实也是离散的，谁叫用户的电脑屏幕也是离散的呢
            //此之谓 再现，可算是一门高深的艺术，以离散表示离散，某种意义上实现了一种自指，无穷尽也
            //啥，你说这些话似曾相识？别问我是谁，我是人类的本质
            if (assist)
                g.DrawEllipse(Pens.Black, new Rectangle(center.X - radius + 5, center.Y - radius + 5, radius * 2, radius * 2));

        }

        /// <summary>
        /// 如你所见，画圆，用的是正负法，只考虑效果不考虑效率
        /// </summary>
        /// <param name="e">画图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="assist">是否画出辅助线</param>
        private void paintInOut(PaintEventArgs e, Color color, bool assist)
        {
            Graphics g = e.Graphics;
            //绘制圆心
            g.FillRectangle(new SolidBrush(color), new Rectangle(center, new Size(10, 10)));
            if (0 == radius)
                return;
            int x = 0, y = radius;
            double distance;
            while (x < radius || y > 0)
            {
                //注意本处的矩形格式，必须是将 x, y 的正负号组合之后再平移
                //而不是平移以后再直接交换，那样画只能画对一部分的点，十分玄学
                //不要问我为什么，厂长是我表锅
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y + y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + x, center.Y - y, 10, 10));
                g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - x, center.Y - y, 10, 10));

                distance = Math.Sqrt(x*x+y*y);
                if (distance <= radius)
                    x += 10;
                else
                    y -= 10;
            }
            g.FillRectangle(new SolidBrush(color), new Rectangle(center.X + radius, center.Y, 10, 10));
            g.FillRectangle(new SolidBrush(color), new Rectangle(center.X - radius, center.Y, 10, 10));

            //最后把我们要离散化的圆画出来，当然这个要离散的圆其实也是离散的，谁叫用户的电脑屏幕也是离散的呢
            //此之谓 再现，可算是一门高深的艺术，以离散表示离散，某种意义上实现了一种自指，无穷尽也
            //啥，你说这些话似曾相识？别问我是谁，我是人类的本质
            if (assist)
                g.DrawEllipse(Pens.Black, new Rectangle(center.X - radius + 5, center.Y - radius + 5, radius * 2, radius * 2));

        }

    }


}
