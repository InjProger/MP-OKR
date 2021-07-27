namespace MissionPlanner.Log
{
    partial class LogDownloadMavLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogDownloadMavLink));
            this.CHK_logs = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressPanel = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelBytes = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BUT_DLall = new MissionPlanner.Controls.MyButton();
            this.BUT_clearlogs = new MissionPlanner.Controls.MyButton();
            this.BUT_firstperson = new MissionPlanner.Controls.MyButton();
            this.BUT_DLthese = new MissionPlanner.Controls.MyButton();
            this.BUT_bintolog = new MissionPlanner.Controls.MyButton();
            this.BUT_redokml = new MissionPlanner.Controls.MyButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mainFullPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logPanel = new System.Windows.Forms.TableLayoutPanel();
            this.outPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TXT_seriallog = new System.Windows.Forms.TextBox();
            this.progressPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.mainFullPanel.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.outPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CHK_logs
            // 
            this.CHK_logs.CheckOnClick = true;
            resources.ApplyResources(this.CHK_logs, "CHK_logs");
            this.CHK_logs.FormattingEnabled = true;
            this.CHK_logs.Name = "CHK_logs";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // progressPanel
            // 
            resources.ApplyResources(this.progressPanel, "progressPanel");
            this.mainFullPanel.SetColumnSpan(this.progressPanel, 2);
            this.progressPanel.Controls.Add(this.progressBar1, 0, 0);
            this.progressPanel.Name = "progressPanel";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // labelBytes
            // 
            resources.ApplyResources(this.labelBytes, "labelBytes");
            this.labelBytes.Name = "labelBytes";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.mainFullPanel.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.Controls.Add(this.BUT_DLall, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BUT_clearlogs, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.BUT_firstperson, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BUT_DLthese, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.BUT_bintolog, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.BUT_redokml, 1, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // BUT_DLall
            // 
            resources.ApplyResources(this.BUT_DLall, "BUT_DLall");
            this.BUT_DLall.Name = "BUT_DLall";
            this.BUT_DLall.UseVisualStyleBackColor = true;
            this.BUT_DLall.Click += new System.EventHandler(this.BUT_DLall_Click);
            // 
            // BUT_clearlogs
            // 
            resources.ApplyResources(this.BUT_clearlogs, "BUT_clearlogs");
            this.BUT_clearlogs.Name = "BUT_clearlogs";
            this.toolTip1.SetToolTip(this.BUT_clearlogs, resources.GetString("BUT_clearlogs.ToolTip"));
            this.BUT_clearlogs.UseVisualStyleBackColor = true;
            this.BUT_clearlogs.Click += new System.EventHandler(this.BUT_clearlogs_Click);
            // 
            // BUT_firstperson
            // 
            resources.ApplyResources(this.BUT_firstperson, "BUT_firstperson");
            this.BUT_firstperson.Name = "BUT_firstperson";
            this.toolTip1.SetToolTip(this.BUT_firstperson, resources.GetString("BUT_firstperson.ToolTip"));
            this.BUT_firstperson.UseVisualStyleBackColor = true;
            this.BUT_firstperson.Click += new System.EventHandler(this.BUT_firstperson_Click);
            // 
            // BUT_DLthese
            // 
            resources.ApplyResources(this.BUT_DLthese, "BUT_DLthese");
            this.BUT_DLthese.Name = "BUT_DLthese";
            this.toolTip1.SetToolTip(this.BUT_DLthese, resources.GetString("BUT_DLthese.ToolTip"));
            this.BUT_DLthese.UseVisualStyleBackColor = true;
            this.BUT_DLthese.Click += new System.EventHandler(this.BUT_DLthese_Click);
            // 
            // BUT_bintolog
            // 
            resources.ApplyResources(this.BUT_bintolog, "BUT_bintolog");
            this.BUT_bintolog.Name = "BUT_bintolog";
            this.toolTip1.SetToolTip(this.BUT_bintolog, resources.GetString("BUT_bintolog.ToolTip"));
            this.BUT_bintolog.UseVisualStyleBackColor = true;
            this.BUT_bintolog.Click += new System.EventHandler(this.BUT_bintolog_Click);
            // 
            // BUT_redokml
            // 
            resources.ApplyResources(this.BUT_redokml, "BUT_redokml");
            this.BUT_redokml.Name = "BUT_redokml";
            this.toolTip1.SetToolTip(this.BUT_redokml, resources.GetString("BUT_redokml.ToolTip"));
            this.BUT_redokml.UseVisualStyleBackColor = true;
            this.BUT_redokml.Click += new System.EventHandler(this.BUT_redokml_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 400;
            this.toolTip1.ShowAlways = true;
            // 
            // mainFullPanel
            // 
            resources.ApplyResources(this.mainFullPanel, "mainFullPanel");
            this.mainFullPanel.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.mainFullPanel.Controls.Add(this.logPanel, 0, 1);
            this.mainFullPanel.Controls.Add(this.outPanel, 1, 1);
            this.mainFullPanel.Controls.Add(this.progressPanel, 0, 2);
            this.mainFullPanel.Name = "mainFullPanel";
            // 
            // logPanel
            // 
            resources.ApplyResources(this.logPanel, "logPanel");
            this.logPanel.Controls.Add(this.CHK_logs, 0, 1);
            this.logPanel.Controls.Add(this.label1, 0, 0);
            this.logPanel.Name = "logPanel";
            // 
            // outPanel
            // 
            resources.ApplyResources(this.outPanel, "outPanel");
            this.outPanel.Controls.Add(this.TXT_seriallog, 0, 1);
            this.outPanel.Controls.Add(this.label2, 0, 0);
            this.outPanel.Name = "outPanel";
            // 
            // TXT_seriallog
            // 
            resources.ApplyResources(this.TXT_seriallog, "TXT_seriallog");
            this.TXT_seriallog.Name = "TXT_seriallog";
            // 
            // LogDownloadMavLink
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.mainFullPanel);
            this.Name = "LogDownloadMavLink";
            this.Load += new System.EventHandler(this.Log_Load);
            this.progressPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.mainFullPanel.ResumeLayout(false);
            this.mainFullPanel.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.outPanel.ResumeLayout(false);
            this.outPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MyButton BUT_DLall;
        private Controls.MyButton BUT_DLthese;
        private Controls.MyButton BUT_clearlogs;
        private System.Windows.Forms.CheckedListBox CHK_logs;
        private Controls.MyButton BUT_redokml;
        private Controls.MyButton BUT_firstperson;
        private Controls.MyButton BUT_bintolog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel progressPanel;
        private System.Windows.Forms.Label labelBytes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel outPanel;
        private System.Windows.Forms.TableLayoutPanel mainFullPanel;
        private System.Windows.Forms.TableLayoutPanel logPanel;
        private System.Windows.Forms.TextBox TXT_seriallog;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}