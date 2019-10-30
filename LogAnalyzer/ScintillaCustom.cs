using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace LogAnalyzer
{
    class ScintillaCustom : Scintilla
    {
        // Menu items for right click
        MenuItem _Copy;
        MenuItem _SelectAll;
        MenuItem showContext;

        /// <summary>
        /// Sets how many lines the 'Show Context' menu item will scroll back.
        /// Defaults to 20
        /// </summary>
        public int ContextLength { get; set; } = 20;

        // Colors for the editor
        public readonly Color colorBG = Color.FromArgb(0x34353B);
        public readonly Color colorMargin = Color.FromArgb(0x43444c);
        public readonly Color colorFG = Color.FromArgb(0xefefef);
        public readonly Color colorSel = Color.FromArgb(0x7289DA);

        // Font 
        public Font font = new Font("Consolas", 10f);

        public ScintillaCustom() : base()
        {
            setStyle();
            initContextMenu();
        }

        /// <summary>
        /// Defines what appears in the right click menu in Scintilla
        /// </summary>
        void initContextMenu()
        {
            ContextMenu cm = ContextMenu = new ContextMenu();

            showContext = new MenuItem("Show Context", (s, ea) => ShowContext());
            cm.MenuItems.Add(showContext);

            cm.MenuItems.Add(new MenuItem("-"));

            _Copy = new MenuItem("Copy", (s, ea) => Copy());
            cm.MenuItems.Add(_Copy);

            _SelectAll = new MenuItem("Select All", (s, ea) => SelectAll());
            cm.MenuItems.Add(_SelectAll);
        }

        public void setStyle()
        {
            // Reset default style
            StyleResetDefault();
            Styles[Style.Default].Font = font.Name;
            Styles[Style.Default].Size = Convert.ToInt32(font.SizeInPoints);
            Styles[Style.Default].BackColor = colorBG;
            Styles[Style.Default].FillLine = true;
            Styles[Style.Default].ForeColor = colorFG;
            CaretLineBackColor = colorSel;
            StyleClearAll();

            // Set line numbers
            // Add enough margin space for large line counts
            Margins[0].Width = 36;
            Margins[0].Type = MarginType.Number;
            Styles[Style.LineNumber].BackColor = colorMargin;

            // Windows forms shenanigans
            CaretStyle = CaretStyle.Invisible;
            CaretLineVisible = true;
            ExtraAscent = 2;
            ExtraDescent = 2;
            ReadOnly = true;
            TabIndex = 0;
            WrapMode = WrapMode.Whitespace;
            BorderStyle = BorderStyle.None;
        }

        public void GetTextLineRange(int startRange, int endRange)
        {
            var sb = new StringBuilder();
            //for (int i = startRange; i < endRange; i++)
            //{
            //    sb.Append
            //}
        }
        public void ShowContext()
        {
            var toParse = new  List<string>(MainForm.fileContentsOriginal.Split('\n'));
            var line = Lines[CurrentLine].Text.Trim(new char[] { '\n', '\r' });
            var lineIdx = toParse.IndexOf(line);

            // get beginning of context
            int begin;
            if (lineIdx - ContextLength < 0)
                begin = 0;
            else
                begin = lineIdx - ContextLength;

            // get end of context
            int end;
            if (lineIdx + ContextLength > toParse.Count)
                end = toParse.Count;
            else
                end = lineIdx + ContextLength;

            var sb = new StringBuilder();
            for (int i = begin; i <= end; i++)
            {
                sb.Append(toParse[i]);
            }

            using (Form ctx = new FormShowCtx(sb.ToString()))
            {
                ctx.ShowDialog();
            }
        }
    }
}
