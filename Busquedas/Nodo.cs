using System;
using System.Collections.Generic;

namespace Busquedas {
    /// <summary>
    /// Clase de Nodo para el Arbol n-ario
    /// </summary>
    public class Nodo {

        /// <summary>
        /// Atributos de a clases
        /// </summary>
        private String ciudad;
        private int costo;
        List<Nodo> rutas = new List<Nodo>();

        /// <summary>
        /// Constructor de la clase Nodo
        /// </summary>
        /// <param name="ciudad">ciuda que representa el nodo</param>
        /// <param name="costo">costo que lleva ir de la
        /// ciudad a la que esta liga a ella</param>
        public Nodo (String ciudad, int costo) {
            this.ciudad = ciudad;
            this.costo = costo;
        }
        
        /// <summary>
        /// Metodo que regresa el nombre de la ciudad 
        /// </summary>
        /// <returns>valor de tipo String</returns>
        public String GetCiudad () {
            return this.ciudad;
        }

        /// <summary>
        /// Metodo que regresa el costo de ir a esa ciudad
        /// </summary>
        /// <returns>valor de tipo Int</returns>
        public int GetCosto () {
            return this.costo;
        }

        /// <summary>
        /// Metodo que agrega rutas al Nodo
        /// </summary>
        /// <param name="nuevaCiudad"></param>
        public void InsertarCiudad(Nodo nuevaCiudad) {
            rutas.Add(nuevaCiudad);
        }

        /// <summary>
        /// Metodo que regresa el numero de rutas
        /// </summary>
        /// <returns></returns>
        public int NumeroRutas () {
            return this.rutas.Count;
        }

        /// <summary>
        /// Metodo que regresa la ruta hija solicitada
        /// </summary>
        /// <param name="posicion"></param>
        /// <returns></returns>
        public Nodo RutaHija (int posicion) {
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
