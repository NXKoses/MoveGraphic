namespace MoveGraphic.Objects
{
    internal class CursorMoveObject : ObjectBase
    {
        bool isupdown = false;
        Pen Pen = new(Color.Red, 2);

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            if (isupdown)
            {
                e.Graphics.DrawLine(Pen, X, Y, X2, Y2);
            }
        }

        public void IsUpDown(bool updown)
        {
            isupdown = updown;
        }
    }
}
