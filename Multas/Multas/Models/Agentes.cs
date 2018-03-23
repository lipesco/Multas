using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Agentes
    {
        // criar o construtor
        public Agentes(){
            ListaMultas = new HashSet<Multas>();
        }

        public int ID { get; set; } // chave primária
        // dados do Agente
        public string Nome { get; set; }
        public string Fotografia { get; set; }
        // local de trabalho do Agente
        public string Esquadra { get; set; }
        // criar uma lista de multas aplicadas pelo agente
        public virtual ICollection<Multas> ListaMultas { get; set; }
    }
}