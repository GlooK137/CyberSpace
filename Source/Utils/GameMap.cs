public class GameMap
{
    public GameObject[,] Objects { get; private set; }

    public GameMap()
    {
        Objects = new GameObject[15, 10];
        // Инициализация объектов...
    }

    // Методы для обновления состояния игрового мира...
}
