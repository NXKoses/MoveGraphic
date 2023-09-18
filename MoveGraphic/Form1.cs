using MoveGraphic.Objects;
using Timer = System.Windows.Forms.Timer;

namespace MoveGraphic
{
    public partial class Form1 : Form
    {
        //更新処理のためにタイマーを作成
        private Timer Updatetimer = new Timer();

        //描画オブジェクトリスト
        internal List<ObjectBase> ObjectList = new();

        /*マウス関係*/
        private Point DiffMovepoint;
        private CursorLineObject CursorLineObject = new();
        private int WheelCount = 0;

        /*座標*/


        public Form1()
        {
            //コントロールFormの表示
            new Form2(this).Show();

            InitializeComponent();
            this.MouseWheel += MouseWheelEvent;

            //ちらつき防止
            this.DoubleBuffered = true;

            ObjectList.Add(new LineObject(
                new Point(150, 0), new Point(150, 150)));

            Updatetimer.Interval = 1;
            Updatetimer.Tick += new EventHandler(Update);
            Updatetimer.Start();
        }

        private void MouseWheelEvent(object? sender, MouseEventArgs e)
        {
            // マウスの位置を中心に拡大縮小
            float zoomFactor = (e.Delta > 0) ? 1.1f : 0.9f;
            Program.DisplayScale *= zoomFactor;

            for (int i = 0; i < ObjectList.Count; i++)
            {
                //// マウスの位置を中心に内部座標を変更
                //ObjectList[i].DisplayStartPoint = new Point(
                //    (int)((ObjectList[i].InternalStartPoint.X - e.X) * zoomFactor + e.X),
                //    (int)((ObjectList[i].InternalStartPoint.Y - e.Y) * zoomFactor + e.Y)
                //);
                //ObjectList[i].DisplayStartPoint = new Point(
                //    (int)((ObjectList[i].InternalStartPoint.X - e.X) * zoomFactor + e.X),
                //    (int)((ObjectList[i].InternalStartPoint.Y - e.Y) * zoomFactor + e.Y)
                //);

                // 描画座標を更新
                ObjectList[i].DisplayStartPoint = new Point(
                    (int)(ObjectList[i].InternalStartPoint.X * Program.DisplayScale),
                    (int)(ObjectList[i].InternalStartPoint.Y * Program.DisplayScale)
                );
                ObjectList[i].DisplayEndPoint = new Point(
                    (int)(ObjectList[i].InternalEndPoint.X * Program.DisplayScale),
                    (int)(ObjectList[i].InternalEndPoint.Y * Program.DisplayScale)
                );
            }
            //Debug.WriteLine($"{e.Delta}, {WheelCount}");
        }

        /// <summary>
        /// タイマーで1msごとに呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// 再描画時に呼び出される
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //リストの数だけ実行
            for (int i = 0; i < ObjectList.Count; i++)
            {
                //オブジェクトの種類を取得
                var type = ObjectList[i].GetType();

                //オブジェクト隣の文字描画
                DebugTextObject.DispToBveScale(ObjectList[i], e);

                /*オブジェクトごとに描画*/
                if (type == typeof(LineObject))
                {
                    LineObject lineObject = (LineObject)ObjectList[i];
                    lineObject.Draw(e);
                }
                else if (type == typeof(RectangleObject))
                {
                    RectangleObject rectangleObject = (RectangleObject)ObjectList[i];
                    rectangleObject.Draw(e);
                }
            }

            /*マウスの線描画*/
            CursorLineObject.Draw(e);
        }

        /// <summary>
        /// マウスを動かしたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //画面下に座標を表示する
            toolStripStatusLabel1.Text = $"Disp in X: {e.X}, Y: {e.Y}";
            toolStripStatusLabel2.Text = $"Abso in X: {e.X - Program.X_offset}, Y: {e.Y - Program.Y_offset}";

            //クリックしている間
            if (e.Button == MouseButtons.Left)
            {
                /*Cursor線の先を設定する    同時に、移動した差分も取得する*/
                DiffMovepoint = CursorLineObject.DragXY(e.X, e.Y);

                //画面下に座標を表示する
                toolStripStatusLabel3.Text = $"Diff X: {DiffMovepoint.X}, Y: {DiffMovepoint.Y}";
            }
        }

        /// <summary>
        /// マウスをクリックした時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*Cursor線の根元の設定*/
            CursorLineObject.DownXY(e.X, e.Y);
            CursorLineObject.IsUpDown(true);
        }

        /// <summary>
        /// マウスのクリックを離した時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //Cursor線を非表示にします
            CursorLineObject.IsUpDown(false);

            //マウス移動分をオフセットに加算します。
            if (e.Button == MouseButtons.Left)
            {
                Program.X_offset += DiffMovepoint.X;
                Program.Y_offset += DiffMovepoint.Y;
            }
            DiffMovepoint.X = 0;
            DiffMovepoint.Y = 0;
        }

        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            //未完成
            Program.SaveObject(ObjectList, @"");
        }
    }
}