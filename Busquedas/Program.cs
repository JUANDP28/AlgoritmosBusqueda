using System;
using System.Collections.Generic;

namespace Busquedas {
    class Program {

        List<Ruta> rutas = new List<Ruta>();
        List<String> memoria = new List<string>();
        List<String> rutaMenorCosto = new List<string>();
        int costoMenorVariable = 0;

        public void crearRutas () {
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

        struct Ruta {
            public String salida { get; set; }
            public String destino { get; set; }
            public int costo { get; set; }
        }

        public void crearArbol (Nodo ciudad) {
            memoria.Add(ciudad.getCiudad());

            foreach (Ruta ruta in rutas) {

                if (ruta.salida.Equals(ciudad.getCiudad())) {

                    if (!memoria.Contains(ruta.destino)) {

                        ciudad.insertarCiudad(new Nodo(ruta.destino, ruta.costo));
                    }
                }
            }

            for (int i = 0; i< ciudad.numeroRutas(); i++) {

                if (ciudad.rutaHija(i+1) != null) {

                    crearArbol(ciudad.rutaHija(i+1));
                }
            }

            memoria.Remove(ciudad.getCiudad());
        }

        public void rutasAmplitud (Nodo ciudad, String destinoFinal) {
            memoria.Add(ciudad.getCiudad());

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

            for (int i = 0; i < ciudad.numeroRutas(); i++) {

                if (ciudad.rutaHija(i+1) != null) {

                    rutasAmplitud(ciudad.rutaHija(i+1), destinoFinal);
                }
            }

            memoria.Remove(ciudad.getCiudad());
        }

        public int busquedaCostoUniforme (Nodo ciudad, String destinoFinal,
            int costoMenor) {
            memoria.Add(ciudad.getCiudad());

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

            for (int i = 0; i < ciudad.numeroRutas(); i++) {

                if (ciudad.rutaHija(i + 1) != null) {

                    costoMenorVariable += ciudad.rutaHija(i + 1).getCosto();

                    costoMenor = busquedaCostoUniforme(ciudad.rutaHija(i + 1), 
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

            costoMenorVariable -= ciudad.getCosto();
            memoria.Remove(ciudad.getCiudad());
            return costoMenor;
        }

        static void Main (string [] args) {
            Console.WriteLine("INTRODUSCA LA CIUDAD DE SALIDA: ");
            String salida = Console.ReadLine();
            Arbol arbol = new Arbol(salida);
            Program menu = new Program();
            menu.crearRutas();
            menu.crearArbol(arbol.getRaiz());
            Console.WriteLine("=============== SE CREO EL ARBOL ===============");
            menu.memoria.Clear();
            Console.WriteLine("INTRODUSCA LA CIUDAD DE DESTINO: ");
            String destino = Console.ReadLine();
            menu.rutasAmplitud(arbol.getRaiz(), destino);
            Console.WriteLine("");
            Console.WriteLine("ESTA ES LA RUTA CON EL MENOR COSTO");
            menu.busquedaCostoUniforme(arbol.getRaiz(), destino, 0);
        }
    }
}
