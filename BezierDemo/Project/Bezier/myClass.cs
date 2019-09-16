/*****************************
* Yao,Zhaoyuan 创建于 2018/12/15
* 上一次修改时间：2018/12/16
* GitHub:https://github.com/yzyGitHuub/
* 保留所有权利
* **************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Bezier
{    
    /// <summary>
    /// 静态不可变对象集合
    /// </summary>
    static class myStatic
    {
        /// <summary>
        /// 贝塞尔曲线绘制阈值
        /// 当小于此值时认为绘制的是一个直线段
        /// </summary>
        public static double bezierThreshold = 0.1;
        /// <summary>
        /// 点对点产生的引力场半径
        /// </summary>
        public static float  poi2poiDistMin = 10;
        /// <summary>
        /// 线段对点产生的引力场
        /// </summary>
        public static float  poi2edgeDistMin = 6;
        /// <summary>
        /// 精度上限
        /// 小于此值时认为两浮点数相等
        /// </summary>
        public static double min = 0.00000000001;
        /// <summary>
        /// 表示一个不存在的点，也即（-1，-1）
        /// </summary>
        public static PointF emptyPoi = new PointF(-1, -1);
        /// <summary>
        /// 表示一个不存在的边
        /// 也即 ( (-1, -1), (-1, -1) )
        /// </summary>
        public static Edge   emptyEdge = new Edge(new PointF(-1, -1), new PointF(-1, -1));
        /// <summary>
        /// 两点间的距离
        /// </summary>
        /// <param name="poi1">点 1</param>
        /// <param name="poi2">点 2</param>
        /// <returns>返回两点间的欧式距离</returns>
        public static double getDistance(PointF poi1, PointF poi2)
        {
            return Math.Sqrt((poi1.X - poi2.X) * (poi1.X - poi2.X) + (poi1.Y - poi2.Y) * (poi1.Y - poi2.Y));
        }
        /// <summary>
        /// 两点间的距离
        /// </summary>
        /// <param name="poi1">点 1</param>
        /// <param name="poi2">点 2</param>
        /// <returns>返回两点间的欧式距离</returns>
        public static double getDistance(Point poi1, PointF poi2)
        {
            return Math.Sqrt((poi1.X - poi2.X) * (poi1.X - poi2.X) + (poi1.Y - poi2.Y) * (poi1.Y - poi2.Y));
        }
        /// <summary>
        /// 两点间的距离
        /// </summary>
        /// <param name="poi1">点 1</param>
        /// <param name="poi2">点 2</param>
        /// <returns>返回两点间的欧式距离</returns>
        public static double getDistance(PointF poi1, Point poi2)
        {
            return Math.Sqrt((poi1.X - poi2.X) * (poi1.X - poi2.X) + (poi1.Y - poi2.Y) * (poi1.Y - poi2.Y));
        }
        /// <summary>
        /// 两点间的距离
        /// </summary>
        /// <param name="poi1">点 1</param>
        /// <param name="poi2">点 2</param>
        /// <returns>返回两点间的欧式距离</returns>
        public static double getDistance(Point poi1, Point poi2)
        {
            return Math.Sqrt((poi1.X - poi2.X) * (poi1.X - poi2.X) + (poi1.Y - poi2.Y) * (poi1.Y - poi2.Y));
        }
        /// <summary>
        /// 点到直线的距离
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>返回点到直线的欧式距离</returns>
        public static double getDistance(PointF poi, Edge edge)
        {
            if (edge.poi1 == edge.poi2)
                return getDistance(poi, edge.poi1);
            double A = edge.poi2.Y - edge.poi1.Y, B = edge.poi1.X - edge.poi2.X, C = edge.poi2.X * edge.poi1.Y - edge.poi1.X * edge.poi2.Y;
            return Math.Abs(A * poi.X + B * poi.Y + C) / Math.Sqrt(A * A + B * B);
        }
        /// <summary>
        /// 点到直线的距离
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>返回点到直线的欧式距离</returns>
        public static double getDistance(Point poi, Edge edge)
        {
            if (edge.poi1 == edge.poi2)
                return getDistance(poi, edge.poi1);
            double A = edge.poi2.Y - edge.poi1.Y, B = edge.poi1.X - edge.poi2.X, C = edge.poi2.X * edge.poi1.Y - edge.poi1.X * edge.poi2.Y;
            return Math.Abs(A * poi.X + B * poi.Y + C) / Math.Sqrt(A * A + B * B);
        }
        /// <summary>
        /// 点在直线上的垂足
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>返回点在直线上的垂足</returns>
        public static PointF getPedal(PointF poi, Edge edge)
        {
            float A = edge.poi2.Y - edge.poi1.Y, B = edge.poi1.X - edge.poi2.X, C = edge.poi2.X * edge.poi1.Y - edge.poi1.X * edge.poi2.Y;
            float x = (B * B * poi.X - A * B * poi.Y - A * C) / (A * A + B * B), y = (A * A * poi.Y - A * B * poi.X - B * C) / (A * A + B * B);
            return new PointF(x, y);
        }
        /// <summary>
        /// 点在直线上的垂足
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>返回点在直线上的垂足</returns>
        public static PointF getPedal(Point poi, Edge edge)
        {
            float A = edge.poi2.Y - edge.poi1.Y, B = edge.poi1.X - edge.poi2.X, C = edge.poi2.X * edge.poi1.Y - edge.poi1.X * edge.poi2.Y;
            float x = (B * B * poi.X - A * B * poi.Y - A * C) / (A * A + B * B), y = (A * A * poi.Y - A * B * poi.X - B * C) / (A * A + B * B);
            return new PointF(x, y);
        }
        /// <summary>
        /// 过点做线段的垂线是否与线段相交
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>相交返回 true，不相交返回 false</returns>
        public static bool   isPedalIn(PointF poi, Edge edge)
        {
            if (Math.Abs(edge.poi1.X - edge.poi2.X) < min)
            {
                if ((poi.Y >= edge.poi1.Y && poi.Y <= edge.poi2.Y) || (poi.Y >= edge.poi2.Y && poi.Y <= edge.poi1.Y))
                    return true;
                else
                    return false;
            }
            else
            {
                PointF poiP = getPedal(poi, edge);
                double deltaX = edge.poi2.X - edge.poi1.X;
                double t = (poi.X - edge.poi1.X) / deltaX;
                if (t < 0 || t > 1)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// 过点做线段的垂线是否与线段相交
        /// </summary>
        /// <param name="poi">点</param>
        /// <param name="edge">直线，用一线段表示</param>
        /// <returns>相交返回 true，不相交返回 false</returns>
        public static bool   isPedalIn(Point poi, Edge edge)
        {
            if (Math.Abs(edge.poi1.X - edge.poi2.X) < min)
            {
                if ((poi.Y >= edge.poi1.Y && poi.Y <= edge.poi2.Y) || (poi.Y >= edge.poi2.Y && poi.Y <= edge.poi1.Y))
                    return true;
                else
                    return false;
            }
            else
            {
                PointF poiP = getPedal(poi, edge);
                double deltaX = edge.poi2.X - edge.poi1.X;
                double t = (poi.X - edge.poi1.X) / deltaX;
                if (t < 0 || t > 1)
                    return false;
                else
                    return true;
            }
        }
    }

    /// <summary>
    /// 边 Edge
    /// 包括起始点和终止点
    /// </summary>
    class Edge
    {
        /// <summary>
        /// 端点 1
        /// </summary>
        public PointF poi1;
        /// <summary>
        /// 端点 2
        /// </summary>
        public PointF poi2;
        /// <summary>
        /// 构造空线段
        /// </summary>
        public Edge()
        {
            poi1 = myStatic.emptyPoi;
            poi2 = myStatic.emptyPoi;
        }
        /// <summary>
        /// 构造线段
        /// </summary>
        /// <param name="p1">端点 1</param>
        /// <param name="p2">端点 2</param>
        public Edge(PointF p1, PointF p2)
        {
            poi1 = p1;
            poi2 = p2;
        }
        /// <summary>
        /// 得到线段长度
        /// </summary>
        /// <returns>返回线段长度</returns>
        public double getLen()
        {
            return myStatic.getDistance(poi1, poi2);
        }
        public static bool operator ==(Edge e1, Edge e2)
        {
            if (e1.poi2 == e2.poi1 && e1.poi1 == e2.poi2)
                return true;
            else if (e1.poi1 == e2.poi1 && e1.poi2 == e2.poi2)
                return true;
            else
                return false;
        }
        public static bool operator !=(Edge e1, Edge e2)
        {
            if (e1.poi2 == e2.poi1 && e1.poi1 == e2.poi2)
                return false;
            else if (e1.poi1 == e2.poi1 && e1.poi2 == e2.poi2)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 判断给定点是否在当前线段引力场内
        /// 返回是否捕获传入点的状态
        /// </summary>
        /// <param name="location">待捕获的点</param>
        /// <returns>返回是否捕获传入点</returns>
        public bool catchPoint(Point location)
        {
            if (myStatic.getDistance(poi1, location) <= myStatic.poi2edgeDistMin || myStatic.getDistance(poi2, location) <= myStatic.poi2edgeDistMin)
                return true;
            if (myStatic.isPedalIn(location, new Edge(poi1, poi2)) && (myStatic.getDistance(location, new Edge(poi1, poi2)) <= myStatic.poi2edgeDistMin))
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 折线 Polyline 
    /// </summary>
    class Polyline
    {
        /// <summary>
        /// 折线的点序列，每个点只记录一次
        /// </summary>
        public List<System.Drawing.PointF> poiList = new List<PointF>();

        /// <summary>
        /// 新建空折线对象
        /// </summary>
        public Polyline()
        {
            poiList = new List<PointF>();
        }

        /// <summary>
        /// 根据点序列新建折线对象
        /// </summary>
        /// <param name="input"></param>
        public Polyline(List<PointF> input)
        {
            poiList = input;
        }

        /// <summary>
        /// 根据点序列新建折线对象
        /// </summary>
        /// <param name="input"></param>
        public Polyline(List<Point> input)
        {
            int num = input.Count();
            for (int i = 0; i < num; i++)
                poiList.Add(input[i]);
        }

        /// <summary>
        /// 绘制折线边界
        /// </summary>
        /// <param name="e">绘图事件</param>
        /// <param name="poiCursor">鼠标位置</param>
        public void drawMyself(PaintEventArgs e, Point poiCursor)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (poiList.Count())
            {
                case 0:
                    break;
                case 1:
                    g.DrawLine(new Pen(Color.Aqua), poiList[0], poiCursor);
                    g.FillRectangle(new SolidBrush(Color.Red), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    break;
                default:
                    PointF poi1, poi2;
                    int num = poiList.Count();
                    g.DrawLine(new Pen(Color.Aqua), poiList[num - 1], poiCursor);
                    for (int i = 0; i < num - 1; i++)
                    {
                        poi1 = poiList[i];
                        poi2 = poiList[i + 1];
                        g.FillRectangle(new SolidBrush(Color.Green), poi1.X - 2, poi1.Y - 2, 4, 4);
                        g.DrawLine(new Pen(Color.Green), poi1, poi2);
                    }
                    g.FillRectangle(new SolidBrush(Color.Red), poiList[num - 1].X - 2, poiList[num - 1].Y - 2, 4, 4);
                    break;
            }
        }

        /// <summary>
        /// 绘制折线边界
        /// </summary>
        /// <param name="e">绘图事件</param>
        public void drawMyself(PaintEventArgs e, Color color)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (poiList.Count())
            {
                case 0:
                    break;
                case 1:
                    g.FillRectangle(new SolidBrush(color), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    break;
                default:
                    PointF poi1, poi2;
                    g.FillRectangle(new SolidBrush(color), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    int num = poiList.Count();
                    for (int i = 1; i < num; i++)
                    {
                        poi1 = poiList[i];
                        poi2 = poiList[i - 1];
                        g.FillRectangle(new SolidBrush(color), poi1.X - 2, poi1.Y - 2, 4, 4);
                        g.DrawLine(new Pen(color, 1), poi1, poi2);
                    }
                    break;
            }
        }

        /// <summary>
        /// 输入的点是否在当前顶点集合的引力场内
        /// 返回捕获传入点的点的编号（没有被捕获则返回 -1）
        /// </summary>
        /// <param name="location">输入的位置</param>
        /// <returns>返回捕获传入点的点的编号（没有被捕获则返回 -1）</returns>
        private int _poiCatchPoint(Point location)
        {
            if (poiList.Count() == 0)
                return -1;
            for (int i = 0; i < poiList.Count(); i++)
                if (myStatic.getDistance(poiList[i], location) <= myStatic.poi2poiDistMin)
                    return i;
            return -1;
        }

        /// <summary>
        /// 判断给定点是否在当前折线边界集合的引力场内
        /// 边的编号是 poiList.Count() + 起始点编号
        /// </summary>
        /// <param name="location">待捕获的点</param>
        /// <returns>返回捕获传入点的线段的编号（没有被捕获则返回 -1）</returns>
        private int _lineCatchPoint(Point location)
        {
            int num = poiList.Count();
            if ( num < 2)
                return -1;
            Edge edge = myStatic.emptyEdge;
            for(int i = 0; i < num-1; i++)
            {
                if (new Edge(poiList[i], poiList[i + 1]).catchPoint(location))
                    return i + num;
            }
            return -1;
        }

        /// <summary>
        /// 判断给定点是否在当前折线引力场内
        /// 返回捕获传入点的元素的编号
        /// 没有被捕获则返回 -1 
        /// </summary>
        /// <param name="location">待捕获的点</param>
        /// <returns>返回捕获传入点的元素的编号</returns>
        public int catchPoint(Point location)
        {
            int temp = _poiCatchPoint(location);
            if ( temp == -1)
                temp = _lineCatchPoint(location);
            return temp;
        }

        /// <summary>
        /// 移动 Polyline
        /// </summary>
        /// <param name="deltax">x 方向移动值</param>
        /// <param name="deltay">y 方向移动值</param>
        public void move(double deltax, double deltay)
        {
            if (poiList.Count() == 0)
                return;
            for(int i = 0; i < poiList.Count(); i++)
            {
                poiList[i] = new PointF((float)(poiList[i].X + deltax), (float)(poiList[i].Y + deltay));
            }
        }
    }

    /// <summary>
    /// 贝塞尔曲线类 Bezier
    /// </summary>
    class Bezier
    {
        /// <summary>
        /// 贝塞尔曲线的控制多边形
        /// </summary>
        public Polyline P;
        /// <summary>
        /// 构建空贝塞尔曲线对象
        /// </summary>
        public Bezier()
        {
            P = new Polyline();
        }
        /// <summary>
        /// 构建贝塞尔曲线对象
        /// </summary>
        /// <param name="pol">控制多边形序列</param>
        public Bezier(Polyline pol)
        {
            P = pol;
        }
        private void curveSplit(ref List<PointF> p1, ref List<PointF>Q, ref List<PointF> R)
        {
            int n = p1.Count() - 1;
            Q = p1;
            for(int i = 1; i <= n;i++)
            {
                R[n + 1 - i] = Q[n];
                for (int j = n; j >= i; j--)
                    Q[j] = new PointF((Q[j - 1].X + Q[j].X) / 2, (Q[j - 1].Y + Q[j].Y) / 2);
            }
            R[0] = Q[n];
        }
        private void curveGeneration(PaintEventArgs e, Color color)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int num = P.poiList.Count() - 1;
            List<PointF> P1,Q1,R1;
            Stack<List<PointF>> stack = new Stack<List<PointF>> { };
            stack.Push(new List<PointF>(P.poiList));
            while(stack.Count() != 0)
            {
                P1 = stack.Pop();
                double max = 0;
                for(int i = 1; i < num; i++)
                {
                    double dis = myStatic.getDistance(P1[i], new Edge(P1[0], P1[num]));
                    if (dis > max)
                        max = dis;
                }
                if(max <= myStatic.bezierThreshold)
                {
                    g.DrawLine(new Pen(color, 1), P1[0], P1[num]);
                }
                else
                {
                    Q1 = new List<PointF>(P1);
                    R1 = new List<PointF>(P1);
                    curveSplit(ref P1, ref Q1, ref R1);
                    stack.Push(Q1);
                    stack.Push(R1);
                }
            }
        }
        /// <summary>
        /// 绘制贝塞尔曲线
        /// </summary>
        /// <param name="e">绘图事件</param>
        /// <param name="color">曲线颜色</param>
        public void drawMyself(PaintEventArgs e, Color color)
        {
            if (P.poiList.Count() < 2)
                return;
            curveGeneration(e, color);
        }
    }

}
