
namespace lab5
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pointsCounter = new System.Windows.Forms.Label();
            this.infBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(720, 480);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(738, 12);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(426, 480);
            this.LogBox.TabIndex = 1;
            this.LogBox.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pointsCounter
            // 
            this.pointsCounter.AutoSize = true;
            this.pointsCounter.Location = new System.Drawing.Point(17, 17);
            this.pointsCounter.Name = "pointsCounter";
            this.pointsCounter.Size = new System.Drawing.Size(0, 19);
            this.pointsCounter.TabIndex = 2;
            // 
            // infBtn
            // 
            this.infBtn.Location = new System.Drawing.Point(21, 498);
            this.infBtn.Name = "infBtn";
            this.infBtn.Size = new System.Drawing.Size(242, 33);
            this.infBtn.TabIndex = 3;
            this.infBtn.Text = "Информация о программе";
            this.infBtn.UseVisualStyleBackColor = true;
            this.infBtn.Click += new System.EventHandler(this.infBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 543);
            this.Controls.Add(this.infBtn);
            this.Controls.Add(this.pointsCounter);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label pointsCounter;
        private System.Windows.Forms.Button infBtn;
    }
}

