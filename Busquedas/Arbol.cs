using System;

namespace Busquedas {

    /// <summary>
    /// Clase que donde inicia el arbol
    /// </summary>
    class Arbol {

        /// <summary>
        /// Atributo del arbol
        /// </summary>
        private Nodo raiz;

        /// <summary>
        /// Constructor del arbol
        /// </summary>
        /// <param name="ciudad"></param>
        public Arbol (String ciudad) {
            this.raiz = new Nodo(ciudad, 0);
        }

        /// <summary>
        /// Metodo que obtiene la  raiz del arbol
        /// </summary>
        /// <returns></returns>
        public Nodo GetRaiz () {
            return this.raiz;
        }
    }
}
