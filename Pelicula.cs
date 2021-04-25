public class Pelicula{

    public string Titulo;

    public string Tipo;

    public string Genero;

    public string Sinopsis;

    public int Id;

    public override string ToString(){
        return "Id: " + Id + "Titulo: " + Titulo + " Tipo: " + Tipo + " Genero: " + Genero + " Sinopsis: " + Sinopsis;
    }

    public Pelicula(int Id, string Titulo, string Tipo, string Genero, string Sinopsis){
        this.Id = Id;

        this.Titulo = Titulo;

        this.Tipo = Tipo;

        this.Genero = Genero;

        this.Sinopsis = Sinopsis;
    }
}