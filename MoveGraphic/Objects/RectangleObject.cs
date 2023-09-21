namespace MoveGraphic.Objects
{
    internal class RectangleObject : ObjectBase
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public RectangleObject(Point startPoint, Point endPoint, int width, int height)
        {
            InternalStartPoint = startPoint;
            InternalEndPoint = endPoint;
            DisplayStartPoint = startPoint;
            DisplayEndPoint = endPoint;

            Width = width; Height = height;
            Brush = new SolidBrush(Color.Gray);
        }


        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brush, DisplayStartPoint.X, DisplayStartPoint.Y, Width, Height);
        }
    }
}
