using System.Runtime.InteropServices;
using Dapper;
using meuprimeirocrud.Contracts.Repository;
using meuprimeirocrud.DTO;
using meuprimeirocrud.Entity;
using meuprimeirocrud.InfraEstructure;
using meuprimeirocrud.Repository;
using MySql.Data.MySqlClient;

namespace meuprimeirocrud
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            PlantioInsumoRepository plantioInsumoRepository = new PlantioInsumoRepository();
            var plantiosInsumos= await plantioInsumoRepository.GetAll();
            foreach (var plantioInsumo in plantiosInsumos)
            {
                Console.WriteLine(plantioInsumo.PlantioId);
                Console.WriteLine(plantioInsumo.Quantidade);
                Console.WriteLine(plantioInsumo.DataAplicacao);
            }

            var plantioInsumoDto = new PlantioInsumoInsertDTO() { DataAplicacao = DateTime.Now, Quantidade = 5, InsumoId = 15, PlantioId = 2 };
            await plantioInsumoRepository.Insert(plantioInsumoDto);
            
            var plantioVindoDoBanco = await plantioInsumoRepository.GetById(10);
            plantioVindoDoBanco.Quantidade = 10;
            await plantioInsumoRepository.Update(plantioVindoDoBanco);

            await plantioInsumoRepository.Delete(10);

            while (true)
            {
                

                Console.WriteLine("Cadastro de Insumos");
                Console.WriteLine("C - Create");
                Console.WriteLine("R - Read ");
                Console.WriteLine("U - Update");
                Console.WriteLine("D - Delete");
                char op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        await CreateInsumo();
                        break;
                    case 'R':
                        await ReadInsumos();
                        break;
                    case 'U':
                        await UpdateInsumo();
                        break;
                    case 'D':
                        await DeleteInsumo();
                        break;
                    default:
                        Console.WriteLine("opcao invalida");
                        break;
                }
            }
            Console.WriteLine("Precione enter para continuar");
            Console.ReadLine();
            Console.Clear();
        }


        static async Task ReadInsumos()
        {
            IInsumoRepository insumoRepository = new InsumoRepository();
            IEnumerable<InsumoEntity> insumolist = await insumoRepository.GetAll();
            foreach (InsumoEntity insumo in insumolist)
            {
                Console.WriteLine($"Id {insumo.Id}");
                Console.WriteLine($"Nome {insumo.Nome}");
            }


        }
        static async Task CreateInsumo()
        {
            InsumoInsertDTO insumo = new InsumoInsertDTO();
            Console.WriteLine("Digite o nome");
            insumo.Nome = Console.ReadLine();

            IInsumoRepository insumoRepository = new InsumoRepository();
            await insumoRepository.Insert(insumo);
            Console.WriteLine("Insumo Cadastrado");

        }


        static async Task DeleteInsumo()
        {
            await ReadInsumos();
            Console.WriteLine("Digite o Id que deseja excluir");
            int id = int.Parse(Console.ReadLine());
            IInsumoRepository insumoRepository= new InsumoRepository();
            await insumoRepository.Delete(id);
            Console.WriteLine("Insumo deletado com sucesso!");
        }
         static async Task UpdateInsumo()
        { //Leitura dos dados - Imagine a tabela
            await ReadInsumos();
            //Seleciona o ID - Simular o clique no botao de editar
            Console.WriteLine("Digite o Id que deseja Alterar");
            int id = int.Parse(Console.ReadLine());

            //Carregar o formulário preenchido
            IInsumoRepository insumoRepository = new InsumoRepository();
            InsumoEntity insumo = await insumoRepository.GetById(id);

            //Trocar os valores no formulario
            Console.WriteLine($"Digite um novo nome para {insumo.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                insumo.Nome = newName;
            }

            //Chamar o banco
            await insumoRepository.Update(insumo);

            Console.WriteLine("Insumo alterado com sucesso!");

        }
    }

   






}




