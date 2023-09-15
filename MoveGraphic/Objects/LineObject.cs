namespace MoveGraphic.Objects
{
    internal class LineObject : ObjectBase
    {
        public LineObject(int x, int y, int x2, int y2)
        {
            X = x; Y = y;
            X2 = x2; Y2 = y2;
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, GetDrawX(), GetDrawY(), GetDrawX2(), GetDrawY2());
        }
    }
}
