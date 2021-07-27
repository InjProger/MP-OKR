namespace MissionPlanner.GCSViews
{
    partial class FlightParamsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightParamsForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbUAV = new System.Windows.Forms.GroupBox();
            this.gbTargetLoad = new System.Windows.Forms.GroupBox();
            this.cmbTargetLoadType = new System.Windows.Forms.ComboBox();
            this.lblTargetLoadType = new System.Windows.Forms.Label();
            this.gbWeapon = new System.Windows.Forms.GroupBox();
            this.gbContainer = new System.Windows.Forms.GroupBox();
            this.tbLoadWeight = new System.Windows.Forms.TextBox();
            this.lblLoadWeight = new System.Windows.Forms.Label();
            this.gbShell = new System.Windows.Forms.GroupBox();
            this.cmbShellType = new System.Windows.Forms.ComboBox();
            this.lblShellType = new System.Windows.Forms.Label();
            this.cmbWeaponType = new System.Windows.Forms.ComboBox();
            this.lblWeaponType = new System.Windows.Forms.Label();
            this.gbPendant = new System.Windows.Forms.GroupBox();
            this.cmbPendantType = new System.Windows.Forms.ComboBox();
            this.lblPendantType = new System.Windows.Forms.Label();
            this.gbWeather = new System.Windows.Forms.GroupBox();
            this.gbWind = new System.Windows.Forms.GroupBox();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbAzimuth = new System.Windows.Forms.TextBox();
            this.lblAzimuth = new System.Windows.Forms.Label();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbUAV.SuspendLayout();
            this.gbTargetLoad.SuspendLayout();
            this.gbWeapon.SuspendLayout();
            this.gbContainer.SuspendLayout();
            this.gbShell.SuspendLayout();
            this.gbPendant.SuspendLayout();
            this.gbWeather.SuspendLayout();
            this.gbWind.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbUAV);
            this.splitContainer.Panel1.Controls.Add(this.gbWeather);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer.Panel2.Controls.Add(this.btnOk);
            // 
            // gbUAV
            // 
            this.gbUAV.Controls.Add(this.gbTargetLoad);
            this.gbUAV.Controls.Add(this.gbWeapon);
            this.gbUAV.Controls.Add(this.gbPendant);
            resources.ApplyResources(this.gbUAV, "gbUAV");
            this.gbUAV.Name = "gbUAV";
            this.gbUAV.TabStop = false;
            // 
            // gbTargetLoad
            // 
            this.gbTargetLoad.Controls.Add(this.cmbTargetLoadType);
            this.gbTargetLoad.Controls.Add(this.lblTargetLoadType);
            resources.ApplyResources(this.gbTargetLoad, "gbTargetLoad");
            this.gbTargetLoad.Name = "gbTargetLoad";
            this.gbTargetLoad.TabStop = false;
            // 
            // cmbTargetLoadType
            // 
            this.cmbTargetLoadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetLoadType.FormattingEnabled = true;
            this.cmbTargetLoadType.Items.AddRange(new object[] {
            resources.GetString("cmbTargetLoadType.Items"),
            resources.GetString("cmbTargetLoadType.Items1"),
            resources.GetString("cmbTargetLoadType.Items2")});
            resources.ApplyResources(this.cmbTargetLoadType, "cmbTargetLoadType");
            this.cmbTargetLoadType.Name = "cmbTargetLoadType";
            this.cmbTargetLoadType.TextChanged += new System.EventHandler(this.cmbTargetLoadType_TextChanged);
            // 
            // lblTargetLoadType
            // 
            resources.ApplyResources(this.lblTargetLoadType, "lblTargetLoadType");
            this.lblTargetLoadType.Name = "lblTargetLoadType";
            // 
            // gbWeapon
            // 
            this.gbWeapon.Controls.Add(this.gbContainer);
            this.gbWeapon.Controls.Add(this.gbShell);
            this.gbWeapon.Controls.Add(this.cmbWeaponType);
            this.gbWeapon.Controls.Add(this.lblWeaponType);
            resources.ApplyResources(this.gbWeapon, "gbWeapon");
            this.gbWeapon.Name = "gbWeapon";
            this.gbWeapon.TabStop = false;
            // 
            // gbContainer
            // 
            this.gbContainer.Controls.Add(this.tbLoadWeight);
            this.gbContainer.Controls.Add(this.lblLoadWeight);
            resources.ApplyResources(this.gbContainer, "gbContainer");
            this.gbContainer.Name = "gbContainer";
            this.gbContainer.TabStop = false;
            // 
            // tbLoadWeight
            // 
            resources.ApplyResources(this.tbLoadWeight, "tbLoadWeight");
            this.tbLoadWeight.Name = "tbLoadWeight";
            // 
            // lblLoadWeight
            // 
            resources.ApplyResources(this.lblLoadWeight, "lblLoadWeight");
            this.lblLoadWeight.Name = "lblLoadWeight";
            // 
            // gbShell
            // 
            this.gbShell.Controls.Add(this.cmbShellType);
            this.gbShell.Controls.Add(this.lblShellType);
            resources.ApplyResources(this.gbShell, "gbShell");
            this.gbShell.Name = "gbShell";
            this.gbShell.TabStop = false;
            // 
            // cmbShellType
            // 
            this.cmbShellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShellType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbShellType, "cmbShellType");
            this.cmbShellType.Name = "cmbShellType";
            // 
            // lblShellType
            // 
            resources.ApplyResources(this.lblShellType, "lblShellType");
            this.lblShellType.Name = "lblShellType";
            // 
            // cmbWeaponType
            // 
            this.cmbWeaponType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeaponType.FormattingEnabled = true;
            this.cmbWeaponType.Items.AddRange(new object[] {
            resources.GetString("cmbWeaponType.Items")});
            resources.ApplyResources(this.cmbWeaponType, "cmbWeaponType");
            this.cmbWeaponType.Name = "cmbWeaponType";
            // 
            // lblWeaponType
            // 
            resources.ApplyResources(this.lblWeaponType, "lblWeaponType");
            this.lblWeaponType.Name = "lblWeaponType";
            // 
            // gbPendant
            // 
            this.gbPendant.Controls.Add(this.cmbPendantType);
            this.gbPendant.Controls.Add(this.lblPendantType);
            resources.ApplyResources(this.gbPendant, "gbPendant");
            this.gbPendant.Name = "gbPendant";
            this.gbPendant.TabStop = false;
            // 
            // cmbPendantType
            // 
            this.cmbPendantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPendantType.FormattingEnabled = true;
            this.cmbPendantType.Items.AddRange(new object[] {
            resources.GetString("cmbPendantType.Items"),
            resources.GetString("cmbPendantType.Items1")});
            resources.ApplyResources(this.cmbPendantType, "cmbPendantType");
            this.cmbPendantType.Name = "cmbPendantType";
            // 
            // lblPendantType
            // 
            resources.ApplyResources(this.lblPendantType, "lblPendantType");
            this.lblPendantType.Name = "lblPendantType";
            // 
            // gbWeather
            // 
            this.gbWeather.Controls.Add(this.gbWind);
            this.gbWeather.Controls.Add(this.tbTemp);
            this.gbWeather.Controls.Add(this.lblTemperature);
            resources.ApplyResources(this.gbWeather, "gbWeather");
            this.gbWeather.Name = "gbWeather";
            this.gbWeather.TabStop = false;
            // 
            // gbWind
            // 
            this.gbWind.Controls.Add(this.tbSpeed);
            this.gbWind.Controls.Add(this.lblSpeed);
            this.gbWind.Controls.Add(this.tbAzimuth);
            this.gbWind.Controls.Add(this.lblAzimuth);
            resources.ApplyResources(this.gbWind, "gbWind");
            this.gbWind.Name = "gbWind";
            this.gbWind.TabStop = false;
            // 
            // tbSpeed
            // 
            resources.ApplyResources(this.tbSpeed, "tbSpeed");
            this.tbSpeed.Name = "tbSpeed";
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.Name = "lblSpeed";
            // 
            // tbAzimuth
            // 
            resources.ApplyResources(this.tbAzimuth, "tbAzimuth");
            this.tbAzimuth.Name = "tbAzimuth";
            // 
            // lblAzimuth
            // 
            resources.ApplyResources(this.lblAzimuth, "lblAzimuth");
            this.lblAzimuth.Name = "lblAzimuth";
            // 
            // tbTemp
            // 
            resources.ApplyResources(this.tbTemp, "tbTemp");
            this.tbTemp.Name = "tbTemp";
            // 
            // lblTemperature
            // 
            resources.ApplyResources(this.lblTemperature, "lblTemperature");
            this.lblTemperature.Name = "lblTemperature";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FlightParamsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlightParamsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FlightParamsForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlightParamsForm_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbUAV.ResumeLayout(false);
            this.gbTargetLoad.ResumeLayout(false);
            this.gbTargetLoad.PerformLayout();
            this.gbWeapon.ResumeLayout(false);
            this.gbWeapon.PerformLayout();
            this.gbContainer.ResumeLayout(false);
            this.gbContainer.PerformLayout();
            this.gbShell.ResumeLayout(false);
            this.gbShell.PerformLayout();
            this.gbPendant.ResumeLayout(false);
            this.gbPendant.PerformLayout();
            this.gbWeather.ResumeLayout(false);
            this.gbWeather.PerformLayout();
            this.gbWind.ResumeLayout(false);
            this.gbWind.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbWeather;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.GroupBox gbWind;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.TextBox tbAzimuth;
        private System.Windows.Forms.Label lblAzimuth;
        private System.Windows.Forms.GroupBox gbUAV;
        private System.Windows.Forms.GroupBox gbPendant;
        private System.Windows.Forms.Label lblPendantType;
        private System.Windows.Forms.ComboBox cmbPendantType;
        private System.Windows.Forms.GroupBox gbWeapon;
        private System.Windows.Forms.ComboBox cmbWeaponType;
        private System.Windows.Forms.Label lblWeaponType;
        private System.Windows.Forms.GroupBox gbTargetLoad;
        private System.Windows.Forms.ComboBox cmbTargetLoadType;
        private System.Windows.Forms.Label lblTargetLoadType;
        private System.Windows.Forms.GroupBox gbShell;
        private System.Windows.Forms.ComboBox cmbShellType;
        private System.Windows.Forms.Label lblShellType;
        private System.Windows.Forms.GroupBox gbContainer;
        private System.Windows.Forms.Label lblLoadWeight;
        private System.Windows.Forms.TextBox tbLoadWeight;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}