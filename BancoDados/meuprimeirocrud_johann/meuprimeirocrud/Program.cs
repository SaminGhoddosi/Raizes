using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.InfraEstructure;
using MeuPrimeiroCrud.Repository;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Operators;
using System.Xml;

namespace MeuPrimeiroCrud
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Cadastro de Cidade:");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                char op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        await Create();
                        break;
                    case 'R':
                        await Read();
                        break;
                    case 'U':
                        await Update();
                        break;
                    case 'D':
                        await Delete();
                        break;
                }
            }

            Console.WriteLine("Precione enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }
        static async Task Read()
        {
            ICidadeRepository cidadeRepository = new CidadeRepository();
            IEnumerable<cidadeEntity> cidadeList = await cidadeRepository.GetAll();

            foreach(cidadeEntity city in cidadeList)
            {
                Console.WriteLine($"ID {city.Id}");
                Console.WriteLine($"    -Nome {city.Nome}");
                Console.WriteLine($"    -Estado {city.Estado}");
                Console.WriteLine($"    -Pais {city.Pais}");
                Console.WriteLine($"    -Regiao {city.Regiao}");
                Console.WriteLine($"    -Criado Em {city.CriadoEm}");
            }
        }
        static async Task Create()
        {
            CidadeInsertDTO cidade = new CidadeInsertDTO();

            Console.WriteLine("Digite o Nome:");
            cidade.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Estado:");
            cidade.Estado = Console.ReadLine();
            Console.WriteLine("Digite o Pais:");
            cidade.Pais = Console.ReadLine();
            Console.WriteLine("Digite a Região:");
            cidade.Regiao = Console.ReadLine();

            ICidadeRepository cidadeRepository = new CidadeRepository();

            await cidadeRepository.Insert( cidade );
            Console.WriteLine("Cidade cadastrada com sucesso!");
        }
        static async Task Delete()
        {
            await Read();
            Console.WriteLine("Digite o ID que deseja excluir");
            int id =int.Parse( Console.ReadLine() );
            ICidadeRepository cidadeRepository = new CidadeRepository();
            await cidadeRepository.Delete( id );
            Console.WriteLine("Cidade deletada com sucesso!");
        }

        static async Task Update()
        {
            //leitura da tabela
            await Read();
            //Seleciona o ID - simular o click do botão de editar
            Console.WriteLine("Digite o Id que deseja alterar");
            int id = int.Parse( Console.ReadLine() );
            //carregar o formulario preenchido
            ICidadeRepository cidadeRepository = new CidadeRepository();
            cidadeEntity cidade = await cidadeRepository.GetById(id);
            //trocar os valores do formulario
            Console.WriteLine($"Digite um novo nome para {cidade.Nome} ou enter para deixar assim");
            string newName = Console.ReadLine();
            if (newName != "")
            {
                cidade.Nome = newName;
            }

            await cidadeRepository.Update( cidade );
            Console.WriteLine("Cidade alterada com sucesso!");
        }

       
    }
}
