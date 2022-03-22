using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeSolver.Reporting;
internal class WordWrapper {
    public WordWrapper(int width, string separator) {
        Width = width;
        Separator = separator;
    }

    public int Width { get; set; }
    public string Separator { get; set; }

    public string[] Wrap(string value) {
        if (string.IsNullOrEmpty(value)) {
            return Array.Empty<string>();
        }

        string[] tokens = Split(value);
        if (tokens.Length == 0) {
            return Array.Empty<string>();
        }

        var sbs = new List<StringBuilder>();

        for (int i = 0; i < tokens.Length; i++) {
            if (sbs.Count == 0) {
                GoToNewLine();
            }

            bool isFirst = i == 0;
            string token = tokens[i];
            var sb = sbs[^1];
            
            int resultingLength = sb.Length + token.Length;
            if (!isFirst) {
                resultingLength += Separator.Length;
            }

            if (resultingLength > Width) {
                GoToNewLine();
            } else {
                if (!isFirst) {
                    sb.Append(Separator);
                }
                sb.Append(token);
            }

            void GoToNewLine() {
                sbs.Add(new());
                i--;
            }
        }

        return sbs.Select(sb => sb.ToString()).ToArray();
    }

    private string[] Split(string value) =>
        value.Split(
            Separator,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
}
