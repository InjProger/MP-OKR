using MissionPlanner.Controls;
using System.Windows.Forms;

namespace MissionPlanner.Joystick
{
    partial class JoystickSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoystickSetup));
            this.CMB_joysticks = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CHK_elevons = new System.Windows.Forms.CheckBox();
            this.BUT_enable = new MissionPlanner.Controls.MyButton();
            this.BUT_save = new MissionPlanner.Controls.MyButton();
            this.label14 = new System.Windows.Forms.Label();
            this.chk_manualcontrol = new System.Windows.Forms.CheckBox();
            this.pbJoy = new System.Windows.Forms.PictureBox();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.tbYaw = new MissionPlanner.Controls.HorizontalProgressBar2();
            this.tbPitch = new MissionPlanner.Controls.VerticalProgressBar2();
            this.tbRoll = new MissionPlanner.Controls.HorizontalProgressBar2();
            this.tbVelocity = new MissionPlanner.Controls.VerticalProgressBar2();
            this.tbYawMin = new MissionPlanner.Controls.HorizontalProgressBar2();
            this.tbGimble = new MissionPlanner.Controls.VerticalProgressBar2();
            this.tbCameras = new MissionPlanner.Controls.VerticalProgressBar2();
            this.tbFlightMode = new MissionPlanner.Controls.VerticalProgressBar2();
            this.pictureFire = new MissionPlanner.Controls.DoublePicture.DoublePicture();
            this.pictureFuse2 = new MissionPlanner.Controls.DoublePicture.DoublePicture();
            this.pictureFuse1 = new MissionPlanner.Controls.DoublePicture.DoublePicture();
            this.pictureF2 = new MissionPlanner.Controls.DoublePicture.DoublePicture();
            this.pictureF1 = new MissionPlanner.Controls.DoublePicture.DoublePicture();
            this.timerJoy = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbJoy)).BeginInit();
            this.backgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMB_joysticks
            // 
            resources.ApplyResources(this.CMB_joysticks, "CMB_joysticks");
            this.CMB_joysticks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_joysticks.FormattingEnabled = true;
            this.CMB_joysticks.Name = "CMB_joysticks";
            this.CMB_joysticks.Click += new System.EventHandler(this.CMB_joysticks_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CHK_elevons
            // 
            resources.ApplyResources(this.CHK_elevons, "CHK_elevons");
            this.CHK_elevons.Name = "CHK_elevons";
            this.CHK_elevons.UseVisualStyleBackColor = true;
            this.CHK_elevons.CheckedChanged += new System.EventHandler(this.CHK_elevons_CheckedChanged);
            // 
            // BUT_enable
            // 
            resources.ApplyResources(this.BUT_enable, "BUT_enable");
            this.BUT_enable.Name = "BUT_enable";
            this.BUT_enable.UseVisualStyleBackColor = true;
            this.BUT_enable.Click += new System.EventHandler(this.BUT_enable_Click);
            // 
            // BUT_save
            // 
            resources.ApplyResources(this.BUT_save, "BUT_save");
            this.BUT_save.Name = "BUT_save";
            this.BUT_save.UseVisualStyleBackColor = true;
            this.BUT_save.Click += new System.EventHandler(this.BUT_save_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // chk_manualcontrol
            // 
            resources.ApplyResources(this.chk_manualcontrol, "chk_manualcontrol");
            this.chk_manualcontrol.Name = "chk_manualcontrol";
            this.chk_manualcontrol.UseVisualStyleBackColor = true;
            this.chk_manualcontrol.CheckedChanged += new System.EventHandler(this.chk_manualcontrol_CheckedChanged);
            // 
            // pbJoy
            // 
            resources.ApplyResources(this.pbJoy, "pbJoy");
            this.pbJoy.Name = "pbJoy";
            this.pbJoy.TabStop = false;
            // 
            // backgroundPanel
            // 
            resources.ApplyResources(this.backgroundPanel, "backgroundPanel");
            this.backgroundPanel.Controls.Add(this.tbYaw);
            this.backgroundPanel.Controls.Add(this.tbPitch);
            this.backgroundPanel.Controls.Add(this.tbRoll);
            this.backgroundPanel.Controls.Add(this.tbVelocity);
            this.backgroundPanel.Controls.Add(this.tbYawMin);
            this.backgroundPanel.Controls.Add(this.tbGimble);
            this.backgroundPanel.Controls.Add(this.tbCameras);
            this.backgroundPanel.Controls.Add(this.tbFlightMode);
            this.backgroundPanel.Controls.Add(this.pictureFire);
            this.backgroundPanel.Controls.Add(this.pictureFuse2);
            this.backgroundPanel.Controls.Add(this.pictureFuse1);
            this.backgroundPanel.Controls.Add(this.pictureF2);
            this.backgroundPanel.Controls.Add(this.pictureF1);
            this.backgroundPanel.Controls.Add(this.pbJoy);
            this.backgroundPanel.Name = "backgroundPanel";
            // 
            // tbYaw
            // 
            resources.ApplyResources(this.tbYaw, "tbYaw");
            this.tbYaw.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbYaw.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbYaw.DisplayScale = 1F;
            this.tbYaw.DrawLabel = true;
            this.tbYaw.Label = "";
            this.tbYaw.Maximum = 68000;
            this.tbYaw.maxline = 0;
            this.tbYaw.Minimum = 0;
            this.tbYaw.minline = 0;
            this.tbYaw.Name = "tbYaw";
            this.tbYaw.Value = 0;
            this.tbYaw.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tbPitch
            // 
            resources.ApplyResources(this.tbPitch, "tbPitch");
            this.tbPitch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbPitch.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbPitch.DisplayScale = 1F;
            this.tbPitch.DrawLabel = true;
            this.tbPitch.Label = "";
            this.tbPitch.Maximum = 68000;
            this.tbPitch.maxline = 0;
            this.tbPitch.Minimum = 0;
            this.tbPitch.minline = 0;
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.Value = 0;
            this.tbPitch.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tbRoll
            // 
            resources.ApplyResources(this.tbRoll, "tbRoll");
            this.tbRoll.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbRoll.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbRoll.DisplayScale = 1F;
            this.tbRoll.DrawLabel = true;
            this.tbRoll.Label = "";
            this.tbRoll.Maximum = 68000;
            this.tbRoll.maxline = 0;
            this.tbRoll.Minimum = 0;
            this.tbRoll.minline = 0;
            this.tbRoll.Name = "tbRoll";
            this.tbRoll.Value = 0;
            this.tbRoll.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tbVelocity
            // 
            resources.ApplyResources(this.tbVelocity, "tbVelocity");
            this.tbVelocity.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(69)))));
            this.tbVelocity.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbVelocity.DisplayScale = 1F;
            this.tbVelocity.DrawLabel = true;
            this.tbVelocity.Label = "";
            this.tbVelocity.Maximum = 68000;
            this.tbVelocity.maxline = 0;
            this.tbVelocity.Minimum = 0;
            this.tbVelocity.minline = 0;
            this.tbVelocity.Name = "tbVelocity";
            this.tbVelocity.Value = 0;
            this.tbVelocity.ValueColor = System.Drawing.Color.Magenta;
            // 
            // tbYawMin
            // 
            resources.ApplyResources(this.tbYawMin, "tbYawMin");
            this.tbYawMin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbYawMin.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbYawMin.DisplayScale = 1F;
            this.tbYawMin.DrawLabel = true;
            this.tbYawMin.Label = "";
            this.tbYawMin.Maximum = 68000;
            this.tbYawMin.maxline = 0;
            this.tbYawMin.Minimum = 0;
            this.tbYawMin.minline = 0;
            this.tbYawMin.Name = "tbYawMin";
            this.tbYawMin.Value = 0;
            this.tbYawMin.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tbGimble
            // 
            resources.ApplyResources(this.tbGimble, "tbGimble");
            this.tbGimble.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbGimble.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbGimble.DisplayScale = 1F;
            this.tbGimble.DrawLabel = true;
            this.tbGimble.Label = "";
            this.tbGimble.Maximum = 68000;
            this.tbGimble.maxline = 0;
            this.tbGimble.Minimum = 0;
            this.tbGimble.minline = 0;
            this.tbGimble.Name = "tbGimble";
            this.tbGimble.Value = 0;
            this.tbGimble.ValueColor = System.Drawing.Color.Magenta;
            // 
            // tbCameras
            // 
            resources.ApplyResources(this.tbCameras, "tbCameras");
            this.tbCameras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbCameras.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbCameras.DisplayScale = 1F;
            this.tbCameras.DrawLabel = true;
            this.tbCameras.Label = "";
            this.tbCameras.Maximum = 68000;
            this.tbCameras.maxline = 0;
            this.tbCameras.Minimum = 0;
            this.tbCameras.minline = 0;
            this.tbCameras.Name = "tbCameras";
            this.tbCameras.Value = 0;
            this.tbCameras.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // tbFlightMode
            // 
            resources.ApplyResources(this.tbFlightMode, "tbFlightMode");
            this.tbFlightMode.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.tbFlightMode.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbFlightMode.DisplayScale = 1F;
            this.tbFlightMode.DrawLabel = true;
            this.tbFlightMode.Label = "";
            this.tbFlightMode.Maximum = 68000;
            this.tbFlightMode.maxline = 0;
            this.tbFlightMode.Minimum = 0;
            this.tbFlightMode.minline = 0;
            this.tbFlightMode.Name = "tbFlightMode";
            this.tbFlightMode.Value = 0;
            this.tbFlightMode.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // pictureFire
            // 
            resources.ApplyResources(this.pictureFire, "pictureFire");
            this.pictureFire.Click = false;
            this.pictureFire.Name = "pictureFire";
            // 
            // pictureFuse2
            // 
            resources.ApplyResources(this.pictureFuse2, "pictureFuse2");
            this.pictureFuse2.Click = false;
            this.pictureFuse2.Name = "pictureFuse2";
            // 
            // pictureFuse1
            // 
            resources.ApplyResources(this.pictureFuse1, "pictureFuse1");
            this.pictureFuse1.Click = false;
            this.pictureFuse1.Name = "pictureFuse1";
            // 
            // pictureF2
            // 
            resources.ApplyResources(this.pictureF2, "pictureF2");
            this.pictureF2.Click = false;
            this.pictureF2.Name = "pictureF2";
            // 
            // pictureF1
            // 
            resources.ApplyResources(this.pictureF1, "pictureF1");
            this.pictureF1.Click = false;
            this.pictureF1.Name = "pictureF1";
            // 
            // timerJoy
            // 
            this.timerJoy.Interval = 50;
            this.timerJoy.Tick += new System.EventHandler(this.timerJoy_Tick);
            // 
            // JoystickSetup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.CMB_joysticks);
            this.Controls.Add(this.BUT_enable);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.chk_manualcontrol);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.CHK_elevons);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BUT_save);
            this.Name = "JoystickSetup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JoystickSetup_FormClosed);
            this.Load += new System.EventHandler(this.JoystickSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbJoy)).EndInit();
            this.backgroundPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMB_joysticks;
        private Controls.MyButton BUT_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CHK_elevons;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chk_manualcontrol;
        public MyButton BUT_enable;
        private PictureBox pbJoy;
        private Panel backgroundPanel;
        private Timer timerJoy;
        private Controls.DoublePicture.DoublePicture pictureF1;
        private Controls.DoublePicture.DoublePicture pictureFuse2;
        private Controls.DoublePicture.DoublePicture pictureFuse1;
        private Controls.DoublePicture.DoublePicture pictureF2;
        private Controls.DoublePicture.DoublePicture pictureFire;
        private VerticalProgressBar2 tbFlightMode;
        private VerticalProgressBar2 tbCameras;
        private VerticalProgressBar2 tbGimble;
        private HorizontalProgressBar2 tbYawMin;
        private VerticalProgressBar2 tbVelocity;
        private HorizontalProgressBar2 tbRoll;
        private VerticalProgressBar2 tbPitch;
        private HorizontalProgressBar2 tbYaw;
    }
}