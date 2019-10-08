using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using ScintillaNET;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using LogAnalyzer.Properties;
using LogAnalyzer.utils;

/*
 * TODO:
 * Create different Analyzer classes for different types of log files
 * Do autodetect and allow switching in case of erroneous detection
 * 
 * 
 * Allow users to create custom filters and add them to the list of filters
 * Save that info in a json file perhaps
 * Mouseover tooltips w/ information --> in the list view
 * Count how many instances of each line of the list are in the editor
 * 
 */

namespace LogAnalyzer
{
    // Aliases
    using NestedDict = Dictionary<string, Dictionary<string, string>>;
    using CheckListItem = Types.CheckListItem<string>;

    public partial class MainForm : Form
    { 
        // Init open/save file dialogs
        private OpenFileDialog fileDialog = new OpenFileDialog();
        private FontDialog font = new FontDialog
        {
            FixedPitchOnly = true,
            ShowHelp = false,
            ShowColor = false,
            ShowEffects = false,
            AllowScriptChange = false,
            AllowVectorFonts = false,
            AllowVerticalFonts = false
        };

        // Default font stored in Settings
        private Font userFont = Settings.Default.Font;

        // TODO: Probably should utilize this at some point or something
        private StringCollection recentlyOpenedFiles;

        // Parser
        // TODO: Don't instantiate unless LMI detected
        // Perhaps via a detect() method on something...
        private ParserLMI parserLMI = new ParserLMI();
        
        // Init file information
        private string fileNameOpen = string.Empty;
        private string fileContentsOriginal = string.Empty;

        // Store filter information
        private List<string> filterListLeft = new List<string>();
        private List<string> filterListRight = new List<string>();

        // Dictionary storing errors / line details
        public static NestedDict jsonErrorInfo;
        public static NestedDict winSockErrorInfo;
        public static List<string> logEntryTypes = new List<string>{ "Info", "Debug", "Error", "Warning" };

        public MainForm()
        {
            InitializeComponent();

            // Get error and logging information from JSON file
            jsonErrorInfo = JsonConvert.DeserializeObject<NestedDict>(Resources.errorInfo);
            winSockErrorInfo = JsonConvert.DeserializeObject<NestedDict>(Resources.winSockErrorInfo);

            //checkedListBoxMain.DataSource = new List<CheckListItem>();
            //checkedListBoxMore.DataSource = new List<CheckListItem>();
            
            // Add items to the checkbox
            foreach (string line in jsonErrorInfo["LogMeIn"].Keys)
            {
                checkedListBoxMore.Items.Add(new CheckListItem(line, line));
            }
            foreach (string line in logEntryTypes)
            {
                checkedListBoxMain.Items.Add(new CheckListItem(line, line));
            }

            // Set the font to custom user font if it exists
            SetScintillaFont();
        }

        // 
        // Helper methods for dynamic updates
        //

        /// <summary>
        /// Opens a file, displays it, and updates file information
        /// </summary>
        private void OpenFile()
        {
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileNameOpen = fileDialog.FileName;
                    fileContentsOriginal = File.ReadAllText(fileNameOpen);
                    SetScintillaText(fileContentsOriginal);
                    // Display the name of the file opened in the statusbar
                    toolStripStatusLabel1.Text = $"Viewing {fileNameOpen.Split('\\').Last()}";
                    SetLabelInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Redraw the filters
            List<string> splitFileContents = fileContentsOriginal.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            checkedListBoxMore.Items.Clear();
            foreach (string item in jsonErrorInfo["LogMeIn"].Keys)
            {
                CheckListItem toAdd = CountMatches(item, splitFileContents);
                if (toAdd.Display != string.Empty)
                    checkedListBoxMore.Items.Add(CountMatches(item, splitFileContents));
            }

            checkedListBoxMain.Items.Clear();
            foreach (string item in logEntryTypes)
            {
                CheckListItem toAdd = CountMatches(item, splitFileContents);
                if (toAdd.Display != string.Empty)
                    checkedListBoxMain.Items.Add(CountMatches(item, splitFileContents));
            }
        }

        private void SetScintillaFont()
        {
            scintillaCustom1.font = userFont;
            scintillaCustom1.setStyle();

        }

        /// <summary>
        /// Sets label above Scintilla text box to indicate what filters are selected
        /// </summary>
        private void SetFilterLabelInfo()
        {
            labelFilters.Text = $"Filters: {string.Join(", ", filterListLeft.Concat(filterListRight))}";
        }

