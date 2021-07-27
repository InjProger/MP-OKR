namespace MissionPlanner.GCSViews.FlyToPoint.Views
{
    partial class FlyToPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlyToPoint));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tcCoordinates = new System.Windows.Forms.TabControl();
            this.tpMap = new System.Windows.Forms.TabPage();
            this.tlpOnMap = new System.Windows.Forms.TableLayoutPanel();
            this.btnOnMap = new System.Windows.Forms.Button();
            this.tpCoordinates = new System.Windows.Forms.TabPage();
            this.tlpCoordinates = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.tbLongitude = new System.Windows.Forms.TextBox();
            this.tpAzimuth = new System.Windows.Forms.TabPage();
            this.tlpAzimuth = new System.Windows.Forms.TableLayoutPanel();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.tbAngle = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tcCoordinates.SuspendLayout();
            this.tpMap.SuspendLayout();
            this.tlpOnMap.SuspendLayout();
            this.tpCoordinates.SuspendLayout();
            this.tlpCoordinates.SuspendLayout();
            this.tpAzimuth.SuspendLayout();
            this.tlpAzimuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.tcCoordinates, 0, 0);
            this.tlpMain.Controls.Add(this.btnOk, 0, 1);
            this.tlpMain.Controls.Add(this.btnCancel, 1, 1);
            this.tlpMain.Name = "tlpMain";
            // 
            // tcCoordinates
            // 
            resources.ApplyResources(this.tcCoordinates, "tcCoordinates");
            this.tlpMain.SetColumnSpan(this.tcCoordinates, 2);
            this.tcCoordinates.Controls.Add(this.tpMap);
            this.tcCoordinates.Controls.Add(this.tpCoordinates);
            this.tcCoordinates.Controls.Add(this.tpAzimuth);
            this.tcCoordinates.Name = "tcCoordinates";
            this.tcCoordinates.SelectedIndex = 0;
            // 
            // tpMap
            // 
            resources.ApplyResources(this.tpMap, "tpMap");
            this.tpMap.Controls.Add(this.tlpOnMap);
            this.tpMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpMap.Name = "tpMap";
            this.tpMap.UseVisualStyleBackColor = true;
            // 
            // tlpOnMap
            // 
            resources.ApplyResources(this.tlpOnMap, "tlpOnMap");
            this.tlpOnMap.Controls.Add(this.btnOnMap, 1, 0);
            this.tlpOnMap.Name = "tlpOnMap";
            // 
            // btnOnMap
            // 
            resources.ApplyResources(this.btnOnMap, "btnOnMap");
            this.btnOnMap.Name = "btnOnMap";
            this.btnOnMap.UseVisualStyleBackColor = true;
            this.btnOnMap.Click += new System.EventHandler(this.BtnOnMap_Click);
            // 
            // tpCoordinates
            // 
            resources.ApplyResources(this.tpCoordinates, "tpCoordinates");
            this.tpCoordinates.Controls.Add(this.tlpCoordinates);
            this.tpCoordinates.Name = "tpCoordinates";
            this.tpCoordinates.UseVisualStyleBackColor = true;
            // 
            // tlpCoordinates
            // 
            resources.ApplyResources(this.tlpCoordinates, "tlpCoordinates");
            this.tlpCoordinates.Controls.Add(this.lblLatitude, 0, 0);
            this.tlpCoordinates.Controls.Add(this.lblLongitude, 0, 1);
            this.tlpCoordinates.Controls.Add(this.tbLatitude, 1, 0);
            this.tlpCoordinates.Controls.Add(this.tbLongitude, 1, 1);
            this.tlpCoordinates.Name = "tlpCoordinates";
            // 
            // lblLatitude
            // 
            resources.ApplyResources(this.lblLatitude, "lblLatitude");
            this.lblLatitude.Name = "lblLatitude";
            // 
            // lblLongitude
            // 
            resources.ApplyResources(this.lblLongitude, "lblLongitude");
            this.lblLongitude.Name = "lblLongitude";
            // 
            // tbLatitude
            // 
            resources.ApplyResources(this.tbLatitude, "tbLatitude");
            this.tbLatitude.Name = "tbLatitude";
            // 
            // tbLongitude
            // 
            resources.ApplyResources(this.tbLongitude, "tbLongitude");
            this.tbLongitude.Name = "tbLongitude";
            // 
            // tpAzimuth
            // 
            resources.ApplyResources(this.tpAzimuth, "tpAzimuth");
            this.tpAzimuth.Controls.Add(this.tlpAzimuth);
            this.tpAzimuth.Name = "tpAzimuth";
            this.tpAzimuth.UseVisualStyleBackColor = true;
            // 
            // tlpAzimuth
            // 
            resources.ApplyResources(this.tlpAzimuth, "tlpAzimuth");
            this.tlpAzimuth.Controls.Add(this.lblDistance, 0, 0);
            this.tlpAzimuth.Controls.Add(this.lblAngle, 0, 1);
            this.tlpAzimuth.Controls.Add(this.tbDistance, 1, 0);
            this.tlpAzimuth.Controls.Add(this.tbAngle, 1, 1);
            this.tlpAzimuth.Name = "tlpAzimuth";
            // 
            // lblDistance
            // 
            resources.ApplyResources(this.lblDistance, "lblDistance");
            this.lblDistance.Name = "lblDistance";
            // 
            // lblAngle
            // 
            resources.ApplyResources(this.lblAngle, "lblAngle");
            this.lblAngle.Name = "lblAngle";
            // 
            // tbDistance
            // 
            resources.ApplyResources(this.tbDistance, "tbDistance");
            this.tbDistance.Name = "tbDistance";
            // 
            // tbAngle
            // 
            resources.ApplyResources(this.tbAngle, "tbAngle");
            this.tbAngle.Name = "tbAngle";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FlyToPoint
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlyToPoint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tlpMain.ResumeLayout(false);
            this.tcCoordinates.ResumeLayout(false);
            this.tpMap.ResumeLayout(false);
            this.tlpOnMap.ResumeLayout(false);
            this.tpCoordinates.ResumeLayout(false);
            this.tlpCoordinates.ResumeLayout(false);
            this.tlpCoordinates.PerformLayout();
            this.tpAzimuth.ResumeLayout(false);
            this.tlpAzimuth.ResumeLayout(false);
            this.tlpAzimuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tcCoordinates;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.TableLayoutPanel tlpCoordinates;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox tbLatitude;
        private System.Windows.Forms.TextBox tbLongitude;
        private System.Windows.Forms.TableLayoutPanel tlpOnMap;
        public System.Windows.Forms.Button btnOnMap;
        private System.Windows.Forms.TabPage tpCoordinates;
        private System.Windows.Forms.TableLayoutPanel tlpAzimuth;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.TextBox tbAngle;
        private System.Windows.Forms.TabPage tpAzimuth;
    }
}