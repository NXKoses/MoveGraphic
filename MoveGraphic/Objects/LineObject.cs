using System.Net;

namespace MoveGraphic.Objects
{
    internal class LineObject : ObjectBase
    {
        public LineObject(Point startPoint, Point endPoint)
        {
            InternalStartPoint = startPoint;
            InternalEndPoint = endPoint;
            DisplayStartPoint = startPoint;
            DisplayEndPoint = endPoint;
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            // 描画座標を使用して直線を描画
            //e.Graphics.ScaleTransform(Program.DisplayScale, Program.DisplayScale);
            e.Graphics.DrawLine(Pens.Black, new Point(DisplayStartPoint.X, DisplayStartPoint.Y), new Point(DisplayEndPoint.X, DisplayEndPoint.Y));
        }
    }
}
