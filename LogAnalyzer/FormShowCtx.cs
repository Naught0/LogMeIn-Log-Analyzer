using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogAnalyzer
{
    public partial class FormShowCtx : Form
    {
        public FormShowCtx(string showText)
        {
            InitializeComponent();

            // Removes the line count margin because it's irrelevant in this context
            foreach (var margin in scintillaCustomShowCtx.Margins)
            {
                margin.Width = 0;
            }
            scintillaCustomShowCtx.ReadOnly = false;
            scintillaCustomShowCtx.Text = showText;
            scintillaCustomShowCtx.ReadOnly = true;
        }
    }
}
