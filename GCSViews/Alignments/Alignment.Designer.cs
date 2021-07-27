namespace MissionPlanner.GCSViews.Alignments
{
    partial class Alignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alignment));
            this.tlpFill = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.tlpFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFill
            // 
            resources.ApplyResources(this.tlpFill, "tlpFill");
            this.tlpFill.Controls.Add(this.btnOk, 2, 2);
            this.tlpFill.Controls.Add(this.btnUp, 1, 0);
            this.tlpFill.Controls.Add(this.btnCenter, 1, 1);
            this.tlpFill.Controls.Add(this.btnBottom, 1, 2);
            this.tlpFill.Controls.Add(this.btnRight, 2, 1);
            this.tlpFill.Controls.Add(this.btnLeft, 0, 1);
            this.tlpFill.Name = "tlpFill";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnUp
            // 
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.Name = "btnUp";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // btnCenter
            // 
            resources.ApplyResources(this.btnCenter, "btnCenter");
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.BtnCenter_Click);
            // 
            // btnBottom
            // 
            resources.ApplyResources(this.btnBottom, "btnBottom");
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.BtnBottom_Click);
            // 
            // btnRight
            // 
            resources.ApplyResources(this.btnRight, "btnRight");
            this.btnRight.Name = "btnRight";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // btnLeft
            // 
            resources.ApplyResources(this.btnLeft, "btnLeft");
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // Alignment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpFill);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alignment";
            this.ShowInTaskbar = false;
            this.tlpFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpFill;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnCenter;
    }
}