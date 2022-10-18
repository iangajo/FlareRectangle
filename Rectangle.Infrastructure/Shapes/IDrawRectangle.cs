namespace Rectangle.Infrastructure.Shapes
{
    public interface IDrawRectangle
    {
        void Draw(int x, int y, int row, int column);
        bool HasOverlap(int x, int y, int row, int column);
        bool HasExtendedBeyondGrid(int x, int y, int row, int column);
    }
}
