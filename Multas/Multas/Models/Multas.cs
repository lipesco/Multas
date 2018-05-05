using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas_tC.Models
{
    public class Multas
    {
        public int ID { get; set; }
        // dados da multa
        public string Infraccao { get; set; }
        public string LocalDaMulta { get; set; }
        public decimal ValorMulta { get; set; }
        public DateTime DataDaMulta { get; set; }
        // ******************************************
        // *  especificação das chaves forasteiras  *
        // ******************************************
        // FK para o Agente em sql
        // Foreignkey NomeDaVarQueÉFK refecences NomeDaTabela(NomeDaPK)
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public virtual Agentes Agente { get; set; }
        // FK para condutor
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }
        // FK para vistura
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

    }
}