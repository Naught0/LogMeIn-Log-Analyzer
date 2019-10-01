﻿using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LogAnalyzer
{
    class ScintillaCustom : Scintilla
    {
        // Menu items for right click
        MenuItem _Undo;
        MenuItem _Redo;
        MenuItem _Cut;
        MenuItem _Copy;
        MenuItem _Delete;
        MenuItem _SelectAll;
        MenuItem showContext;

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
        private void initContextMenu()
        {
            ContextMenu cm = ContextMenu = new ContextMenu();

            showContext = new MenuItem("Show Context", (s, ea) => { }); // do nothing for now
            cm.MenuItems.Add(showContext);

            cm.MenuItems.Add(new MenuItem("-"));

            _Undo = new MenuItem("Undo", (s, ea) => Undo());
            cm.MenuItems.Add(_Undo);

            _Redo = new MenuItem("Redo", (s, ea) => Redo());
            cm.MenuItems.Add(_Redo);

            cm.MenuItems.Add(new MenuItem("-"));

            _Cut = new MenuItem("Cut", (s, ea) => Cut());
            cm.MenuItems.Add(_Cut);

            _Copy = new MenuItem("Copy", (s, ea) => Copy());
            cm.MenuItems.Add(_Copy);

            cm.MenuItems.Add(new MenuItem("Paste", (s, ea) => Paste()));

            _Delete = new MenuItem("Delete", (s, ea) => ReplaceSelection(""));
            cm.MenuItems.Add(_Delete);

            cm.MenuItems.Add(new MenuItem("-"));

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
    }
}
