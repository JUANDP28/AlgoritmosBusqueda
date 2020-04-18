using System;

namespace Busquedas {
    class Arbol {

        private Nodo raiz;

        public Arbol (String ciudad) {
            this.raiz = new Nodo(ciudad);
        }

        public Nodo getRaiz () {
            return this.raiz;
        }
    }
}
