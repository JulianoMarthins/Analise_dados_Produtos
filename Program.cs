using Analise_dados_Produtos.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Analise_dados_Produtos {
    internal class Program {
        static void Main(string[] args) {

            string path = @"D:\WorkSpace\Analise_dados_Produtos/Arquivo.txt";

            List<Product> prod = new List<Product>();


            using (StreamReader sr = File.OpenText(path)) {

                while (!sr.EndOfStream) {
                    string[] vetor = sr.ReadLine().Split(',');
                    string name = vetor[0];
                    double price = double.Parse(vetor[1], CultureInfo.InvariantCulture);

                    prod.Add(new Product(name, price));

                }
            }

            double media = prod.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            string valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", media);

            Console.WriteLine("Média de preço dos produtos" + valorFormatado);

            var abaixoMedia = prod.Where(p => p.Price < media).OrderByDescending(p => p.Name).Select(p => p.Name);

            Console.WriteLine("\nLista de produtos abaixo da média em ordem descrecente");


            foreach(var p in abaixoMedia) {
                
                Console.WriteLine(p.ToString().ToUpper());
            }

        }
    }
}
