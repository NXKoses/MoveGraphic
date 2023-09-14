using MoveGraphic.Objects;
using Timer = System.Windows.Forms.Timer;

namespace MoveGraphic
{
    public partial class Form1 : Form
    {
        Form2 Form2;

        //更新処理のためにタイマーを作成
        Timer Updatetimer = new Timer();

        public List<Object> ObjectList = new();

        /*マウス関係*/
        Point MousePoint;
        Point DiffMovepoint;
        CursorMoveObject CursorLineObject = new();

        public Form1()
        {
            InitializeComponent();

            //ちらつき防止
            this.DoubleBuffered = true;

            ObjectList.Add(new LineObject(100, 100, 150, 150));
            ObjectList.Add(new RectangleObject(150, 150, 20, 20));

            Updatetimer.Interval = 1;
            Updatetimer.Tick += new EventHandler(Update);
            Updatetimer.Start();

            Form2 = new(this);
            Form2.Show(this);
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
                var type = ObjectList[i].GetType();

                DebugTextObject.Draw((ObjectBase)ObjectList[i], e);

                /*描画*/
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = $"X: {e.X}, Y: {e.Y}";

            if (e.Button == MouseButtons.Left)
            {
                DiffMovepoint = new Point(e.X - MousePoint.X, e.Y - MousePoint.Y);

                /*Cursor線の先っぽ設定*/
                CursorLineObject.X2 = DiffMovepoint.X + CursorLineObject.X;
                CursorLineObject.Y2 = DiffMovepoint.Y + CursorLineObject.Y;

                toolStripStatusLabel2.Text = $"Diff X: {DiffMovepoint.X}, Y: {DiffMovepoint.Y}";
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*Cursor線の設定*/
            CursorLineObject.X = e.X;
            CursorLineObject.Y = e.Y;
            CursorLineObject.X2 = e.X;
            CursorLineObject.Y2 = e.Y;
            CursorLineObject.IsUpDown(true);

            if (e.Button == MouseButtons.Left)
            {
                MousePoint = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            CursorLineObject.IsUpDown(false);

            if (e.Button == MouseButtons.Left)
            {
                //リストの数だけ実行
                for (int i = 0; i < ObjectList.Count; i++)
                {
                    ObjectBase objectBase = (ObjectBase)ObjectList[i];
                    objectBase.X += DiffMovepoint.X;
                    objectBase.Y += DiffMovepoint.Y;
                    objectBase.X2 += DiffMovepoint.X;
                    objectBase.Y2 += DiffMovepoint.Y;
                }
                DiffMovepoint.X = 0;
                DiffMovepoint.Y = 0;
            }
        }
    }
}