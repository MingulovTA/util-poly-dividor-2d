using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PolyDividor
{
    class Field
    {
        private const int Scale = 40;
        private static PictureBox _cPictureBox;
        private static Graphics _cGraphics;
        private static Random _random = new Random();

        private static Pen _blackPen = new Pen(Color.Black);
        private static Pen _redPen = new Pen(Color.FromArgb(255,200,0,0));
        private static Pen _randomPen = new Pen(Color.Black);
        private static SolidBrush _randomBrush = new SolidBrush(Color.Black);

        private static SolidBrush _blackBrush = new SolidBrush(Color.Black);
        private static SolidBrush _whiteBrush = new SolidBrush(Color.White);

        

        public static void Init(PictureBox cPictureBox)
        {
            _random.Next();
            _random.NextDouble();
            _cPictureBox = cPictureBox;
            cPictureBox.Image = new Bitmap(400,400);            
        }

        public static void ShowWireframe(List<Triangle> triangles)
        {
            ShowField();
            _cGraphics = Graphics.FromImage(_cPictureBox.Image);
            foreach (var tri in triangles)
            {
                List<Point> points = new List<Point>();
                tri.Points.ForEach(p => points.Add(new Point(ToWorldCoord(p.X), ToWorldCoord(-p.Y))));
                _cGraphics.DrawPolygon(_redPen, points.ToArray());
                tri.Points.ForEach(p => _cGraphics.FillRectangle(_blackBrush, new Rectangle(ToWorldCoord(p.X) - 3, ToWorldCoord(-p.Y) - 3, 6, 6)));
            }
            _cPictureBox.Refresh();  //Обновление компонента вывода изображения
            _cGraphics.Dispose();    //Разрушение созданной поверхности рисования
        }

        public static void ShowPolygon(List<Triangle> triangles)
        {
            ShowField();
            
            foreach (var tri in triangles)
            {
                _cGraphics = Graphics.FromImage(_cPictureBox.Image);
                //Random r = new Random();
                //r.Next();
                Color randomColor = Color.FromArgb(255, _random.Next(0, 255), _random.Next(0, 255),_random.Next(0, 255));

                _randomBrush = new SolidBrush(randomColor);
                List<Point> points = new List<Point>();
                tri.Points.ForEach(p => points.Add(new Point(ToWorldCoord(p.X), ToWorldCoord(-p.Y))));
                _cGraphics.FillPolygon(_randomBrush, points.ToArray());
                _cGraphics.DrawPolygon(_blackPen, points.ToArray());
                tri.Points.ForEach(p => _cGraphics.FillRectangle(_blackBrush, new Rectangle(ToWorldCoord(p.X) - 3, ToWorldCoord(-p.Y) - 3, 6, 6)));
                _cPictureBox.Refresh();  //Обновление компонента вывода изображения
                _cGraphics.Dispose();    //Разрушение созданной поверхности рисования
            }

        }

        private static int ToWorldCoord(float f)
        {
            return (int)(f * Scale + 200);
        }

        private static void ShowField()
        {
            _cGraphics = Graphics.FromImage(_cPictureBox.Image);
            _cGraphics.FillRectangle(_whiteBrush, new Rectangle(0, 0, 399, 399));
            _cGraphics.DrawRectangle(_blackPen, new Rectangle(0, 0, 399, 399));

            for (int i = 0; i < 20; i++)
            {
                _cGraphics.DrawLine(_blackPen, new Point(i * Scale, 0), new Point(i * Scale, 400));
                _cGraphics.DrawLine(_blackPen, new Point(0, i * Scale), new Point(400, i * Scale));
            }
            _cGraphics.DrawLine(_blackPen, new Point(201, 0), new Point(201, 400));
            _cGraphics.DrawLine(_blackPen, new Point(0, 201), new Point(400, 201));
            _cGraphics.DrawString("(0,0)",SystemFonts.DefaultFont,_blackBrush,new Point(205,205));

            _cPictureBox.Refresh();  //Обновление компонента вывода изображения
            _cGraphics.Dispose();    //Разрушение созданной поверхности рисования
        }
    }
}
