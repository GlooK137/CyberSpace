// Constants.cs
namespace monogame_1
{
    public static class Constants
    {
        // Размеры для игрового "квадрата" игрока
        public const int SquareWidth = 16;
        public const int SquareHeight = 22;

        public const int Cell = 16;

        // Разрешение и масштаб по умолчанию для "экрана GameBoy"
        public const int GbaWidth = 240;
        public const int GbaHeight = 160;
        public const int Scale = 4;

        // Скорость движения игрока
        public const float MoveSpeed = 2f;

        // Расстояния для движения игрока
        public const int MoveDistance = Cell;
    }
}
