/*****************************
* Yao,Zhaoyuan 创建于 2018/11/28
* 上一次修改时间：2018/12/01
* GitHub:https://github.com/yzyGitHuub/
* 保留所有权利
* **************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ScanConversion
{
    /// <summary>
    /// 边类型，用且仅用于多边形的扫描转换算法
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// 边的下端点的 y 坐标，排序的依据
        /// </summary>
        public int ymin;
        /// <summary>
        /// 边的上端点的 y 坐标;
        /// </summary>
        public int ymax;
        /// <summary>
        /// 在 ET 中表示边的下端点 x 坐标, 在 AEL 中则表示边与扫描线的交点坐标;
        /// </summary>
        public double x;
        /// <summary>
        /// 边的斜率的倒数
        /// </summary>
        public double deltax;
    }

    /// <summary>
    /// 简单多边形 Polygon 
    /// </summary>
    partial class Polygon
    {
        /// <summary>
        /// 简单多边形的点序列，每个点只记录一次
        /// </summary>
        public List<System.Drawing.Point> poiList;

        /// <summary>
        /// 从 C# 的 Stack 类型转换成了 List 类型生成简单多边形
        /// 注意这样做时，点序列是与传入的数据反序的
        /// </summary>
        /// <param name="input"> 输入构成简单多边形的点序列 </param>
        public Polygon(Stack<Point> input)
        {
            //这里很值得注意
            //我是直接从 C# 的 Stack 类型转换成了 List 类型
            //显然这种内置的实现机制是一个个从栈顶弹出然后构建的列表
            //所以是倒序的
            //和我们形式上的理解是不一样的
            poiList = new List<Point>(input);
        }

        /// <summary>
        /// 填充多边形
        /// </summary>
        /// <param name="e">绘图事件</param>
        public void fillMyself(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Aquamarine, 1);
            int allYMin = 100000;//y 的最小值，肯定比
            int num = poiList.Count();
            if (num <= 2)
                return;
            //创建并维护 EdgeTable 表
            //EdgeTable 用 SQL 语句来描述就是
            // select * from 边全集 group by ymin;
            Dictionary<int, List<Edge>> EdgeTable = new Dictionary<int, List<Edge>> { };// 下端点 y 坐标相同的边序列的序列
            poiList.Add(poiList[0]);
            int i;
            for (i = 1; i <= num; i++)
            {
                Edge tempEdge = new Edge();
                if (poiList[i].Y < allYMin)
                    allYMin = poiList[i].Y;
                if (poiList[i].Y != poiList[i - 1].Y)
                {
                    if (poiList[i].Y < poiList[i - 1].Y)
                    {
                        tempEdge.ymax = poiList[i - 1].Y;
                        tempEdge.ymin = poiList[i].Y;
                        tempEdge.x = poiList[i].X;
                        tempEdge.deltax = 1.0 * (poiList[i - 1].X - poiList[i].X) / (poiList[i - 1].Y - poiList[i].Y);
                    }
                    else
                    {
                        tempEdge.ymin = poiList[i - 1].Y;
                        tempEdge.ymax = poiList[i].Y;
                        tempEdge.x = poiList[i - 1].X;
                        tempEdge.deltax = 1.0 * (poiList[i].X - poiList[i - 1].X) / (poiList[i].Y - poiList[i - 1].Y);
                    }
                    if (EdgeTable.ContainsKey(tempEdge.ymin))
                    {
                        List<Edge> edgelist = EdgeTable[tempEdge.ymin];
                        edgelist.Add(tempEdge);
                        EdgeTable[tempEdge.ymin] = edgelist;
                    }
                    else
                    {
                        List<Edge> edgelist = new List<Edge>();
                        edgelist.Add(tempEdge);
                        EdgeTable[tempEdge.ymin] = edgelist;
                    }
                }
            }
            poiList.RemoveAt(num);
            //EdgeTable 维护完以后开始进入算法

            //边的活化链表集合为空
            List<Edge> availiableList = new List<Edge>();
            //去扫描线纵坐标的初始值为 ET 中非空集合的最小序号
            i = allYMin;
            do
            {
                //若边分类表钟的第 i 类元素不为空
                //则将属于该类的所有边从 ET 中取出
                //并插入活化链表中 AEL
                if (EdgeTable.ContainsKey(i))
                {
                    foreach (Edge temper in EdgeTable[i])
                        availiableList.Add(temper);
                    EdgeTable.Remove(i);
                }
                //若当前活化链表不为空
                if (availiableList.Count() != 0)
                {
                    //AEL 中各边按照 x 值升序排列
                    //x 相同时按照 deltax 升序排列
                    availiableList = availiableList.OrderBy(availiableLists => availiableLists.x).ThenBy(availiableLists => availiableLists.deltax).ToList();



                    //将 AEL 中的边两两依次配对
                    //每队边与当前扫描线的交点构成的区域位于多边形内
                    //用边长为 1 的画笔画线
                    for (int j = 1; j < availiableList.Count(); j = j + 2)
                        g.DrawLine(pen, (float)availiableList[j - 1].x, i, (float)availiableList[j].x, i);

                    //将边的活化链表中满足 ymax = i + 1 的边删去
                    //如果是将边的活化链表中满足 ymax = i 的边删去
                    //按照这个顺序来的话会在非极值点的地方出现一条空白的线
                    //如果非要删除 ymax = i，应该将此模块移动到绘制模块，也就是上一块的前边
                    for (int j = availiableList.Count() - 1; j >= 0; j--)
                        if (availiableList[j].ymax == i + 1)
                            availiableList.RemoveAt(j);

                    for (int j = 0; j < availiableList.Count(); j++)
                        availiableList[j].x += availiableList[j].deltax;
                }
                i++;
            } while (EdgeTable.Count() != 0 || availiableList.Count() != 0);
        }

        public void fillMyself(PaintEventArgs e, Point Cursor)
        {
            poiList.Add(Cursor);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Aquamarine, 1);
            int allYMin = 100000;//y 的最小值，肯定比
            int num = poiList.Count();
            if (num <= 2)
                return;
            //创建并维护 EdgeTable 表
            //EdgeTable 用 SQL 语句来描述就是
            // select * from 边全集 group by ymin;
            Dictionary<int, List<Edge>> EdgeTable = new Dictionary<int, List<Edge>> { };// 下端点 y 坐标相同的边序列的序列
            poiList.Add(poiList[0]);
            int i;
            for (i = 1; i <= num; i++)
            {
                Edge tempEdge = new Edge();
                if (poiList[i].Y < allYMin)
                    allYMin = poiList[i].Y;
                if (poiList[i].Y != poiList[i - 1].Y)
                {
                    if (poiList[i].Y < poiList[i - 1].Y)
                    {
                        tempEdge.ymax = poiList[i - 1].Y;
                        tempEdge.ymin = poiList[i].Y;
                        tempEdge.x = poiList[i].X;
                        tempEdge.deltax = 1.0 * (poiList[i - 1].X - poiList[i].X) / (poiList[i - 1].Y - poiList[i].Y);
                    }
                    else
                    {
                        tempEdge.ymin = poiList[i - 1].Y;
                        tempEdge.ymax = poiList[i].Y;
                        tempEdge.x = poiList[i - 1].X;
                        tempEdge.deltax = 1.0 * (poiList[i].X - poiList[i - 1].X) / (poiList[i].Y - poiList[i - 1].Y);
                    }
                    if (EdgeTable.ContainsKey(tempEdge.ymin))
                    {
                        List<Edge> edgelist = EdgeTable[tempEdge.ymin];
                        edgelist.Add(tempEdge);
                        EdgeTable[tempEdge.ymin] = edgelist;
                    }
                    else
                    {
                        List<Edge> edgelist = new List<Edge>();
                        edgelist.Add(tempEdge);
                        EdgeTable[tempEdge.ymin] = edgelist;
                    }
                }
            }
            poiList.RemoveAt(num);
            //EdgeTable 维护完以后开始进入算法

            //边的活化链表集合为空
            List<Edge> availiableList = new List<Edge>();
            //去扫描线纵坐标的初始值为 ET 中非空集合的最小序号
            i = allYMin;
            do
            {
                //若边分类表钟的第 i 类元素不为空
                //则将属于该类的所有边从 ET 中取出
                //并插入活化链表中 AEL
                if (EdgeTable.ContainsKey(i))
                {
                    foreach (Edge temper in EdgeTable[i])
                        availiableList.Add(temper);
                    EdgeTable.Remove(i);
                }
                //若当前活化链表不为空
                if (availiableList.Count() != 0)
                {
                    //AEL 中各边按照 x 值升序排列
                    //x 相同时按照 deltax 升序排列
                    availiableList = availiableList.OrderBy(availiableLists => availiableLists.x).ThenBy(availiableLists => availiableLists.deltax).ToList();



                    //将 AEL 中的边两两依次配对
                    //每队边与当前扫描线的交点构成的区域位于多边形内
                    //用边长为 1 的画笔画线
                    for (int j = 1; j < availiableList.Count(); j = j + 2)
                        g.DrawLine(pen, (float)availiableList[j - 1].x, i, (float)availiableList[j].x, i);

                    //将边的活化链表中满足 ymax = i + 1 的边删去
                    //如果是将边的活化链表中满足 ymax = i 的边删去
                    //按照这个顺序来的话会在非极值点的地方出现一条空白的线
                    //如果非要删除 ymax = i，应该将此模块移动到绘制模块，也就是上一块的前边
                    for (int j = availiableList.Count() - 1; j >= 0; j--)
                        if (availiableList[j].ymax == i + 1)
                            availiableList.RemoveAt(j);

                    for (int j = 0; j < availiableList.Count(); j++)
                        availiableList[j].x += availiableList[j].deltax;
                }
                i++;
            } while (EdgeTable.Count() != 0 || availiableList.Count() != 0);
        }
        
        public void drawMyself(PaintEventArgs e, Point poiCursor)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (poiList.Count())
            {
                case 0:
                    //g.FillRectangle(new SolidBrush(Color.Aqua), poiCursor.X - 2, poiCursor.Y - 2, 4, 4);
                    break;
                case 1:
                    g.DrawLine(new Pen(Color.Aqua), poiList[0], poiCursor);
                    //g.FillRectangle(new SolidBrush(Color.Aqua), poiCursor.X - 2, poiCursor.Y - 2, 4, 4);
                    g.FillRectangle(new SolidBrush(Color.Red), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    break;
                default:
                    Point poi1, poi2;
                    g.DrawLine(new Pen(Color.Aqua), poiList.First(), poiCursor);
                    g.DrawLine(new Pen(Color.Aqua), poiList.Last(), poiCursor);
                    //g.FillRectangle(new SolidBrush(Color.Aqua), poiCursor.X - 2, poiCursor.Y - 2, 4, 4);
                    int num = poiList.Count();
                    for (int i = 1; i < num; i++)
                    {
                        poi1 = poiList[i];
                        poi2 = poiList[i - 1];
                        g.FillRectangle(new SolidBrush(Color.Green), poi1.X - 2, poi1.Y - 2, 4, 4);
                        g.DrawLine(new Pen(Color.Green), poi1, poi2);
                    }
                    g.FillRectangle(new SolidBrush(Color.Red), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    break;
            }

        }

        /// <summary>
        /// 绘制多边形边界
        /// </summary>
        /// <param name="e">绘图事件</param>
        public void drawMyself(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (poiList.Count())
            {
                case 0:
                    break;
                case 1:
                    g.FillRectangle(new SolidBrush(Color.Green), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    break;
                default:
                    Point poi1, poi2;
                    g.FillRectangle(new SolidBrush(Color.Green), poiList[0].X - 2, poiList[0].Y - 2, 4, 4);
                    int num = poiList.Count();
                    for (int i = 1; i < num; i++)
                    {
                        poi1 = poiList[i];
                        poi2 = poiList[i - 1];
                        g.FillRectangle(new SolidBrush(Color.Green), poi1.X - 2, poi1.Y - 2, 4, 4);
                        g.DrawLine(new Pen(Color.Green), poi1, poi2);
                    }
                    g.DrawLine(new Pen(Color.Green), poiList[0], poiList[poiList.Count() - 1]);
                    break;
            }

        }

        private double getDistance(Point poi1, Point poi2)
        {
            return Math.Sqrt((poi1.X - poi2.X) * (poi1.X - poi2.X) + (poi1.Y - poi2.Y) * (poi1.Y - poi2.Y));
        }

        /// <summary>
        /// 判断给定点是否在当前点引力场内
        /// 返回捕获传入点的点的坐标（没有被捕获则返回 (-1, -1)）
        /// </summary>
        /// <param name="location">待捕获的点</param>
        /// <returns>返回捕获传入点的点的坐标（没有被捕获则返回 (-1, -1)）</returns>
        public Point catchPoint(Point location)
        {
            foreach (Point poi in poiList)
                if (getDistance(poi, location) <= 4)
                    return poi;
            return new Point(-1, -1);
        }

    }

    /// <summary>
    /// 复杂多边形类
    /// </summary>
    partial class MultiPolygon
    {
        /// <summary>
        /// 多边形的边界的集合
        /// 将复杂多边形视为简单多边形的集合
        /// </summary>
        public Stack<Polygon> edgeCollection = new Stack<Polygon> { };

        /// <summary>
        /// 构建空的复杂多边形
        /// </summary>
        public MultiPolygon()
        {
            edgeCollection = new Stack<Polygon> { };
        }

        /// <summary>
        /// 构建一个等同于简单多边形的复杂多边形对象
        /// </summary>
        /// <param name="input"></param>
        public MultiPolygon(Stack<Point> input)
        {
            Polygon pol = new Polygon(input);
            edgeCollection.Push(pol);
        }

        /// <summary>
        /// 根据边界序列构建复杂多边形
        /// </summary>
        /// <param name="input"></param>
        public MultiPolygon(Stack<Polygon> input)
        {
            edgeCollection = input;
        }

        /// <summary>
        /// 向复杂多边形添加新边界
        /// </summary>
        /// <param name="pol"></param>
        public void Add(Polygon pol)
        {
            edgeCollection.Push(pol);
        }

        /// <summary>
        /// 删除最近添加的边界
        /// </summary>
        /// <returns></returns>
        public Polygon Pop()
        {
            return edgeCollection.Pop();
        }

        /// <summary>
        /// 返回最近编辑的边界
        /// </summary>
        /// <returns></returns>
        public Polygon Peek()
        {
            return edgeCollection.Peek();
        }

        /// <summary>
        /// 填充复杂多边形
        /// </summary>
        /// <param name="e">绘图事件</param>
        public void drawMyself(PaintEventArgs e)
        {
            if (edgeCollection.Count() == 0)
                return;
            else
                foreach (Polygon pol in edgeCollection)
                    pol.drawMyself(e);            
        }

        /// <summary>
        /// 填充复杂多边形，追踪当前鼠标位置
        /// </summary>
        /// <param name="e">绘图事件</param>
        /// <param name="cursor">鼠标位置</param>
        public void drawMyself(PaintEventArgs e, Point cursor)
        {
            switch (edgeCollection.Count())
            {
                case 0:
                    break;
                case 1:
                    edgeCollection.Pop().drawMyself(e, cursor);
                    break;
                default:
                    Polygon polEditoring = edgeCollection.Pop();
                    foreach (Polygon pol in edgeCollection)
                        pol.drawMyself(e);
                    polEditoring.drawMyself(e, cursor);
                    break;
            }
        }

        /// <summary>
        /// 绘制复杂多边形边界和顶点
        /// </summary>
        /// <param name="e">绘图事件</param>
        public void fillMyself(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Aquamarine, 1);
            int allYMin = 100000;//y 的最小值，肯定比
            //创建并维护 EdgeTable 表
            //EdgeTable 用 SQL 语句来描述就是
            // select * from 边全集 group by ymin;
            int i;

            Dictionary<int, List<Edge>> EdgeTable = new Dictionary<int, List<Edge>> { };// 下端点 y 坐标相同的边序列的序列
            foreach (Polygon pol in edgeCollection)
            {
                List<Point> poiList = new List<Point>();
                poiList.AddRange(pol.poiList);


                int num = poiList.Count();
                if (num <= 2)
                    continue;

                poiList.Add(poiList[0]);
                for (i = 1; i <= num; i++)
                {
                    Edge tempEdge = new Edge();
                    if (poiList[i].Y < allYMin)
                        allYMin = poiList[i].Y;
                    if (poiList[i].Y != poiList[i - 1].Y)
                    {
                        if (poiList[i].Y < poiList[i - 1].Y)
                        {
                            tempEdge.ymax = poiList[i - 1].Y;
                            tempEdge.ymin = poiList[i].Y;
                            tempEdge.x = poiList[i].X;
                            tempEdge.deltax = 1.0 * (poiList[i - 1].X - poiList[i].X) / (poiList[i - 1].Y - poiList[i].Y);
                        }
                        else
                        {
                            tempEdge.ymin = poiList[i - 1].Y;
                            tempEdge.ymax = poiList[i].Y;
                            tempEdge.x = poiList[i - 1].X;
                            tempEdge.deltax = 1.0 * (poiList[i].X - poiList[i - 1].X) / (poiList[i].Y - poiList[i - 1].Y);
                        }
                        if (EdgeTable.ContainsKey(tempEdge.ymin))
                        {
                            List<Edge> edgelist = EdgeTable[tempEdge.ymin];
                            edgelist.Add(tempEdge);
                            EdgeTable[tempEdge.ymin] = edgelist;
                        }
                        else
                        {
                            List<Edge> edgelist = new List<Edge>();
                            edgelist.Add(tempEdge);
                            EdgeTable[tempEdge.ymin] = edgelist;
                        }
                    }
                }
                poiList.RemoveAt(num);
            }


            //EdgeTable 维护完以后开始进入算法

            //边的活化链表集合为空
            List<Edge> availiableList = new List<Edge>();
            //去扫描线纵坐标的初始值为 ET 中非空集合的最小序号
            i = allYMin;
            do
            {
                //若边分类表钟的第 i 类元素不为空
                //则将属于该类的所有边从 ET 中取出
                //并插入活化链表中 AEL
                if (EdgeTable.ContainsKey(i))
                {
                    foreach (Edge temper in EdgeTable[i])
                        availiableList.Add(temper);
                    EdgeTable.Remove(i);
                }
                //若当前活化链表不为空
                if (availiableList.Count() != 0)
                {
                    //AEL 中各边按照 x 值升序排列
                    //x 相同时按照 deltax 升序排列
                    availiableList = availiableList.OrderBy(availiableLists => availiableLists.x).ThenBy(availiableLists => availiableLists.deltax).ToList();
                   
                    //将 AEL 中的边两两依次配对
                    //每队边与当前扫描线的交点构成的区域位于多边形内
                    //用边长为 1 的画笔画线
                    for (int j = 1; j < availiableList.Count(); j = j + 2)
                        g.DrawLine(pen, (float)availiableList[j - 1].x, i, (float)availiableList[j].x, i);

                    //将边的活化链表中满足 ymax = i + 1 的边删去
                    //如果是将边的活化链表中满足 ymax = i 的边删去
                    //按照这个顺序来的话会在非极值点的地方出现一条空白的线
                    //如果非要删除 ymax = i，应该将此模块移动到绘制模块，也就是上一块的前边
                    for (int j = availiableList.Count() - 1; j >= 0; j--)
                        if (availiableList[j].ymax == i + 1)
                            availiableList.RemoveAt(j);

                    for (int j = 0; j < availiableList.Count(); j++)
                        availiableList[j].x += availiableList[j].deltax;
                }
                i++;
            } while (EdgeTable.Count() != 0 || availiableList.Count() != 0);
        }

        /// <summary>
        /// 绘制复杂多边形边界和顶点，追踪鼠标位置
        /// </summary>
        /// <param name="e">绘图事件</param>
        /// <param name="Cursor">鼠标位置</param>
        public void fillMyself(PaintEventArgs e, Point Cursor)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Aquamarine, 1);
            int allYMin = 100000;//y 的最小值，肯定比
            //创建并维护 EdgeTable 表
            //EdgeTable 用 SQL 语句来描述就是
            // select * from 边全集 group by ymin;
            int i;
            Dictionary<int, List<Edge>> EdgeTable = new Dictionary<int, List<Edge>> { };// 下端点 y 坐标相同的边序列的序列
            foreach (Polygon pol in edgeCollection)
            {
                List<Point> poiList = new List<Point>();
                poiList.AddRange(pol.poiList);
                if (pol == edgeCollection.First())
                    poiList.Add(Cursor);

                int num = poiList.Count();
                if (num <= 2)
                    continue;

                poiList.Add(poiList[0]);
                for (i = 1; i <= num; i++)
                {
                    Edge tempEdge = new Edge();
                    if (poiList[i].Y < allYMin)
                        allYMin = poiList[i].Y;
                    if (poiList[i].Y != poiList[i - 1].Y)
                    {
                        if (poiList[i].Y < poiList[i - 1].Y)
                        {
                            tempEdge.ymax = poiList[i - 1].Y;
                            tempEdge.ymin = poiList[i].Y;
                            tempEdge.x = poiList[i].X;
                            tempEdge.deltax = 1.0 * (poiList[i - 1].X - poiList[i].X) / (poiList[i - 1].Y - poiList[i].Y);
                        }
                        else
                        {
                            tempEdge.ymin = poiList[i - 1].Y;
                            tempEdge.ymax = poiList[i].Y;
                            tempEdge.x = poiList[i - 1].X;
                            tempEdge.deltax = 1.0 * (poiList[i].X - poiList[i - 1].X) / (poiList[i].Y - poiList[i - 1].Y);
                        }
                        if (EdgeTable.ContainsKey(tempEdge.ymin))
                        {
                            List<Edge> edgelist = EdgeTable[tempEdge.ymin];
                            edgelist.Add(tempEdge);
                            EdgeTable[tempEdge.ymin] = edgelist;
                        }
                        else
                        {
                            List<Edge> edgelist = new List<Edge>();
                            edgelist.Add(tempEdge);
                            EdgeTable[tempEdge.ymin] = edgelist;
                        }
                    }
                }
                poiList.RemoveAt(num);
            }


            //EdgeTable 维护完以后开始进入算法

            //边的活化链表集合为空
            List<Edge> availiableList = new List<Edge>();
            //去扫描线纵坐标的初始值为 ET 中非空集合的最小序号
            i = allYMin;
            do
            {
                //若边分类表钟的第 i 类元素不为空
                //则将属于该类的所有边从 ET 中取出
                //并插入活化链表中 AEL
                if (EdgeTable.ContainsKey(i))
                {
                    foreach (Edge temper in EdgeTable[i])
                        availiableList.Add(temper);
                    EdgeTable.Remove(i);
                }
                //若当前活化链表不为空
                if (availiableList.Count() != 0)
                {
                    //AEL 中各边按照 x 值升序排列
                    //x 相同时按照 deltax 升序排列
                    availiableList = availiableList.OrderBy(availiableLists => availiableLists.x).ThenBy(availiableLists => availiableLists.deltax).ToList();

                    //将 AEL 中的边两两依次配对
                    //每队边与当前扫描线的交点构成的区域位于多边形内
                    //用边长为 1 的画笔画线
                    for (int j = 1; j < availiableList.Count(); j = j + 2)
                        g.DrawLine(pen, (float)availiableList[j - 1].x, i, (float)availiableList[j].x, i);

                    //将边的活化链表中满足 ymax = i + 1 的边删去
                    //如果是将边的活化链表中满足 ymax = i 的边删去
                    //按照这个顺序来的话会在非极值点的地方出现一条空白的线
                    //如果非要删除 ymax = i，应该将此模块移动到绘制模块，也就是上一块的前边
                    for (int j = availiableList.Count() - 1; j >= 0; j--)
                        if (availiableList[j].ymax == i + 1)
                            availiableList.RemoveAt(j);

                    for (int j = 0; j < availiableList.Count(); j++)
                        availiableList[j].x += availiableList[j].deltax;
                }
                i++;
            } while (EdgeTable.Count() != 0 || availiableList.Count() != 0);
        }

        /// <summary>
        /// 判断给定点是否在当前多边形的顶点的引力场内
        /// 返回捕获传入点的点的坐标（没有被捕获则返回 (-1, -1)）
        /// </summary>
        /// <param name="location">待捕获的点</param>
        /// <returns>返回捕获传入点的点的坐标（没有被捕获则返回 (-1, -1)）</returns>
        public Point catchPoint(Point location)
        {
            if(edgeCollection.Count() == 0)
                return new Point(-1, -1);
            foreach (Polygon pol in edgeCollection)
                if (pol.catchPoint(location) != new Point(-1,-1))
                    return pol.catchPoint(location);
            return new Point(-1, -1);
        }
    }
}
