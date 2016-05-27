using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urna
{
    public class Chapa
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Presidente { get; set; }
        public string VicePresidente { get; set; }
        public string Relator { get; set; }
        public string ViceRelator { get; set; }
        public byte[] FotoPresidente { get; set; }
        public byte[] FotoVicePresidente { get; set; }
        public byte[] FotoRelator { get; set; }
        public byte[] FotoViceRelator { get; set; }
        public int Votos { get; set; }
    }
}
