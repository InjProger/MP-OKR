namespace MissionPlanner.GCSViews.HUDs.Views
{
    partial class HudView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HudView));
            this.lblNoSignal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNoSignal
            // 
            resources.ApplyResources(this.lblNoSignal, "lblNoSignal");
            this.lblNoSignal.ForeColor = System.Drawing.Color.Red;
            this.lblNoSignal.Name = "lblNoSignal";
            // 
            // HudView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoSignal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HudView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNoSignal;
    }
}