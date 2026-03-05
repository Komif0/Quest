using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;

class StoryGame
{
    static class SceneCreator 
    {
        public static Dictionary<string, Scene> CreateScene() 
        {
            Console.WriteLine("Введите описание сцены: ");
            var desc = Console.ReadLine();

            Console.WriteLine("Сцена является концовкой? 0 - нет; 1 - да");
            bool isEnding = bool.Parse(Console.ReadLine());
            

            Console.WriteLine("Вводите варианты ответа, 0 - выход из цикла");

            Dictionary<string, string> opts = new Dictionary<string, string>(); 

            int i = 0; 
            while (true) 
            {
                Console.WriteLine($"Введите вариант ответа {i}: ");
                string keyVal = Console.ReadLine();
                if (keyVal == "0") 
                {
                    Console.WriteLine("Вы завершили создание опций!");
                    break; 
                }
                Console.WriteLine($"Введите локацию, на которую ведет ответ {i}: ");
                string nextScene = Console.ReadLine();
                
                opts.Add(keyVal, nextScene); 
            }

            Scene scene = new Scene
            {
                Description = Console.ReadLine(),
                Options = opts,
                IsEnding = isEnding
            };

            Dictionary<string, Scene> newScene = new Dictionary<string, Scene>() { [desc] = scene};
            return newScene; 
        }
    }
    class Scene
    {
        public string Description { get; set; }
        public Dictionary<string, string> Options { get; set; }
        public bool IsEnding { get; set; }
    }

    static Dictionary<string, Scene> _world = new();

    static void Main()
    {
        InitGame();

        string jsonInfo = JsonConvert.SerializeObject(_world, Formatting.Indented);

        
        using (StreamReader sw = new StreamReader("scenes.json")) 
        {
            string json = File.ReadAllText("scenes.json");
            Dictionary<string, Scene> values = JsonConvert.DeserializeObject<Dictionary<string, Scene>>(json);
            foreach (var val in values) 
            {
                 Console.WriteLine(val.Key);
            }
            //Console.WriteLine(json);
        }

        string currentId = "entry";

        //while (true)
        //{
        //    var scene = _world[currentId];
        //    Console.Clear();
        //    Console.WriteLine($"--- {currentId.ToUpper()} ---\n");
        //    Console.WriteLine(scene.Description);

        //    if (scene.IsEnding) break;

        //    var optionsList = scene.Options.Keys.ToList();
        //    for (int i = 0; i < optionsList.Count; i++)
        //        Console.WriteLine($"{i + 1}. {optionsList[i]}");

        //    Console.Write("\nВыбор: ");
        //    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= optionsList.Count)
        //    {
        //        currentId = scene.Options[optionsList[choice - 1]];
        //    }
        //}
        //Console.WriteLine("\n[Нажмите любую клавишу для выхода]");
        //Console.ReadKey();
    }

    static void InitGame()
    {

        // Ветка 1: Вход
        _world["entry"] = new Scene
        {
            Description = "Вы стоите перед заброшенным бункером. Внутри слышен гул.",
            Options = new()
            {
                ["Спуститься внутрь"] = "corridor",
                ["Осмотреть окрестности"] = "forest"
            }
        };



        // Ветка 2: Лес (Поиск ресурсов)
        _world["forest"] = new Scene
        {
            Description = "В лесу вы находите старый рюкзак и ржавый люк.",
            Options = new()
            {
                ["Открыть люк"] = "lab",
                ["Вернуться к входу в бункер"] = "entry"
            }
        };

        // Ветка 3: Коридор
        _world["corridor"] = new Scene
        {
            Description = "Длинный коридор. Слева — дверь с надписью 'BIO', справа — лестница вниз.",
            Options = new()
            {
                ["Зайти в BIO"] = "lab",
                ["Спуститься по лестнице"] = "generator"
            }
        };

        // Ветка 4: Лаборатория (Ловушка или прогресс)
        _world["lab"] = new Scene
        {
            Description = "Здесь колбы с синим газом. Одна из них разбита!",
            Options = new()
            {
                ["Задержать дыхание и бежать"] = "generator",
                ["Исследовать записи"] = "death_gas"
            }
        };

        // Финалы
        _world["generator"] = new Scene
        {
            Description = "Вы нашли работающий генератор и активировали связь. Спасение близко!",
            IsEnding = true
        };

        _world["death_gas"] = new Scene
        {
            Description = "Газ оказался быстрее. Вы засыпаете навсегда.",
            IsEnding = true
        };

    }
}