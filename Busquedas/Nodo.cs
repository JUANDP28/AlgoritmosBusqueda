using System;
using System.Collections.Generic;

namespace Busquedas {
    public class Nodo {

        private String ciudad;
        List<Nodo> rutas = new List<Nodo>();

        public Nodo (String ciudad) {
            this.ciudad = ciudad;
        }
        

        public String getCiudad () {
            return this.ciudad;
        }

        public void insertarCiudad(Nodo nuevaCiudad) {
            rutas.Add(nuevaCiudad);
        }

        public int numeroRutas () {
            return this.rutas.Count;
        }

        public Nodo rutaHija (int posicion) {
            int contador = 1;
            foreach (Nodo ruta in this.rutas) {
                if (contador == posicion) {
                    return ruta;
                }
                contador++;
            }
            return null;
        }
    }
}
