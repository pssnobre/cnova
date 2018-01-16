using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Amigo> listaAmigos = new List<Amigo>();


            while (true)
            {
                int option = ShowMenu();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Opção inválida.");
                        break;
                    case 1:
                        if (AdicionarAmigo(listaAmigos))
                        {
                            Console.WriteLine("Amigo adicionado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("O amigo não pode ser adicionado.");
                        }
                        break;
                    case 2:
                        BuscarAmigosMaisProximos(listaAmigos);
                        break;
                    case 3:
                        return;
                }
            }

        }

        public static double InputLatitude()
        {
            Console.WriteLine("Digite a latitude");
            string latitude = Console.ReadLine();
            try
            {
                return double.Parse(latitude);
            }
            catch (Exception)
            {
                return InputLatitude();
            }
        }

        public static double InputLongitude()
        {
            Console.WriteLine("Digite a longitude");
            string longitude = Console.ReadLine();
            try
            {
                return double.Parse(longitude);
            }
            catch (Exception)
            {
                return InputLongitude();
            }
        }

        public static int ShowMenu()
        {
            Console.WriteLine("Escolha uma opção");
            Console.WriteLine();
            Console.WriteLine("1. Adicionar novo amigo.");
            Console.WriteLine("2. Procurar amigos mais proximos");
            Console.WriteLine("3. Sair");
            var result = Console.ReadLine();
            try
            {
                int num = Convert.ToInt32(result);
                if (num > 3)
                {
                    return 0;
                }
                return num;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static bool AdicionarAmigo(List<Amigo> lista)
        {
            Console.WriteLine("Digite o nome do amigo");
            string nome = Console.ReadLine();
            double latitude = InputLatitude();
            double longitude = InputLongitude();
            
            Amigo novoAmigo = new Amigo(nome, latitude, longitude);
            return Amigo.AdicionarAmigo(lista, novoAmigo);
        }

        public static void BuscarAmigosMaisProximos(List<Amigo> lista)
        {
            Console.WriteLine("Digite o nome do amigo que esta visitando.");
            string nome = Console.ReadLine();

            List<Amigo> listaAmigos =  Amigo.BuscarAmigosMaisProximos(lista, nome);

            if (listaAmigos.Count > 0)
            {
                Console.WriteLine("Os amigos mais próximos são:");
                foreach (Amigo item in listaAmigos)
                {
                    Console.WriteLine(item.nome);
                }
            }
            else
            {
                Console.WriteLine("Nenhum amigo encontrado.");
            }
        }

    }
}
