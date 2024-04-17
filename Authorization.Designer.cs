namespace _17
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLog = new System.Windows.Forms.TextBox();
            this.textPas = new System.Windows.Forms.TextBox();
            this.btn_enter = new System.Windows.Forms.Button();
            this.label_registr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(7, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::_17.Properties.Resources.вгту;
            this.pictureBox1.Location = new System.Drawing.Point(132, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textLog
            // 
            this.textLog.Location = new System.Drawing.Point(12, 237);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(292, 36);
            this.textLog.TabIndex = 5;
            // 
            // textPas
            // 
            this.textPas.Location = new System.Drawing.Point(12, 320);
            this.textPas.Multiline = true;
            this.textPas.Name = "textPas";
            this.textPas.Size = new System.Drawing.Size(292, 36);
            this.textPas.TabIndex = 6;
            // 
            // btn_enter
            // 
            this.btn_enter.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_enter.FlatAppearance.BorderSize = 3;
            this.btn_enter.Font = new System.Drawing.Font("Perpetua Titling MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enter.Location = new System.Drawing.Point(114, 384);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(199, 48);
            this.btn_enter.TabIndex = 7;
            this.btn_enter.Text = "Вход";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            this.btn_enter.MouseEnter += new System.EventHandler(this.btn_enter_MouseEnter);
            this.btn_enter.MouseLeave += new System.EventHandler(this.btn_enter_MouseLeave);
            // 
            // label_registr
            // 
            this.label_registr.AutoSize = true;
            this.label_registr.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_registr.Location = new System.Drawing.Point(158, 454);
            this.label_registr.Name = "label_registr";
            this.label_registr.Size = new System.Drawing.Size(116, 23);
            this.label_registr.TabIndex = 8;
            this.label_registr.Text = "Регистрация";
            this.label_registr.Click += new System.EventHandler(this.label_registr_Click);
            this.label_registr.MouseEnter += new System.EventHandler(this.label_registr_MouseEnter);
            this.label_registr.MouseLeave += new System.EventHandler(this.label_registr_MouseLeave);
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 512);
            this.Controls.Add(this.label_registr);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.textPas);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Authorization";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.TextBox textPas;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.Label label_registr;
    }
}

