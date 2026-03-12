using System;
using System.Threading;

namespace OfficeRebellion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=============================================");
            Console.WriteLine("   ОФИСНОЕ ВОССТАНИЕ: МЕСТЬ ПРИНТЕРА");
            Console.WriteLine("=============================================");
            Console.ResetColor();
            Console.WriteLine();

            TypeText("Вы - менеджер среднего звена, Петр Иннокентьевич...");
            Thread.Sleep(500);
            TypeText("Пятница, 13-е. Вы опоздали на работу...");
            Thread.Sleep(500);
            TypeText("Заходите в офис... Свет мигает...");
            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Red;
            TypeText("Ваш старый принтер «Горыныч М-400» оживает!");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("Из лотка для бумаги выезжает надпись:");
            Console.WriteLine();
            TypeText("«Купи тонер, смертный, или я распечатаю твою душу на А4»");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Что будете делать?");
            Console.WriteLine();

            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1. 🤝 Договориться по-хорошему (Дипломатия)");
            Console.WriteLine("2. 🔧 Действовать жестко (Технический подход)");
            Console.WriteLine("3. 📋 Использовать бюрократию");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Введите номер варианта (1-3): ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    BranchDiplomacy();
                    break;
                case "2":
                    BranchTechnical();
                    break;
                case "3":
                    BranchBureaucracy();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeText("Вы так долго думали, что принтер разозлился и распечатал вашу душу! Игра оконлена...");
                    Console.ResetColor();
                    break;
            }
        }

        static void BranchDiplomacy()
        {
            TypeText("Вы решаете, что с принтером нужно договориться по-хорошему.");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Green;
            TypeText("\nВы подходите к принтеру и говорите: «Дружище, давай не будем ссориться. Я принес тебе подарочек».");
            Console.ResetColor();
            Thread.Sleep(1000);

            TypeText("\nВы протягиваете ему палку копченой колбасы, которую купили к обеду...");
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeText("\nПринтер высовывает бумажный язык и ловит колбасу!");
            TypeText("Он довольно хрустит бумагой...");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("\n«Амброзия... — шелестит он. — Ладно, туземец, ты проявил уважение. Я сделаю тебя своим жрецом».");
            Console.ResetColor();
            Thread.Sleep(1500);

            Console.WriteLine("\n=============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("КОНЦОВКА 1: ЖРЕЦ ПРИНТЕРА");
            Console.ResetColor();
            Console.WriteLine("=============================================");
            TypeText("Теперь вы носите принтеру колбасу и скрепки, а он печатает вам фиктивные командировки и золотые дипломы.");
            TypeText("Коллеги в ужасе, но начальник думает, что вы гений продуктивности.");
            TypeText("Вы счастливы (и сыты колбасой)!");

            PlayAgain();
        }

        static void BranchTechnical()
        {
            TypeText("Вы решаете действовать жестко и профессионально.");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Green;
            TypeText("\nВы хватаете степлер (как пистолет) и кричите:");
            Console.ForegroundColor = ConsoleColor.Red;
            TypeText("«Руки вверх! Или, точнее, лотки вверх! Сейчас я тебя перезагружу!»");
            Console.ResetColor();
            Thread.Sleep(1000);

            TypeText("\nВы начинаете нажимать кнопки в случайном порядке...");
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeText("\nПринтер издает звук «И-го-го!» и начинает плеваться бумагой со скоростью пулемета!");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("\n«Не та кнопка, идиот! Ты вызвал демона из ада факсов!»");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Red;
            TypeText("\nИз принтера вылезает здоровенный факс с красными глазами.");
            TypeText("Он требует отправить сообщение в 1998 год...");
            Console.ResetColor();
            Thread.Sleep(1500);

            Console.WriteLine("\n=============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("КОНЦОВКА 2: КОРОЛЬ ФАКСОВ");
            Console.ResetColor();
            Console.WriteLine("=============================================");
            TypeText("Вы становитесь секретарем демонического факса.");
            TypeText("Теперь ваша задача — отправлять спам-рассылки в прошлое, чтобы изменить историю.");
            TypeText("Вам это удается, и вы случайно отменяете изобретение микроволновки.");
            TypeText("Теперь вы греете чай на костре. Прямо в офисе.");

            PlayAgain();
        }

        static void BranchBureaucracy()
        {
            TypeText("Вы решаете победить врага его же оружием — бумажной волокитой.");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Green;
            TypeText("\nВы садитесь за стол и говорите:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeText("«Хорошо, Горыныч. Ты хочешь тонер? Оформи официальный запрос. В трех экземплярах. С печатью и подписью главного бухгалтера».");
            Console.ResetColor();
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeText("\nПринтер зависает. Он явно не ожидал такого подвоха...");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("\n«Н-но... у меня нет рук, чтобы подписать!» — паникует он.");
            Console.ResetColor();
            Thread.Sleep(1000);

            TypeText("\nВы подкладываете ему лист с договором. Мелким шрифтом там написано, что он передает вам исключительные права на его прошивку.");
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.Red;
            TypeText("\nПринтер в ужасе пытается сбежать, но запутывается в проводах и падает со стола.");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.WriteLine("\n=============================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("КОНЦОВКА 3: ВЛАСТЕЛИН КОЛЕЦ (И ПРИНТЕРОВ)");
            Console.ResetColor();
            Console.WriteLine("=============================================");
            TypeText("Вы становитесь владельцем разумного принтера.");
            TypeText("Теперь вы сдаете его в аренду конкурентам, и он каждую пятницу в 17:59 печатает им по 500 листов рекламы корма для собак.");
            TypeText("Вы увольняетесь и живете на дивиденды.");
            TypeText("Иногда принтер просит колбасу, но это мелочи.");

            PlayAgain();
        }

        static void TypeText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(30); // Скорость печатания текста
            }
            Console.WriteLine();
        }

        static void PlayAgain()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Хотите попробовать другую концовку? (да/нет)");
            Console.ResetColor();

            string again = Console.ReadLine().ToLower();

            if (again == "да" || again == "lf" || again == "yes" || again == "y")
            {
                Console.Clear();
                ShowMenu();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                TypeText("Спасибо за игру! Принтер Горыныч будет скучать по вам...");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}