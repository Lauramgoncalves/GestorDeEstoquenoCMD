using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoquenoCMD
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>(); //Lista
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar a entrada\n5-Registrar a saida\n6-Sair");
                int OpcaoSelecionada = int.Parse(Console.ReadLine());
                Menu Opcao = (Menu)OpcaoSelecionada;
                Console.WriteLine(Opcao);

                switch (Opcao)
                {
                    case Menu.Listar:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Cadastro();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Entrada:
                        Entrada();
                        break;
                    case Menu.Saida:
                        Saida();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                    default:
                        Console.WriteLine("Opção invalida!!");
                        break;
                }
                Console.Clear();


            }

        }
        static void Listagem()
        {
            Console.WriteLine("Listagem de produtos");
            int id = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + id);
                produto.Exibir();
                id++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que voce deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();

            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento quer voce dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {

                produtos[id].AdicionarEntrada(); // Acessa o id ue o usuario digitou, e chama o metodo adcentrada.
                Salvar();

            }
        }
            static void Saida()
            {
                Listagem();
                Console.WriteLine("Digite o ID do elemento quer voce dar saida: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < produtos.Count)
                {

                    produtos[id].AdicionarSaida(); // Acessa o id ue o usuario digitou, e chama o metodo adcentrada.
                    Salvar();

                }
            }

            static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produto:");
            Console.WriteLine("1-Produto Fisico\n2-Ebook\n3-Curso");
            int opcCad = int.Parse(Console.ReadLine());
            switch (opcCad)
            {
                case 1:
                    CadastrarProdFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastroDeCurso();
                    break;

            }
        }

        static void CadastrarProdFisico()
        {
            Console.WriteLine("Cadastrando produto fisico: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete); // Salva os produtos e adc na lista.
            produtos.Add(pf);
            Salvar();

        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }
        static void CadastroDeCurso()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Curso Curso = new Curso(nome, preco, autor);
            produtos.Add(Curso);
            Salvar();

        }

        // Salvando os produtos no aruivo
        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        //Leitura de aruivo
        static void Carregar()
        {

            FileStream stream = new FileStream("Produtos", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
            
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();

                }
                stream.Close();
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();

            }
            stream.Close();
        }
      
        }
    }



