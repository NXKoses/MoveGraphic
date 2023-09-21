using MoveGraphic.Objects;

namespace MoveGraphic
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void AddLine_button_Click(object sender, EventArgs e)
        {
            Program.ObjectList.Add(new LineObject(new Point(int.Parse(LineX_textBox.Text), int.Parse(LineY_textBox.Text)), new Point(int.Parse(LineX2_textBox.Text), int.Parse(LineY2_textBox.Text))));
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
