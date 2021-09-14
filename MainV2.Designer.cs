using System;
using System.IO;
using System.Windows.Forms;

namespace MissionPlanner
{
    partial class MainV2
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
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFlightData = new System.Windows.Forms.ToolStripButton();
            this.MenuFlightPlanner = new System.Windows.Forms.ToolStripButton();
            this.MenuInitConfig = new System.Windows.Forms.ToolStripButton();
            this.MenuConfigTune = new System.Windows.Forms.ToolStripButton();
            this.MenuSimulation = new System.Windows.Forms.ToolStripButton();
            this.MenuHelp = new System.Windows.Forms.ToolStripButton();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.MenuAction = new System.Windows.Forms.ToolStripButton();
            this.MenuArduPilot = new System.Windows.Forms.ToolStripButton();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAerodrome = new System.Windows.Forms.Button();
            this.btnTakeoff = new System.Windows.Forms.Button();
            this.btnLanding = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btnFlyPoint = new System.Windows.Forms.Button();
            this.lblRSSI = new System.Windows.Forms.Label();
            this.pictureRSSI = new System.Windows.Forms.PictureBox();
            this.lblEkfStatus = new System.Windows.Forms.Label();
            this.btnNavigationLights = new System.Windows.Forms.Button();
            this.recordOnPicture = new System.Windows.Forms.PictureBox();
            this.lblGpsStatus = new System.Windows.Forms.Label();
            this.tabMenuView = new MissionPlanner.Controls.TabMenus.Views.TabMenuView();
            this.status1 = new MissionPlanner.Controls.Status();
            this.toolStripConnectionControl = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRSSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            resources.ApplyResources(this.miniToolStrip, "miniToolStrip");
            this.miniToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(45, 39);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.ShowItemToolTips = true;
            // 
            // MenuFlightData
            // 
            this.MenuFlightData.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightData, "MenuFlightData");
            this.MenuFlightData.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightData.Name = "MenuFlightData";
            this.MenuFlightData.Click += new System.EventHandler(this.MenuFlightData_Click);
            // 
            // MenuFlightPlanner
            // 
            this.MenuFlightPlanner.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuFlightPlanner, "MenuFlightPlanner");
            this.MenuFlightPlanner.Margin = new System.Windows.Forms.Padding(0);
            this.MenuFlightPlanner.Name = "MenuFlightPlanner";
            this.MenuFlightPlanner.Click += new System.EventHandler(this.MenuFlightPlanner_Click);
            // 
            // MenuInitConfig
            // 
            this.MenuInitConfig.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuInitConfig, "MenuInitConfig");
            this.MenuInitConfig.Margin = new System.Windows.Forms.Padding(0);
            this.MenuInitConfig.Name = "MenuInitConfig";
            this.MenuInitConfig.Click += new System.EventHandler(this.MenuSetup_Click);
            // 
            // MenuConfigTune
            // 
            this.MenuConfigTune.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConfigTune, "MenuConfigTune");
            this.MenuConfigTune.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConfigTune.Name = "MenuConfigTune";
            this.MenuConfigTune.Click += new System.EventHandler(this.MenuTuning_Click);
            // 
            // MenuSimulation
            // 
            this.MenuSimulation.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuSimulation, "MenuSimulation");
            this.MenuSimulation.Margin = new System.Windows.Forms.Padding(0);
            this.MenuSimulation.Name = "MenuSimulation";
            this.MenuSimulation.Click += new System.EventHandler(this.MenuSimulation_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuHelp, "MenuHelp");
            this.MenuHelp.Margin = new System.Windows.Forms.Padding(0);
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuConnect.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // MenuAction
            // 
            this.MenuAction.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuAction.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.MenuAction, "MenuAction");
            this.MenuAction.Margin = new System.Windows.Forms.Padding(0);
            this.MenuAction.Name = "MenuAction";
            this.MenuAction.Click += new System.EventHandler(this.MenuAction_Click);
            // 
            // MenuArduPilot
            // 
            this.MenuArduPilot.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuArduPilot, "MenuArduPilot");
            this.MenuArduPilot.BackColor = System.Drawing.Color.Transparent;
            this.MenuArduPilot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuArduPilot.ForeColor = System.Drawing.Color.White;
            this.MenuArduPilot.Image = global::MissionPlanner.Properties.Resources._0d92fed790a3a70170e61a86db103f399a595c70;
            this.MenuArduPilot.Margin = new System.Windows.Forms.Padding(0);
            this.MenuArduPilot.Name = "MenuArduPilot";
            this.MenuArduPilot.Click += new System.EventHandler(this.MenuArduPilot_Click);
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(45, 39);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFlightData,
            this.MenuFlightPlanner,
            this.MenuInitConfig,
            this.MenuConfigTune,
            this.MenuSimulation,
            this.MenuHelp,
            this.MenuConnect,
            this.MenuAction,
            this.toolStripConnectionControl,
            this.MenuArduPilot});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = true;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            this.MainMenu.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnDisconnect
            // 
            resources.ApplyResources(this.btnDisconnect, "btnDisconnect");
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // btnAerodrome
            // 
            resources.ApplyResources(this.btnAerodrome, "btnAerodrome");
            this.btnAerodrome.Name = "btnAerodrome";
            this.btnAerodrome.UseVisualStyleBackColor = true;
            this.btnAerodrome.Click += new System.EventHandler(this.BtnAerodrome_Click);
            // 
            // btnTakeoff
            // 
            resources.ApplyResources(this.btnTakeoff, "btnTakeoff");
            this.btnTakeoff.Name = "btnTakeoff";
            this.btnTakeoff.UseVisualStyleBackColor = true;
            this.btnTakeoff.Click += new System.EventHandler(this.BtnTakeoff_Click);
            // 
            // btnLanding
            // 
            resources.ApplyResources(this.btnLanding, "btnLanding");
            this.btnLanding.Name = "btnLanding";
            this.btnLanding.UseVisualStyleBackColor = true;
            this.btnLanding.Click += new System.EventHandler(this.BtnLanding_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // btnFlyPoint
            // 
            resources.ApplyResources(this.btnFlyPoint, "btnFlyPoint");
            this.btnFlyPoint.Name = "btnFlyPoint";
            this.btnFlyPoint.UseVisualStyleBackColor = true;
            this.btnFlyPoint.Click += new System.EventHandler(this.BtnFlyPoint_Click);
            // 
            // lblRSSI
            // 
            resources.ApplyResources(this.lblRSSI, "lblRSSI");
            this.lblRSSI.Name = "lblRSSI";
            // 
            // pictureRSSI
            // 
            resources.ApplyResources(this.pictureRSSI, "pictureRSSI");
            this.pictureRSSI.Name = "pictureRSSI";
            this.pictureRSSI.TabStop = false;
            // 
            // lblEkfStatus
            // 
            resources.ApplyResources(this.lblEkfStatus, "lblEkfStatus");
            this.lblEkfStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblEkfStatus.Name = "lblEkfStatus";
            // 
            // btnNavigationLights
            // 
            resources.ApplyResources(this.btnNavigationLights, "btnNavigationLights");
            this.btnNavigationLights.Name = "btnNavigationLights";
            this.btnNavigationLights.UseVisualStyleBackColor = true;
            this.btnNavigationLights.Click += new System.EventHandler(this.BtnNavigationLights_Click);
            // 
            // recordOnPicture
            // 
            resources.ApplyResources(this.recordOnPicture, "recordOnPicture");
            this.recordOnPicture.Name = "recordOnPicture";
            this.recordOnPicture.TabStop = false;
            // 
            // lblGpsStatus
            // 
            resources.ApplyResources(this.lblGpsStatus, "lblGpsStatus");
            this.lblGpsStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGpsStatus.Name = "lblGpsStatus";
            this.lblGpsStatus.Click += new System.EventHandler(this.lblGpsStatus_Click);
            // 
            // tabMenuView
            // 
            this.tabMenuView.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tabMenuView, "tabMenuView");
            this.tabMenuView.Expand = true;
            this.tabMenuView.IsEditFlyToPoint = false;
            this.tabMenuView.Name = "tabMenuView";
            // 
            // status1
            // 
            resources.ApplyResources(this.status1, "status1");
            this.status1.Name = "status1";
            this.status1.Percent = 0D;
            // 
            // toolStripConnectionControl
            // 
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            // 
            // MainV2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGpsStatus);
            this.Controls.Add(this.recordOnPicture);
            this.Controls.Add(this.btnNavigationLights);
            this.Controls.Add(this.lblEkfStatus);
            this.Controls.Add(this.pictureRSSI);
            this.Controls.Add(this.lblRSSI);
            this.Controls.Add(this.btnFlyPoint);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnAerodrome);
            this.Controls.Add(this.tabMenuView);
            this.Controls.Add(this.status1);
            this.Controls.Add(this.btnLanding);
            this.Controls.Add(this.btnTakeoff);
            this.KeyPreview = true;
            this.MainMenuStrip = this.miniToolStrip;
            this.MinimizeBox = false;
            this.Name = "MainV2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainV2_FormClosed);
            this.Load += new System.EventHandler(this.MainV2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainV2_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRSSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordOnPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip miniToolStrip;
        public ToolStripButton MenuFlightData;
        public ToolStripButton MenuFlightPlanner;
        public ToolStripButton MenuInitConfig;
        public ToolStripButton MenuConfigTune;
        public ToolStripButton MenuSimulation;
        public ToolStripButton MenuHelp;
        public ToolStripButton MenuConnect;
        public ToolStripButton MenuAction;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        public ToolStripButton MenuArduPilot;
        public Controls.Status status1;
        public MenuStrip MainMenu;
        public Button btnConnect;
        public Button btnDisconnect;
        public Button btnHome;
        public Button btnAerodrome;
        public Button btnTakeoff;
        public Button btnLanding;
        private Timer timer1;
        private Timer timer2;
        private Controls.TabMenus.Views.TabMenuView tabMenuView;
        private Button btnFlyPoint;
        private Label lblRSSI;
        private PictureBox pictureRSSI;
        private Label lblEkfStatus;
        public Button btnNavigationLights;
        private PictureBox recordOnPicture;
        private Label lblGpsStatus;
    }
}