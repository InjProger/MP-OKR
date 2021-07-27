namespace MissionPlanner.Controls.Buttons.ThreeStateButton
{

    partial class ThreeButtonState
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.btnBegState = new System.Windows.Forms.Button();
            this.btnMidState = new System.Windows.Forms.Button();
            this.btnEndState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBegState
            // 
            this.btnBegState.AutoSize = true;
            this.btnBegState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBegState.Location = new System.Drawing.Point(0, 0);
            this.btnBegState.Name = "btnBegState";
            this.btnBegState.Size = new System.Drawing.Size(95, 95);
            this.btnBegState.TabIndex = 0;
            this.btnBegState.UseVisualStyleBackColor = true;
            this.btnBegState.Click += new System.EventHandler(this.BtnBegState_Click);
            // 
            // btnMidState
            // 
            this.btnMidState.AutoSize = true;
            this.btnMidState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMidState.Location = new System.Drawing.Point(0, 0);
            this.btnMidState.Name = "btnMidState";
            this.btnMidState.Size = new System.Drawing.Size(95, 95);
            this.btnMidState.TabIndex = 1;
            this.btnMidState.UseVisualStyleBackColor = true;
            this.btnMidState.Visible = false;
            this.btnMidState.Click += new System.EventHandler(this.BtnMidState_Click);
            // 
            // btnEndState
            // 
            this.btnEndState.AutoSize = true;
            this.btnEndState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEndState.Location = new System.Drawing.Point(0, 0);
            this.btnEndState.Name = "btnEndState";
            this.btnEndState.Size = new System.Drawing.Size(95, 95);
            this.btnEndState.TabIndex = 2;
            this.btnEndState.UseVisualStyleBackColor = true;
            this.btnEndState.Visible = false;
            this.btnEndState.Click += new System.EventHandler(this.BtnEndState_Click);
            // 
            // ThreeButtonState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBegState);
            this.Controls.Add(this.btnMidState);
            this.Controls.Add(this.btnEndState);
            this.Name = "ThreeButtonState";
            this.Size = new System.Drawing.Size(95, 95);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnMidState;
        public System.Windows.Forms.Button btnBegState;
        public System.Windows.Forms.Button btnEndState;
    }
}
