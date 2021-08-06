namespace Dio.Series.App.Model
{
    public record SerieDto
    {   
        public Genero Genero { get; init; }
        public string Titulo { get; init; }
        public string Descricao { get; init; }
        public int Ano { get; init; }

        public SerieDto(Genero genero, string titulo, string descricao, int ano)
        {
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }

        
    }
}