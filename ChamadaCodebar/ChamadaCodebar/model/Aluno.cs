using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaCodebar.model
{
    public class Aluno
    {
        public int id { get; }
        public string nome { get; set; }
        public int cartao { get; set; }
        public byte[] foto { get; set; }
    }
}
