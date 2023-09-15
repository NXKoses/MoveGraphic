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
    }
}