namespace MoveGraphic.Objects
{
    internal class ObjectBase
    {
        /// <summary>
        /// 本当の座標
        /// </summary>
        internal int X { get; set; }

        internal int Y { get; set; }

        internal int X2 { get; set; }

        internal int Y2 { get; set; }

        /// <summary>
        /// 描画するときのペン
        /// </summary>
        internal Pen pen { get; set; } = new(Color.Black, 2);

        /// <summary>
        /// 描画するときのブラシ
        /// </summary>
        internal SolidBrush Brush { get; set; } = new(Color.Gray);

        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>X座標</returns>
        internal int GetDrawX() => X + Program.X_offset;

        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>Y座標</returns>
        internal int GetDrawY() => Y + Program.Y_offset;

        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>座標</returns>
        internal int GetDrawX2() => X2 + Program.X_offset;

        /// <summary>
        /// 描画すべき座標を取得します
        /// </summary>
        /// <returns>座標</returns>
        internal int GetDrawY2() => Y2 + Program.Y_offset;

        /// <summary>
        /// 色を変更します。
        /// </summary>
        /// <param name="newcolor"></param>
        internal void SetColor(Color newcolor)
        {
            pen.Color = newcolor;
            Brush.Color = newcolor;
        }
    }
}
