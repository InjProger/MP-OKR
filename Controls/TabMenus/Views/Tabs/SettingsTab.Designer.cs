namespace MissionPlanner.Controls.TabMenus.Views.Tabs
{
    partial class SettingsTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsTab));
            this.btnSetups = new System.Windows.Forms.Button();
            this.panelSplit1 = new System.Windows.Forms.Panel();
            this.btnControl = new System.Windows.Forms.Button();
            this.btnAlignment = new System.Windows.Forms.Button();
            this.btnCompass = new System.Windows.Forms.Button();
            this.btnAccelerometer = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnESC = new System.Windows.Forms.Button();
            this.panelSplit2 = new System.Windows.Forms.Panel();
            this.btnBattery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetups
            // 
            resources.ApplyResources(this.btnSetups, "btnSetups");
            this.btnSetups.Name = "btnSetups";
            this.btnSetups.UseVisualStyleBackColor = true;
            // 
            // panelSplit1
            // 
            resources.ApplyResources(this.panelSplit1, "panelSplit1");
            this.panelSplit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit1.Name = "panelSplit1";
            // 
            // btnControl
            // 
            resources.ApplyResources(this.btnControl, "btnControl");
            this.btnControl.Name = "btnControl";
            this.btnControl.UseVisualStyleBackColor = true;
            // 
            // btnAlignment
            // 
            resources.ApplyResources(this.btnAlignment, "btnAlignment");
            this.btnAlignment.Name = "btnAlignment";
            this.btnAlignment.UseVisualStyleBackColor = true;
            // 
            // btnCompass
            // 
            resources.ApplyResources(this.btnCompass, "btnCompass");
            this.btnCompass.Name = "btnCompass";
            this.btnCompass.UseVisualStyleBackColor = true;
            // 
            // btnAccelerometer
            // 
            resources.ApplyResources(this.btnAccelerometer, "btnAccelerometer");
            this.btnAccelerometer.Name = "btnAccelerometer";
            this.btnAccelerometer.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            resources.ApplyResources(this.btnConfig, "btnConfig");
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnESC
            // 
            resources.ApplyResources(this.btnESC, "btnESC");
            this.btnESC.Name = "btnESC";
            this.btnESC.UseVisualStyleBackColor = true;
            // 
            // panelSplit2
            // 
            resources.ApplyResources(this.panelSplit2, "panelSplit2");
            this.panelSplit2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit2.Name = "panelSplit2";
            // 
            // btnBattery
            // 
            resources.ApplyResources(this.btnBattery, "btnBattery");
            this.btnBattery.Name = "btnBattery";
            this.btnBattery.UseVisualStyleBackColor = true;
            // 
            // SettingsTab
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnBattery);
            this.Controls.Add(this.btnESC);
            this.Controls.Add(this.btnSetups);
            this.Controls.Add(this.panelSplit1);
            this.Controls.Add(this.btnControl);
            this.Controls.Add(this.btnAlignment);
            this.Controls.Add(this.btnCompass);
            this.Controls.Add(this.btnAccelerometer);
            this.Controls.Add(this.panelSplit2);
            this.Controls.Add(this.btnConfig);
            this.Name = "SettingsTab";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnSetups;
        public System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Panel panelSplit1;
        public System.Windows.Forms.Button btnAccelerometer;
        public System.Windows.Forms.Button btnCompass;
        public System.Windows.Forms.Button btnAlignment;
        public System.Windows.Forms.Button btnConfig;
        public System.Windows.Forms.Button btnESC;
        public System.Windows.Forms.Button btnBattery;
        public System.Windows.Forms.Panel panelSplit2;
    }
}
