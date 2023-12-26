namespace MMS_Projekat
{
    partial class GammaInput
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.redTbx = new System.Windows.Forms.TextBox();
            this.greenTbx = new System.Windows.Forms.TextBox();
            this.blueTbx = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "R:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "G:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "B:";
            // 
            // redTbx
            // 
            this.redTbx.Location = new System.Drawing.Point(93, 45);
            this.redTbx.Name = "redTbx";
            this.redTbx.Size = new System.Drawing.Size(100, 23);
            this.redTbx.TabIndex = 3;
            // 
            // greenTbx
            // 
            this.greenTbx.Location = new System.Drawing.Point(93, 78);
            this.greenTbx.Name = "greenTbx";
            this.greenTbx.Size = new System.Drawing.Size(100, 23);
            this.greenTbx.TabIndex = 4;
            // 
            // blueTbx
            // 
            this.blueTbx.Location = new System.Drawing.Point(93, 111);
            this.blueTbx.Name = "blueTbx";
            this.blueTbx.Size = new System.Drawing.Size(100, 23);
            this.blueTbx.TabIndex = 5;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(33, 162);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(137, 162);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unesite vrednosti izmedju 0.2 i 5.0";
            // 
            // GammaInput
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 211);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.blueTbx);
            this.Controls.Add(this.greenTbx);
            this.Controls.Add(this.redTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GammaInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GammaInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox redTbx;
        private TextBox greenTbx;
        private TextBox blueTbx;
        private Button okBtn;
        private Button cancelBtn;
        private Label label4;
    }
}