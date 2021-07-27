namespace MissionPlanner.GCSViews.NavigationLights
{

    partial class NavigationLights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationLights));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnFlicker = new System.Windows.Forms.Button();
            this.btnLight = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.btnCancel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnOff, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.btnFlicker, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.btnLight, 0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOff
            // 
            resources.ApplyResources(this.btnOff, "btnOff");
            this.btnOff.Name = "btnOff";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnFlicker
            // 
            resources.ApplyResources(this.btnFlicker, "btnFlicker");
            this.btnFlicker.Name = "btnFlicker";
            this.btnFlicker.UseVisualStyleBackColor = true;
            this.btnFlicker.Click += new System.EventHandler(this.btnFlicker_Click);
            // 
            // btnLight
            // 
            resources.ApplyResources(this.btnLight, "btnLight");
            this.btnLight.Name = "btnLight";
            this.btnLight.UseVisualStyleBackColor = true;
            this.btnLight.Click += new System.EventHandler(this.btnLight_Click);
            // 
            // NavigationLights
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NavigationLights";
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnFlicker;
        private System.Windows.Forms.Button btnLight;
    }
}