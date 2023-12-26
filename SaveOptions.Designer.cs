namespace MMS_Projekat
{
    partial class SaveOptions
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
            this.downsplCbx = new System.Windows.Forms.CheckBox();
            this.compressionCbx = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hbRadio = new System.Windows.Forms.RadioButton();
            this.bRadio = new System.Windows.Forms.RadioButton();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // downsplCbx
            // 
            this.downsplCbx.AutoSize = true;
            this.downsplCbx.Location = new System.Drawing.Point(40, 31);
            this.downsplCbx.Name = "downsplCbx";
            this.downsplCbx.Size = new System.Drawing.Size(106, 19);
            this.downsplCbx.TabIndex = 0;
            this.downsplCbx.Text = "Downsampling";
            this.downsplCbx.UseVisualStyleBackColor = true;
            // 
            // compressionCbx
            // 
            this.compressionCbx.AutoSize = true;
            this.compressionCbx.Location = new System.Drawing.Point(40, 56);
            this.compressionCbx.Name = "compressionCbx";
            this.compressionCbx.Size = new System.Drawing.Size(96, 19);
            this.compressionCbx.TabIndex = 1;
            this.compressionCbx.Text = "Compression";
            this.compressionCbx.UseVisualStyleBackColor = true;
            this.compressionCbx.CheckedChanged += new System.EventHandler(this.compressionCbx_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bRadio);
            this.groupBox1.Controls.Add(this.hbRadio);
            this.groupBox1.Location = new System.Drawing.Point(31, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alphabet size";
            // 
            // hbRadio
            // 
            this.hbRadio.AutoSize = true;
            this.hbRadio.Location = new System.Drawing.Point(9, 19);
            this.hbRadio.Name = "hbRadio";
            this.hbRadio.Size = new System.Drawing.Size(75, 19);
            this.hbRadio.TabIndex = 0;
            this.hbRadio.TabStop = true;
            this.hbRadio.Text = "Half-byte";
            this.hbRadio.UseVisualStyleBackColor = true;
            // 
            // bRadio
            // 
            this.bRadio.AutoSize = true;
            this.bRadio.Location = new System.Drawing.Point(9, 44);
            this.bRadio.Name = "bRadio";
            this.bRadio.Size = new System.Drawing.Size(48, 19);
            this.bRadio.TabIndex = 1;
            this.bRadio.TabStop = true;
            this.bRadio.Text = "Byte";
            this.bRadio.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(31, 189);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(126, 189);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 260);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.compressionCbx);
            this.Controls.Add(this.downsplCbx);
            this.Name = "SaveOptions";
            this.Text = "SaveOptions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox downsplCbx;
        private CheckBox compressionCbx;
        private GroupBox groupBox1;
        private RadioButton bRadio;
        private RadioButton hbRadio;
        private Button saveBtn;
        private Button cancelBtn;
    }
}