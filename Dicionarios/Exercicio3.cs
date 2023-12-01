using System;
using System.Collections.Generic;
using System.Linq;

namespace Dicionarios
{
    internal class Exercicio3
    {
        internal static void MetodoPrincipal()
        {
            // Inicialização de dois dicionários com alguns meses e seus números correspondentes
            Dictionary<string, int> dictInt = new Dictionary<string, int>
            {
                {"Janeiro", 1},
                {"Fevereiro", 2},
                {"Março", 3},
                {"Abril", 4},
                {"Maio", 5},
                {"Junho", 6},
                {"Julho", 7}
            };

            Dictionary<string, int> dict2 = new Dictionary<string, int>
            {
                {"Agosto", 8},
                {"Setembro", 9},
                {"Outubro", 10},
                {"Novembro", 11},
                {"Dezembro", 12}
            };

            // Chamada de métodos para demonstrar operações com dicionários
            AlterarValor(dictInt);
            DictLINQ(dictInt);
            VerificarValor(dictInt);
            VerificadorAlgumValor(dictInt);
            AdicionarElemento(dictInt);
            FiltrarChave(dictInt);
            ComparadorDict(dictInt);
            ConcatenarDicionarios(dictInt, dict2);
            Console.WriteLine(TamanhoDict(dictInt));
        }

        private static void AlterarValor(Dictionary<string, int> dictInt)
        {
            // Método que permite ao usuário fornecer uma chave e, em seguida, exibe o valor correspondente
            Console.WriteLine("Informe qual chave deseja remover (removendo também o valor correspondente:");
            string alterar = Console.ReadLine();

            if (dictInt.TryGetValue(alterar, out int valorDict))
            {
                Console.WriteLine($"Valor encontrado para a chave {alterar}: {valorDict}");
            }
            else
            {
                Console.WriteLine("Chave informada não pertence ao dicionário.");
            }
        }

        private static void DictLINQ(Dictionary<string, int> dictInt)
        {
            // Método que utiliza LINQ para exibir informações sobre o dicionário
            Console.WriteLine($"Máximo valor do dicionário: {dictInt.Values.Max()}.\nSoma dos valores de um dicionário:" +
                $" {dictInt.Values.Sum()}");
            Console.WriteLine($"Essas são todas as chaves do dicionário: {string.Join(", ", dictInt.Keys)}");
        }

        private static void VerificarValor(Dictionary<string, int> dictInt)
        {
            // Método que permite ao usuário fornecer um valor mínimo e verifica se todos os valores no dicionário são maiores que esse valor
            Console.WriteLine("Informe abaixo um número mínimo para os valores do dicionário e retornarei se " +
                "todas as chaves estão ou não acima deste valor.");

            if (int.TryParse(Console.ReadLine(), out int comparador))
            {
                bool verificador = dictInt.Values.All(valor => valor > comparador);
                Console.WriteLine($"Todos os valores estão acima de {comparador}? {verificador}");
            }
            else
            {
                Console.WriteLine("O valor informado não é um número inteiro.");
            }
        }

        private static void VerificadorAlgumValor(Dictionary<string, int> dictInt)
        {
            // Método que permite ao usuário fornecer um valor mínimo e verifica se algum valor no dicionário é maior que esse valor
            Console.WriteLine("Informe abaixo um número mínimo para os valores do dicionário e retornarei se " +
                "alguma as chaves estão ou não acima deste valor.");

            if (int.TryParse(Console.ReadLine(), out int comparador))
            {
                bool verificador = dictInt.Values.Any(valor => valor > comparador);
                Console.WriteLine($"Algum dos valores está acima de {comparador}? {verificador}");
            }
            else
            {
                Console.WriteLine("O valor informado não é um número inteiro.");
            }
        }

        private static void AdicionarElemento(Dictionary<string, int> dictInt)
        {
            // Método que permite ao usuário adicionar uma chave e valor ao dicionário
            Console.WriteLine("Informe uma chave que deseja inserir no dicionário:");
            string chave = Console.ReadLine();
            Console.WriteLine("Informe o valor referente a ser adicionado ao dicionário:");
            if (int.TryParse(Console.ReadLine(), out int valor) & dictInt.TryAdd(chave, valor))
            {
                Console.WriteLine("Elementos adicionados com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor informado não é um inteiro ou a chave informada já existe no dicionário em questão.");
            }
        }

        private static void FiltrarChave(Dictionary<string, int> dictInt)
        {
            // Método que permite ao usuário fornecer uma letra e exibe as chaves que começam com essa letra
            Console.WriteLine("Informe com qual letra as chaves devem iniciar:");
            char letra = char.Parse(Console.ReadLine());

            var chavesFiltradas = dictInt.Keys.Where(chave => chave.StartsWith(letra.ToString(), StringComparison.OrdinalIgnoreCase));

            foreach (var chave in chavesFiltradas)
            {
                Console.WriteLine($"Chave: {chave}");
            }
        }

        private static void ComparadorDict(Dictionary<string, int> dictInt)
        {
            // Método que exibe o tipo do comparador usado pelo dicionário
            IEqualityComparer<string> comparador = dictInt.Comparer;
            Console.WriteLine($"Tipo do comparador: {comparador.GetType().FullName}");
        }

        private static void ConcatenarDicionarios(Dictionary<string, int> dictInt, Dictionary<string, int> dict2)
        {
            // Método que concatena dois dicionários e exibe os resultados
            var dictConc = dictInt.Concat(dict2).ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var (chave, valor) in dictConc)
            {
                Console.WriteLine($"Chave: {chave}, Valor: {valor}");
            }
        }

        private static int TamanhoDict(Dictionary<string, int> dictInt)
        {
            // Método que retorna o tamanho (número de pares chave/valor) do dicionário
            int tamanho = dictInt.Count;
            return tamanho;
        }
    }
}
