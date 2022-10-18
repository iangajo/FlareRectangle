namespace Rectangle.Infrastructure
{
    public static class MemoryDatabase
    {
        public static Dictionary<string, List<string>> Rectangles = new Dictionary<string, List<string>>();

        public static string[,] MemGrid = new string[0, 0];
        public static string[,] CreateGrid(int x, int y)
        {
            Array.Clear(MemGrid);

            MemGrid = new string[x, y];

            return MemGrid;
        }

    }
}
