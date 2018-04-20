using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //deixa de ser a base de bados a fazer o auto-number do id, passo a ser eu
        public int ID { get; set; } // chave primária
        // dados do Agente
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-ZÁÂÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëïöüñ]+(( | e | de | da | dos | das | do | d'|-)[A-ZÁÂÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëïöüñ]+){1,3}", ErrorMessage ="Tem de introduzir um {0} num formato válido")]
        [StringLength(40,ErrorMessage ="O {0} deve ter um máximo de {1} caracteres")]
        public string Nome { get; set; }
        //[Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        public string Fotografia { get; set; }
        // local de trabalho do Agente
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        [RegularExpression("[A-Za-z0-9áéíóúàèìòùâêîôûãõçäëïöüñ -]+", ErrorMessage = "Tem de introduzir uma {0} num formato válido")]
        public string Esquadra { get; set; }
        // criar uma lista de multas aplicadas pelo agente
        public virtual ICollection<Multas> ListaMultas { get; set; }
    }
}