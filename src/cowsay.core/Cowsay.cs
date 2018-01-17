 using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cowsay.core {
    public class Cowsay : ICowsay {
        private readonly int _bubbleWidth;
        private readonly string _version;

        public Cowsay() {
            _bubbleWidth = 40;
            _version = "0.1.0";
        }

        public string GetVersion() {
            var builder = new StringBuilder();
            builder.AppendLine(GenerateMessageBubble($"nCowsay version {_version}"));
            builder.Append(GenerateCow(ModeSettings.FindMode(Modes.Default)));
            return builder.ToString();
        }

        public string GetCow(string message, Modes mode = Modes.Default) {
            var builder = new StringBuilder();
            builder.Append(GenerateMessageBubble(message));
            builder.Append(GenerateCow(ModeSettings.FindMode(mode)));
            return builder.ToString();
        }

        private string GenerateCow(ModeSetting settings) {
            var builder = new StringBuilder();
            builder.AppendLine("      \\  ^__^             ");
            builder.AppendLine($"       \\ ({settings.Eyes})\\________    ");
            builder.AppendLine("         (__)\\        )\\/\\");
            builder.AppendLine($"         {settings.Tongue}    ||----w |   ");
            builder.AppendLine("              ||     ||   ");
            return builder.ToString();
        }

        private string GenerateMessageBubble(string message) {
            var lines = ConvertMessageToLines(message).ToList();
            var lineWidth = MaxWidth(lines);

            var builder = new StringBuilder();
            builder.AppendLine(GenerateMessageBubbleBoundaryLine(lineWidth, '_'));

            foreach (var index in Enumerable.Range(0, lines.Count)) {
                var delemiters = DetermineMessageBubbleDelimiters(index, lines.Count);
                builder.AppendLine(GenearteMessageBubbleLine(lineWidth, delemiters, $" {lines[index]} "));
            }

            builder.AppendLine(GenerateMessageBubbleBoundaryLine(lineWidth, '-'));
            return builder.ToString();
        }

        private IEnumerable<string> ConvertMessageToLines(string message) {
            var words = SplitMessage(message);
            var lines = new List<string>();
            var line = string.Empty;
            foreach (var word in words) {
                if (line.Length + word.Length + 1 > _bubbleWidth) {
                    if (!string.IsNullOrWhiteSpace(line)) {
                        lines.Add(line);
                    }

                    line = word;
                }
                else {
                    if (string.IsNullOrWhiteSpace(line)) {
                        line = word;
                    }
                    else {
                        line = " " + word;
                    }
                }
            }

            var lastLine = line;
            lines.Add(lastLine);
            return lines;
        }

        private IEnumerable<string> SplitMessage(string message) {
            var wordsSplitOnSpaces = message.Split(' ');
            var words = new List<string>();

            foreach (var longWord in wordsSplitOnSpaces) {
                if (longWord.Length < _bubbleWidth) {
                    words.Add(longWord);
                }
                else {
                    var splitWords = Enumerable.Range(0, longWord.Length / _bubbleWidth)
                        .Select(x => longWord.Substring(x * _bubbleWidth, _bubbleWidth));
                    words.AddRange(splitWords.Where(splitWord => !string.IsNullOrWhiteSpace(splitWord)));
                }
            }

            return words;
        }

        private int MaxWidth(IEnumerable<string> lines) {
            return lines.Select(line => line.Length).Concat(new[] {0}).Max();
        }

        private string GenerateMessageBubbleBoundaryLine(int lineWidth, char boundaryChar) {
            return GenearteMessageBubbleLine(lineWidth, "  ", "".PadRight(lineWidth + 2, boundaryChar));
        }
        
        private string GenearteMessageBubbleLine(int lineWidth, string delimeters, string message) {
            return (delimeters[0] + message.PadRight(lineWidth + 2, ' ') + delimeters[1]).TrimEnd();
        }

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
