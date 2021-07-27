namespace MissionPlanner.Controls.DoublePicture
{

    partial class DoublePicture
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoublePicture));
            this.pictureUp = new System.Windows.Forms.PictureBox();
            this.pictureDown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureUp
            // 
            this.pictureUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureUp.Image")));
            this.pictureUp.Location = new System.Drawing.Point(0, 0);
            this.pictureUp.Name = "pictureUp";
            this.pictureUp.Size = new System.Drawing.Size(26, 27);
            this.pictureUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUp.TabIndex = 0;
            this.pictureUp.TabStop = false;
            // 
            // pictureDown
            // 
            this.pictureDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureDown.Image = ((System.Drawing.Image)(resources.GetObject("pictureDown.Image")));
            this.pictureDown.Location = new System.Drawing.Point(0, 0);
            this.pictureDown.Name = "pictureDown";
            this.pictureDown.Size = new System.Drawing.Size(26, 27);
            this.pictureDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureDown.TabIndex = 1;
            this.pictureDown.TabStop = false;
            this.pictureDown.Visible = false;
            // 
            // DoublePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureUp);
            this.Controls.Add(this.pictureDown);
            this.Name = "DoublePicture";
            this.Size = new System.Drawing.Size(26, 27);
            ((System.ComponentModel.ISupportInitialize)(this.pictureUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureUp;
        private System.Windows.Forms.PictureBox pictureDown;
    }
}
