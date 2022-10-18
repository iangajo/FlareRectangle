namespace Rectangle.Application
{
    public interface IGridService
    {
        /// <summary>
        /// Create Grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        string[,] CreateGrid(int x, int y);

        /// <summary>
        /// Get Grid
        /// </summary>
        /// <returns></returns>
        string[,] GetGrid();

        void ClearGrid();
    }
}
