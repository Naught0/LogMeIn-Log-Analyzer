using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ScintillaNET;

namespace LogAnalyzer.Lexers
{
    class LogLexer
    {
        // https://github.com/jacobslusser/ScintillaNET/wiki/Custom-Syntax-Highlighting
        // Fix the ugly logic located here, not using GOTO statements like an ape
        // apply the custom lexer to Scintilla 
        public const int StyleDefault = 0;
        public const int StyleKeyword = 1;
        public const int StyleIdentifier = 2;
        public const int StyleNumber = 3;
        public const int StyleString = 4;

        const int STATE_UNKNOWN = 0;
        const int STATE_IDENTIFIER = 1;
        const int STATE_NUMBER = 2;
        const int STATE_STRING = 3;

        HashSet<string> keywords;

        public void Style(Scintilla scintilla, int startPos, int endPos)
        {
            // Back up to the line start
            var line = scintilla.LineFromPosition(startPos);
            startPos = scintilla.Lines[line].Position;

            var length = 0;
            var state = STATE_UNKNOWN;

            // Start styling
            scintilla.StartStyling(startPos);
            while (startPos < endPos)
            {
                var c = (char)scintilla.GetCharAt(startPos);

            REPROCESS:
                switch (state)
                {
                    case STATE_UNKNOWN:
                        if (c == '"')
                        {
                            // Start of "string"
                            scintilla.SetStyling(1, StyleString);
                            state = STATE_STRING;
                        }
                        else if (char.IsDigit(c))
                        {
                            state = STATE_NUMBER;
                            goto REPROCESS;
                        }
                        else if (char.IsLetter(c))
                        {
                            state = STATE_IDENTIFIER;
                            goto REPROCESS;
                        }
                        else
                        {
                            // Everything else
                            scintilla.SetStyling(1, StyleDefault);
                        }
                        break;

                    case STATE_STRING:
                        if (c == '"')
                        {
                            length++;
                            scintilla.SetStyling(length, StyleString);
                            length = 0;
                            state = STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }
                        break;

                    case STATE_NUMBER:
                        if (char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || c == 'x')
                        {
                            length++;
                        }
                        else
                        {
                            scintilla.SetStyling(length, StyleNumber);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;

                    case STATE_IDENTIFIER:
                        if (char.IsLetterOrDigit(c))
                        {
                            length++;
                        }
                        else
                        {
                            var style = StyleIdentifier;
                            var identifier = scintilla.GetTextRange(startPos - length, length);
                            if (keywords.Contains(identifier))
                                style = StyleKeyword;

                            scintilla.SetStyling(length, style);
                            length = 0;
                            state = STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;
                }

                startPos++;
            }
        }
        public LogLexer(string keywords)
        {
            // Put keywords in a HashSet
            var list = Regex.Split(keywords ?? string.Empty, @"\s+").Where(l => !string.IsNullOrEmpty(l));
            this.keywords = new HashSet<string>(list);
        }
    }
}
