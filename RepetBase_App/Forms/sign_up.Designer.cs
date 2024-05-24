namespace RepetBase_App
{
    partial class sign_up
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sign_up));
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconPic = new System.Windows.Forms.PictureBox();
            this.QuastionButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_password2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonShow = new System.Windows.Forms.PictureBox();
            this.ButtonHied = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuastionButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonHied)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.iconPic);
            this.panel1.Controls.Add(this.QuastionButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 100);
            this.panel1.TabIndex = 0;
            // 
            // iconPic
            // 
            this.iconPic.BackColor = System.Drawing.Color.PaleTurquoise;
            this.iconPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iconPic.Image = ((System.Drawing.Image)(resources.GetObject("iconPic.Image")));
            this.iconPic.Location = new System.Drawing.Point(16, 10);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(82, 79);
            this.iconPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPic.TabIndex = 2;
            this.iconPic.TabStop = false;
            // 
            // QuastionButton
            // 
            this.QuastionButton.Location = new System.Drawing.Point(673, 10);
            this.QuastionButton.Name = "QuastionButton";
            this.QuastionButton.Size = new System.Drawing.Size(85, 79);
            this.QuastionButton.TabIndex = 1;
            this.QuastionButton.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 80);
            this.label1.TabIndex = 1;
            this.label1.Text = "Регистрация нового пользователя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(29, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(742, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Зарегистрироваться!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(123, 266);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(544, 20);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Я принимаю условия соглашения и несу отвественность за использование ПО";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox_login
            // 
            this.textBox_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_login.Location = new System.Drawing.Point(122, 142);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(649, 26);
            this.textBox_login.TabIndex = 9;
            // 
            // textBox_password2
            // 
            this.textBox_password2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_password2.Location = new System.Drawing.Point(122, 185);
            this.textBox_password2.Name = "textBox_password2";
            this.textBox_password2.Size = new System.Drawing.Size(590, 26);
            this.textBox_password2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(33, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Логин:";
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Items.AddRange(new object[] {
            "Математика",
            "Физика",
            "Химия",
            "Английский Язык",
            "Русский Язык",
            "История",
            "Обществознание"});
            this.comboBoxSubject.Location = new System.Drawing.Point(122, 225);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(649, 28);
            this.comboBoxSubject.TabIndex = 10;
            this.comboBoxSubject.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubject_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(17, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Предмет:";
            // 
            // ButtonShow
            // 
            this.ButtonShow.Image = global::RepetBase_App.Properties.Resources.close;
            this.ButtonShow.Location = new System.Drawing.Point(722, 174);
            this.ButtonShow.Name = "ButtonShow";
            this.ButtonShow.Size = new System.Drawing.Size(49, 47);
            this.ButtonShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonShow.TabIndex = 13;
            this.ButtonShow.TabStop = false;
            this.ButtonShow.Click += new System.EventHandler(this.Hide_Click);
            // 
            // ButtonHied
            // 
            this.ButtonHied.Image = global::RepetBase_App.Properties.Resources.open;
            this.ButtonHied.Location = new System.Drawing.Point(722, 174);
            this.ButtonHied.Name = "ButtonHied";
            this.ButtonHied.Size = new System.Drawing.Size(49, 47);
            this.ButtonHied.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonHied.TabIndex = 12;
            this.ButtonHied.TabStop = false;
            this.ButtonHied.Click += new System.EventHandler(this.Show_Click);
            // 
            // sign_up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 369);
            this.Controls.Add(this.ButtonHied);
            this.Controls.Add(this.ButtonShow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.textBox_password2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "sign_up";
            this.Text = "Регистрация пользователя";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sign_up_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.sign_up_FormClosed);
            this.Load += new System.EventHandler(this.log_in_load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuastionButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonHied)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox iconPic;
        private System.Windows.Forms.PictureBox QuastionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_password2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox ButtonShow;
        private System.Windows.Forms.PictureBox ButtonHied;
    }
}