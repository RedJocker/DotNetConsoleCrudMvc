namespace Dio.Series.App.Model
{
    public class Serie
    {
        private int Id { get; set; }
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, int ano, string descricao)
        {   
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Ano = ano;
            Descricao = descricao;
        }

        public override string ToString()
        {
            var nl = System.Environment.NewLine;
            return $"(Id: {Id},{nl}Genero: {Genero},{nl}Titulo: {Titulo},{nl}Descricao: {Descricao},{nl}Ano:{Ano})";
        }

        public int GetId() {
            return Id;
        }

    }
}