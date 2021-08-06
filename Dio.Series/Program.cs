using System;
using Dio.Series.App.View;
using Dio.Series.App.Controller;
using Dio.Series.App.Repository;

namespace Dio.Series
{
    class Program
    {
        static void Main()
        {   
            SerieRepository repository = new();
            MainController mainController = new(repository);

            new CommandLineUI(mainController).Interact();
        }
    }
}
