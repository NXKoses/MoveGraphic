using MoveGraphic.Objects;
using Timer = System.Windows.Forms.Timer;

namespace MoveGraphic
{
    public partial class Form1 : Form
    {
        //�X�V�����̂��߂Ƀ^�C�}�[���쐬
        private Timer Updatetimer = new Timer();

        //�`��I�u�W�F�N�g���X�g
        internal List<ObjectBase> ObjectList = new();

        /*�}�E�X�֌W*/
        private Point DiffMovepoint;
        private CursorLineObject CursorLineObject = new();
        private int WheelCount = 0;

        /*���W*/


        public Form1()
        {
            //�R���g���[��Form�̕\��
            new Form2(this).Show();

            InitializeComponent();
            this.MouseWheel += MouseWheelEvent;

            //������h�~
            this.DoubleBuffered = true;

            ObjectList.Add(new LineObject(
                new Point(150, 0), new Point(150, 150)));

            Updatetimer.Interval = 1;
            Updatetimer.Tick += new EventHandler(Update);
            Updatetimer.Start();
        }

        private void MouseWheelEvent(object? sender, MouseEventArgs e)
        {
            // �}�E�X�̈ʒu�𒆐S�Ɋg��k��
            float zoomFactor = (e.Delta > 0) ? 1.1f : 0.9f;
            Program.DisplayScale *= zoomFactor;

            for (int i = 0; i < ObjectList.Count; i++)
            {
                //// �}�E�X�̈ʒu�𒆐S�ɓ������W��ύX
                //ObjectList[i].DisplayStartPoint = new Point(
                //    (int)((ObjectList[i].InternalStartPoint.X - e.X) * zoomFactor + e.X),
                //    (int)((ObjectList[i].InternalStartPoint.Y - e.Y) * zoomFactor + e.Y)
                //);
                //ObjectList[i].DisplayStartPoint = new Point(
                //    (int)((ObjectList[i].InternalStartPoint.X - e.X) * zoomFactor + e.X),
                //    (int)((ObjectList[i].InternalStartPoint.Y - e.Y) * zoomFactor + e.Y)
                //);

                // �`����W���X�V
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
                DebugTextObject.DispToBveScale(ObjectList[i], e);

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
            //��ʉ��ɍ��W��\������
            toolStripStatusLabel1.Text = $"Disp in X: {e.X}, Y: {e.Y}";
            toolStripStatusLabel2.Text = $"Abso in X: {e.X - Program.X_offset}, Y: {e.Y - Program.Y_offset}";

            //�N���b�N���Ă����
            if (e.Button == MouseButtons.Left)
            {
                /*Cursor���̐��ݒ肷��    �����ɁA�ړ������������擾����*/
                DiffMovepoint = CursorLineObject.DragXY(e.X, e.Y);

                //��ʉ��ɍ��W��\������
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
            /*Cursor���̍����̐ݒ�*/
            CursorLineObject.DownXY(e.X, e.Y);
            CursorLineObject.IsUpDown(true);
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

            //�}�E�X�ړ������I�t�Z�b�g�ɉ��Z���܂��B
            if (e.Button == MouseButtons.Left)
            {
                Program.X_offset += DiffMovepoint.X;
                Program.Y_offset += DiffMovepoint.Y;
            }
            DiffMovepoint.X = 0;
            DiffMovepoint.Y = 0;
        }

        private void �ۑ�SToolStripButton_Click(object sender, EventArgs e)
        {
            //������
            Program.SaveObject(ObjectList, @"");
        }
    }
}