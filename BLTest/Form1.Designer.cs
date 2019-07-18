namespace BLTest
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bRandom = new System.Windows.Forms.Button();
            this.bDeserialize = new System.Windows.Forms.Button();
            this.bSerialize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1274, 44);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // bRandom
            // 
            this.bRandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRandom.ForeColor = System.Drawing.Color.White;
            this.bRandom.Location = new System.Drawing.Point(10, 60);
            this.bRandom.Name = "bRandom";
            this.bRandom.Size = new System.Drawing.Size(75, 23);
            this.bRandom.TabIndex = 1;
            this.bRandom.Text = "Random";
            this.bRandom.UseVisualStyleBackColor = true;
            this.bRandom.Click += new System.EventHandler(this.button1_Click);
            // 
            // bDeserialize
            // 
            this.bDeserialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDeserialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bDeserialize.ForeColor = System.Drawing.Color.White;
            this.bDeserialize.Location = new System.Drawing.Point(1209, 60);
            this.bDeserialize.Name = "bDeserialize";
            this.bDeserialize.Size = new System.Drawing.Size(75, 23);
            this.bDeserialize.TabIndex = 2;
            this.bDeserialize.Text = "Deserialize";
            this.bDeserialize.UseVisualStyleBackColor = true;
            this.bDeserialize.Click += new System.EventHandler(this.bDeserialize_Click);
            // 
            // bSerialize
            // 
            this.bSerialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSerialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSerialize.ForeColor = System.Drawing.Color.White;
            this.bSerialize.Location = new System.Drawing.Point(1128, 60);
            this.bSerialize.Name = "bSerialize";
            this.bSerialize.Size = new System.Drawing.Size(75, 23);
            this.bSerialize.TabIndex = 3;
            this.bSerialize.Text = "Serialize";
            this.bSerialize.UseVisualStyleBackColor = true;
            this.bSerialize.Click += new System.EventHandler(this.bSerialize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1294, 94);
            this.Controls.Add(this.bSerialize);
            this.Controls.Add(this.bDeserialize);
            this.Controls.Add(this.bRandom);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bi-directional list example";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bRandom;
        private System.Windows.Forms.Button bDeserialize;
        private System.Windows.Forms.Button bSerialize;
    }
}

