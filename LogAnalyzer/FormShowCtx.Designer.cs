namespace LogAnalyzer
{
    partial class FormShowCtx
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
            this.scintillaCustomShowCtx = new LogAnalyzer.ScintillaCustom();
            this.SuspendLayout();
            // 
            // scintillaCustomShowCtx
            // 
            this.scintillaCustomShowCtx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scintillaCustomShowCtx.CaretLineBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.scintillaCustomShowCtx.CaretLineVisible = true;
            this.scintillaCustomShowCtx.CaretStyle = ScintillaNET.CaretStyle.Invisible;
            this.scintillaCustomShowCtx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintillaCustomShowCtx.ExtraAscent = 2;
            this.scintillaCustomShowCtx.ExtraDescent = 2;
            this.scintillaCustomShowCtx.Location = new System.Drawing.Point(0, 0);
            this.scintillaCustomShowCtx.Name = "scintillaCustomShowCtx";
            this.scintillaCustomShowCtx.ReadOnly = true;
            this.scintillaCustomShowCtx.Size = new System.Drawing.Size(800, 450);
            this.scintillaCustomShowCtx.TabIndex = 0;
            this.scintillaCustomShowCtx.WrapMode = ScintillaNET.WrapMode.Whitespace;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scintillaCustomShowCtx);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LogAnalyzer.ScintillaCustom scintillaCustomShowCtx;
    }
}