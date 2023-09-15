namespace MoveGraphic.Objects
{
    internal class CursorLineObject : ObjectBase
    {
        private bool isupdown = false;
        private Pen Pen = new(Color.FromArgb(50, Color.Red), 2);

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            //ドラッグしている時だけ
            if (isupdown)
            {
                e.Graphics.DrawLine(Pen, X, Y, X2, Y2);
            }
        }

        /// <summary>
        /// クリックした時の座標を設定します
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DownXY(int x_down, int y_down)
        {
            X = X2 = x_down;
            Y = Y2 = y_down;
        }

        /// <summary>
        /// ドラッグしてクリックした時との差分を設定します。
        /// </summary>
        /// <param name="x_now"></param>
        /// <param name="y_now"></param>
        /// <returns>移動した分の座標</returns>
        public Point DragXY(int x_now, int y_now)
        {
            X2 = x_now;
            Y2 = y_now;

            //移動した距離を求めて返す
            return new Point(x_now - X, y_now - Y);
        }

        public void IsUpDown(bool updown)
        {
            isupdown = updown;
        }
    }
}
