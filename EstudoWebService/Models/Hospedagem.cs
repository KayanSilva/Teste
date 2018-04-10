using EstudoWebService.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace EstudoWebService.Models
{
    public class Hospedagem
    {
        public List<Cliente> Clientes { get; set; }
        public string Endereco { get; set; }
        public long Id { get; set; }

        public Hospedagem()
        {
            this.Clientes = new List<Cliente>();
        }

        public void Adiciona(Cliente cliente)
        {
            this.Clientes.Add(cliente);
        }

        public void Remove(long id)
        {
            Cliente cliente = Clientes.FirstOrDefault(p => p.Id == id);

            Clientes.Remove(cliente);
        }

        public void Troca(Cliente cliente)
        {
            Remove(cliente.Id);
            Adiciona(cliente);
        }

        public void TrocaEndereco(string endereco)
        {
            this.Endereco = endereco;
        }

        public void TrocaQuantidade(Cliente cliente)
        {
            Cliente clienteCarregado = Clientes.FirstOrDefault(p => p.Id == cliente.Id);

            clienteCarregado.Quantidade = cliente.Quantidade;
        }

        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Hospedagem));
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, this);
                return stringWriter.ToString();
            }
        }
    }
}