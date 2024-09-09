using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analise_dados_Produtos.Entites {
    internal class Product {


        // Atributos de classe
        public string Name { get; set; }
        public double Price { get; set; }


        // Construtor
        public Product(string name, double price) {
            Name = name;
            Price = price;
        }


        // Métodos
        public override string ToString() {
            string valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Price);
            return $"Produto: {Name} {valorFormatado}";
        }

        public override bool Equals(object obj) {
            return obj is Product product &&
                   Name == product.Name;
        }

        public override int GetHashCode() {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
