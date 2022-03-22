namespace IterativeSolver.Reporting;

internal partial class Table {
    public class Cell {
        public Cell(string text) {
            Text = text;
        }

        public string Text { get; }

        public static implicit operator Cell(string text) =>
            new Cell(text);
    }
}
