using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre
{
    public class Registro
    {
        public int Id { get; set; }
        public int IdProfessor { get; set; }
        public int IdIntervencao { get; set; }
        public string Texto { get; set; }
        public byte[] Imagem { get; set; }
    }
}
