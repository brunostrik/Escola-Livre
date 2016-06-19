using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre
{
    public class Memorial
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdAluno { get; set; }
        public int IdDiaIntervencao { get; set; }
        public DateTime momento { get; set; }
        public byte[] anexo { get; set; }
    }
}
