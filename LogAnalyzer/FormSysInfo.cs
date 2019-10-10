using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogAnalyzer.utils;

namespace LogAnalyzer
{
    public partial class FormSystemInfo : Form
    {
        string logFile;
        public FormSystemInfo(string passedLog)
        {
            logFile = passedLog;
            InitializeComponent();
        }

        void FormSystemInfo_Load(object sender, EventArgs e)
        {
            SysInfoParser parser = new SysInfoParser(logFile);
            string parsedText = parser.GetSysInfo();
            rtfInfo.ReadOnly = false;
            rtfInfo.Text = parsedText;
            rtfInfo.ReadOnly = true;
        }

        void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
