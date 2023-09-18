namespace MoveGraphic.Objects
{
    internal class ObjectBase
    {
        private Point displaystartpoint;
        private Point displayendpoint;

        internal Point InternalStartPoint { get; set; } = new();      // 内部座標
        internal Point InternalEndPoint { get; set; } = new();        // 内部座標

        /// <summary>
        /// 描画座標　取得するときにオフセットを足して返す
        /// </summary>
        internal Point DisplayStartPoint
        {
            set
            {
                displaystartpoint = value;
            }
            get { return new Point(displaystartpoint.X + Program.X_offset, displaystartpoint.Y + Program.Y_offset); }
        }

        /// <summary>
        /// 描画座標　取得するときにオフセットを足して返す
        /// </summary>
        internal Point DisplayEndPoint
        {
            set
            {
                displayendpoint = value;
            }
            get { return new Point(displayendpoint.X + Program.X_offset, displayendpoint.Y + Program.Y_offset); }
        }


        /// <summary>
        /// 描画するときのペン
        /// </summary>
        internal Pen pen { get; set; } = new(Color.Black, 2);

        /// <summary>
        /// 描画するときのブラシ
        /// </summary>
        internal SolidBrush Brush { get; set; } = new(Color.Gray);

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
