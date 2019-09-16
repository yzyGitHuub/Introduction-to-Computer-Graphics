/*****************************
* Yao,Zhaoyuan 创建于 2018/11/10
* 上一次修改时间：2018/11/13
* GitHub:https://github.com/yzyGitHuub/
* 保留所有权利
* **************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectionAndRotation
{
    /// <summary>
    /// 自定义三维点类
    /// </summary>
    partial class MyPoint
    {
        public bool visible = true;
        public float X, Y, Z;
        public MyPoint(float _x, float _y, float _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }
        public PointF projectionParallel(MyPoint direction)
        {
            return new PointF(X - Z * direction.X / direction.Z, Y - Z * direction.Y / direction.Z);
        }
        public PointF projectionPerspective(MyPoint viewPoint)
        {
            return new PointF(viewPoint.X + (X - viewPoint.X) * viewPoint.Z / (viewPoint.Z - Z), viewPoint.Y + (Y - viewPoint.Y) * viewPoint.Z / (viewPoint.Z - Z));
        }
    }

    /// <summary>
    /// 自定义三维线段类
    /// 面向绘制的线段类别
    /// </summary>
    partial class MyLine3D
    {
        public MyPoint fromNode;
        public MyPoint toNode;
        public bool isParallel = true;
        public MyLine3D(MyPoint from, MyPoint to,bool ispa)
        {
            fromNode = from;
            toNode = to;
            isParallel = ispa;
        }
        public MyLine3D(float x1, float y1,float z1, float x2, float y2,float z2,bool ispa)
        {
            fromNode = new MyPoint(x1, y1,z1);
            toNode = new MyPoint(x2, y2,z2);
            isParallel = ispa;
        }

        public MyLine2D projectMyself(MyPoint viewPoint)
        {
            if (isParallel && viewPoint.Z == 0)
                return new MyLine2D(0, 0, 0, 0);
            if(fromNode.visible && toNode.visible)
            {
                if (isParallel)
                    return new MyLine2D(fromNode.projectionParallel(viewPoint), toNode.projectionParallel(viewPoint));
                else
                    return new MyLine2D(fromNode.projectionPerspective(viewPoint), toNode.projectionPerspective(viewPoint));
            }
            //之后的都是透视投影
            else if(fromNode.visible)
            {
                PointF from = fromNode.projectionPerspective(viewPoint);
                float delta = (viewPoint.Z - fromNode.Z) / 2 / (toNode.Z - fromNode.Z);
                PointF newDirection = new MyPoint(fromNode.X + (toNode.X - fromNode.X) * delta, fromNode.Y + (toNode.Y - fromNode.Y) * delta, fromNode.Z + (toNode.Z - fromNode.Z) * delta).projectionPerspective(viewPoint);
                return new MyLine2D(from, getEnd(from,newDirection,5000),false);
            }
            else if (toNode.visible)
            {
                PointF from = toNode.projectionPerspective(viewPoint);
                float delta = (viewPoint.Z - toNode.Z) / 2 / (fromNode.Z - toNode.Z);
                PointF newDirection = new MyPoint(toNode.X + (fromNode.X - toNode.X) * delta, toNode.Y + (fromNode.Y - toNode.Y) * delta, toNode.Z + (fromNode.Z - toNode.Z) * delta).projectionPerspective(viewPoint);
                return new MyLine2D(from, getEnd(from, newDirection, 5000), false);
            }
            else
                return new MyLine2D(0, 0, 0, 0);
        }
        private PointF getEnd(PointF from, PointF direction, double distance)
        {
            double len = Math.Sqrt((from.X - direction.X) * (from.X - direction.X) + (from.Y - direction.Y) * (from.Y - direction.Y));
            return new PointF((float)(from.X + distance * (direction.X - from.X) / len), (float)(from.Y + distance * (direction.Y - from.Y) / len));
        }

    }

    /// <summary>
    /// 自定义二维线段，主要是为了渲染样式
    /// </summary>
    partial class MyLine2D
    {
        public PointF fromNode;
        public PointF toNode;
        public bool fullVisible;
        public MyLine2D(PointF from, PointF to, bool full = true)
        {
            fromNode = from;
            toNode = to;
            fullVisible = full;
        }
        public MyLine2D(float x1, float y1, float x2, float y2, bool full = true)
        {
            fromNode = new PointF(x1, y1);
            toNode = new PointF(x2, y2);
            fullVisible = full;
        }

        /// <summary>
        /// 从真实坐标系下转移到屏幕坐标系
        /// </summary>
        /// <param name="g"></param>
        /// <param name="color"></param>
        /// <param name="visible"></param>
        /// <param name="xdelta"></param>
        /// <param name="ydelta"></param>
        public void paintMyself(Graphics g, Color color, int xdelta,int ydelta)
        {
            Pen pen = new Pen(color, 1);
            if (fullVisible)
            {
                //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                g.DrawLine(pen, fromNode.X + xdelta, ydelta - fromNode.Y, toNode.X + xdelta, ydelta - toNode.Y);
            }
            else
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                pen.DashPattern = new float[] { 4, 3 };
                g.DrawLine(pen, fromNode.X + xdelta, ydelta - fromNode.Y, toNode.X + xdelta, ydelta - toNode.Y);
            }
        }
    }


    /// <summary>
    /// 自定义多面体类
    /// </summary>
    partial class MyPolyhedron
    {
        public List<MyLine3D> inList;
        public List<MyLine2D> showList;
        public bool isParallel;
        const float a = (float)0.001;
        MyPoint viewPoint;

        public MyPolyhedron(List<MyLine3D> lineList, bool showStyle, MyPoint station)
        {
            if (lineList.Count() > 5)
            {
                isParallel = showStyle;
                inList = lineList;
                for (int i = 0; i < lineList.Count(); i++)
                    inList[i].isParallel = isParallel;
                viewPoint = station;
                projectMyself();
            }
            else
                throw (new Exception("多面体应该至少有六个边，但是传输了 " + lineList.Count() + " 个;"));
        }

        /// <summary>
        /// 投影立方体
        /// </summary>
        public void projectMyself()
        {
            int count = inList.Count();
            if (isParallel)
                for (int i = 0; i < count; i++)
                {
                    inList[i].toNode.visible = true;
                    inList[i].fromNode.visible = true;
                }
            else
                for (int i = 0; i < count; i++)
                {
                    inList[i].toNode.visible = isMiddle(viewPoint.Z, inList[i].toNode.Z);
                    inList[i].fromNode.visible = isMiddle(viewPoint.Z, inList[i].fromNode.Z);
                }
            showList = new List<MyLine2D> { };
            foreach (MyLine3D line in inList)
            {
                MyLine2D newline = line.projectMyself(viewPoint);
                showList.Add(newline);
            }
        }
        private bool isMiddle(float station, float poi)
        {
            if (station >= 0 && station > poi)
                return true;
            else if (station < 0 && station < poi)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 绘制投影后的图像
        /// </summary>
        /// <param name="g">绘图事件</param>
        /// <param name="color">颜色</param>
        /// <param name="viewPoint">视点坐标</param>
        public void paintMyself(Graphics g, Color color, int xdelta,int ydelta)
        {
            int count = inList.Count();
            if (count <= 1)
                return;
            //这里画立方体真的是一塌糊涂
            //得好好改改
            //注意！！！！
            //这里的y坐标为了和我们正常的看起来一样必须取个负号
            //遍历十二条线
            foreach (MyLine2D line in showList)
                line.paintMyself(g, color, xdelta, ydelta);

        }
        
        /// <summary>
        /// 旋转立方体
        /// </summary>
        public void rollMyself(float maxism)
        {
            float alpha = a * maxism;
            int num = inList.Count();
            MyPoint p;
            for(int i = 0; i < num; i++)
            {
                p = inList[i].fromNode;
                p = new MyPoint(p.X * (float)Math.Cos(alpha) - p.Y * (float)Math.Sin(alpha), p.X * (float)Math.Sin(alpha) + p.Y * (float)Math.Cos(alpha), p.Z);
                inList[i].fromNode = p;
                p = inList[i].toNode;
                p = new MyPoint(p.X * (float)Math.Cos(alpha) - p.Y * (float)Math.Sin(alpha), p.X * (float)Math.Sin(alpha) + p.Y * (float)Math.Cos(alpha), p.Z);
                inList[i].toNode = p;
            }
            projectMyself();
        }

        public PointF projectionParallel(MyPoint poi)
        {
            return new PointF(poi.X - poi.Z * viewPoint.X / viewPoint.Z, poi.Y - poi.Z * viewPoint.Y / viewPoint.Z);
        }
        public PointF projectionPerspective(MyPoint poi)
        {
            return new PointF(viewPoint.X + (poi.X - viewPoint.X) * viewPoint.Z / (viewPoint.Z - poi.Z), viewPoint.Y + (poi.Y - viewPoint.Y) * viewPoint.Z / (viewPoint.Z - poi.Z));
        }

    }


}
