using System;
using System.Linq;
using Dio.Series.App.Model;
using Dio.Series.App.Repository;
using Dio.Series.App.View;

namespace Dio.Series.App.Controller
{   
   
    public class MainController
    {   
        private static int idGenerator = 0;

        private SerieRepository repository;

        public MainController(SerieRepository repository)
        {
            this.repository = repository;
        }

        public string Execute(string command, CommandLineUI ui) 
        {
            return command switch
            {
                Commands.addCommand => ui.AddInteraction(),
                Commands.RemoveCommand => ui.RemoveInteraction(),
                Commands.getAllCommand => GetAll(),
                Commands.getOneCommand => ui.GetOneInteraction(),
                Commands.updateCommand => ui.UpdateInteraction(),
                Commands.exit => ui.ByeGreeting(),
                _ => "comando desconhecido",
            };
        }

        internal string Add(SerieDto serieDto)
        {   
            Serie toAdd = new(++idGenerator, 
                                serieDto.Genero, 
                                serieDto.Titulo, 
                                serieDto.Ano, 
                                serieDto.Descricao);
            
            repository.Add(toAdd);

            return "adicionado:" + Environment.NewLine
            + toAdd.ToString();
        }

        internal string RemoveSerie(int id)
        {
            Serie toRemove = repository.GetOne(id);
            repository.Remove(id);
            
            return "removido:" + Environment.NewLine
            + toRemove.ToString();
        }

        internal string Update(int Id, SerieDto serieDto) 
        {
            Serie toUpdate = new(Id, 
                                serieDto.Genero, 
                                serieDto.Titulo, 
                                serieDto.Ano, 
                                serieDto.Descricao);
            
            repository.Update(toUpdate);

            return "editado:" + Environment.NewLine
            + toUpdate.ToString();

        }

        internal string GetAll(){
            var series = repository.GetAll();

            if(series.Count == 0) {
                return "a lista está vazia";
            } 


            return "séries:" + Environment.NewLine
                    + String.Join("," + Environment.NewLine + Environment.NewLine, 
                                repository.GetAll().Select(serie => serie.ToString()).ToList());
        }

        internal string GetOne(int indexSerie) {
            return "série:" + Environment.NewLine 
                    + repository.GetOne(indexSerie).ToString();
        }

        internal bool SerieExists(int indexSerie)
        {
            return repository.Contains(indexSerie);
        }
    }
}