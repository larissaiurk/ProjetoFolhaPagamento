using FolhaPagamento.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaPagamento
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            int opcao = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("  -- MENU FOLHA DE PAGAMENTO -- \n");
                Console.WriteLine("1 - Cadastrar cargo \n");
                Console.WriteLine("2 - Cadastrar funcionário \n");
                Console.WriteLine("3 - Cadastrar folha de pagamento \n");
                Console.WriteLine("4 - Consultar folha de pagamento \n ");
                Console.WriteLine("5 - Consultar histórico de folhas de pagamento do funcionário \n ");
                Console.WriteLine("6 - Consultar histórico de folhas de pagamento do mês \n ");
                Console.WriteLine("0 - Sair\n");

                Console.WriteLine("Digite a opção desejada:");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        ListPositions.Render();
                        RegisterPosition.Render();
                        break;
                    case 2:
                        ListEmployees.Render();
                        RegisterEmployee.Render();
                        break;
                    case 3:
                        //CadastrarFuncionario.Renderizar();
                        break;
                    case 4:
                        //ListarFuncionarios.Renderizar();
                        break;
                    case 5:
                        //CadastrarProduto.Renderizar();
                        break;
                    case 6:
                        //ListarProdutos.Renderizar();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine("\n Aperte uma tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }
    }
}
