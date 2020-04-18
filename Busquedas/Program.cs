using System;
using System.Collections.Generic;

namespace Busquedas {
    class Program {

        /// <summary>
        /// Variables globales para la recursión
        /// </summary>
        List<Ruta> rutas = new List<Ruta>();
        List<String> memoria = new List<string>();
        List<String> rutaMenorCosto = new List<string>();
        int costoMenorVariable = 0;

        /// <summary>
        /// Metodo que crea el Directorio de rutas y costos
        /// </summary>
        public void CrearRutas () {
            rutas.Add(new Ruta { salida = "Oradea", destino = "Zerind", costo = 71 });
            rutas.Add(new Ruta { salida = "Oradea", destino = "Sibiu", costo = 151 });
            rutas.Add(new Ruta { salida = "Zerind", destino = "Oradea", costo = 71 });
            rutas.Add(new Ruta { salida = "Zerind", destino = "Arad", costo = 75 });
            rutas.Add(new Ruta { salida = "Arad", destino = "Zerind", costo = 75 });
            rutas.Add(new Ruta { salida = "Arad", destino = "Sibiu", costo = 140 });
            rutas.Add(new Ruta { salida = "Arad", destino = "Timisoara", costo = 118 });
            rutas.Add(new Ruta { salida = "Timisoara", destino = "Arad", costo = 118 });
            rutas.Add(new Ruta { salida = "Timisoara", destino = "Lugoj", costo = 111 });
            rutas.Add(new Ruta { salida = "Lugoj", destino = "Timisoara", costo = 111 });
            rutas.Add(new Ruta { salida = "Lugoj", destino = "Mehadia", costo = 70 });
            rutas.Add(new Ruta { salida = "Mehadia", destino = "Lugoj", costo = 70 });
            rutas.Add(new Ruta { salida = "Mehadia", destino = "Dobreta", costo = 75 });
            rutas.Add(new Ruta { salida = "Dobreta", destino = "Mehadia", costo = 75 });
            rutas.Add(new Ruta { salida = "Dobreta", destino = "Craiova", costo = 120 });
            rutas.Add(new Ruta { salida = "Craiova", destino = "Dobreta", costo = 120 });
            rutas.Add(new Ruta { salida = "Craiova", destino = "Rimnicu Vilcea", costo = 146 });
            rutas.Add(new Ruta { salida = "Craiova", destino = "Pitesti", costo = 138 });
            rutas.Add(new Ruta { salida = "Sibiu", destino = "Arad", costo = 140 });
            rutas.Add(new Ruta { salida = "Sibiu", destino = "Oradea", costo = 151 });
            rutas.Add(new Ruta { salida = "Sibiu", destino = "Fagaras", costo = 99 });
            rutas.Add(new Ruta { salida = "Sibiu", destino = "Rimnicu Vilcea", costo = 80 });
            rutas.Add(new Ruta { salida = "Rimnicu Vilcea", destino = "Sibiu", costo = 80 });
            rutas.Add(new Ruta { salida = "Rimnicu Vilcea", destino = "Pitesti", costo = 97 });
            rutas.Add(new Ruta { salida = "Rimnicu Vilcea", destino = "Craiova", costo = 146 });
            rutas.Add(new Ruta { salida = "Pitesti", destino = "Rimnicu Vilcea", costo = 97 });
            rutas.Add(new Ruta { salida = "Pitesti", destino = "Craiova", costo = 138 });
            rutas.Add(new Ruta { salida = "Pitesti", destino = "Bucarest", costo = 101 });
            rutas.Add(new Ruta { salida = "Fagaras", destino = "Sibiu", costo = 99 });
            rutas.Add(new Ruta { salida = "Fagaras", destino = "Bucarest", costo = 211 });
            rutas.Add(new Ruta { salida = "Bucarest", destino = "Pitesti", costo = 101 });
            rutas.Add(new Ruta { salida = "Bucarest", destino = "Fagaras", costo = 211 });
            rutas.Add(new Ruta { salida = "Bucarest", destino = "Giurgiu", costo = 90 });
            rutas.Add(new Ruta { salida = "Bucarest", destino = "Urziceni", costo = 85 });
            rutas.Add(new Ruta { salida = "Giurgiu", destino = "Bucarest", costo = 90 });
            rutas.Add(new Ruta { salida = "Urziceni", destino = "Bucarest", costo = 85 });
            rutas.Add(new Ruta { salida = "Urziceni", destino = "Hirsova", costo = 98 });
            rutas.Add(new Ruta { salida = "Urziceni", destino = "Vaslui", costo = 142 });
            rutas.Add(new Ruta { salida = "Hirsova", destino = "Urziceni", costo = 98 });
            rutas.Add(new Ruta { salida = "Hirsova", destino = "Eforie", costo = 86 });
            rutas.Add(new Ruta { salida = "Eforie", destino = "Hirsova", costo = 86 });
            rutas.Add(new Ruta { salida = "Vaslui", destino = "Urziceni", costo = 142 });
            rutas.Add(new Ruta { salida = "Vaslui", destino = "Iasi", costo = 92 });
            rutas.Add(new Ruta { salida = "Iasi", destino = "Vaslui", costo = 92 });
            rutas.Add(new Ruta { salida = "Iasi", destino = "Neamt", costo = 87 });
            rutas.Add(new Ruta { salida = "Neamt", destino = "Iasi", costo = 87 });
        }

        /// <summary>
        /// Struct para crear el Directorio con la información
        /// </summary>
        struct Ruta {
            public String salida { get; set; }
            public String destino { get; set; }
            public int costo { get; set; }
        }

