using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PolyDividor
{
    public partial class Main : Form
    {
        private List<Triangle> _triangles = new List<Triangle>();
        public Main()
        {
            InitializeComponent();
            Field.Init(PB_Space);
        }
        
        private void B_ShowWire_Click(object sender, EventArgs e)
        {
            Field.ShowWireframe(_triangles);
        }

        private void B_GenNewTriangle_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Triangle t = new Triangle();
            t.Points.Add(new PointF(GetRandom(r), GetRandom(r)));
            t.Points.Add(new PointF(GetRandom(r), GetRandom(r)));
            t.Points.Add(new PointF(GetRandom(r), GetRandom(r)));
            _triangles.Add(t);
        }

        private float GetRandom(Random r)
        {            
            r.Next();
            return (float)(r.Next(0, 9) - 5 + r.NextDouble());
        }

        private float GetRandom(Random r, int min, int max)
        {
            r.Next();
            return (float)(r.Next(min, max) + r.NextDouble());
        }

        private void B_ShowPoly_Click(object sender, EventArgs e)
        {
            Field.ShowPolygon(_triangles);
        }

        private void B_AddGoodTriangle_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Triangle t = new Triangle();
            t.Points.Add(new PointF(GetRandom(r, -3, 0), GetRandom(r, -3, 0)));
            t.Points.Add(new PointF(GetRandom(r, -3, 0), GetRandom(r, 0, 3)));
            t.Points.Add(new PointF(GetRandom(r, 0, 3), GetRandom(r, 0, 3)));
            
            _triangles.Add(t);

            foreach (var pts in _triangles.Last().Points)
                AddLog("pts.X = " + pts.X + ",pts.Y = " + pts.Y);
        }

        private void AddLog(string s)
        {
            List<string> log = Log.Lines.ToList();
            log.Add(s);
            Log.Lines = log.ToArray();
        }

        private void B_Divide_Click(object sender, EventArgs e)
        {
            PolygonCount.Text = _triangles.Count.ToString();
            DivideVertical();
            DivideHorisontal();
            Triangulate();
            Field.ShowPolygon(_triangles);
        }

        private List<Edge> GenerateEdges(Triangle t)
        {
            List<Edge> edges = new List<Edge>();
            foreach (var p in t.Points)
                edges.Add(new Edge(new PointF(p.X, p.Y), new PointF(0,0)));

            for (int i = 1; i < t.Points.Count; i++)
            {
                edges[i - 1].P2.X = t.Points[i].X;
                edges[i - 1].P2.Y = t.Points[i].Y;
            }

            edges.Last().P2.X = t.Points.First().X;
            edges.Last().P2.Y = t.Points.First().Y;
            return edges;
        }

        private Edge FindFirstDividedEdge(List<Edge> edges, bool horisontal = true)
        {
            if (horisontal)
            {
                foreach (var e in edges)
                    if (GetIntsBetween(e.P1.X, e.P2.X).Count > 0)
                        return e;
            }
            else
            {
                foreach (var e in edges)
                    if (GetIntsBetween(e.P1.Y, e.P2.Y).Count > 0)
                        return e;
            }
            return null;
        }

        private Edge FindSecondDividedEdge(List<Edge> edges, Edge firstDividedEdge, bool horisontal = true)
        {
            if (horisontal)
            {
                List<int> xCrosses = GetIntsBetween(firstDividedEdge.P1.X, firstDividedEdge.P2.X);
                foreach (var e in edges)
                {
                    if (e == firstDividedEdge) continue;
                    foreach (var i in GetIntsBetween(e.P1.X, e.P2.X))
                        if (xCrosses.Contains(i)) return e;
                }
            }
            else
            {
                List<int> yCrosses = GetIntsBetween(firstDividedEdge.P1.Y, firstDividedEdge.P2.Y);
                foreach (var e in edges)
                {
                    if (e == firstDividedEdge) continue;
                    foreach (var i in GetIntsBetween(e.P1.Y, e.P2.Y))
                        if (yCrosses.Contains(i)) return e;
                }
            }
            return null;
        }

        private List<PointF> GetLeftCrossPoints(Triangle t, Edge crossEdge)
        {
            List<PointF> leftPoints = new List<PointF>();
            foreach (var p in t.Points)
                if (p.X < crossEdge.P1.X) leftPoints.Add(new PointF(p.X, p.Y));
            return leftPoints;
        }

        private List<PointF> GetRightCrossPoints(Triangle t, Edge crossEdge)
        {
            List<PointF> rightPoints = new List<PointF>();
            foreach (var p in t.Points)
                if (p.X > crossEdge.P1.X) rightPoints.Add(new PointF(p.X, p.Y));
            return rightPoints;
        }

        private List<PointF> GetUpperCrossPoints(Triangle t, Edge crossEdge)
        {
            List<PointF> upperPoints = new List<PointF>();
            foreach (var p in t.Points)
                if (p.Y > crossEdge.P1.Y) upperPoints.Add(new PointF(p.X, p.Y));
            return upperPoints;
        }

        private List<PointF> GetLowerCrossPoints(Triangle t, Edge crossEdge)
        {
            List<PointF> lowerPoints = new List<PointF>();
            foreach (var p in t.Points)
                if (p.Y < crossEdge.P1.Y) lowerPoints.Add(new PointF(p.X, p.Y));
            return lowerPoints;
        }

        private Edge GetCrossEdge(Edge edge1, Edge edge2, bool horisontal = true)
        {
            if (horisontal)
            {
                List<int> xCrosses1 = GetIntsBetween(edge1.P1.X, edge1.P2.X);
                List<int> xCrosses2 = GetIntsBetween(edge2.P1.X, edge2.P2.X);
                float k1 = (edge1.P1.Y - edge1.P2.Y) / (edge1.P1.X - edge1.P2.X);
                float b1 = edge1.P1.Y - k1 * edge1.P1.X;
                float k2 = (edge2.P1.Y - edge2.P2.Y) / (edge2.P1.X - edge2.P2.X);
                float b2 = edge2.P1.Y - k2 * edge2.P1.X;
                foreach (var xCross1 in xCrosses1)
                    foreach (var xCross2 in xCrosses2)
                        if (xCross1 == xCross2)
                            return new Edge(new PointF(xCross1, k1 * xCross1 + b1), new PointF(xCross1, k2 * xCross1 + b2));
            }
            else
            {
                List<int> yCrosses1 = GetIntsBetween(edge1.P1.Y, edge1.P2.Y);
                List<int> yCrosses2 = GetIntsBetween(edge2.P1.Y, edge2.P2.Y);
                float k1 = (edge1.P1.Y - edge1.P2.Y) / (edge1.P1.X - edge1.P2.X);
                float b1 = edge1.P1.Y - k1 * edge1.P1.X;
                float k2 = (edge2.P1.Y - edge2.P2.Y) / (edge2.P1.X - edge2.P2.X);
                float b2 = edge2.P1.Y - k2 * edge2.P1.X;
                foreach (var yCross1 in yCrosses1)
                    foreach (var yCross2 in yCrosses2)
                        if (yCross1 == yCross2)
                            return new Edge(new PointF((yCross1 - b1) / k1, yCross1), new PointF((yCross1 - b2) / k2, yCross1));
            }

            return null;

        }

        private void DivideHorisontal()
        {            
            int pCount = 0;
            while (pCount != _triangles.Count)
            {
                pCount = _triangles.Count;
                int i = 0;
                while (i < _triangles.Count)
                {
                    var t = _triangles[i];

                    List<Edge> edges = GenerateEdges(t);

                    Edge firstDividedEdge = FindFirstDividedEdge(edges);
                    if (firstDividedEdge == null)
                    {
                        i++;
                        continue;
                    }

                    Edge secondDividedEdge = FindSecondDividedEdge(edges, firstDividedEdge);
                    if (secondDividedEdge == null)
                    {
                        i++;
                        continue;
                    }
                    Edge crossEdge = GetCrossEdge(firstDividedEdge, secondDividedEdge);

                    List<PointF> leftPoints = GetLeftCrossPoints(t, crossEdge);
                    List<PointF> rightPoints = GetRightCrossPoints(t, crossEdge);

                    leftPoints.Add(new PointF(crossEdge.P2.X, crossEdge.P2.Y));
                    leftPoints.Add(new PointF(crossEdge.P1.X, crossEdge.P1.Y));
                    rightPoints.Add(new PointF(crossEdge.P2.X, crossEdge.P2.Y));
                    rightPoints.Add(new PointF(crossEdge.P1.X, crossEdge.P1.Y));

                    Triangle cross = new Triangle();
                    cross.Points = RadialSort(leftPoints);
                    _triangles.Add(cross);

                    cross = new Triangle();
                    cross.Points = RadialSort(rightPoints);
                    _triangles.Add(cross);

                    _triangles.Remove(t);
                    continue;
                }
            }
        }

        private void DivideVertical()
        {            
            int pCount = 0;
            while (pCount != _triangles.Count)
            {
                pCount = _triangles.Count;
                int i = 0;
                while (i < _triangles.Count)
                {
                    var t = _triangles[i];

                    List<Edge> edges = GenerateEdges(t);

                    Edge firstDividedEdge = FindFirstDividedEdge(edges, false);
                    if (firstDividedEdge == null)
                    {
                        i++;
                        continue;
                    }

                    Edge secondDividedEdge = FindSecondDividedEdge(edges, firstDividedEdge, false);
                    if (secondDividedEdge == null)
                    {
                        i++;
                        continue;
                    }
                    Edge crossEdge = GetCrossEdge(firstDividedEdge, secondDividedEdge, false);

                    List<PointF> upperPoints = GetUpperCrossPoints(t, crossEdge);
                    List<PointF> lowerPoints = GetLowerCrossPoints(t, crossEdge);

                    upperPoints.Add(new PointF(crossEdge.P2.X, crossEdge.P2.Y));
                    upperPoints.Add(new PointF(crossEdge.P1.X, crossEdge.P1.Y));
                    lowerPoints.Add(new PointF(crossEdge.P2.X, crossEdge.P2.Y));
                    lowerPoints.Add(new PointF(crossEdge.P1.X, crossEdge.P1.Y));

                    Triangle cross = new Triangle();
                    cross.Points = RadialSort(upperPoints);
                    _triangles.Add(cross);

                    cross = new Triangle();
                    cross.Points = RadialSort(lowerPoints);
                    _triangles.Add(cross);

                    _triangles.Remove(t);
                    continue;
                }
            }            
        }

        private List<PointF> RadialSort(List<PointF> points)
        {
            points = points.OrderBy(p => p.X).ToList();
            return points.Take(1).Union(points.Skip(1).OrderBy(dot => 
            {
                double a = Math.Atan2(dot.X - points[0].X, dot.Y - points[0].Y);
                if (a < 0) a += 360;
                return a;
            })).ToList();

        }

        private List<int> GetIntsBetween(float f1, float f2)
        {
            List<int> ints = new List<int>();
            float min;
            float max;

            if (f1 > f2)
            {
                min = f2;
                max = f1;
            }
            else
            {
                min = f1;
                max = f2;
            }
            int minInt = Convert.ToInt32(Math.Ceiling(min));
            for (int i = minInt; i <= Math.Floor(max); i++)
                ints.Add(i);

            List<int> intsForRemove = new List<int>();
            float tolerance = 0.001f;
            foreach (var i in ints)
                if (Math.Abs(f1 - i) < tolerance || Math.Abs(f2 - i) < tolerance)
                    intsForRemove.Add(i);
            foreach (var i in intsForRemove)
                ints.Remove(i);

                return ints;
        }

        private void Triangulate() 
        {
            int pCount = 0;
            while (pCount != _triangles.Count)
            {
                pCount = _triangles.Count;
                int i = 0;

                while (i < _triangles.Count)
                {
                    Triangle t = _triangles[i];
                    if (t.Points.Count > 3)
                        SubDividePolygon(t);
                    i++;
                }            
            }

        }

        private void SubDividePolygon(Triangle t)
        {
            List<PointF> points = RadialSort(t.Points);
            for (int i = 2; i <= points.Count; i++)
            {
                Triangle newT = new Triangle();
                newT.Points = new List<PointF>();
                newT.Points.Add(new PointF(points[i - 2].X, points[i - 2].Y));
                newT.Points.Add(new PointF(points[i - 1].X, points[i - 1].Y));
                newT.Points.Add(new PointF(points[0].X, points[0].Y));
                _triangles.Add(newT);
            }
            _triangles.Remove(t);            
        }

        private void PullPolygonsToCenter()
        {
            foreach (var t in _triangles) 
            {
                int i = 0;
                while (i < t.Points.Count)
                {
                    var p = t.Points[i];
                    p = new PointF(p.X, p.Y);
                    i++;
                }

                int minX = 15478;
                int minY = 15478;
                foreach (var p in t.Points)
                {
                    if (p.X < minX) 
                        minX = (int)Math.Floor(p.X);
                    if (p.Y < minY) 
                        minY = (int)Math.Floor(p.Y);
                }
                foreach (var p in t.Points)
                {
                    p.X = p.X - minX;
                    p.Y = p.Y - minY;
                }
                
            }
        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            _triangles.Clear();
        }             

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            PolygonCount.Text = _triangles.Count.ToString();
            DivideVertical();
            DivideHorisontal();
            Triangulate();
            Field.ShowPolygon(_triangles);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            //PullPolygonsToCenter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PullPolygonsToCenter();
        }

    }
}
