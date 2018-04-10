using EstudoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstudoWebService.DAO
{
    public class HospedagemDAO
    {
        private static Dictionary<long, Hospedagem> banco = new Dictionary<long, Hospedagem>();
        private static long contador = 1;

        static HospedagemDAO()
        {
            Cliente Brasileiro = new Cliente(1111, "José Aldo", "Rua Primavera", "47005452", 4);
            Cliente Argentino = new Cliente(9999, "Raimundo Lopes", "Rua La casa de papel", "47003662", 2);
            Hospedagem hospedagem = new Hospedagem();
            hospedagem.Adiciona(Brasileiro);
            hospedagem.Adiciona(Argentino);
            hospedagem.Endereco = "Rua Alameda Campinas, 1070";
            hospedagem.Id = 1;
            banco.Add(1, hospedagem);
        }

        public void Adiciona(Hospedagem hospedagem)
        {
            contador++;
            hospedagem.Id = contador;
            banco.Add(contador, hospedagem);
        }

        public Hospedagem Busca(long id)
        {
            return banco[id];
        }

        public void Remove(long id)
        {
            banco.Remove(id);
        }
    }
}