using System;
using System.Collections.Generic;

public class Tool {
    public string Name { get; set; }
    public bool IsInteractable { get; set; }
    public int HP { get; set; }
    // Добавляем новые свойства для атаки и защиты
    public int Attack { get; set; }
    public int Defense { get; set; }
    public List<Action> Actions { get; set; }

    // Обновляем конструктор для включения параметров атаки и защиты
    public Tool(string name, bool isInteractable, int hp, int attack, int defense) {
        Name = name;
        IsInteractable = isInteractable;
        HP = hp;
        Attack = attack;
        Defense = defense;
        Actions = new List<Action>();
    }

    public void AddAction(string name, ActionType type, int power) {
        Actions.Add(new Action(name, type, power));
    }

    public void PerformAction(int actionIndex) {
        if (actionIndex < 0 || actionIndex >= Actions.Count) {
            Console.WriteLine("Invalid action index.");
            return;
        }

        var action = Actions[actionIndex];
        Console.WriteLine($"{Name} performs {action.Name}.");
        // Здесь реализуйте логику выполнения действия в зависимости от его типа
    }

    // Здесь можно добавить другие методы, связанные с `Tool`
    // Например, метод для получения урона
    public void TakeDamage(int damage) {
        HP -= damage;
        Console.WriteLine($"{Name} takes {damage} damage. Remaining HP: {HP}");
    }
}

public class Action {
    public string Name { get; set; }
    public ActionType Type { get; set; }
    public int Power { get; set; }

    public Action(string name, ActionType type, int power) {
        Name = name;
        Type = type;
        Power = power;
    }
}

public enum ActionType {
    Attack,
    DefenseBoost
}
