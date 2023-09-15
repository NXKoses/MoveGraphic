namespace MoveGraphic.Objects
{
    internal class ObjectBase
    {
        /// <summary>
        /// 本当の座標
        /// </summary>
        public int X { get; set; }

        public int Y { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        /// <summary>
        /// 描画するときのペン
        /// </summary>
        public Pen pen { get; set; } = new(Color.Black, 2);

        /// <summary>
        /// 描画するときのブラシ
        /// </summary>
        public SolidBrush Brush { get; set; }

        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>X座標</returns>
        public int GetDrawX() => X + Program.X_offset;
        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>Y座標</returns>
        public int GetDrawY() => Y + Program.Y_offset;
        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>座標</returns>
        public int GetDrawX2() => X2 + Program.X_offset;
        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>座標</returns>
        public int GetDrawY2() => Y2 + Program.Y_offset;

        /// <summary>
        /// 色を変更します。
        /// </summary>
        /// <param name="newcolor"></param>
        public void ChangeColor(Color newcolor)
        {
            pen.Color = newcolor;
        }
    }
}
