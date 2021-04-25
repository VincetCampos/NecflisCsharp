using System;
using System.Collections.Generic;

namespace Nuevoproyecto
{
    class Program
    {
        public Dictionary < int, Cliente > registroClientes = new Dictionary < int, Cliente >();

        public Dictionary < int, Pelicula> registroPeliculas = new Dictionary < int, Pelicula> ();

        public int ContadorPeliculas = 1;

        public int ContadorClientes = 1;

        static void Main(string[] args)
        {
            Program miPrograma = new Program();
            Console.WriteLine("-----Necflis-----");
            Console.WriteLine("Bienvenido");
            while (true)
            {
                Console.WriteLine("Elija una opcion");
                Console.WriteLine("1. Clientes");
                Console.WriteLine("2. Peliculas");
                Console.WriteLine("3. Salir");
                string opcion = Console.ReadLine();
                if(opcion == "1"){
                    Console.WriteLine("Esta es la lista de clientes");
                    while(true){
                        Console.WriteLine("Elija una opcion");
                        Console.WriteLine("1. Ver el listado clientes");
                        Console.WriteLine("2. Crear un nuevo cliente");
                        Console.WriteLine("3. Seleccionar clientes");
                        Console.WriteLine("4. atras");
                        string opcion2 = Console.ReadLine();
                        if(opcion2 == "1"){
                            Console.WriteLine("Listado de cliente");
                            miPrograma.vistaClientes();
                        }else if(opcion2 == "2"){
                            Console.WriteLine("Agregar un cliente");
                            miPrograma.ingresoClientes();
                        }else if(opcion2 == "3"){
                            Console.WriteLine("Seleccionar un cliente");
                            Console.WriteLine("elija una opcion");
                            miPrograma.SeleccionarCliente();
                        }else if(opcion2 == "4"){
                            Console.WriteLine("Regresara al menu principal");
                            break;
                        }else{
                            Console.WriteLine("Esa no es una opcion valida");
                        }
                    }
                    
                }else if(opcion == "2"){
                    Console.WriteLine("Esta es la opcion de las peliculas");
                    while(true){
                        Console.WriteLine("Elija una opcion");
                        Console.WriteLine("1. Ver el listado de peliculas");
                        Console.WriteLine("2. Crear pelicula");
                        Console.WriteLine("3. atras");
                        string opcion3 = Console.ReadLine();
                        if(opcion3 == "1"){
                            Console.WriteLine("Listado de peliculas");
                            miPrograma.ListaPeliculas();
                        }else if(opcion3 == "2"){
                            Console.WriteLine("Creacion de peliculas");
                            miPrograma.ingresoPeliculas();
                        }else if(opcion3 == "3"){
                            Console.WriteLine("Regresara al menu principal");
                            break;
                        }else{
                            Console.WriteLine("Opcion no valida");
                        }
                    }

                }else if(opcion == "3"){
                    Console.WriteLine("Hasta pronto");
                    break;
                }else{
                    Console.WriteLine("Elija una opcion valida");
                }
            }
        }

        public void ingresoClientes(){
            Console.WriteLine("Ingrese el nombre del cliente");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion del cliente");
            string direccion = Console.ReadLine();
            Console.WriteLine("Ingrese la edad del cliente");
            int edad = Int16.Parse(Console.ReadLine());

            Cliente nuevoCliente = new Cliente(ContadorClientes, nombre, direccion, edad);
            
            registroClientes.Add(nuevoCliente.Id, nuevoCliente);

            Console.WriteLine("Nuevo cliente ingresado id: " + nuevoCliente.Id);
            
            ContadorClientes ++;
        }

        public void vistaClientes(){
            Console.WriteLine("-----");

            foreach(KeyValuePair<int, Cliente> cliente in registroClientes){ 
                Console.WriteLine(cliente.Key + " --- Nombre: " + cliente.Value.Nombre + " Direccion: " + cliente.Value.Direccion + " Edad: " + cliente.Value.Edad);
            }

            Console.WriteLine("-----");
        }

