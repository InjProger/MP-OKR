using MissionPlanner.Controls.TextBoxes;

using MissionPlanner.Controls.Buttons;

namespace MissionPlanner.GCSViews.Connections.Views
{
    partial class ConnectionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionView));
            this.gbUavModel = new System.Windows.Forms.GroupBox();
            this.cmbUavModel = new System.Windows.Forms.ComboBox();
            this.btnNoConnect = new System.Windows.Forms.Button();
            this.tlpRows = new System.Windows.Forms.TableLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.pPayload = new System.Windows.Forms.Panel();
            this.cbPayload = new System.Windows.Forms.CheckBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.cmbWeight = new System.Windows.Forms.ComboBox();
            this.gbLeftWeapon = new System.Windows.Forms.GroupBox();
            this.rbNoneLeft = new System.Windows.Forms.RadioButton();
            this.rbUnloadedLeft = new System.Windows.Forms.RadioButton();
            this.rbEquivalentLeft = new System.Windows.Forms.RadioButton();
            this.rbCombatLeft = new System.Windows.Forms.RadioButton();
            this.gbRightWeapon = new System.Windows.Forms.GroupBox();
            this.rbNoneRight = new System.Windows.Forms.RadioButton();
            this.rbUnloadedRight = new System.Windows.Forms.RadioButton();
            this.rbEquivalentRight = new System.Windows.Forms.RadioButton();
            this.rbCombatRight = new System.Windows.Forms.RadioButton();
            this.tlpCols = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbUavModel.SuspendLayout();
            this.tlpRows.SuspendLayout();
            this.panel.SuspendLayout();
            this.pPayload.SuspendLayout();
            this.gbLeftWeapon.SuspendLayout();
            this.gbRightWeapon.SuspendLayout();
            this.tlpCols.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUavModel
            // 
            this.gbUavModel.Controls.Add(this.cmbUavModel);
            resources.ApplyResources(this.gbUavModel, "gbUavModel");
            this.gbUavModel.Name = "gbUavModel";
            this.gbUavModel.TabStop = false;
            // 
            // cmbUavModel
            // 
            resources.ApplyResources(this.cmbUavModel, "cmbUavModel");
            this.cmbUavModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUavModel.FormattingEnabled = true;
            this.cmbUavModel.Name = "cmbUavModel";
            this.cmbUavModel.SelectedIndexChanged += new System.EventHandler(this.CmbUavModel_SelectedIndexChanged);
            // 
            // btnNoConnect
            // 
            this.btnNoConnect.DialogResult = System.Windows.Forms.DialogResult.No;
            resources.ApplyResources(this.btnNoConnect, "btnNoConnect");
            this.btnNoConnect.Name = "btnNoConnect";
            this.btnNoConnect.UseVisualStyleBackColor = true;
            this.btnNoConnect.Click += new System.EventHandler(this.BtnWithoutConnection_Click);
            // 
            // tlpRows
            // 
            resources.ApplyResources(this.tlpRows, "tlpRows");
            this.tlpRows.Controls.Add(this.gbUavModel, 0, 0);
            this.tlpRows.Controls.Add(this.panel, 0, 1);
            this.tlpRows.Controls.Add(this.tlpCols, 0, 2);
            this.tlpRows.Name = "tlpRows";
            // 
            // panel
            // 
            this.panel.Controls.Add(this.pPayload);
            this.panel.Controls.Add(this.gbLeftWeapon);
            this.panel.Controls.Add(this.gbRightWeapon);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // pPayload
            // 
            this.pPayload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPayload.Controls.Add(this.cbPayload);
            this.pPayload.Controls.Add(this.lblWeight);
            this.pPayload.Controls.Add(this.cmbWeight);
            resources.ApplyResources(this.pPayload, "pPayload");
            this.pPayload.Name = "pPayload";
            // 
            // cbPayload
            // 
            resources.ApplyResources(this.cbPayload, "cbPayload");
            this.cbPayload.Name = "cbPayload";
            this.cbPayload.UseVisualStyleBackColor = true;
            this.cbPayload.CheckedChanged += new System.EventHandler(this.CbPayload_CheckedChanged);
            // 
            // lblWeight
            // 
            resources.ApplyResources(this.lblWeight, "lblWeight");
            this.lblWeight.Name = "lblWeight";
            // 
            // cmbWeight
            // 
            this.cmbWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbWeight, "cmbWeight");
            this.cmbWeight.FormattingEnabled = true;
            this.cmbWeight.Name = "cmbWeight";
            // 
            // gbLeftWeapon
            // 
            this.gbLeftWeapon.Controls.Add(this.rbNoneLeft);
            this.gbLeftWeapon.Controls.Add(this.rbUnloadedLeft);
            this.gbLeftWeapon.Controls.Add(this.rbEquivalentLeft);
            this.gbLeftWeapon.Controls.Add(this.rbCombatLeft);
            resources.ApplyResources(this.gbLeftWeapon, "gbLeftWeapon");
            this.gbLeftWeapon.Name = "gbLeftWeapon";
            this.gbLeftWeapon.TabStop = false;
            // 
            // rbNoneLeft
            // 
            resources.ApplyResources(this.rbNoneLeft, "rbNoneLeft");
            this.rbNoneLeft.Checked = true;
            this.rbNoneLeft.Name = "rbNoneLeft";
            this.rbNoneLeft.TabStop = true;
            this.rbNoneLeft.UseVisualStyleBackColor = true;
            this.rbNoneLeft.CheckedChanged += new System.EventHandler(this.RbNoneLeft_CheckedChanged);
            // 
            // rbUnloadedLeft
            // 
            resources.ApplyResources(this.rbUnloadedLeft, "rbUnloadedLeft");
            this.rbUnloadedLeft.Name = "rbUnloadedLeft";
            this.rbUnloadedLeft.UseVisualStyleBackColor = true;
            this.rbUnloadedLeft.CheckedChanged += new System.EventHandler(this.RbUnloadedLeft_CheckedChanged);
            // 
            // rbEquivalentLeft
            // 
            resources.ApplyResources(this.rbEquivalentLeft, "rbEquivalentLeft");
            this.rbEquivalentLeft.Name = "rbEquivalentLeft";
            this.rbEquivalentLeft.UseVisualStyleBackColor = true;
            this.rbEquivalentLeft.CheckedChanged += new System.EventHandler(this.RbEquivalentLeft_CheckedChanged);
            // 
            // rbCombatLeft
            // 
            resources.ApplyResources(this.rbCombatLeft, "rbCombatLeft");
            this.rbCombatLeft.Name = "rbCombatLeft";
            this.rbCombatLeft.UseVisualStyleBackColor = true;
            this.rbCombatLeft.CheckedChanged += new System.EventHandler(this.RbCombatLeft_CheckedChanged);
            // 
            // gbRightWeapon
            // 
            this.gbRightWeapon.Controls.Add(this.rbNoneRight);
            this.gbRightWeapon.Controls.Add(this.rbUnloadedRight);
            this.gbRightWeapon.Controls.Add(this.rbEquivalentRight);
            this.gbRightWeapon.Controls.Add(this.rbCombatRight);
            resources.ApplyResources(this.gbRightWeapon, "gbRightWeapon");
            this.gbRightWeapon.Name = "gbRightWeapon";
            this.gbRightWeapon.TabStop = false;
            // 
            // rbNoneRight
            // 
            resources.ApplyResources(this.rbNoneRight, "rbNoneRight");
            this.rbNoneRight.Checked = true;
            this.rbNoneRight.Name = "rbNoneRight";
            this.rbNoneRight.TabStop = true;
            this.rbNoneRight.UseVisualStyleBackColor = true;
            // 
            // rbUnloadedRight
            // 
            resources.ApplyResources(this.rbUnloadedRight, "rbUnloadedRight");
            this.rbUnloadedRight.Name = "rbUnloadedRight";
            this.rbUnloadedRight.UseVisualStyleBackColor = true;
            // 
            // rbEquivalentRight
            // 
            resources.ApplyResources(this.rbEquivalentRight, "rbEquivalentRight");
            this.rbEquivalentRight.Name = "rbEquivalentRight";
            this.rbEquivalentRight.UseVisualStyleBackColor = true;
            this.rbEquivalentRight.CheckedChanged += new System.EventHandler(this.RbEquivalentRight_CheckedChanged);
            // 
            // rbCombatRight
            // 
            resources.ApplyResources(this.rbCombatRight, "rbCombatRight");
            this.rbCombatRight.Name = "rbCombatRight";
            this.rbCombatRight.UseVisualStyleBackColor = true;
            this.rbCombatRight.CheckedChanged += new System.EventHandler(this.RbCombatRight_CheckedChanged);
            // 
            // tlpCols
            // 
            resources.ApplyResources(this.tlpCols, "tlpCols");
            this.tlpCols.Controls.Add(this.btnNoConnect, 1, 0);
            this.tlpCols.Controls.Add(this.btnConnect, 0, 0);
            this.tlpCols.Name = "tlpCols";
            // 
            // btnConnect
            // 
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // ConnectionView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpRows);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionView";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionView_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionView_KeyDown);
            this.gbUavModel.ResumeLayout(false);
            this.tlpRows.ResumeLayout(false);
            this.tlpRows.PerformLayout();
            this.panel.ResumeLayout(false);
            this.pPayload.ResumeLayout(false);
            this.pPayload.PerformLayout();
            this.gbLeftWeapon.ResumeLayout(false);
            this.gbLeftWeapon.PerformLayout();
            this.gbRightWeapon.ResumeLayout(false);
            this.gbRightWeapon.PerformLayout();
            this.tlpCols.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUavModel;
        private System.Windows.Forms.Button btnNoConnect;
        private System.Windows.Forms.ComboBox cmbUavModel;
        private System.Windows.Forms.TableLayoutPanel tlpRows;
        public System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TableLayoutPanel tlpCols;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox gbLeftWeapon;
        private System.Windows.Forms.RadioButton rbNoneLeft;
        private System.Windows.Forms.RadioButton rbUnloadedLeft;
        private System.Windows.Forms.RadioButton rbEquivalentLeft;
        private System.Windows.Forms.RadioButton rbCombatLeft;
        private System.Windows.Forms.GroupBox gbRightWeapon;
        private System.Windows.Forms.RadioButton rbNoneRight;
        private System.Windows.Forms.RadioButton rbUnloadedRight;
        private System.Windows.Forms.RadioButton rbEquivalentRight;
        private System.Windows.Forms.RadioButton rbCombatRight;
        private System.Windows.Forms.Panel pPayload;
        private System.Windows.Forms.CheckBox cbPayload;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.ComboBox cmbWeight;
    }
}