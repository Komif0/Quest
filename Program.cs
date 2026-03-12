using System;
using System.Collections.Generic;
using System.Threading;

namespace PoscldniyReys
{
    class Program
    {
        // Структура для хранения состояния игры
        struct GameState
        {
            public int TrustLeo;        // Доверие Лео (влияет на концовку)
            public int Pragmatism;       // Прагматизм/Цинизм (влияет на концовку)
            public int Chaos;            // Хаотичность решений (влияет на концовку)
            public bool HasMedkit;        // Есть ли аптечка (для лечения)
            public bool ContainerOpened;   // Вскрывал ли контейнер
            public bool LeoWithYou;        // Жив ли Лео и с вами ли он
            public int CurrentQuestion;    // Текущий вопрос
            public string PlayerName;       // Имя игрока
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Для поддержки русского языка
            Console.Title = "Последний рейс - Текстовый квест";

            // Приветствие
            Console.WriteLine("=============================================");
            Console.WriteLine("         Добро пожаловать в игру");
            Console.WriteLine("           'ПОСЛЕДНИЙ РЕЙС'");
            Console.WriteLine("=============================================");
            Console.WriteLine("\nВы - водитель грузовика в постапокалиптическом мире.");
            Console.WriteLine("Вам предстоит доставить таинственный груз из форта 'Надежда' в город 'Оазис'.");
            Console.WriteLine("Будьте осторожны: каждое решение влияет на вашу судьбу.\n");

            Console.Write("Введите имя вашего персонажа: ");
            string playerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(playerName))
                playerName = "Сталкер";

            // Инициализация состояния игры
            GameState state = new GameState
            {
                TrustLeo = 0,
                Pragmatism = 0,
                Chaos = 0,
                HasMedkit = true, // По умолчанию есть базовая аптечка
                ContainerOpened = false,
                LeoWithYou = true, // Лео с вами по умолчанию
                CurrentQuestion = 1,
                PlayerName = playerName
            };

            Console.Clear();
            Console.WriteLine($"Хорошей дороги, {state.PlayerName}!\n");
            Thread.Sleep(1500);

            // Запуск игры
            PlayGame(ref state);