        public void ingresoPeliculas(){
            Console.WriteLine("Ingrese el titulo de la pelicula o serie");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el tipo de la pelicula o serie");
            string tipo = "Serie";
            while(true){
                Console.WriteLine("1. Pelicula");
                Console.WriteLine("2. Serie");
                string tiponumerico = Console.ReadLine();
                
                if(tiponumerico == "1"){
                    tipo = "Pelicula";
                    break;
                }else if(tiponumerico == "2"){
                    break;
                }else{
                    Console.WriteLine("No es una opcion valida");
                }
            }
            Console.WriteLine("Ingrese el genero");
            string genero = Console.ReadLine();
            Console.WriteLine("Ingrese la descripcion");
            string sinopsis = Console.ReadLine();

            Pelicula nuevaPelicula = new Pelicula(ContadorPeliculas, titulo, tipo, genero, sinopsis);
            
            registroPeliculas.Add(nuevaPelicula.Id, nuevaPelicula);

            Console.WriteLine("Nueva pelicula/serie ingresada id: " + nuevaPelicula.Id);
            
            ContadorPeliculas ++;
        }
        public void ListaPeliculas(){
            Console.WriteLine("-----");

            foreach(KeyValuePair<int, Pelicula> pelicula in registroPeliculas){ 
                Console.WriteLine(pelicula.Key + " --- titulo: " + pelicula.Value.Titulo + " tipo: " + pelicula.Value.Tipo + " genero: " + pelicula.Value.Genero + " sinopsis: " + pelicula.Value.Sinopsis);
            }

            Console.WriteLine("-----");
        }

        public void SeleccionarCliente(){
            while(true){
                vistaClientes();
                Console.WriteLine("Elija el id del cliente");
                int opcion4 = Int16.Parse(Console.ReadLine());
                Cliente micliente = BuscarCliente(opcion4);
                if(micliente == null){
                    Console.WriteLine("Cliente inexistente");
                }else{
                    Console.WriteLine(micliente.Id + " --- Nombre: " + micliente.Nombre + " Direccion: " + micliente.Direccion + " Edad: " + micliente.Edad);
                    while(true){
                        Console.WriteLine("1. playlist");
                        Console.WriteLine("2. Agregar a la playlist");
                        Console.WriteLine("3. atras");
                        string opcion5 = Console.ReadLine();
                        if(opcion5 == "1"){
                            Console.WriteLine("--playlist--");
                            micliente.mostrarplaylist();
                        }else if(opcion5 == "2"){
                            Console.WriteLine("Agregar a la playlist");
                            ListaPeliculas();
                            Console.WriteLine("Elija una pelicula");
                            Console.WriteLine("Elija 0 para cancelar");
                            int opcionpelicula = Int16.Parse(Console.ReadLine());
                            if(opcionpelicula == 0){
                                break;
                            }
                            Pelicula mipelicula = BuscarPelicula(opcionpelicula);
                            if(mipelicula == null){
                                Console.WriteLine("Pelicula inexistente");
                            }else{
                                micliente.agregarPelicula(mipelicula);
                                Console.WriteLine("Pelicula agregada");
                            }
                        }else if(opcion5 == "3"){
                            Console.WriteLine("Volviendo a la seleccion");
                            break;
                        }else{
                            Console.WriteLine("Opcion no valida");
                        }
                    }
                    
                    break;
                }
            }
        }

        private Cliente BuscarCliente (int clienteId){
            Cliente resultado;

            if (registroClientes.TryGetValue(clienteId, out resultado))
            {
                return resultado;
            }
            else
            {
                return null;
            }

        }
        private Pelicula BuscarPelicula (int peliculaId){
            Pelicula resultado;

            if (registroPeliculas.TryGetValue(peliculaId, out resultado))
            {
                return resultado;
            }
            else
            {
                return null;
            }

        }
    }
    
}
