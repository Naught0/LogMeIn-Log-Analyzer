namespace LogAnalyzer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFiltersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFilters = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.checkedListBoxMain = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxMore = new System.Windows.Forms.CheckedListBox();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.scintillaCustom1 = new LogAnalyzer.ScintillaCustom();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.resetFiltersToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.fontToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // resetFiltersToolStripMenuItem
            // 
            this.resetFiltersToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.resetFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFiltersToolStripMenuItem1});
            this.resetFiltersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.resetFiltersToolStripMenuItem.Name = "resetFiltersToolStripMenuItem";
            this.resetFiltersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.resetFiltersToolStripMenuItem.Text = "Filters";
            // 
            // resetFiltersToolStripMenuItem1
            // 
            this.resetFiltersToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.resetFiltersToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.resetFiltersToolStripMenuItem1.Name = "resetFiltersToolStripMenuItem1";
            this.resetFiltersToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.resetFiltersToolStripMenuItem1.Text = "Reset Filters";
            this.resetFiltersToolStripMenuItem1.Click += new System.EventHandler(this.ResetFiltersToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemInfoToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // systemInfoToolStripMenuItem
            // 
            this.systemInfoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.systemInfoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.systemInfoToolStripMenuItem.Name = "systemInfoToolStripMenuItem";
            this.systemInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.systemInfoToolStripMenuItem.Text = "System Info";
            this.systemInfoToolStripMenuItem.Click += new System.EventHandler(this.SystemInfoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelInfo,
            this.labelFilters});
            this.statusStrip1.Location = new System.Drawing.Point(0, 501);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1038, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.LightGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelInfo.Text = "...";
            // 
            // labelFilters
            // 
            this.labelFilters.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(44, 17);
            this.labelFilters.Text = "Filters: ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(124)))), ((int)(((byte)(138)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scintillaCustom1);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 477);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBoxInfo);
            this.splitContainer2.Size = new System.Drawing.Size(264, 477);
            this.splitContainer2.SplitterDistance = 190;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.checkedListBoxMain);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.checkedListBoxMore);
            this.splitContainer3.Size = new System.Drawing.Size(264, 190);
            this.splitContainer3.SplitterDistance = 94;
            this.splitContainer3.TabIndex = 1;
            // 
            // checkedListBoxMain
            // 
            this.checkedListBoxMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.checkedListBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxMain.CheckOnClick = true;
            this.checkedListBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxMain.ForeColor = System.Drawing.Color.White;
            this.checkedListBoxMain.FormattingEnabled = true;
            this.checkedListBoxMain.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxMain.Name = "checkedListBoxMain";
            this.checkedListBoxMain.Size = new System.Drawing.Size(94, 190);
            this.checkedListBoxMain.Sorted = true;
            this.checkedListBoxMain.TabIndex = 0;
            this.checkedListBoxMain.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxMain_ItemCheck);
            // 
            // checkedListBoxMore
            // 
            this.checkedListBoxMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(68)))), ((int)(((byte)(76)))));
            this.checkedListBoxMore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxMore.CheckOnClick = true;
            this.checkedListBoxMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxMore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxMore.ForeColor = System.Drawing.Color.White;
            this.checkedListBoxMore.FormattingEnabled = true;
            this.checkedListBoxMore.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxMore.Name = "checkedListBoxMore";
            this.checkedListBoxMore.Size = new System.Drawing.Size(166, 190);
            this.checkedListBoxMore.Sorted = true;
            this.checkedListBoxMore.TabIndex = 0;
            this.checkedListBoxMore.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxMore_ItemCheck);
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(59)))));
            this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.ShortcutsEnabled = false;
            this.richTextBoxInfo.Size = new System.Drawing.Size(264, 283);
            this.richTextBoxInfo.TabIndex = 1;
            this.richTextBoxInfo.Text = "";
            // 
            // scintillaCustom1
            // 
            this.scintillaCustom1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scintillaCustom1.CaretLineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(181)))), ((int)(((byte)(236)))));
            this.scintillaCustom1.CaretLineVisible = true;
            this.scintillaCustom1.CaretStyle = ScintillaNET.CaretStyle.Invisible;
            this.scintillaCustom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaCustom1.ExtraAscent = 2;
            this.scintillaCustom1.ExtraDescent = 2;
            this.scintillaCustom1.Location = new System.Drawing.Point(0, 0);
            this.scintillaCustom1.Name = "scintillaCustom1";
            this.scintillaCustom1.ReadOnly = true;
            this.scintillaCustom1.Size = new System.Drawing.Size(770, 477);
            this.scintillaCustom1.TabIndex = 1;
            this.scintillaCustom1.WrapMode = ScintillaNET.WrapMode.Whitespace;
            this.scintillaCustom1.TextChanged += new System.EventHandler(this.ScintillaCustom1_TextChanged);
            this.scintillaCustom1.Click += new System.EventHandler(this.ScintillaCustom1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 523);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "LogMeIn Log Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem resetFiltersToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetFiltersToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.CheckedListBox checkedListBoxMain;
        private System.Windows.Forms.CheckedListBox checkedListBoxMore;
        private System.Windows.Forms.ToolStripStatusLabel labelFilters;
        private ScintillaCustom scintillaCustom1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemInfoToolStripMenuItem;
    }
}

