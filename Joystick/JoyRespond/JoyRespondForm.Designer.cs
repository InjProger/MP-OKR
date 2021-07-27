namespace MissionPlanner.Joystick.JoyRespond
{

    partial class JoyRespondForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoyRespondForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnUav = new System.Windows.Forms.Button();
            this.btnControl = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.btnUav, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnControl, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // btnUav
            // 
            resources.ApplyResources(this.btnUav, "btnUav");
            this.btnUav.Name = "btnUav";
            this.btnUav.UseVisualStyleBackColor = true;
            this.btnUav.Click += new System.EventHandler(this.btnUav_Click);
            // 
            // btnControl
            // 
            resources.ApplyResources(this.btnControl, "btnControl");
            this.btnControl.Name = "btnControl";
            this.btnControl.UseVisualStyleBackColor = true;
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // JoyRespondForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JoyRespondForm";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnUav;
        private System.Windows.Forms.Button btnControl;
    }
}