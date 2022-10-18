using Rectangle.Domain;

namespace Rectangle.Infrastructure.Shapes
{
    public class Rectangle : Shape, IDrawRectangle
    {
        public void Draw(int x, int y, int row, int column)
        {
            var key = $"{x},{y},{row},{column}";
            var values = new List<string>();

            for (int i = 0; i < column; i++)
            {
                values.Add($"{x},{y + i}");

                for (int j = 0; j < row; j++)
                {
                    values.Add($"{x + j},{y + i}");
                }
            }

            MemoryDatabase.Rectangles.Add(key, values);
        }

        public bool HasOverlap(int x, int y, int row, int column)
        {
            var positions = new List<string>();

            for (int i = 0; i < column; i++)
            {

                positions.Add($"{x},{y + i}");

                for (int j = 0; j < row; j++)
                {

                    positions.Add($"{x + j},{y + i}");

                }
            }

            var data = MemoryDatabase.Rectangles.Select(s => s.Value).ToList();

            foreach (var item in data)
            {
                foreach (var pos in item)
                {
                    if (positions.Contains(pos)) return true;
                }

            }

            return false;

        }

        public override bool Find(int x, int y)
        {
            var position = $"{x},{y}";

            return MemoryDatabase.Rectangles.Any(s => s.Value.Contains($"{x},{y}"));
        }

        public override void Remove(int x, int y)
        {
            var key = MemoryDatabase.Rectangles.FirstOrDefault(s => s.Value.Contains($"{x},{y}")).Key;

            MemoryDatabase.Rectangles.Remove(key);

        }

        public bool HasExtendedBeyondGrid(int x, int y, int row, int column)
        {
            var height = MemoryDatabase.MemGrid.GetLength(0);
            var width = MemoryDatabase.MemGrid.GetLength(1);

            var maxHeight = x + row;
            var maxWidth = y + column;

            if (maxHeight > height) return true;
            if (maxWidth > width) return true;

            return false;
        }
    }
}
