using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class StoryGame
{
    class Scene
    {
        public string Description { get; set; }
        public Dictionary<string, string> Options { get; set; } = new();
        public bool IsEnding { get; set; }
    }

    static Dictionary<string, Scene> _world = new();
    const string FileName = "scenes.json";

    static void Main()
    {
        LoadGame();
        if (_world.Count == 0) InitGame();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ТЕКСТОВЫЙ КВЕСТ: РЕДАКТОР И ИГРА ===");
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Добавить новые локации (Редактор)");
            Console.WriteLine("3. Показать список всех ID локаций");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите действие: ");

            string choice = Console.ReadLine();
            if (choice == "1") RunGameLoop();
            else if (choice == "2") EditorMenu();
            else if (choice == "3") ShowAllIds();
            else if (choice == "0") break;
        }
    }

    static void EditorMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- РЕДАКТОР ЛОКАЦИЙ ---");
            AddNewSceneToWorld();

            Console.Write("\nДобавить еще одну сцену? (1 - да, 0 - вернуться в меню): ");
            if (Console.ReadLine() != "1") break;
        }
    }

    static void AddNewSceneToWorld()
    {
        Console.Write("\nВведите уникальный ID сцены (напр. 'kitchen_2'): ");
        string id = Console.ReadLine();

        if (_world.ContainsKey(id))
        {
            Console.WriteLine("Внимание: Сцена с таким ID уже существует и будет перезаписана!");
        }

        Console.Write("Введите описание, которое увидит игрок: ");
        string desc = Console.ReadLine();

        Console.Write("Это финальная сцена (концовка)? (1 - да, 0 - нет): ");
        bool isEnding = Console.ReadLine() == "1";

        Dictionary<string, string> opts = new();
        if (!isEnding)
        {
            while (true)
            {
                Console.Write("Текст действия (напр. 'Открыть дверь') или '0' для завершения: ");
                string action = Console.ReadLine();
                if (action == "0") break;

                Console.Write($"Куда ведет действие '{action}'? Введите ID целевой сцены: ");
                string targetId = Console.ReadLine();
                opts[action] = targetId;
            }
        }

        _world[id] = new Scene { Description = desc, IsEnding = isEnding, Options = opts };
        SaveGame(); // Сохраняем после каждой созданной сцены
        Console.WriteLine($"\nСцена '{id}' успешно сохранена в файл!");
    }

    static void ShowAllIds()
    {
        Console.Clear();
        Console.WriteLine("--- СПИСОК ДОСТУПНЫХ ID ---");
        foreach (var id in _world.Keys) Console.WriteLine($"- {id}");
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    static void RunGameLoop()
    {
        string currentId = "entry";
        while (true)
        {
            if (!_world.ContainsKey(currentId))
            {
                Console.WriteLine($"\nОШИБКА: Сцена '{currentId}' не создана в редакторе!");
                Console.ReadKey();
                break;
            }

            var scene = _world[currentId];
            Console.Clear();
            Console.WriteLine($"--- {currentId.ToUpper()} ---\n");
            Console.WriteLine(scene.Description);

            if (scene.IsEnding)
            {
                Console.WriteLine("\n=== КОНЕЦ ИГРЫ ===");
                Console.ReadKey();
                break;
            }

            var optionsList = scene.Options.Keys.ToList();
            for (int i = 0; i < optionsList.Count; i++)
                Console.WriteLine($"{i + 1}. {optionsList[i]}");

            Console.Write("\nВаш выбор: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= optionsList.Count)
            {
                currentId = scene.Options[optionsList[choice - 1]];
            }
        }
    }

    static void SaveGame() => File.WriteAllText(FileName, JsonConvert.SerializeObject(_world, Formatting.Indented));

    static void LoadGame()
    {
        if (File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);
            _world = JsonConvert.DeserializeObject<Dictionary<string, Scene>>(json) ?? new();
        }
    }

    static void InitGame()
    {
        _world["entry"] = new Scene
        {
            Description = "Вы перед заброшенным бункером.",
            Options = new() { ["Войти"] = "corridor" }
        };
        _world["corridor"] = new Scene { Description = "Темный коридор.", IsEnding = true };
        SaveGame();
    }
}