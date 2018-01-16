using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Amigo
    {
        public string nome { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double distancia { get; set; }

        public Amigo(String nome, double latitude, double longitude)
        {
            this.nome = nome;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public static double CalcularDistancia(Amigo amigo1, Amigo amigo2)
        {
            double result = 0;

            double parcialValue = ((amigo1.latitude - amigo2.latitude) * (amigo1.latitude - amigo2.latitude)) + ((amigo1.longitude - amigo2.longitude) * (amigo1.longitude - amigo2.longitude));
            result = Math.Sqrt(parcialValue);

            return result;
        }

        public static bool AdicionarAmigo(List<Amigo> listaAmigos, Amigo amigo)
        {
            foreach (Amigo ami in listaAmigos)
            {
                if (amigo.latitude == ami.latitude && amigo.longitude == ami.longitude)
                {
                    return false;
                }
            }

            listaAmigos.Add(amigo);

            return true;
        }

        public static List<Amigo> BuscarAmigosMaisProximos(List<Amigo> listaAmigos, string nome)
        {
            Amigo amigoAtual = listaAmigos.FirstOrDefault(x => x.nome == nome);
            if (amigoAtual == null)
            {
                return new List<Amigo>();
            }

            List<Amigo> listaRetorno = new List<Amigo>(listaAmigos);
            listaRetorno.Remove(amigoAtual);

            foreach (Amigo ami in listaRetorno)
            {   
                ami.distancia = CalcularDistancia(amigoAtual, ami);
            }

            listaRetorno = listaRetorno.OrderBy(x => x.distancia).Take(3).ToList();

            return listaRetorno;
        }

    }
}
