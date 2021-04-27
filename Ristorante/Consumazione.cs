using System;
using System.Collections.Generic;
using System.Text;

namespace Ristorante
{
    public class Consumazione {
        
        int id;
        String nome;
        double prezzo;

        public Consumazione(int id, String nome, double prezzo) {
            this.id = id;
            this.nome = nome;
            this.prezzo = prezzo;
        }

        public Consumazione(Consumazione cons) {
            id = cons.id;
            nome = cons.nome;
            prezzo = cons.prezzo;
        }

        public String getNome() {
            return nome;
        }

        public double getPrezzo() {
            return prezzo;
        }
    }
}
