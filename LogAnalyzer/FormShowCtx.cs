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

            // Removes the line count because it's irrelevant in this context
            scintillaCustomShowCtx.Margins[0].Width = 0;
            scintillaCustomShowCtx.Text = showText;
            scintillaCustomShowCtx.ReadOnly = true;
        }
    }
}
