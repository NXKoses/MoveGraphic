using MoveGraphic.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            mainform.ObjectList.Add(new LineObject(int.Parse(LineX_textBox.Text), int.Parse(LineY_textBox.Text), int.Parse(LineX2_textBox.Text), int.Parse(LineY2_textBox.Text)));
        }
    }
}
