using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudoWebService.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int Quantidade { get; set; }

        public Cliente()
        {

        }

        public Cliente(long id, string nome, string endereco, string telefone, int quantidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Telefone = telefone;
            this.Quantidade = quantidade;
        }
    }
}