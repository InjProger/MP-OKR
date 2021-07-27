﻿using MissionPlanner.GCSViews.ConfigurationView;

namespace MissionPlanner.GCSViews
{
    partial class BatteryMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
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
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryMonitor));
            this.configBatteryMonitoring1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigBatteryMonitoring();
            this.SuspendLayout();
            // 
            // configBatteryMonitoring1
            // 
            resources.ApplyResources(this.configBatteryMonitoring1, "configBatteryMonitoring1");
            this.configBatteryMonitoring1.Name = "configBatteryMonitoring1";
            // 
            // BatteryMonitor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configBatteryMonitoring1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatteryMonitor";
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigBatteryMonitoring configBatteryMonitoring1;
    }
}