            // Завершение
            Console.WriteLine("\n\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void PlayGame(ref GameState state)
        {
            bool gameOver = false;

            while (!gameOver)
            {
                switch (state.CurrentQuestion)
                {
                    case 1: Question1(ref state); break;
                    case 2: Question2(ref state); break;
                    case 3: Question3(ref state); break;
                    case 4: Question4(ref state); break;
                    case 5: Question5(ref state); break;
                    case 6: Question6(ref state); break;
                    case 7: Question7(ref state); break;
                    case 8: Question8(ref state); break;
                    case 9: Question9(ref state); break;
                    case 10: Question10(ref state); break;
                    case 11: Question11(ref state); break;
                    case 12: Question12(ref state); break;
                    case 13: Question13(ref state); break;
                    case 14: Question14(ref state); break;
                    case 15: Question15(ref state); break;
                    case 16: Question16(ref state); break;
                    case 17: Question17(ref state); break;
                    case 18: Question18(ref state); break;
                    case 19: Question19(ref state); break;
                    case 20: Question20(ref state); break;
                    case 99: // Концовка хорошая
                        GoodEnding(state);
                        gameOver = true;
                        break;
                    case 100: // Концовка плохая
                        BadEnding(state);
                        gameOver = true;
                        break;
                    case 101: // Концовка ничья
                        NeutralEnding(state);
                        gameOver = true;
                        break;
                    default:
                        gameOver = true;
                        break;
                }
            }
        }

        static void Question1(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Начало пути");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Стоя у своего старого тягача «Верный», вы перебираете инструменты.");
            Console.WriteLine("Вдруг слышите странный шорох в кузове. Ваши действия?\n");
            Console.WriteLine("1. Взять монтировку и проверить кузов.");
            Console.WriteLine("2. Решить, что показалось, и сесть в кабину прогревать двигатель.");
            Console.WriteLine("3. Позвать на помощь механика со станции.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Проверить самому
                    state.Pragmatism += 1;
                    Console.WriteLine("\nВы осторожно берете монтировку и крадетесь к кузову...");
                    break;
                case 2: // Игнорировать
                    state.Chaos += 1;
                    Console.WriteLine("\n«Показалось, наверное. Надо ехать», - думаете вы и забираетесь в кабину.");
                    break;
                case 3: // Звать механика
                    state.TrustLeo -= 1;
                    Console.WriteLine("\nВы зовете механика. Вдвоем веселее, но шум привлекает внимание.");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 2;
        }

        static void Question2(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Неожиданная находка");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Заглянув под брезент, вы видите съежившегося мальчишку лет двенадцати.");
            Console.WriteLine("Он смотрит на вас испуганными глазами и прикладывает палец к губам:");
            Console.WriteLine("«Тсс! Пожалуйста, не выдавайте! Они убьют меня!»\n");
            Console.WriteLine("1. Выгнать его взашей. Свои проблемы пусть решает сам.");
            Console.WriteLine("2. Спрятать его обратно и сделать вид, что ничего не было.");
            Console.WriteLine("3. Разозлиться и громко закричать, зовя стражу.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Выгнать
                    state.Pragmatism += 2;
                    state.TrustLeo -= 2;
                    state.LeoWithYou = false;
                    Console.WriteLine("\n«Пошел вон отсюда! Мне свои проблемы не нужны!» - рявкаете вы.");
                    break;
                case 2: // Спрятать
                    state.TrustLeo += 2;
                    state.Chaos += 1;
                    Console.WriteLine("\nВы молча закрываете брезент и делаете вид, что ничего не произошло.");
                    break;
                case 3: // Звать стражу
                    state.Pragmatism -= 1;
                    state.TrustLeo -= 3;
                    state.LeoWithYou = false;
                    Console.WriteLine("\n«Стража! Здесь нарушитель карантина!» - орете вы на всю округу.");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 3;
        }

        static void Question3(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: На выезде");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы выезжаете за ворота форта. Охранник сверяется со списком и замечает:");
            Console.WriteLine("«Что-то твоя махина сегодня тяжелее идет. Проверим груз?»\n");
            Console.WriteLine("1. «Без проблем, смотри. Мне скрывать нечего».");
            Console.WriteLine("2. Дать охраннику взятку (пачку старых сигарет).");
            Console.WriteLine("3. Нажать на газ и попытаться прорваться через шлагбаум.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Пустить проверять
                    if (state.LeoWithYou)
                    {
                        Console.WriteLine("\nОхранник заглядывает в кузов и находит Лео.");
                        Console.WriteLine("«А это что за пассажир? Придется задержаться...»");
                        state.TrustLeo -= 2;
                        state.Chaos += 1;
                    }
                    else
                    {
                        Console.WriteLine("\nОхранник осматривает пустой кузов и машет рукой: «Проезжай!»");
                    }
                    break;
                case 2: // Взятка
                    Console.WriteLine("\nОхранник быстро прячет сигареты и делает вид, что проверяет планшет.");
                    Console.WriteLine("«Ладно, езжай уже. Дорога ровная!»");
                    state.Pragmatism += 1;
                    break;
                case 3: // Прорыв
                    Console.WriteLine("\nВы вдавливаете педаль газа в пол! Шлагбаум разлетается в щепки!");
                    Console.WriteLine("Сзади слышны крики и выстрелы, но вы уже далеко.");
                    state.Chaos += 2;
                    state.Pragmatism -= 1;
                    break;
            }
            Thread.Sleep(2000);
            state.CurrentQuestion = 4;
        }

        static void Question4(ref GameState state)
        {
            if (!state.LeoWithYou)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine($"Вопрос {state.CurrentQuestion}: Одиночество");
                Console.WriteLine("=============================================\n");
                Console.WriteLine("Вы едете один по пустой трассе. Тишина давит на уши.");
                Console.WriteLine("Может, стоило оставить мальчишку?");
                Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                state.CurrentQuestion = 6; // Пропускаем вопросы с Лео
                return;
            }

            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Первый километр");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы отъехали достаточно далеко. Мальчик стучит в окошко из кузова.");
            Console.WriteLine("Вы открываете люк.\n");
            Console.WriteLine("1. Остановиться и высадить его прямо посреди трассы.");
            Console.WriteLine("2. Впустить его в кабину, чтобы поговорить.");
            Console.WriteLine("3. Кричать на него через люк, требуя объяснений, но продолжать ехать.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Высадить
                    state.TrustLeo -= 2;
                    state.Pragmatism += 1;
                    state.LeoWithYou = false;
                    Console.WriteLine("\n«Приехали. Выходи. Дальше сам как-нибудь.»");
                    break;
                case 2: // Впустить
                    state.TrustLeo += 2;
                    Console.WriteLine("\nВы останавливаетесь и открываете дверь. В кабину забирается чумазый паренек.");
                    break;
                case 3: // Кричать
                    state.Chaos += 1;
                    state.TrustLeo -= 1;
                    Console.WriteLine("\n«Ты какого черта тут делаешь?! Быстро говори!» - орете вы, не оборачиваясь.");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 5;
        }

