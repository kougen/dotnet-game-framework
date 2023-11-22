using System.ComponentModel;

namespace BoardTemplate.Forms.Views.Main
{
    sealed partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapName = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.explodedEnemiesText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1121, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem,
            this.recentMapsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.openToolStripMenuItem.Text = "Open...";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // recentMapsToolStripMenuItem
            // 
            this.recentMapsToolStripMenuItem.Name = "recentMapsToolStripMenuItem";
            this.recentMapsToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.recentMapsToolStripMenuItem.Text = "Recent Maps";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapGeneratorToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // openMapGeneratorToolStripMenuItem
            // 
            this.openMapGeneratorToolStripMenuItem.Name = "openMapGeneratorToolStripMenuItem";
            this.openMapGeneratorToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.openMapGeneratorToolStripMenuItem.Text = "Open MapGenerator";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(145, 26);
            this.websiteToolStripMenuItem.Text = "Website";
            // 
            // mapName
            // 
            this.mapName.AutoSize = true;
            this.mapName.Font = new System.Drawing.Font("UD Digi Kyokasho NP-B", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mapName.Location = new System.Drawing.Point(684, 59);
            this.mapName.Name = "mapName";
            this.mapName.Size = new System.Drawing.Size(304, 26);
            this.mapName.TabIndex = 3;
            this.mapName.Text = "(Name) No map selected";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.description.Location = new System.Drawing.Point(684, 97);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(424, 183);
            this.description.TabIndex = 4;
            this.description.Text = "(Description) No map selected";
            // 
            // currentTime
            // 
            this.currentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentTime.AutoSize = true;
            this.currentTime.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentTime.Location = new System.Drawing.Point(14, 635);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(85, 17);
            this.currentTime.TabIndex = 8;
            this.currentTime.Text = "Stopwatch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(684, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Stats";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(687, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Exploded enemies:";
            // 
            // explodedEnemiesText
            // 
            this.explodedEnemiesText.AutoSize = true;
            this.explodedEnemiesText.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.explodedEnemiesText.Location = new System.Drawing.Point(848, 309);
            this.explodedEnemiesText.Name = "explodedEnemiesText";
            this.explodedEnemiesText.Size = new System.Drawing.Size(18, 17);
            this.explodedEnemiesText.TabIndex = 11;
            this.explodedEnemiesText.Text = "0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1121, 663);
            this.Controls.Add(this.explodedEnemiesText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.description);
            this.Controls.Add(this.mapName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem openMapGeneratorToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem websiteToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem recentMapsToolStripMenuItem;
        private Label mapName;
        private Label description;
        private Label currentTime;
        private Label label1;
        private Label label2;
        private Label explodedEnemiesText;
    }
}

