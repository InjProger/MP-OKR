namespace MissionPlanner.Controls.TabMenus.Views.Tabs
{
    partial class TaskTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTab));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelSplit1 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelSplit2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelSplit3 = new System.Windows.Forms.Panel();
            this.btnCalcOn = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panelSplit4 = new System.Windows.Forms.Panel();
            this.btnArm = new System.Windows.Forms.Button();
            this.btnDisarm = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // panelSplit1
            // 
            resources.ApplyResources(this.panelSplit1, "panelSplit1");
            this.panelSplit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit1.Name = "panelSplit1";
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // panelSplit2
            // 
            resources.ApplyResources(this.panelSplit2, "panelSplit2");
            this.panelSplit2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit2.Name = "panelSplit2";
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // panelSplit3
            // 
            resources.ApplyResources(this.panelSplit3, "panelSplit3");
            this.panelSplit3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit3.Name = "panelSplit3";
            // 
            // btnCalcOn
            // 
            resources.ApplyResources(this.btnCalcOn, "btnCalcOn");
            this.btnCalcOn.Name = "btnCalcOn";
            this.btnCalcOn.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // panelSplit4
            // 
            resources.ApplyResources(this.panelSplit4, "panelSplit4");
            this.panelSplit4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSplit4.Name = "panelSplit4";
            // 
            // btnArm
            // 
            resources.ApplyResources(this.btnArm, "btnArm");
            this.btnArm.Name = "btnArm";
            this.btnArm.UseVisualStyleBackColor = true;
            // 
            // btnDisarm
            // 
            resources.ApplyResources(this.btnDisarm, "btnDisarm");
            this.btnDisarm.Name = "btnDisarm";
            this.btnDisarm.UseVisualStyleBackColor = true;
            // 
            // btnMessages
            // 
            resources.ApplyResources(this.btnMessages, "btnMessages");
            this.btnMessages.Name = "btnMessages";
            this.btnMessages.UseVisualStyleBackColor = true;
            // 
            // TaskTab
            // 
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnMessages);
            this.Controls.Add(this.btnArm);
            this.Controls.Add(this.btnDisarm);
            this.Controls.Add(this.panelSplit4);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCalcOn);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelSplit1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panelSplit2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelSplit3);
            this.Name = "TaskTab";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnOpen;
        public System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panelSplit1;
        private System.Windows.Forms.Panel panelSplit2;
        public System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelSplit3;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnCalcOn;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panelSplit4;
        public System.Windows.Forms.Button btnArm;
        public System.Windows.Forms.Button btnDisarm;
        public System.Windows.Forms.Button btnMessages;
    }
}
