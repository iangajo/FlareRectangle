using Rectangle.Application;

namespace Rectangle.Infrastructure
{
    public class RectangleService : IRectangleService
    {
        /// <summary>
        /// Draw the rectangle in the grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Draw(int x, int y, int row, int column)
        {
            Validate(x, y, row, column);

            var rectangle = new Shapes.Rectangle();
            rectangle.Draw(x, y, row, column);

        }

        /// <summary>
        /// base on the position, we can determine if there's a rectangle on it
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Find(int x, int y)
        {
            var rectangle = new Shapes.Rectangle();

            return rectangle.Find(x, y);
        }

        /// <summary>
        /// Remove the rectangle base on the grid position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Remove(int x, int y)
        {
            var rectangle = new Shapes.Rectangle();

            rectangle.Remove(x, y);
        }

        /// <summary>
        /// Validate the rectangle before we draw, we check for non-negative value
        /// rectangle overlap and extended beyond grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="Exception"></exception>
        private void Validate(int x, int y, int row, int column)
        {
            if (x < 0 || y < 0) throw new Exception("Position should not be non-negative value.");

            var rectangle = new Shapes.Rectangle();
            var isOverlap = rectangle.HasOverlap(x, y, row, column);

            if (isOverlap) throw new Exception("Overlap detected.");

            var hasExtendedBeyondGrid = rectangle.HasExtendedBeyondGrid(x, y, row, column);
            if (hasExtendedBeyondGrid) throw new Exception("Has Extended Beyond Grid detected.");

        }
    }
}