        static void Question5(ref GameState state)
        {
            if (!state.LeoWithYou)
            {
                state.CurrentQuestion = 6;
                return;
            }

            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: История парня");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Мальчика зовут Лео. Он рассказывает, что сбежал из лаборатории «Ковчег»,");
            Console.WriteLine("где ставили опыты на детях. За ним послали охотников за головами.");
            Console.WriteLine("Он умоляет довезти его до Оазиса, где у него есть дядя.\n");
            Console.WriteLine("1. Поверить ему. История звучит страшно.");
            Console.WriteLine("2. Не поверить. Скорее всего, он врет.");
            Console.WriteLine("3. Спросить, что он украл из лаборатории.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Поверить
                    state.TrustLeo += 3;
                    Console.WriteLine("\n«Ладно, парень. Сиди тихо и не высовывайся. Довезем твоего дядю.»");
                    break;
                case 2: // Не верить
                    state.Pragmatism += 2;
                    state.TrustLeo -= 2;
                    Console.WriteLine("\n«Сказки рассказываешь? Ладно, отработаешь проезд. Будешь помогать с грузом.»");
                    break;
                case 3: // Что украл?
                    state.Chaos += 1;
                    state.TrustLeo += 1;
                    Console.WriteLine("\nЛео мнется: «Я... я ничего не крал. Я просто убежал. Но я знаю, что в контейнере.»");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 6;
        }

        static void Question6(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Погоня");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Через час езды вы замечаете в зеркале заднего вида два пылевых столба —");
            Console.WriteLine("быстро движущиеся багги.\n");
            Console.WriteLine("1. Прибавить газу. «Верный» хоть и старый, но тяговитый.");
            Console.WriteLine("2. Свернуть с трассы в каньон, попытаться оторваться в камнях.");
            Console.WriteLine("3. Остановиться и приготовить оружие. Встретим их лицом к лицу.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Газ
                    Console.WriteLine("\nВы выжимаете максимум из старого двигателя. Погоня не отстает!");
                    state.Pragmatism += 1;
                    break;
                case 2: // В каньон
                    Console.WriteLine("\nВы резко сворачиваете с трассы, поднимая тучи пыли.");
                    state.Chaos += 1;
                    break;
                case 3: // Бой
                    Console.WriteLine("\nВы выходите из кабины с револьвером в руке. Пыль оседает...");
                    state.Pragmatism -= 1;
                    state.Chaos += 2;
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 7;
        }

        static void Question7(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Засада в каньоне");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы въезжаете в узкое ущелье.");
            if (state.LeoWithYou)
            {
                Console.WriteLine("Лео говорит, что здесь есть тропа, по которой могут пройти только люди.");
                Console.WriteLine("А на машине тут тупик. Позади слышен рев моторов багги.\n");
            }
            else
            {
                Console.WriteLine("Карта показывает, что дальше дороги нет - тупик. Позади слышен рев моторов.\n");
            }

            Console.WriteLine("1. Бросить грузовик и уходить пешком" + (state.LeoWithYou ? " с Лео по тропе." : "."));
            Console.WriteLine("2. Спрятаться в расщелине и попытаться отсидеться.");
            Console.WriteLine("3. Развернуть грузовик поперек ущелья, создав баррикаду.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Пешком
                    Console.WriteLine("\nВы хватаете самое необходимое и углубляетесь в скалы.");
                    if (state.LeoWithYou) state.TrustLeo += 1;
                    state.Chaos += 1;
                    break;
                case 2: // Спрятаться
                    Console.WriteLine("\nВы забиваетесь в глубокую расщелину, затаив дыхание.");
                    state.Pragmatism += 1;
                    break;
                case 3: // Баррикада
                    Console.WriteLine("\nВы разворачиваете грузовик и готовитесь к бою.");
                    state.Chaos += 2;
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 8;
        }

