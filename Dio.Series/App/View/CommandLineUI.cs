using System;
using Dio.Series.App.Controller;
using Dio.Series.App.Model;


namespace Dio.Series.App.View
{
    public class CommandLineUI
    {
        readonly string nl = Environment.NewLine;

        MainController mainController;

        public CommandLineUI(MainController mainController)
        {
            this.mainController = mainController;
        }

        public void Interact() {
            
            Console.WriteLine("Bem vindo ao melhor gerenciador de series para terminal de comando" + nl);
            
            while(true) {
                Console.WriteLine($"Digite um comando {Commands.allCommands}");
                Console.Write("> ");
                string command = Console.ReadLine();
                
                string response = mainController.Execute(command, this);
                Console.WriteLine(nl + response + nl);

            }
        }

        public string RemoveInteraction()
        {
            Console.WriteLine("Remova uma série");

            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            if(!mainController.SerieExists(indiceSerie)) {
                return "não foi encontrada série com id " + indiceSerie;
            }

            return mainController.RemoveSerie(indiceSerie); 

        }

        public string AddInteraction() 
        {
            Console.WriteLine("Inserir nova série");

            var serieDto = GetSerieDataFromInput();
	
			return mainController.Add(serieDto);
        }

        public string UpdateInteraction() {
            Console.WriteLine("Edite as informações da serie");

            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            if(!mainController.SerieExists(indiceSerie)) {
                return "não foi encontrada série com id " + indiceSerie;
            } 

            var serieDto = GetSerieDataFromInput();
	
			return mainController.Update(indiceSerie, serieDto);
        }

        public string GetOneInteraction() {
            Console.WriteLine("Visualize as informações da serie");

            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            if(!mainController.SerieExists(indiceSerie)) {
                return "não foi encontrada série com id " + indiceSerie;
            } 

            return mainController.GetOne(indiceSerie);
        }

        private SerieDto GetSerieDataFromInput() {
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima:");
            Console.Write("> ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o Título da Série: ");
            Console.Write("> ");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o Ano de Início da Série: ");
            Console.Write("> ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a Descrição da Série: ");
            Console.Write("> ");
			string entradaDescricao = Console.ReadLine();

            return new SerieDto((Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
        }

        public string ByeGreeting(){
        
            Console.WriteLine(nl + "Até a próxima" + nl);
            System.Environment.Exit(0);
            return "";        
        }
        
    }

    static class Commands {
        public const string addCommand = "adicionar";
        public const string updateCommand = "editar";
        public const string getAllCommand = "listar";
        public const string RemoveCommand = "remover";
        public const string getOneCommand = "visualizar";
        public const string exit = "sair";

        public const string allCommands = "(" 
            + addCommand + ", "
            + updateCommand + ", "
            + getAllCommand + ", "
            + RemoveCommand + ", "
            + getOneCommand + ", "
            + exit
            + ")";
    }

   
}