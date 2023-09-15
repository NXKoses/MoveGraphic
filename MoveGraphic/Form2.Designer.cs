namespace MoveGraphic
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddLine_button = new Button();
            LineX_textBox = new TextBox();
            LineY_textBox = new TextBox();
            LineY2_textBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            LineX2_textBox = new TextBox();
            SuspendLayout();
            // 
            // AddLine_button
            // 
            AddLine_button.Location = new Point(167, 58);
            AddLine_button.Name = "AddLine_button";
            AddLine_button.Size = new Size(75, 23);
            AddLine_button.TabIndex = 0;
            AddLine_button.Text = "Add Line";
            AddLine_button.UseVisualStyleBackColor = true;
            AddLine_button.Click += AddLine_button_Click;
            // 
            // LineX_textBox
            // 
            LineX_textBox.Location = new Point(12, 29);
            LineX_textBox.Name = "LineX_textBox";
            LineX_textBox.Size = new Size(39, 23);
            LineX_textBox.TabIndex = 1;
            // 
            // LineY_textBox
            // 
            LineY_textBox.Location = new Point(57, 29);
            LineY_textBox.Name = "LineY_textBox";
            LineY_textBox.Size = new Size(39, 23);
            LineY_textBox.TabIndex = 2;
            // 
            // LineY2_textBox
            // 
            LineY2_textBox.Location = new Point(163, 29);
            LineY2_textBox.Name = "LineY2_textBox";
            LineY2_textBox.Size = new Size(39, 23);
            LineY2_textBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 6;
            label1.Text = "X             Y";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(118, 9);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 7;
            label2.Text = "X2           Y2";
            // 
            // LineX2_textBox
            // 
            LineX2_textBox.Location = new Point(118, 29);
            LineX2_textBox.Name = "LineX2_textBox";
            LineX2_textBox.Size = new Size(39, 23);
            LineX2_textBox.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 536);
            Controls.Add(LineX2_textBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LineY2_textBox);
            Controls.Add(LineY_textBox);
            Controls.Add(LineX_textBox);
            Controls.Add(AddLine_button);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddLine_button;
        private TextBox LineX_textBox;
        private TextBox LineY_textBox;
        private TextBox LineZ_textBox;
        private TextBox textBox4;
        private TextBox LineY2_textBox;
        private Label label1;
        private Label label2;
        private TextBox textBox6;
        private TextBox LineX2_textBox;
    }
}