        static void Question8(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Цель груза");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы оторвались от погони. Наступила ночь.");
            if (state.LeoWithYou) Console.WriteLine("Вы с Лео сидите у костра.");
            else Console.WriteLine("Вы сидите один у костра.");
            Console.WriteLine("Вы рассматриваете накладную на груз. Там написано просто:");
            Console.WriteLine("«Био-материал. Хрупкий. Температурный режим соблюдать».\n");
            Console.WriteLine("1. Вскрыть контейнер и посмотреть, что там внутри.");
            Console.WriteLine("2. Не лезть не в свое дело. Моя задача доставить — получить деньги.");
            Console.WriteLine("3. Спросить у Лео, не знает ли он, что это может быть.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Вскрыть
                    state.ContainerOpened = true;
                    state.Chaos += 2;
                    Console.WriteLine("\nЛомать не строить! Вы взламываете замок контейнера...");
                    break;
                case 2: // Не лезть
                    state.Pragmatism += 2;
                    Console.WriteLine("\n«Не мое дело — не лезу. Утром поедем дальше.»");
                    break;
                case 3: // Спросить Лео
                    if (state.LeoWithYou)
                    {
                        state.TrustLeo += 1;
                        Console.WriteLine("\nЛео задумчиво смотрит на огонь: «Я думаю, там то, из-за чего они охотятся за мной.»");
                    }
                    else
                    {
                        Console.WriteLine("\nНекого спрашивать. Придется решать самому.");
                        state.CurrentQuestion = 9; // Переход без изменений
                        Question9(ref state);
                        return;
                    }
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 9;
        }

