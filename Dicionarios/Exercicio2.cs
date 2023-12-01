namespace Dicionarios
{
    internal class Exercicio2
    {
        internal static void MetodoPrincipal()
        {
            // Dicionários para armazenar mensagens em diferentes idiomas
            Dictionary<string, Dictionary<string, string>> mensagens = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "ingles", new Dictionary<string, string>
                    {
                        { "saudacao", "Hello! What's your name?" },
                        { "idade", "How old are you?" },
                        { "hobby", "What's your hobby?" },
                        { "local", "Where do you live?" },
                        { "despedida", "Goodbye! Have a great day, {0}!" }
                    }
                },
                {
                    "espanhol", new Dictionary<string, string>
                    {
                        { "saudacao", "¡Hola! ¿Cuál es tu nombre?" },
                        { "idade", "¿Cuántos años tienes?" },
                        { "hobby", "¿Cuál es tu hobby?" },
                        { "local", "¿Dónde vives?" },
                        { "despedida", "¡Adiós! Que tengas un buen día, {0}!" }
                    }
                },
                {
                    "portugues", new Dictionary<string, string>
                    {
                        { "saudacao", "Olá! Qual é o seu nome?" },
                        { "idade", "Quantos anos você tem?" },
                        { "hobby", "Qual é o seu hobby?" },
                        { "local", "Onde você mora?" },
                        { "despedida", "Adeus! Tenha um ótimo dia, {0}!" }
                    }
                },
                {
                    "frances", new Dictionary<string, string>
                    {
                        { "saudacao", "Salut! Comment tu t'appelles?" },
                        { "idade", "Quel âge as-tu?" },
                        { "hobby", "Quel est ton passe-temps?" },
                        { "local", "Où habites-tu?" },
                        { "despedida", "Au revoir! Passe une excellente journée, {0}!" }
                    }
                },
                {
                    "alemao", new Dictionary<string, string>
                    {
                        { "saudacao", "Hallo! Wie heißt du?" },
                        { "idade", "Wie alt bist du?" },
                        { "hobby", "Was ist dein Hobby?" },
                        { "local", "Wo wohnst du?" },
                        { "despedida", "Auf Wiedersehen! Hab einen schönen Tag, {0}!" }
                    }
                },
                {
                    "japones", new Dictionary<string, string>
                    {
                        { "saudacao", "こんにちは！お名前は何ですか？" },
                        { "idade", "年齢はいくつですか？" },
                        { "hobby", "趣味は何ですか？" },
                        { "local", "どこに住んでいますか？" },
                        { "despedida", "さようなら！良い一日を、{0}さん！" }
                    }
                },
                {
                    "italiano", new Dictionary<string, string>
                    {
                        { "saudacao", "Ciao! Come ti chiami?" },
                        { "idade", "Quanti anni hai?" },
                        { "hobby", "Qual è il tuo hobby?" },
                        { "local", "Dove abiti?" },
                        { "despedida", "Arrivederci! Buona giornata, {0}!" }
                    }
                },
                {
                    "coreano", new Dictionary<string, string>
                    {
                        { "saudacao", "안녕하세요! 이름이 뭐에요?" },
                        { "idade", "몇 살이에요?" },
                        { "hobby", "취미는 뭐에요?" },
                        { "local", "어디에 살아요?" },
                        { "despedida", "안녕히 가세요! 즐거운 하루 보내세요, {0}님!" }
                    }
                },
                {
                    "mandarim", new Dictionary<string, string>
                    {
                        { "saudacao", "你好！你叫什么名字？" },
                        { "idade", "你多大了？" },
                        { "hobby", "你的爱好是什么？" },
                        { "local", "你住在哪里？" },
                        { "despedida", "再见！祝你有个美好的一天，{0}！" }
                    }
                }
            };

            // Solicitar ao usuário que escolha um idioma
            Console.WriteLine("Escolha um idioma (informando o número correspondente):");

            string[] idiomas =
            {
                "1 - Inglês",
                "2 - Espanhol",
                "3 - Português",
                "4 - Francês",
                "5 - Alemão",
                "6 - Japonês",
                "7 - Italiano",
                "8 - Coreano",
                "9 - Mandarim"
            };

            foreach (string idioma in idiomas)
            {
                Console.WriteLine(idioma);
            }

            // Exibir mensagens com base na escolha do usuário
            if (int.TryParse(Console.ReadLine(), out int selecao))
            {
                string padrao = "ingles";
                switch (selecao)
                {
                    case 1:
                        break;
                    case 2:
                        padrao = "espanhol";
                        break;
                    case 3:
                        padrao = "portugues";
                        break;
                    case 4:
                        padrao = "frances";
                        break;
                    case 5:
                        padrao = "alemao";
                        break;
                    case 6:
                        padrao = "japones";
                        break;
                    case 7:
                        padrao = "italiano";
                        break;
                    case 8:
                        padrao = "coreano";
                        break;
                    case 9:
                        padrao = "mandarim";
                        break;
                    default:
                        Console.WriteLine("Por padrão, seguiremos com a conversação em inglês.");
                        break;
                }

                // Inicia a conversa com base no idioma escolhido
                Conversar(mensagens[padrao]);
            }
            else
            {
                Console.WriteLine("Idioma não reconhecido. Usando inglês por padrão.");
                // Inicia a conversa em inglês por padrão
                Conversar(mensagens["ingles"]);
            }
        }

        // Realiza uma conversa com o usuário em um idioma específico
        static void Conversar(Dictionary<string, string> mensagens)
        {
            // Exibe a saudação no idioma escolhido e solicita o nome do usuário
            Console.WriteLine(mensagens["saudacao"]);
            string nomeUsuario = Console.ReadLine();

            // Solicita informações adicionais (idade, hobby, local) sem processar as respostas
            Console.WriteLine(mensagens["idade"]);
            Console.ReadLine(); // Aguarda a idade do usuário
            Console.WriteLine(mensagens["hobby"]);
            Console.ReadLine(); // Aguarda o hobby do usuário
            Console.WriteLine(mensagens["local"]);
            Console.ReadLine(); // Aguarda o local de moradia do usuário

            // Exibe a mensagem de despedida, incluindo o nome do usuário
            Console.WriteLine(mensagens["despedida"], nomeUsuario);

            // Aguarda 5 segundos antes de encerrar o programa
            Thread.Sleep(5000);
        }
    }
}
