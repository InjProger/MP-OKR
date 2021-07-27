namespace MissionPlanner.Controls.TabMenus.Views.Tabs
{
    partial class ArchiveTab
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveTab));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCharts = new System.Windows.Forms.Button();
            this.panelSplit1 = new System.Windows.Forms.Panel();
            this.panelSplit2 = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.btnPrevFrame = new System.Windows.Forms.Button();
            this.btnNextFrame = new System.Windows.Forms.Button();
            this.panelSplit3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnCharts
            // 
            resources.ApplyResources(this.btnCharts, "btnCharts");
            this.btnCharts.Name = "btnCharts";
            this.btnCharts.UseVisualStyleBackColor = true;
            // 
            // panelSplit1
            // 
            this.panelSplit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panelSplit1, "panelSplit1");
            this.panelSplit1.Name = "panelSplit1";
            // 
            // panelSplit2
            // 
            this.panelSplit2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panelSplit2, "panelSplit2");
            this.panelSplit2.Name = "panelSplit2";
            // 
            // btnPlay
            // 
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            resources.ApplyResources(this.btnPause, "btnPause");
            this.btnPause.Name = "btnPause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // trackBar
            // 
            resources.ApplyResources(this.trackBar, "trackBar");
            this.trackBar.LargeChange = 1;
            this.trackBar.Maximum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.TickFrequency = 5;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // btnPrevFrame
            // 
            resources.ApplyResources(this.btnPrevFrame, "btnPrevFrame");
            this.btnPrevFrame.Name = "btnPrevFrame";
            this.btnPrevFrame.UseVisualStyleBackColor = true;
            // 
            // btnNextFrame
            // 
            resources.ApplyResources(this.btnNextFrame, "btnNextFrame");
            this.btnNextFrame.Name = "btnNextFrame";
            this.btnNextFrame.UseVisualStyleBackColor = true;
            // 
            // panelSplit3
            // 
            this.panelSplit3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panelSplit3, "panelSplit3");
            this.panelSplit3.Name = "panelSplit3";
            // 
            // ArchiveTab
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelSplit3);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.panelSplit1);
            this.Controls.Add(this.btnCharts);
            this.Controls.Add(this.panelSplit2);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPrevFrame);
            this.Controls.Add(this.btnNextFrame);
            this.Controls.Add(this.trackBar);
            this.Name = "ArchiveTab";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnOpen;
        public System.Windows.Forms.Button btnCharts;
        private System.Windows.Forms.Panel panelSplit2;
        private System.Windows.Forms.Panel panelSplit1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnNextFrame;
        private System.Windows.Forms.Button btnPrevFrame;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Panel panelSplit3;
    }
}
