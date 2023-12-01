namespace Dicionarios
{
    internal class Exercicio1
    {
        internal static void MetodoPrincipal()
        {
            // Solicita ao usuário uma série de números separados por espaço
            Console.WriteLine("Abaixo, informe uma série de números em uma única linha com um espaço separando eles." +
                "Este programa irá retornar quantas vezes cada número apareceu (número que será informado pelo usuário " +
                "e qual foi o número de maior ocorrência.");

            // Lê a entrada do usuário e divide os números em um array de strings
            string[] arrayInt = Console.ReadLine().Split(" ");

            // Verifica se todos os elementos do array são números inteiros
            bool verificador = Verificador(arrayInt);

            // Constrói e exibe o dicionário ou informa que a entrada é inválida
            ConstruirDict(verificador, arrayInt);
        }

        // Verifica se todos os elementos de um array são números inteiros
        private static bool Verificador(string[] arrayInt)
        {
            foreach (string str in arrayInt)
            {
                if (!int.TryParse(str, out int val))
                {
                    return false; // Retorna falso se encontrar algum elemento que não é um número inteiro
                }
            }
            return true; // Retorna verdadeiro se todos os elementos são números inteiros
        }

        // Constrói um dicionário contando a ocorrência de cada número
        private static void ConstruirDict(bool verificador, string[] arrayInt)
        {
            if (verificador)
            {
                // Cria um dicionário para armazenar a contagem de ocorrências de cada número
                Dictionary<string, int> dictInt = new Dictionary<string, int>();
                int contador = 1;

                // Percorre o array de números e constrói o dicionário
                foreach (string str in arrayInt)
                {
                    if (!dictInt.ContainsKey(str))
                        dictInt.Add(str, contador); // Adiciona o número ao dicionário se não existir
                    else
                        dictInt[str]++; // Incrementa a contagem se o número já existir no dicionário
                }

                // Realiza interação adicional com o usuário
                InteracaoUsuario(dictInt);

                // Exibe as chaves (números) e seus respectivos valores (contagens)
                foreach (var (chave, valor) in dictInt)
                {
                    Console.WriteLine($"Chave: {chave}, Valor: {valor}");
                }
            }
            else
            {
                Console.WriteLine("O dicionario informado é inválido pois não possui apenas números.");
            }
        }

        // Realiza interação adicional com o usuário, como encontrar o número mais frequente
        // e permitir que o usuário pesquise a contagem de um número específico.
        private static void InteracaoUsuario(Dictionary<string, int> dictInt)
        {
            // Encontra as chaves associadas ao maior valor no dicionário
            List<string> chavesDoMaiorValor = dictInt
                .Where(pair => pair.Value == dictInt.Max(kv => kv.Value))
                .Select(pair => pair.Key)
                .ToList();

            // Exibe as chaves associadas ao maior valor
            Console.WriteLine("As chaves associadas ao maior valor são:");
            foreach (var chave in chavesDoMaiorValor)
            {
                Console.WriteLine($"O número que mais apareceu foi: {chave}");
            }

            // Pergunta ao usuário se deseja pesquisar a contagem de um número específico
            Console.WriteLine("Deseja saber sobre um número específico? Digite 1 para sim e qualquer tecla para não:");
            string valor = Console.ReadLine();

            if (valor == "1")
            {
                // Solicita ao usuário um número para pesquisar
                Console.WriteLine("Informe o número que deseja procurar:");

                // Lê a entrada do usuário
                if (int.TryParse(Console.ReadLine(), out int numero) && dictInt.ContainsKey(numero.ToString()))
                    Console.WriteLine($"O número informado apareceu {dictInt[numero.ToString()]} vezes");
                else
                {
                    Console.WriteLine("O número informado apareceu 0 vezes");
                }
            }
            else
            {
                Console.WriteLine("O programa será encerrado. Antes disso, os números e as suas respectivas aparições.");
            }
        }
    }
}
