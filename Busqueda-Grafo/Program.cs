using System;
/*INTEGRANTES:
 
->Avendaño Villegas Brandon
->Rojo Hernandez Andrea Susana
->Trejo Martinez Jorge Joshua

    Es importante recordar que el código fue hecho única y exclusivamente para funcionar sobre el grafo
    planteado en clases. Los métodos aquí pueden o no funcionar para un grafo en general.
    
 */
namespace Grafo
{
    /*Esta clase fungira como el menu de nuestra aplicacion y contendra toda la logica necesaria para mandar 
    a ejecutar procesos ya declarados*/
    class Program
    {
        /*Imprimimos en consola los difrentes algoritmos ya programados en la clase Grafo
        para que el usuario seleccione uno de los 5*/
        public static void Menu()
        {
            Console.WriteLine("1 busqueda en profundidad, '2' busqueda en ancho, '3' primero mejor, '4' Maxima Pendiente '5' Pendiente Simple");
        }
        /*Una vez elegido el algoritmo con el cual se recorrera el grafo le damos la opcion al usuario 
        de elegir de que forma quiere que se recorra, en sentido horrario o antihorario*/
        public static void Menu2()
        {
            Console.WriteLine("¿En qué sentido deseas la busqueda? 'x' Antihorario, 'y' horario");
        }

        /*Clase principal que mandara a imprimir los metodos Menu y Menu2. Tambien se encarga de mandar a
        ejecutar las algoritmos y mostrar el resultado en consola. Basicamente tiene toda la logica del menu*/
        static void Main(string[] args)
        {
            Grafo grafy = new Grafo();
            int opc;
            string opc2;
            while (true)
            {
                Menu();
                opc = int.Parse(Console.ReadLine());



                int inici, final;
                switch (opc)
                {

                    case 1:

                        Console.Write("Inicial: ");
                        inici = int.Parse(Console.ReadLine());
                        Console.Write("Meta: ");
                        final = int.Parse(Console.ReadLine());
                        Console.WriteLine("");



                        Menu2();
                        opc2 = Console.ReadLine();
                        switch (opc2)
                        {
                            case "x":
                                grafy = VARIABLESESTATICAS.grafoAntiHorario;
                                break;
                            case "y":
                                grafy = VARIABLESESTATICAS.grafoHorario;
                                break;
                        }
                        grafy.BusquedaEnProfundidad(inici.ToString(), final.ToString());
                        break;

                    case 2:

                        Console.Write("Inicial:");
                        inici = int.Parse(Console.ReadLine());
                        Console.Write("Meta:");
                        final = int.Parse(Console.ReadLine());
                        Menu2();
                        opc2 = Console.ReadLine();
                        switch (opc2)
                        {
                            case "x":
                                grafy = VARIABLESESTATICAS.grafoAntiHorario;
                                break;
                            case "y":
                                grafy = VARIABLESESTATICAS.grafoHorario;
                                break;
                        }
                        grafy.BusquedaEnAncho(inici.ToString(), final.ToString());
                        break;
                    case 3:
                        grafy = VARIABLESESTATICAS.grafoHorario;
                        Console.Write("Inicial:");
                        inici = int.Parse(Console.ReadLine());
                        Console.Write("Meta:");
                        final = int.Parse(Console.ReadLine());
                        grafy.BusquedaPrimeroMejor(inici.ToString(), final.ToString());
                        break;
                    case 4:
                        grafy = VARIABLESESTATICAS.grafoHorario;
                        Console.Write("Inicial:");
                        inici = int.Parse(Console.ReadLine());
                        Console.Write("Meta:");
                        final = int.Parse(Console.ReadLine());
                        grafy.BusquedaCimaMejorada(inici.ToString(), final.ToString());
                        break;
                    case 5:
                        Console.Write("Inicial: ");
                        inici = int.Parse(Console.ReadLine());
                        Console.Write("Meta: ");
                        final = int.Parse(Console.ReadLine());
                        Console.WriteLine("");



                        Menu2();
                        opc2 = Console.ReadLine();
                        switch (opc2)
                        {
                            case "x":
                                grafy = VARIABLESESTATICAS.grafoAntiHorario;
                                break;
                            case "y":
                                grafy = VARIABLESESTATICAS.grafoHorario;
                                break;
                        }
                        grafy.busquedaCima(inici.ToString(), final.ToString());
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }

        }
    }
}