        static void Question9(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Содержимое контейнера");
            Console.WriteLine("=============================================\n");

            if (state.ContainerOpened)
            {
                Console.WriteLine("Внутри контейнера вы видите криогенные капсулы с эмбрионами и пробирки.");
                Console.WriteLine("Похоже на генетический банк.\n");
            }
            else
            {
                Console.WriteLine("Вы так и не вскрыли контейнер, но сомнения гложут вас.\n");
            }

            Console.WriteLine("1. Уничтожить это. Нечего выводить новых людей для экспериментов.");
            Console.WriteLine("2. Оставить как есть. Это будущее человечества.");
            Console.WriteLine("3. Спрятать пару пробирок в карман. На черный день.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Уничтожить
                    state.Chaos += 2;
                    state.Pragmatism -= 1;
                    Console.WriteLine("\n«Не бывать этому!» - вы решаете избавиться от груза.");
                    break;
                case 2: // Оставить
                    state.Pragmatism += 1;
                    Console.WriteLine("\n«Кто я такой, чтобы решать судьбу будущего? Повезу как есть.»");
                    break;
                case 3: // Спрятать
                    state.Pragmatism += 1;
                    state.Chaos += 1;
                    Console.WriteLine("\nКарман не тянет, пара пробирок точно пригодится. На всякий случай.");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 10;
        }

        static void Question10(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Станция «Западная»");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы доезжаете до заправочной станции. Механик предлагает обменять топливо на информацию.");
            Console.WriteLine("Он говорит, что в Оазисе чума, и въезд закрыт.");
            Console.WriteLine("Но если у вас есть груз для доктора Менгса, то вас пропустят через черный ход.\n");
            Console.WriteLine("1. Ехать напрямую в Оазис, надеясь, что старик ошибся.");
            Console.WriteLine("2. Согласиться на черный ход. Меньше проверок.");
            Console.WriteLine("3. Развернуться и поехать обратно в Форт, пока не поздно.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Напрямую
                    Console.WriteLine("\n«Старики вечно паникуют. Поеду как планировал.»");
                    state.Pragmatism += 1;
                    break;
                case 2: // Черный ход
                    Console.WriteLine("\n«Черный ход так черный ход. Меньше глаз — меньше проблем.»");
                    state.Chaos += 1;
                    break;
                case 3: // Назад
                    Console.WriteLine("\n«Чума? Ну его нафиг. Разворачиваюсь.»");
                    state.Pragmatism -= 1;
                    // Это приводит к плохой концовке? Пока просто штраф
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 11;
        }

        static void Question11(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Просьба механика");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Механик шепчет: «Слушай, в Оазисе бардак. Если у тебя там ценный груз, будь осторожен.");
            Console.WriteLine("А лучше — продай его мне. Я хорошо заплачу.»\n");
            Console.WriteLine("1. Продать груз механику. Деньги сейчас, и никаких проблем с карантином.");
            Console.WriteLine("2. Послать механика. Я выполняю заказ, и точка.");
            Console.WriteLine("3. Спросить, зачем ему груз.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Продать
                    state.Pragmatism += 2;
                    Console.WriteLine("\n«Деньги любят счет. Показывай, что у тебя есть.»");
                    break;
                case 2: // Послать
                    state.TrustLeo += 1; // Лео ценит верность долгу
                    Console.WriteLine("\n«Иди ты со своими предложениями. У меня контракт.»");
                    break;
                case 3: // Спросить
                    Console.WriteLine("\n«Зачем тебе?» - спрашиваете вы.");
                    state.CurrentQuestion = 12;
                    return;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 13;
        }

        static void Question12(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Ответ механика");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Механик говорит, что его дочь больна, и только современные лекарства");
            Console.WriteLine("или оборудование из этого контейнера могут ее спасти.\n");
            Console.WriteLine("1. Отдать контейнер, забрать запчасти и уехать. Мне жаль девочку.");
            Console.WriteLine("2. Отказать. Мне плевать на его девочку, у меня свой интерес.");
            Console.WriteLine("3. Сказать, что контейнер не ваш, и вы не можете им распоряжаться.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Отдать
                    state.TrustLeo += 2;
                    Console.WriteLine("\n«Забирай. Надеюсь, это поможет твоей дочери.»");
                    break;
                case 2: // Отказать
                    state.Pragmatism += 2;
                    state.TrustLeo -= 1;
                    Console.WriteLine("\n«Мне жаль, но у каждого свои проблемы.»");
                    break;
                case 3: // Не мое
                    state.Pragmatism += 1;
                    Console.WriteLine("\n«Я просто водила, груз не мой. Не могу решать.»");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 13;
        }

        static void Question13(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Дорога через Тоннель");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Чтобы быстрее попасть в Оазис, нужно ехать через старый автодорожный тоннель.");
            if (state.LeoWithYou) Console.WriteLine("Лео говорит, что там живут мутанты.");
            else Console.WriteLine("Говорят, там живут мутанты.");
            Console.WriteLine("Ваш грузовик шумит, как стадо слонов.\n");
            Console.WriteLine("1. Ехать через тоннель на скорости. Прорвемся!");
            Console.WriteLine("2. Заглушить двигатель и попытаться пройти пешком, тащить груз на себе.");
            Console.WriteLine("3. Поискать еще один обходной путь по карте.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // На скорости
                    Console.WriteLine("\n«Быстрее ветра!» - вы вдавливаете педаль.");
                    state.Chaos += 1;
                    break;
                case 2: // Пешком
                    Console.WriteLine("\n«Тише едешь — дальше будешь. Пошли пешком.»");
                    state.Pragmatism += 1;
                    break;
                case 3: // Обход
                    Console.WriteLine("\n«Где-то здесь должна быть старая дорога...»");
                    state.Pragmatism += 1;
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 14;
        }

        static void Question14(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Встреча в тоннеле");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Посреди тоннеля дорогу вам преграждает группа вооруженных людей.");
            Console.WriteLine("Это банда «Черные копатели». Главарь: «Стоять! Контейнер и мальчика — нам,");
            Console.WriteLine("водила останется с нами до утра работать».\n");
            Console.WriteLine("1. Согласиться на условия. Жизнь дороже.");
            Console.WriteLine("2. Вступить в перестрелку.");
            Console.WriteLine("3. Попытаться договориться.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Согласиться
                    state.Pragmatism += 2;
                    if (state.LeoWithYou)
                    {
                        state.TrustLeo -= 3;
                        state.LeoWithYou = false;
                    }
                    Console.WriteLine("\n«Забирайте. Мне моя жизнь дороже.»");
                    break;
                case 2: // Перестрелка
                    state.Chaos += 2;
                    Console.WriteLine("\n«На, получи!» - вы выхватываете револьвер.");
                    break;
                case 3: // Договориться
                    state.TrustLeo += 1;
                    state.Pragmatism += 1;
                    Console.WriteLine("\n«Может, договоримся по-хорошему?»");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 15;
        }

        static void Question15(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Выбор оружия");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("У вас есть старый револьвер на 6 зарядов и монтировка. Бандитов пятеро.\n");
            Console.WriteLine("1. Стрелять первым в главаря, чтобы посеять панику.");
            Console.WriteLine("2. Использовать грузовик как таран.");
            Console.WriteLine("3. Применить газовый баллончик и убежать в темноту.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Стрелять
                    Console.WriteLine("\nВы стреляете в главаря! Грохот эхом разносится по тоннелю.");
                    state.Chaos += 1;
                    break;
                case 2: // Таран
                    Console.WriteLine("\nВы прыгаете в кабину и давите на газ!");
                    state.Chaos += 2;
                    break;
                case 3: // Газ и бежать
                    Console.WriteLine("\nБаллончик шипит, слезы застилают глаза бандитам. Бежим!");
                    state.Pragmatism += 1;
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 16;
        }

        static void Question16(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Ранение");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("В перестрелке вы получаете ранение в ногу.");
            if (state.LeoWithYou) Console.WriteLine("Лео перевязывает вас куском рубашки. Кровь не останавливается.");
            else Console.WriteLine("Вы кое-как перевязываете себя сами. Кровь не останавливается.\n");
            Console.WriteLine("1. Заставить Лео идти вперед одному, а самому остаться.");
            Console.WriteLine("2. Идти дальше, опираясь на Лео, чего бы это ни стоило.");
            Console.WriteLine("3. Использовать груз из контейнера (аптечку), чтобы обработать рану.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Остаться
                    if (state.LeoWithYou)
                    {
                        state.TrustLeo += 2;
                        Console.WriteLine("\n«Беги, Лео! Я тебя прикрою!»");
                        state.LeoWithYou = false;
                    }
                    else
                    {
                        Console.WriteLine("\nНекого посылать. Придется выживать самому.");
                    }
                    break;
                case 2: // Идти дальше
                    state.Pragmatism += 1;
                    if (state.LeoWithYou) state.TrustLeo += 1;
                    Console.WriteLine("\n«Только вперед! Я не сдамся!»");
                    break;
                case 3: // Использовать аптечку
                    if (state.HasMedkit)
                    {
                        Console.WriteLine("\nВы достаете аптечку и обрабатываете рану. Кровь останавливается.");
                        state.HasMedkit = false;
                    }
                    else
                    {
                        Console.WriteLine("\nАптечки нет. Придется терпеть боль.");
                    }
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 17;
        }

        static void Question17(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Предместья Оазиса");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вы выходите к воротам города. На стенах военные с автоматами.");
            Console.WriteLine("Громкоговоритель: «Стоять! Назовите цель прибытия! У нас карантин!»\n");
            Console.WriteLine("1. Кричать: «У меня груз для доктора Менгса!»");
            Console.WriteLine("2. Кричать: «У меня раненый! Помогите!»");
            Console.WriteLine("3. Поднять белый флаг и просить убежища для мальчика.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Груз для Менгса
                    Console.WriteLine("\n«Доктор Менгс? Проезжайте, вас ждут.»");
                    state.Pragmatism += 1;
                    break;
                case 2: // Раненый
                    Console.WriteLine("\n«Медицинская помощь? Вас проводят в карантинный блок.»");
                    state.TrustLeo += 1;
                    break;
                case 3: // Убежище
                    Console.WriteLine("\n«Убежище? У нас тут не богадельня. Но... проходите, раз пришли.»");
                    state.TrustLeo += 1;
                    state.Chaos += 1;
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 18;
        }

        static void Question18(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Доктор Менгс");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Вас впускают в шлюз. Приходит доктор Менгс. Это сухой старик в очках.");
            Console.WriteLine("Он смотрит на контейнер, потом на Лео.");
            if (state.LeoWithYou)
            {
                Console.WriteLine("«А, это ты, образец 23? Сбежал все-таки. Ничего, сейчас вернем тебя в лабораторию.»");
            }
            else
            {
                Console.WriteLine("«Груз доставлен? Отлично. А где мальчишка? Жаль, он был ценным экземпляром.»");
            }
            Console.WriteLine("«Контейнер мы забираем. Ты свободен. Вот твоя оплата.»\n");
            Console.WriteLine("1. Отдать Лео. Я сделал свою работу, остальное не мое дело.");
            Console.WriteLine("2. Встать на защиту Лео.");
            Console.WriteLine("3. Попытаться выторговать за Лео побольше денег.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Отдать
                    state.Pragmatism += 2;
                    state.TrustLeo -= 3;
                    if (state.LeoWithYou) state.LeoWithYou = false;
                    Console.WriteLine("\n«Забирайте. Мне он не нужен.»");
                    break;
                case 2: // Защитить
                    state.TrustLeo += 3;
                    Console.WriteLine("\n«Ну уж нет! Он со мной и никуда не пойдет!»");
                    break;
                case 3: // Выторговать
                    state.Pragmatism += 2;
                    if (state.LeoWithYou) state.TrustLeo -= 2;
                    Console.WriteLine("\n«А сколько он стоит? Может, договоримся?»");
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 19;
        }

        static void Question19(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Истина");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Доктор Менгс смеется: «Глупец. Ты думал, что вез какие-то лекарства?");
            Console.WriteLine("Ты вез мне новых подопытных. Эмбрионы. А этот мальчик — мой лучший экземпляр.");
            Console.WriteLine("Отдай его, и иди с миром. Или умри с ним вместе.»\n");
            Console.WriteLine("1. Встать плечом к плечу с Лео и принять бой.");
            Console.WriteLine("2. Отойти в сторону. Извини, парень, но против системы не попрешь.");
            Console.WriteLine("3. Спросить у Лео, что он хочет сам.");

            int choice = GetChoice(1, 3);

            switch (choice)
            {
                case 1: // Бой
                    state.TrustLeo += 3;
                    state.Chaos += 2;
                    Console.WriteLine("\n«Мы принимаем бой! За свободу!»");
                    break;
                case 2: // Отойти
                    state.Pragmatism += 3;
                    if (state.LeoWithYou) state.TrustLeo -= 3;
                    Console.WriteLine("\n«Прости, парень. Так сложилось.»");
                    break;
                case 3: // Спросить Лео
                    if (state.LeoWithYou)
                    {
                        state.TrustLeo += 2;
                        Console.WriteLine("\n«Лео, что скажешь? Я с тобой, что бы ты ни решил.»");
                    }
                    else
                    {
                        Console.WriteLine("\nЛео нет рядом. Придется решать самому.");
                        state.CurrentQuestion = 20;
                        return;
                    }
                    break;
            }
            Thread.Sleep(1500);
            state.CurrentQuestion = 20;
        }

        static void Question20(ref GameState state)
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine($"Вопрос {state.CurrentQuestion}: Последний выбор");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Силы неравны. У доктора охрана. У вас пистолет с двумя патронами.");
            if (state.LeoWithYou)
            {
                Console.WriteLine("Лео шепчет: «Взорви грузовик. Там в кабине, под сиденьем, детонатор.");
                Console.WriteLine("Я знаю. Я подложил. Не хочу, чтобы они получили контейнер.»\n");
            }
            else
            {
                Console.WriteLine("Вы один. Охрана окружает вас.\n");
            }

            Console.WriteLine("1. Активировать детонатор. Взорвать все к чертям собачьим.");
            Console.WriteLine("2. Выстрелить в доктора и попытаться убежать.");
            Console.WriteLine("3. Сдаться. Жизнь дороже принципов.");

            int choice = GetChoice(1, 3);

            // Подсчет очков для определения концовки
            int totalScore = state.TrustLeo * 2 - state.Pragmatism + state.Chaos;

            switch (choice)
            {
                case 1: // Взорвать
                    state.Chaos += 5;
                    Console.WriteLine("\n«Прощайте все!» - вы нажимаете кнопку...");
                    Thread.Sleep(2000);
                    if (totalScore > 5)
                        state.CurrentQuestion = 99; // Хорошая
                    else if (totalScore < -5)
                        state.CurrentQuestion = 100; // Плохая
                    else
                        state.CurrentQuestion = 101; // Нейтральная
                    break;
                case 2: // Стрелять и бежать
                    state.TrustLeo += 2;
                    Console.WriteLine("\nВы стреляете в доктора и бросаетесь бежать!");
                    Thread.Sleep(2000);
                    if (state.TrustLeo > 10)
                        state.CurrentQuestion = 99;
                    else if (state.Pragmatism > 10)
                        state.CurrentQuestion = 100;
                    else
                        state.CurrentQuestion = 101;
                    break;
                case 3: // Сдаться
                    state.Pragmatism += 3;
                    Console.WriteLine("\nВы поднимаете руки. «Я сдаюсь...»");
                    Thread.Sleep(2000);
                    if (state.Pragmatism > 12)
                        state.CurrentQuestion = 100; // Плохая
                    else if (state.TrustLeo > 8)
                        state.CurrentQuestion = 99; // Хорошая
                    else
                        state.CurrentQuestion = 101; // Нейтральная
                    break;
            }
        }

        static void GoodEnding(GameState state)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=============================================");
            Console.WriteLine("              ХОРОШАЯ КОНЦОВКА");
            Console.WriteLine("=============================================\n");
            Console.ResetColor();

            Console.WriteLine("Вы стреляете в доктора Менгса, хватаете Лео и бежите в сторону старого города.");
            Console.WriteLine("Охрана открывает огонь, но вам помогает группа подпольщиков — людей, которые");
            Console.WriteLine("тоже сбежали из лаборатории доктора. Они укрывают вас.");
            Console.WriteLine("\nЛео оказывается уникальным специалистом по генной инженерии.");
            Console.WriteLine("Через год подполье свергает власть безумного доктора.");
            Console.WriteLine($"Вы с Лео и его дядей открываете мастерскую по ремонту грузовиков и возите");
            Console.WriteLine("гуманитарную помощь между фортами.");
            Console.WriteLine("\nВы спасли не просто мальчика — вы спасли будущее, в котором нет места");
            Console.WriteLine("экспериментам над людьми.");

            Console.WriteLine($"\n\nИтоги вашей игры, {state.PlayerName}:");
            Console.WriteLine($"Доверие Лео: {state.TrustLeo}");
            Console.WriteLine($"Прагматизм: {state.Pragmatism}");
            Console.WriteLine($"Хаос: {state.Chaos}");
        }

