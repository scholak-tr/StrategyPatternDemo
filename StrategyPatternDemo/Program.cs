using System;

// Интерфейс стратегии — определяет общий метод атаки для всех видов оружия
public interface IWeapon
{
    void Attack(string playerName);
}

// Конкретная реализация стратегии — топор
public class Axe : IWeapon
{
    public void Attack(string playerName)
    {
        Console.WriteLine($"{playerName} наносит сокрушительный удар топором!");
    }
}

// Конкретная реализация стратегии — лук
public class Bow : IWeapon
{
    public void Attack(string playerName)
    {
        Console.WriteLine($"{playerName} выпускает стрелу из лука!");
    }
}

// Конкретная реализация стратегии — меч
public class Sword : IWeapon
{
    public void Attack(string playerName)
    {
        Console.WriteLine($"{playerName} наносит точный удар мечом!");
    }
}

// Контекст — игрок, использующий стратегию (оружие)
public class Player
{
    public string Name { get; }
    private IWeapon weapon; // Текущая стратегия (оружие)

    public Player(string name, IWeapon initialWeapon)
    {
        Name = name;
        weapon = initialWeapon;
    }

    // Игрок атакует, используя текущее оружие
    public void Attack()
    {
        weapon.Attack(Name);
    }

    // Позволяет динамически изменить стратегию — сменить оружие
    public void ChangeWeapon(IWeapon newWeapon)
    {
        weapon = newWeapon;
        Console.WriteLine($"{Name} сменил оружие.");
    }
}

class Program
{
    static void Main()
    {
        // Создание объектов-стратегий (оружия)
        IWeapon sword = new Sword();
        IWeapon axe = new Axe();
        IWeapon bow = new Bow();

        // Игроки получают стартовое оружие
        Player player1 = new Player("Артур", sword);
        Player player2 = new Player("Леголас", bow);

        // Атака текущим оружием
        player1.Attack();
        player2.Attack();

        // Игроки меняют оружие в бою
        player1.ChangeWeapon(axe);
        player1.Attack();

        player2.ChangeWeapon(sword);
        player2.Attack();
        Console.ReadKey();
    }
}
