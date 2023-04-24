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

            // Calcular o valor médio
            double valorMedio = total / listaDiaValor.Count;

            // Contar quantas vezes o valor ficou acima da média
            int count= 0;
            foreach (var diaValor in listaDiaValor)
            {
                if (diaValor.valor > valorMedio)
                {
                    count++;
                }
            }

            // Imprimir os resultados
            Console.WriteLine($"Valor mínimo: {min}");
            Console.WriteLine($"Valor máximo: {max}");
            Console.WriteLine($"Quantidade de valores acima da média: {count}");
            Console.Read();
        }
    }
}
