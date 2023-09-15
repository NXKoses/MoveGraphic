using MoveGraphic.Objects;
using Timer = System.Windows.Forms.Timer;

namespace MoveGraphic
{
    public partial class Form1 : Form
    {
        //配列の中身は変えずに表示にオフセットかけてあげる


        //更新処理のためにタイマーを作成
        private Timer Updatetimer = new Timer();

        //描画オブジェクトリスト
        internal List<ObjectBase> ObjectList = new();

        /*マウス関係*/
        private Point MousePoint;
        private Point DiffMovepoint;
        private CursorLineObject CursorLineObject = new();

        public Form1()
        {
            new Form2(this).Show();

            InitializeComponent();

            //ちらつき防止
            this.DoubleBuffered = true;

            ObjectList.Add(new LineObject(100, 100, 150, 150));
            ObjectList.Add(new LineObject(0, 0, 0, 0));
            ObjectList.Add(new RectangleObject(150, 150, 20, 20));

            Updatetimer.Interval = 1;
            Updatetimer.Tick += new EventHandler(Update);
            Updatetimer.Start();
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
                DebugTextObject.Absolute_XY(ObjectList[i], e);

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
            toolStripStatusLabel1.Text = $"Disp in X: {e.X}, Y: {e.Y}";
            toolStripStatusLabel2.Text = $"Abso in X: {e.X - Program.X_offset}, Y: {e.Y - Program.Y_offset}";

            if (e.Button == MouseButtons.Left)
            {
                //マウスで移動した距離を求めます
                DiffMovepoint = new Point(e.X - MousePoint.X, e.Y - MousePoint.Y);

                /*Cursor線の先っぽ設定*/
                CursorLineObject.X2 = DiffMovepoint.X + CursorLineObject.X;
                CursorLineObject.Y2 = DiffMovepoint.Y + CursorLineObject.Y;

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
            /*Cursor線の設定*/
            CursorLineObject.X = e.X;
            CursorLineObject.Y = e.Y;
            CursorLineObject.X2 = e.X;  //前回のが残ってるから代入する
            CursorLineObject.Y2 = e.Y;  //前回のが残ってるから代入する
            CursorLineObject.IsUpDown(true);

            //左クリックしたときの座標を取得
            if (e.Button == MouseButtons.Left)
            {
                MousePoint = e.Location;
            }
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

            //マウス移動分をオフセットとして加算します。
            if (e.Button == MouseButtons.Left)
            {
                Program.X_offset += DiffMovepoint.X;
                Program.Y_offset += DiffMovepoint.Y;
            }
            DiffMovepoint.X = 0;
            DiffMovepoint.Y = 0;
        }
    }
}