namespace MMS_Projekat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antialiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom150 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom500 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gammaToolStripMenuItem,
            this.smoothToolStripMenuItem,
            this.edgeDetectVerticalToolStripMenuItem,
            this.timeWarpToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // gammaToolStripMenuItem
            // 
            this.gammaToolStripMenuItem.Name = "gammaToolStripMenuItem";
            this.gammaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gammaToolStripMenuItem.Text = "Gamma";
            this.gammaToolStripMenuItem.Click += new System.EventHandler(this.gammaToolStripMenuItem_Click);
            // 
            // smoothToolStripMenuItem
            // 
            this.smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            this.smoothToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.smoothToolStripMenuItem.Text = "Smooth";
            this.smoothToolStripMenuItem.Click += new System.EventHandler(this.smoothToolStripMenuItem_Click);
            // 
            // edgeDetectVerticalToolStripMenuItem
            // 
            this.edgeDetectVerticalToolStripMenuItem.Name = "edgeDetectVerticalToolStripMenuItem";
            this.edgeDetectVerticalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.edgeDetectVerticalToolStripMenuItem.Text = "Edge detect vertical";
            this.edgeDetectVerticalToolStripMenuItem.Click += new System.EventHandler(this.edgeDetectVerticalToolStripMenuItem_Click);
            // 
            // timeWarpToolStripMenuItem
            // 
            this.timeWarpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.antialiasToolStripMenuItem});
            this.timeWarpToolStripMenuItem.Name = "timeWarpToolStripMenuItem";
            this.timeWarpToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.timeWarpToolStripMenuItem.Text = "Time warp";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // antialiasToolStripMenuItem
            // 
            this.antialiasToolStripMenuItem.Name = "antialiasToolStripMenuItem";
            this.antialiasToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.antialiasToolStripMenuItem.Text = "AntiAlias";
            this.antialiasToolStripMenuItem.Click += new System.EventHandler(this.antialiasToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Zoom25,
            this.Zoom50,
            this.Zoom100,
            this.Zoom150,
            this.Zoom200,
            this.Zoom300,
            this.Zoom500});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // Zoom25
            // 
            this.Zoom25.Name = "Zoom25";
            this.Zoom25.Size = new System.Drawing.Size(180, 22);
            this.Zoom25.Text = "25%";
            this.Zoom25.Click += new System.EventHandler(this.Zoom25_Click);
            // 
            // Zoom50
            // 
            this.Zoom50.Name = "Zoom50";
            this.Zoom50.Size = new System.Drawing.Size(180, 22);
            this.Zoom50.Text = "50%";
            this.Zoom50.Click += new System.EventHandler(this.Zoom50_Click);
            // 
            // Zoom100
            // 
            this.Zoom100.Name = "Zoom100";
            this.Zoom100.Size = new System.Drawing.Size(180, 22);
            this.Zoom100.Text = "100%";
            this.Zoom100.Click += new System.EventHandler(this.Zoom100_Click);
            // 
            // Zoom150
            // 
            this.Zoom150.Name = "Zoom150";
            this.Zoom150.Size = new System.Drawing.Size(180, 22);
            this.Zoom150.Text = "150%";
            this.Zoom150.Click += new System.EventHandler(this.Zoom150_Click);
            // 
            // Zoom200
            // 
            this.Zoom200.Name = "Zoom200";
            this.Zoom200.Size = new System.Drawing.Size(180, 22);
            this.Zoom200.Text = "200%";
            this.Zoom200.Click += new System.EventHandler(this.Zoom200_Click);
            // 
            // Zoom300
            // 
            this.Zoom300.Name = "Zoom300";
            this.Zoom300.Size = new System.Drawing.Size(180, 22);
            this.Zoom300.Text = "300%";
            this.Zoom300.Click += new System.EventHandler(this.Zoom300_Click);
            // 
            // Zoom500
            // 
            this.Zoom500.Name = "Zoom500";
            this.Zoom500.Size = new System.Drawing.Size(180, 22);
            this.Zoom500.Text = "500%";
            this.Zoom500.Click += new System.EventHandler(this.Zoom500_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMS Projekat";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem gammaToolStripMenuItem;
        private ToolStripMenuItem smoothToolStripMenuItem;
        private ToolStripMenuItem edgeDetectVerticalToolStripMenuItem;
        private ToolStripMenuItem timeWarpToolStripMenuItem;
        private ToolStripMenuItem normalToolStripMenuItem;
        private ToolStripMenuItem antialiasToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem Zoom25;
        private ToolStripMenuItem Zoom50;
        private ToolStripMenuItem Zoom100;
        private ToolStripMenuItem Zoom150;
        private ToolStripMenuItem Zoom200;
        private ToolStripMenuItem Zoom300;
        private ToolStripMenuItem Zoom500;
    }
}