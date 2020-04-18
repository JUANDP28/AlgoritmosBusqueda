using System;
using System.Collections.Generic;

namespace Busquedas {
    public class Nodo {

        private String ciudad;
        private int costo;
        List<Nodo> rutas = new List<Nodo>();

        public Nodo (String ciudad, int costo) {
            this.ciudad = ciudad;
            this.costo = costo;
        }
        

        public String getCiudad () {
            return this.ciudad;
        }

        public int getCosto () {
            return this.costo;
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
