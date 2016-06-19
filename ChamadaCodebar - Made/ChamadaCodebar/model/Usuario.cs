using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaLivre
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public int Tipo { get; set; } //0-Professor 1-Aluno
    }
}
