namespace Rectangle.Application
{
    public interface IRectangleService
    {
        /// <summary>
        /// Draw the rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        void Draw(int x, int y, int row, int column);

        /// <summary>
        /// Remove the rectangle bse on the position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void Remove(int x, int y);

        /// <summary>
        /// Find the rectangle base on the position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool Find(int x, int y);
    }
}
