using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Projeto3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string jsonString = File.ReadAllText("C:\\dados.json");

            var listaDiaValor = JsonConvert.DeserializeObject<List<DiaValor>>(jsonString);

            double min = double.MaxValue;
            double max = double.MinValue;
            double total = 0;
            foreach (var diaValor in listaDiaValor)
            {
                if (diaValor.valor < min)
                {
                    min = diaValor.valor;
                }
                if (diaValor.valor > max)
                {
                    max = diaValor.valor;
                }
                total += diaValor.valor;
            }

            double valorMedio = total / listaDiaValor.Count;

            int count= 0;
            foreach (var diaValor in listaDiaValor)
            {
                if (diaValor.valor > valorMedio)
                {
                    count++;
                }
            }

            Console.WriteLine($"Valor mínimo: {min}");
            Console.WriteLine($"Valor máximo: {max}");
            Console.WriteLine($"Quantidade de valores acima da média: {count}");
            Console.Read();
        }
    }
}
