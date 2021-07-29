namespace MissionPlanner.Controls.TabMenus.Views
{
    partial class TabMenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabMenuView));
            this.pbTabUp = new System.Windows.Forms.PictureBox();
            this.pbTabDown = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.taskTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.TaskTab();
            this.viewTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.ViewTab();
            this.airfieldsTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.AirfieldsTab();
            this.settingsTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.SettingsTab();
            this.blackBoxTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.BlackBoxTab();
            this.btnBlackBox = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.btnSettings = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.btnAirfields = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.btnView = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.btnTask = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.panelMapEdit = new System.Windows.Forms.Panel();
            this.btnMapEditing = new MissionPlanner.Controls.Buttons.ClickedButton();
            this.mapEditTab = new MissionPlanner.Controls.TabMenus.Views.Tabs.MapEditTab();
            ((System.ComponentModel.ISupportInitialize)(this.pbTabUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTabDown)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelMapEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbTabUp
            // 
            resources.ApplyResources(this.pbTabUp, "pbTabUp");
            this.pbTabUp.Name = "pbTabUp";
            this.pbTabUp.TabStop = false;
            this.pbTabUp.Click += new System.EventHandler(this.PbTabUp_Click);
            // 
            // pbTabDown
            // 
            resources.ApplyResources(this.pbTabDown, "pbTabDown");
            this.pbTabDown.Name = "pbTabDown";
            this.pbTabDown.TabStop = false;
            this.pbTabDown.Click += new System.EventHandler(this.PbTabDown_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.taskTab);
            this.panelMenu.Controls.Add(this.pbTabDown);
            this.panelMenu.Controls.Add(this.pbTabUp);
            this.panelMenu.Controls.Add(this.viewTab);
            this.panelMenu.Controls.Add(this.airfieldsTab);
            this.panelMenu.Controls.Add(this.settingsTab);
            this.panelMenu.Controls.Add(this.blackBoxTab);
            this.panelMenu.Controls.Add(this.btnBlackBox);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnAirfields);
            this.panelMenu.Controls.Add(this.btnView);
            this.panelMenu.Controls.Add(this.btnTask);
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.Name = "panelMenu";
            // 
            // taskTab
            // 
            this.taskTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.taskTab, "taskTab");
            this.taskTab.Name = "taskTab";
            // 
            // viewTab
            // 
            this.viewTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.viewTab, "viewTab");
            this.viewTab.Name = "viewTab";
            // 
            // airfieldsTab
            // 
            this.airfieldsTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.airfieldsTab, "airfieldsTab");
            this.airfieldsTab.Name = "airfieldsTab";
            // 
            // settingsTab
            // 
            this.settingsTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.Name = "settingsTab";
            // 
            // blackBoxTab
            // 
            this.blackBoxTab.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.blackBoxTab, "blackBoxTab");
            this.blackBoxTab.Name = "blackBoxTab";
            // 
            // btnBlackBox
            // 
            this.btnBlackBox.Clicked = false;
            resources.ApplyResources(this.btnBlackBox, "btnBlackBox");
            this.btnBlackBox.Name = "btnBlackBox";
            this.btnBlackBox.Tag = "4";
            this.btnBlackBox.UseVisualStyleBackColor = true;
            this.btnBlackBox.Click += new System.EventHandler(this.BtnBlackBox_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Clicked = false;
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Tag = "3";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnAirfields
            // 
            this.btnAirfields.Clicked = false;
            resources.ApplyResources(this.btnAirfields, "btnAirfields");
            this.btnAirfields.Name = "btnAirfields";
            this.btnAirfields.Tag = "2";
            this.btnAirfields.UseVisualStyleBackColor = true;
            this.btnAirfields.Click += new System.EventHandler(this.BtnAirfields_Click);
            // 
            // btnView
            // 
            this.btnView.Clicked = false;
            resources.ApplyResources(this.btnView, "btnView");
            this.btnView.Name = "btnView";
            this.btnView.Tag = "1";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // btnTask
            // 
            this.btnTask.Clicked = true;
            resources.ApplyResources(this.btnTask, "btnTask");
            this.btnTask.Name = "btnTask";
            this.btnTask.Tag = "0";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.BtnTask_Click);
            // 
            // panelMapEdit
            // 
            this.panelMapEdit.Controls.Add(this.btnMapEditing);
            this.panelMapEdit.Controls.Add(this.mapEditTab);
            resources.ApplyResources(this.panelMapEdit, "panelMapEdit");
            this.panelMapEdit.Name = "panelMapEdit";
            // 
            // btnMapEditing
            // 
            this.btnMapEditing.Clicked = true;
            resources.ApplyResources(this.btnMapEditing, "btnMapEditing");
            this.btnMapEditing.Name = "btnMapEditing";
            this.btnMapEditing.Tag = "0";
            this.btnMapEditing.UseVisualStyleBackColor = true;
            // 
            // mapEditTab
            // 
            this.mapEditTab.BackColor = System.Drawing.Color.Transparent;
            this.mapEditTab.FlyToPointVisible = false;
            resources.ApplyResources(this.mapEditTab, "mapEditTab");
            this.mapEditTab.Name = "mapEditTab";
            this.mapEditTab.Result = MissionPlanner.Controls.TabMenus.Views.Tabs.EResult.Ok;
            // 
            // TabMenuView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelMapEdit);
            this.Name = "TabMenuView";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.pbTabUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTabDown)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMapEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTabUp;
        private System.Windows.Forms.PictureBox pbTabDown;
        public Buttons.ClickedButton btnView;
        public Buttons.ClickedButton btnAirfields;
        public Buttons.ClickedButton btnTask;
        public Buttons.ClickedButton btnSettings;
        public Buttons.ClickedButton btnBlackBox;
        public Tabs.AirfieldsTab airfieldsTab;
        public Tabs.SettingsTab settingsTab;
        public Tabs.BlackBoxTab blackBoxTab;
        public Tabs.ViewTab viewTab;
        public System.Windows.Forms.Panel panelMenu;
        public System.Windows.Forms.Panel panelMapEdit;
        public Tabs.MapEditTab mapEditTab;
        public Buttons.ClickedButton btnMapEditing;
        public Tabs.TaskTab taskTab;
    }
}
