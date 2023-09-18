using MoveGraphic.Objects;

namespace MoveGraphic
{
    public partial class Form2 : Form
    {
        Form1 mainform;

        public Form2(Form1 form1)
        {
            mainform = form1;
            InitializeComponent();
        }

        private void AddLine_button_Click(object sender, EventArgs e)
        {
            mainform.ObjectList.Add(new LineObject(new Point(int.Parse(LineX_textBox.Text), int.Parse(LineY_textBox.Text)), new Point(int.Parse(LineX2_textBox.Text), int.Parse(LineY2_textBox.Text))));
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
