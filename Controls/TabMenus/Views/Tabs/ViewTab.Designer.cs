namespace MissionPlanner.Controls.TabMenus.Views.Tabs
{
    partial class ViewTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTab));
            this.btnHome = new System.Windows.Forms.Button();
            this.panelSplit1 = new System.Windows.Forms.Panel();
            this.btnUAV = new System.Windows.Forms.Button();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.btnStartPlace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // panelSplit1
            // 
            this.panelSplit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panelSplit1, "panelSplit1");
            this.panelSplit1.Name = "panelSplit1";
            // 
            // btnUAV
            // 
            resources.ApplyResources(this.btnUAV, "btnUAV");
            this.btnUAV.Name = "btnUAV";
            this.btnUAV.UseVisualStyleBackColor = true;
            // 
            // btnLoadMap
            // 
            resources.ApplyResources(this.btnLoadMap, "btnLoadMap");
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            // 
            // btnStartPlace
            // 
            resources.ApplyResources(this.btnStartPlace, "btnStartPlace");
            this.btnStartPlace.Name = "btnStartPlace";
            this.btnStartPlace.UseVisualStyleBackColor = true;
            // 
            // ViewTab
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnStartPlace);
            this.Controls.Add(this.btnLoadMap);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnUAV);
            this.Controls.Add(this.panelSplit1);
            this.Name = "ViewTab";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panelSplit1;
        public System.Windows.Forms.Button btnUAV;
        public System.Windows.Forms.Button btnLoadMap;
        public System.Windows.Forms.Button btnStartPlace;
    }
}
