using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cowsay.core {
    public class Cowsay {
        private readonly string _defaultEyes;
        private readonly string _defaultTongue;
        private readonly int _bubbleWidth;
        private readonly string _version = "0.1.0";

        public Cowsay() {
            _defaultEyes = "oo";
            _defaultTongue = " ";
            _bubbleWidth = 40;
        }

        private string GenerateCow(string eyes, string tongue) {
            var builder = new StringBuilder();
            builder.AppendLine("      \\  ^__^             ");
            builder.AppendLine($"       \\ {eyes}\\________    ");
            builder.AppendLine("         (__)\\        )\\/\\");
            builder.AppendLine($"          {tongue}   ||----w |   ");
            builder.AppendLine("              ||     ||   ");
            return builder.ToString();
        }

        private string GenerateMessageBubble(string message) {
            var lines = ConvertMessageToLines(message);
            throw new NotImplementedException();
        }

        private string ConvertMessageToLines(string message) {
            var words = SplitMessage(message);

            throw new NotImplementedException();
        }

        private IEnumerable<string> SplitMessage(string message) {
            var wordsSplitOnSpaces = message.Split(' ');
            List<string> words = new List<string>();

            foreach (var longWord in wordsSplitOnSpaces) {
                if (longWord.Length < _bubbleWidth) {
                    words.Add(longWord);

                }
                else {
                    var splitWords = Enumerable.Range(0, longWord.Length / _bubbleWidth)
                        .Select(x => longWord.Substring(x * _bubbleWidth, _bubbleWidth));
                    foreach (var splitWord in splitWords) {
                        if (!string.IsNullOrWhiteSpace(splitWord)) {
                            words.Add(splitWord);
                        }
                    }
                }
            }

            return words;
        }
        

        //private string GenearteMessageBubbleLine(int lineWidth, string delimeters, string message) {
        //    var line = delimeters
        //}

        private string DetermineMessageBubbleDelimiters(int lineNumber, int totalNumberOfLines) {
            if (totalNumberOfLines == 1) {
                return "<>";
            }

            if (lineNumber == 0) {
                return "/\\";
            }

            if (lineNumber == totalNumberOfLines - 1) {
                return "\\/";
            }

            return "||";
        }
    }
}
