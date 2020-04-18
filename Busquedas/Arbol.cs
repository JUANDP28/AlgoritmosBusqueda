using System;

namespace Busquedas {
    class Arbol {

        private Nodo raiz;

        public Arbol (String ciudad) {
            this.raiz = new Nodo(ciudad, 0);
        }

        public Nodo getRaiz () {
            return this.raiz;
        }
    }
}
