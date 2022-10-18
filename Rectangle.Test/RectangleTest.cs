using Rectangle.Application;
using Rectangle.Infrastructure;

namespace Rectangle.Test
{
    [Collection("sequential")]
    public class RectangleTest
    {
        IGridService _gridService;
        public RectangleTest()
        {
            _gridService = new GridService();
            _gridService.CreateGrid(7, 11);
        }

        [Fact]
        public void Create_Rectangle()
        {
            var rectangleService = new RectangleService();


            rectangleService.Draw(1, 1, 3, 4);

            _gridService.GetGrid();

            var hasRectangle = rectangleService.Find(1, 1);

            Assert.True(hasRectangle);

        }

        [Fact]
        public void Remove_Rectangle()
        {

            var rectangleService = new RectangleService();


            rectangleService.Draw(4, 8, 3, 3);
            _gridService.GetGrid();

            rectangleService.Remove(4, 8);
            var hasRectangle = rectangleService.Find(4, 8);


            Assert.True(hasRectangle == false);

        }

        [Fact]
        public void Position_NonNegative_ThrowsException()
        {
            var rectangleService = new RectangleService();

            Exception exception = Assert.Throws<Exception>(() => rectangleService.Draw(-1, -5, 2, 6));
            Assert.Equal("Position should not be non-negative value.", exception.Message);

        }

        [Fact]
        public void Overlap_ThrowsException()
        {
            var rectangleService = new RectangleService();

            rectangleService.Draw(5, 2, 2, 5);

            Exception exception = Assert.Throws<Exception>(() => rectangleService.Draw(6, 2, 2, 5));
            Assert.Equal("Overlap detected.", exception.Message);

        }

        [Fact]
        public void ExtendedBeyondGrid_ThrowsException()
        {
            var rectangleService = new RectangleService();

            Exception exception = Assert.Throws<Exception>(() => rectangleService.Draw(3, 9, 3, 3));
            Assert.Equal("Has Extended Beyond Grid detected.", exception.Message);

        }
    }
}