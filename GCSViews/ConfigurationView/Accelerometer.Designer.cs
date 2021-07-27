namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class Accelerometer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accelerometer));
            this.configAccelerometerCalibration1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigAccelerometerCalibration();
            this.SuspendLayout();
            // 
            // configAccelerometerCalibration1
            // 
            resources.ApplyResources(this.configAccelerometerCalibration1, "configAccelerometerCalibration1");
            this.configAccelerometerCalibration1.Name = "configAccelerometerCalibration1";
            // 
            // Accelerometer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configAccelerometerCalibration1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Accelerometer";
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigAccelerometerCalibration configAccelerometerCalibration1;
    }
}