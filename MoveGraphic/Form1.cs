using MoveGraphic.Objects;
using Timer = System.Windows.Forms.Timer;

namespace MoveGraphic
{
    public partial class Form1 : Form
    {
        //�z��̒��g�͕ς����ɕ\���ɃI�t�Z�b�g�����Ă�����


        //�X�V�����̂��߂Ƀ^�C�}�[���쐬
        private Timer Updatetimer = new Timer();

        //�`��I�u�W�F�N�g���X�g
        internal List<ObjectBase> ObjectList = new();

        /*�}�E�X�֌W*/
        private Point MousePoint;
        private Point DiffMovepoint;
        private CursorLineObject CursorLineObject = new();

        public Form1()
        {
            new Form2(this).Show();

            InitializeComponent();

            //������h�~
            this.DoubleBuffered = true;

            ObjectList.Add(new LineObject(100, 100, 150, 150));
            ObjectList.Add(new LineObject(0, 0, 0, 0));
            ObjectList.Add(new RectangleObject(150, 150, 20, 20));

            Updatetimer.Interval = 1;
            Updatetimer.Tick += new EventHandler(Update);
            Updatetimer.Start();
        }

        /// <summary>
        /// �^�C�}�[��1ms���ƂɌĂяo�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// �ĕ`�掞�ɌĂяo�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //���X�g�̐��������s
            for (int i = 0; i < ObjectList.Count; i++)
            {
                //�I�u�W�F�N�g�̎�ނ��擾
                var type = ObjectList[i].GetType();

                //�I�u�W�F�N�g�ׂ̕����`��
                DebugTextObject.Absolute_XY(ObjectList[i], e);

                /*�I�u�W�F�N�g���Ƃɕ`��*/
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

            /*�}�E�X�̐��`��*/
            CursorLineObject.Draw(e);
        }

        /// <summary>
        /// �}�E�X�𓮂������Ƃ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = $"Disp in X: {e.X}, Y: {e.Y}";
            toolStripStatusLabel2.Text = $"Abso in X: {e.X - Program.X_offset}, Y: {e.Y - Program.Y_offset}";

            if (e.Button == MouseButtons.Left)
            {
                //�}�E�X�ňړ��������������߂܂�
                DiffMovepoint = new Point(e.X - MousePoint.X, e.Y - MousePoint.Y);

                /*Cursor���̐���ېݒ�*/
                CursorLineObject.X2 = DiffMovepoint.X + CursorLineObject.X;
                CursorLineObject.Y2 = DiffMovepoint.Y + CursorLineObject.Y;

                toolStripStatusLabel3.Text = $"Diff X: {DiffMovepoint.X}, Y: {DiffMovepoint.Y}";
            }
        }

        /// <summary>
        /// �}�E�X���N���b�N������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*Cursor���̐ݒ�*/
            CursorLineObject.X = e.X;
            CursorLineObject.Y = e.Y;
            CursorLineObject.X2 = e.X;  //�O��̂��c���Ă邩��������
            CursorLineObject.Y2 = e.Y;  //�O��̂��c���Ă邩��������
            CursorLineObject.IsUpDown(true);

            //���N���b�N�����Ƃ��̍��W���擾
            if (e.Button == MouseButtons.Left)
            {
                MousePoint = e.Location;
            }
        }

        /// <summary>
        /// �}�E�X�̃N���b�N�𗣂�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //Cursor�����\���ɂ��܂�
            CursorLineObject.IsUpDown(false);

            //�}�E�X�ړ������I�t�Z�b�g�Ƃ��ĉ��Z���܂��B
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