        /// <summary>
        /// Highlight keywords in current document
        /// </summary>
        /// <param name="text"></param>
        private void HighlightWords(string text)
        {
            const int NUM = 8;

            scintillaCustom1.IndicatorCurrent = NUM;
            scintillaCustom1.IndicatorClearRange(0, scintillaCustom1.TextLength);
            // See here https://github.com/jacobslusser/ScintillaNET/wiki/Find-and-Highlight-Words
        }
        /// <summary>
        /// Saves user settings for recently opened files and user-chosen fonts
        /// </summary>
        public void WriteUserSettings()
        {
            Settings.Default.Font = userFont;
            Settings.Default.RecentlyOpened = recentlyOpenedFiles;
            Settings.Default.Save();
        }
        /// <summary>
        /// Counts matches of a string in a given List<string>
        /// </summary>
        /// <param name="toMatch"></param>
        /// <param name="data"></param>
        /// <returns>"{toMatch} {(count)}"</returns>
        private CheckListItem CountMatches(string toMatch, List<string> data)
        {
            int c = 0;
            foreach (string line in data)
            {
                if (line.Contains($" {toMatch} "))
                {
                    c++;
                }
            }
            if (c != 0)
                return new CheckListItem($"{toMatch} ({c})", toMatch);
            else
                return new CheckListItem(string.Empty, string.Empty);        }

        /// <summary>
        /// Parses currently selected line and display helpful information (sometimes) 
        /// In the RichTextBox on the left pane
        /// </summary>
        /// <param name="currentLine">Currently selected Scintilla line</param>
        private void SetInfoBoxInfo(string currentLine)
        {
            richTextBoxInfo.Text = parserLMI.ParseLine(currentLine);   
        }

        /// <summary>
        /// Sets the statusbar text at the bottom of the window
        /// </summary>
        private void SetLabelInfo()
        {
            toolStripStatusLabelInfo.Text = 
                $"L: {scintillaCustom1.Text.Count(f => f == '\n')} W: {scintillaCustom1.Text.Split(' ').Length:n0} C: {scintillaCustom1.Text.Length:n0}";
        }
        
        /// <summary>
        /// Unsets Scintilla's ReadOnly status, sets the text to a new string, and re-enables ReadOnly
        /// </summary>
        /// <param name="s">Text to set</param>
        private void SetScintillaText(string s)
        {
            scintillaCustom1.ReadOnly = false;
            scintillaCustom1.Text = s;
            scintillaCustom1.ReadOnly = true;
        }

        // *****************************
        // Event definitions and actions
        // *****************************
        
        /// <summary>
        /// Handles the "Open" button click event to open a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        /// <summary>
        /// Handles the "exit" button click event. Exits the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Close Window", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Handles 'text changed' event for scintilla
        /// Presently just updates the statusbar information to reflect current text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScintillaCustom1_TextChanged(object sender, EventArgs e)
        {
            // Don't do this until I can fix the linecount
            //SetLabelInfo();
        }

        /// <summary>
        /// Handles the click event on the scintilla area
        /// Will attempt to parse the line under the cursor and give helpful information
        /// regarding what's in the selected line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScintillaCustom1_Click(object sender, EventArgs e)
        {
            richTextBoxInfo.Text = string.Empty;
            int _currentLine = scintillaCustom1.CurrentLine;
            string _lineContents = scintillaCustom1.Lines[_currentLine].Text;
            SetInfoBoxInfo(_lineContents);
        }

        /// <summary>
        /// Handles the 'font' click event 
        /// Sets a custom font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (font.ShowDialog() == DialogResult.OK)
            {
                // Set window font
                userFont = font.Font;
                SetScintillaFont();
                WriteUserSettings();
            }
        }
           
        /// <summary>
        /// Resets textbox text to original contents (clears filters)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetFiltersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetScintillaText(fileContentsOriginal);

            // Uncheck all items
            for (int i = 0; i < checkedListBoxMain.Items.Count; i++)
            {
                checkedListBoxMain.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBoxMore.Items.Count; i++)
            {
                checkedListBoxMore.SetItemChecked(i, false);
            }
        }
        
        /// <summary>
        /// Handles event when an item is checked in the checkedListBox
        /// Will attempt to filter the scintilla text based on the selected filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBoxMain_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var _selectedItem = checkedListBoxMain.Items[e.Index] as CheckListItem;

            if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                filterListLeft.Add(_selectedItem.Data);

                // Using Linq here because it's neat
                string _newText = Utils.FilterText(filterListLeft, filterListRight, fileContentsOriginal);
                SetScintillaText(_newText);
            }
            else if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                filterListLeft.Remove(_selectedItem.Data);
                string _newText = Utils.FilterText(filterListLeft, filterListRight, fileContentsOriginal);
                SetScintillaText(_newText);
            }
            SetFilterLabelInfo();
        }

        private void CheckedListBoxMore_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var _selectedItem = checkedListBoxMore.Items[e.Index] as CheckListItem;

            if (e.CurrentValue == CheckState.Unchecked && e.NewValue == CheckState.Checked)
            {
                filterListRight.Add(_selectedItem.Data);
                string _newText = Utils.FilterText(filterListLeft, filterListRight, fileContentsOriginal);
                SetScintillaText(_newText);
            }
            else if (e.CurrentValue == CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                filterListRight.Remove(_selectedItem.Data);
                string _newText = Utils.FilterText(filterListLeft, filterListRight, fileContentsOriginal);
                SetScintillaText(_newText);
            }
            SetFilterLabelInfo();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + o Open
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }
        }

        private void SystemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form sysInfo = new FormSystemInfo(fileContentsOriginal))
            {
                sysInfo.ShowDialog();
            }
        }
    }
}
