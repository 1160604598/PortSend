namespace PortSend
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button_Start = new Button();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(109, 13);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(53, 23);
            textBox2.TabIndex = 0;
            textBox2.Text = "50001";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(109, 68);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(151, 23);
            textBox3.TabIndex = 0;
            textBox3.Text = "192.168.102.102";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(275, 68);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(57, 23);
            textBox4.TabIndex = 0;
            textBox4.Text = "8421";
            // 
            // button_Start
            // 
            button_Start.Location = new Point(361, 12);
            button_Start.Name = "button_Start";
            button_Start.Size = new Size(75, 23);
            button_Start.TabIndex = 1;
            button_Start.Text = "Go";
            button_Start.UseVisualStyleBackColor = true;
            button_Start.Click += button_Start_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(31, 120);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(405, 393);
            textBox5.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 16);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 2;
            label1.Text = "本地端口：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 71);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 2;
            label2.Text = "远程端口：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 525);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_Start);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Name = "Form1";
            Text = "端口转发";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button_Start;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
    }
}