        /// <summary>
        /// Metodo para crear el arbol n-ario
        /// </summary>
        /// <param name="ciudad"> Nodo de inicio,
        /// con esto empieza la creación del arbol</param>
        public void CrearArbol (Nodo ciudad) {
            memoria.Add(ciudad.GetCiudad());

            foreach (Ruta ruta in rutas) {

                if (ruta.salida.Equals(ciudad.GetCiudad())) {

                    if (!memoria.Contains(ruta.destino)) {

                        ciudad.InsertarCiudad(new Nodo(ruta.destino, ruta.costo));
                    }
                }
            }

            for (int i = 0; i< ciudad.NumeroRutas(); i++) {

                if (ciudad.RutaHija(i+1) != null) {

                    CrearArbol(ciudad.RutaHija(i+1));
                }
            }

            memoria.Remove(ciudad.GetCiudad());
        }

        /// <summary>
        /// Metodo para buscar todas las rutas posibles de a ciudad de
        /// salida a la ciudad de destino
        /// </summary>
        /// <param name="ciudad">ciudad de salida de tipo Nodo</param>
        /// <param name="destinoFinal">ciudad de destino de tipos String</param>
        public void RutasAmplitud (Nodo ciudad, String destinoFinal) {
            memoria.Add(ciudad.GetCiudad());

            if (memoria.Contains(destinoFinal)) {

                Console.WriteLine("");
                Console.WriteLine("==============  RUTA  =============");
                foreach (String elemento in memoria) {
                    
                    Console.WriteLine(elemento);

                }
                Console.WriteLine("");
                Console.WriteLine("===================================");

                memoria.Remove(destinoFinal);

                return;
            }

            for (int i = 0; i < ciudad.NumeroRutas(); i++) {

                if (ciudad.RutaHija(i+1) != null) {

                    RutasAmplitud(ciudad.RutaHija(i+1), destinoFinal);
                }
            }

            memoria.Remove(ciudad.GetCiudad());
        }

        /// <summary>
        /// Metodo que aplica la Busqueda de Costo Uniforme
        /// </summary>
        /// <param name="ciudad">ciudad de salida de tipos Nodo</param>
        /// <param name="destinoFinal">ciudad de destino de tipo String</param>
        /// <param name="costoMenor">valor de tipo int que almacena el menor costo</param>
        /// <returns></returns>
        public int BusquedaCostoUniforme (Nodo ciudad, String destinoFinal,
            int costoMenor) {
            memoria.Add(ciudad.GetCiudad());

            if (memoria.Contains(destinoFinal)) {

                if (costoMenor == 0) {

                    costoMenor = costoMenorVariable;
                    foreach (String elemento in memoria) {
                        rutaMenorCosto.Add(elemento);
                    }

                } else {

                    if (costoMenor > costoMenorVariable) {

                        rutaMenorCosto.Clear();
                        costoMenor = costoMenorVariable;

                        foreach (String elemento in memoria) {

                            rutaMenorCosto.Add(elemento);
                        }
                    }
                }
            }

            for (int i = 0; i < ciudad.NumeroRutas(); i++) {

                if (ciudad.RutaHija(i + 1) != null) {

                    costoMenorVariable += ciudad.RutaHija(i + 1).GetCosto();

                    costoMenor = BusquedaCostoUniforme(ciudad.RutaHija(i + 1), 
                        destinoFinal, costoMenor);
                }
            }

            if (memoria.Count == 1) {

                Console.WriteLine("");
                Console.WriteLine("==============  RUTA  =============");
                foreach (String elemento in rutaMenorCosto) {
                    
                    Console.WriteLine(elemento);

                }
                Console.WriteLine("");
                Console.WriteLine("COSTO TOTAL = " + costoMenor);
                Console.WriteLine("===================================");
            }

            costoMenorVariable -= ciudad.GetCosto();
            memoria.Remove(ciudad.GetCiudad());
            return costoMenor;
        }

        /// <summary>
        /// Metodo que inicializa el algoritmo
        /// </summary>
        /// <param name="args"></param>
        static void Main (string [] args) {
            Console.WriteLine("=============== CIUDADES ==============");
            Console.WriteLine("1) Oradea            11) Zerind");
            Console.WriteLine("2) Arad              12) Sibiu");
            Console.WriteLine("3) Timisoara         13) Bucarest");
            Console.WriteLine("4) Lugoj             14) Giurgiu");
            Console.WriteLine("5) Mehadia           15) Urziceni");
            Console.WriteLine("6) Dobreta           16) Hirsova");
            Console.WriteLine("7) Craiova           17) Efoire");
            Console.WriteLine("8) Rimnicu Vilcea    18) Vaslui");
            Console.WriteLine("9) Pitesti           19) Iasi");
            Console.WriteLine("10) Fagaras          20) Neamt");
            Console.WriteLine("");

            Console.WriteLine("INTRODUSCA LA CIUDAD DE SALIDA: ");
            String salida = Console.ReadLine();
            Arbol arbol = new Arbol(salida);

            Program menu = new Program();
            menu.CrearRutas();
            menu.CrearArbol(arbol.GetRaiz());
            Console.WriteLine("=============== SE CREO EL ARBOL ===============");
            menu.memoria.Clear();

            Console.WriteLine("INTRODUSCA LA CIUDAD DE DESTINO: ");
            String destino = Console.ReadLine();
            menu.RutasAmplitud(arbol.GetRaiz(), destino);

            Console.WriteLine("");
            Console.WriteLine("ESTA ES LA RUTA CON EL MENOR COSTO");
            menu.BusquedaCostoUniforme(arbol.GetRaiz(), destino, 0);
        }
    }
}
