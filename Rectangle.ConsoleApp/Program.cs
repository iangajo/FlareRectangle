// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Rectangle.Application;
using Rectangle.Infrastructure;

var serviceProvider = new ServiceCollection()
    .AddTransient<IGridService, GridService>()
    .AddTransient<IRectangleService, RectangleService>()
    .BuildServiceProvider();

var gridService = serviceProvider.GetService<IGridService>();
var rectangleService = serviceProvider.GetService<IRectangleService>();

Console.WriteLine("Please input grid size:");

Console.WriteLine("number of rows?");
var rowInput = Console.ReadLine();

Console.WriteLine("number of column?");
var columnInput = Console.ReadLine();

try
{
    gridService?.CreateGrid(Convert.ToInt32(rowInput), Convert.ToInt32(columnInput));


    Console.WriteLine("What is the X-Postion of the first rectangle?");
    var xPostion = Console.ReadLine();


    Console.WriteLine("What is the Y-Postion of the first rectangle?");
    var yPostion = Console.ReadLine();

    Console.WriteLine("What is the height of the first rectangle?");
    var height = Console.ReadLine();

    Console.WriteLine("What is the width of the first rectangle?");
    var width = Console.ReadLine();

    rectangleService?.Draw(Convert.ToInt32(xPostion), Convert.ToInt32(yPostion), Convert.ToInt32(height), Convert.ToInt32(width));



    Console.WriteLine("What is the X-Postion of the second rectangle?");
    xPostion = Console.ReadLine();


    Console.WriteLine("What is the Y-Postion of the second rectangle?");
    yPostion = Console.ReadLine();

    Console.WriteLine("What is the height of the second rectangle?");
    height = Console.ReadLine();

    Console.WriteLine("What is the width of the second rectangle?");
    width = Console.ReadLine();

    rectangleService?.Draw(Convert.ToInt32(xPostion), Convert.ToInt32(yPostion), Convert.ToInt32(height), Convert.ToInt32(width));


    //var isFound = rectangleService?.Find(0, 5);

    //if (isFound == true)
    //    Console.WriteLine("Rectangle found.");


    //rectangleService?.Remove(0, 4);

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{

    var grid = gridService?.GetGrid();

    var row = grid?.GetLength(0);
    var column = grid?.GetLength(1);

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            var data = grid?[i, j];

            if (!string.IsNullOrEmpty(data))
            {
                Console.Write(string.Format("{0} ", "x"));
            }
            else
            {
                Console.Write(string.Format("{0} ", "O"));
            }

        }
        Console.Write(Environment.NewLine + Environment.NewLine);
    }
}


Console.ReadLine();