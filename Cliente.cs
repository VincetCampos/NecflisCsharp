using System;
public class Cliente{
    public string Nombre;
    public string Direccion;
    public int Edad;
    public int Id;
    private Pelicula[] playlist;

    public void mostrarplaylist(){
        if(playlist != null){
            foreach(Pelicula peliculaActual in playlist){
                Console.WriteLine(peliculaActual);
            }
        }
        
    }

    public void agregarPelicula(Pelicula nuevapelicula){
        if(playlist == null){
            playlist = new Pelicula[1];
            playlist[0] = nuevapelicula;
        }else{
            Pelicula[] nuevoplaylist = new Pelicula[playlist.Length + 1];

            Array.Copy(playlist, nuevoplaylist, playlist.Length);

            nuevoplaylist[nuevoplaylist.Length - 1] = nuevapelicula;

            this.playlist = nuevoplaylist;
        }
    }

    public Cliente(int Id, string Nombre, string Direccion, int Edad){
        this.Id = Id;

        this.Nombre = Nombre;

        this.Direccion = Direccion;

        this.Edad = Edad;
    }
}