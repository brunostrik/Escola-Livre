using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaCodebar.model
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cartao { get; set; }
        public byte[] Foto { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public int IdUsuario { get; set; }
    }
}
