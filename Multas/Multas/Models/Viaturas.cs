using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Viaturas
    {
        // criar o construtor
        public Viaturas()
        {
            ListaMultas = new HashSet<Multas>();
        }
        
        public int ID { get; set; }
        // descrição do veículo
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        // descrição do dono
        public string NomeDono { get; set; }
        public string MoradaDono { get; set; }
        public string CodPostalDono { get; set; }
        // criar uma lista de multas associadas à viatura
        public virtual ICollection<Multas> ListaMultas { get; set; }
    }
}