        static void BadEnding(GameState state)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============================================");
            Console.WriteLine("              ПЛОХАЯ КОНЦОВКА");
            Console.WriteLine("=============================================\n");
            Console.ResetColor();

            Console.WriteLine("Вы отворачиваетесь от Лео. Доктор Менгс согласно кивает и щелкает пальцами.");
            Console.WriteLine("Охранники хватают мальчика. Он смотрит на вас с такой болью и ненавистью,");
            Console.WriteLine("что вам становится не по себе.");
            Console.WriteLine("\nДоктор отсчитывает вам пачку денег: «Умный человек. Выживает сильнейший.»");
            Console.WriteLine("Вы покупаете новую машину и уезжаете.");
            Console.WriteLine("\nНо через неделю вы начинаете замечать странности: вас мучают кошмары,");
            Console.WriteLine("местные жители узнают вас и плюют вслед. Ваш новый грузовик взрывают неизвестные.");
            Console.WriteLine("Вы остаетесь один посреди Пустоши, без гроша в кармане, с клеймом предателя на всю жизнь.");
            Console.WriteLine("\nВы проиграли по-крупному.");

            Console.WriteLine($"\n\nИтоги вашей игры, {state.PlayerName}:");
            Console.WriteLine($"Доверие Лео: {state.TrustLeo}");
            Console.WriteLine($"Прагматизм: {state.Pragmatism}");
            Console.WriteLine($"Хаос: {state.Chaos}");
        }

        static void NeutralEnding(GameState state)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================================");
            Console.WriteLine("            КОНЦОВКА - НИЧЬЯ");
            Console.WriteLine("=============================================\n");
            Console.ResetColor();

            Console.WriteLine("Гремит взрыв. Вы теряете сознание.");
            Console.WriteLine("...");
            Console.WriteLine("Вы приходите в себя через неизвестное время. Рядом никого.");
            Console.WriteLine("Ни Лео, ни доктора, ни города. Только обгоревшие останки грузовика.");
            Console.WriteLine("\nВы бредете по пустоши, не зная, куда идти.");
            Console.WriteLine("Контракт не выполнен, мальчик мертв, вы никому не помогли и ничего не добились.");
            Console.WriteLine("Вы просто еще одна тень в Пустоши.");
            Console.WriteLine("\nИсход не проигран и не выигран. Это просто пустота.");
            Console.WriteLine("Вы будете вечно бродить по руинам старого мира в поисках цели,");
            Console.WriteLine("которой больше не существует.");

            Console.WriteLine($"\n\nИтоги вашей игры, {state.PlayerName}:");
            Console.WriteLine($"Доверие Лео: {state.TrustLeo}");
            Console.WriteLine($"Прагматизм: {state.Pragmatism}");
            Console.WriteLine($"Хаос: {state.Chaos}");
        }

        static int GetChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write($"\nВаш выбор ({min}-{max}): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Пожалуйста, введите число от {min} до {max}.");
            }
        }
    }
}