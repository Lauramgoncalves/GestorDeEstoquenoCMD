using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoquenoCMD
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
           
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-book, pois é um produto Digital!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no E-book {nome}");
            Console.WriteLine($"Digite a quantidade de vendas que voce quer dá entrada:");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Saida Registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Preço:{preco}");
            Console.WriteLine($"Numero de vendas:{vendas}");
            Console.WriteLine($"Nome:{autor}");
            Console.WriteLine($"==================================");
        }
    } // Por ser digital, só terá a quantidade de vendas.
}
