namespace MoveGraphic.Objects
{
    static class DebugTextObject
    {
        /// <summary>
        /// 画面上での座標をオブジェクトの隣に描画します。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void Display_in_XY(ObjectBase obj, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, $"DisXY \nX: {obj.GetDrawX()}, Y: {obj.Y + obj.GetDrawY()}\n X2: {obj.GetDrawX2()}, Y2: {obj.GetDrawY2()}", new Font("Yu Gothic UI", 8), new Point(obj.GetDrawX() + 20, obj.GetDrawY() - 20), Color.Black);
        }

        /// <summary>
        /// 絶対的な座標をオブジェクトの隣に描画します。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void Absolute_XY(ObjectBase obj, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, $"Abs XY \nX: {obj.X}, Y: {obj.Y}\n" +
                                              $"X2: {obj.X2}, Y2: {obj.Y2}", new Font("Yu Gothic UI", 8), new Point(obj.GetDrawX() + 20, obj.GetDrawY() - 20), Color.Black);
        }

        /// <summary>
        /// bve内での実際の長さを計算して描画します。
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public static void DispToBveScale(ObjectBase obj, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, $"距離: {MathFunc.TwoPointDistance(obj, 2)}\n" +
                                              $"Bveでの距離: {MathFunc.TwoPointDistance(obj, 2) / Program.DisplayScale}km", new Font("Yu Gothic UI", 8), new Point(obj.GetDrawX() + 20, obj.GetDrawY() - 20), Color.Black);
        }
    }
}
