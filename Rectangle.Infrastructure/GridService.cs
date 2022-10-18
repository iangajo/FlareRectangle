using Rectangle.Application;
using Rectangle.Domain.Constants;

namespace Rectangle.Infrastructure
{
    public class GridService : IGridService
    {
        public void ClearGrid()
        {
            MemoryDatabase.MemGrid = new string[0, 0];
        }

        /// <summary>
        /// Create Grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string[,] CreateGrid(int x, int y)
        {
            if (x < Constants.MIN_ROW || y < Constants.MIN_ROW) throw new ArgumentOutOfRangeException("A grid must have a width and height of no less than 5 and no greater than 25");
            if (x > Constants.MAX_ROW || y > Constants.MAX_ROW) throw new ArgumentOutOfRangeException("A grid must have a width and height of no less than 5 and no greater than 25");

            return MemoryDatabase.CreateGrid(x, y);
        }

        /// <summary>
        /// Get the populated Grid
        /// </summary>
        /// <returns></returns>
        public string[,] GetGrid()
        {
            var data = MemoryDatabase.Rectangles;

            foreach (var item in data)
            {
                foreach (var pos in item.Value)
                {
                    var position = pos.Split(',');
                    var rowInput = Convert.ToInt32(position[0]);
                    var columnInput = Convert.ToInt32(position[1]);

                    MemoryDatabase.MemGrid[rowInput, columnInput] = "x";
                }
            }

            return MemoryDatabase.MemGrid;
        }


    }
}
