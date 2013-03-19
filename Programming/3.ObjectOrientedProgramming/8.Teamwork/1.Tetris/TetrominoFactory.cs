using System;

partial class Tetromino
{
    // Factory design pattern
    private static class Factory
    {
        private static readonly Random random = new Random();

        public static Tetromino Get(Coordinates coordinate)
        {
            int i = random.Next(Tetromino.images.Length);

            char[,] image = Tetromino.images[i];
            Color color = Tetromino.colors[i];

            coordinate -= new Coordinates(image.GetLength(0), image.GetLength(1) / 2); // Top center

            return new Tetromino(image, color, coordinate, (TetrominoType)i);
        }
    }

    public static Tetromino Get(Coordinates coordinate)
    {
        return Tetromino.Factory.Get(coordinate);
    }
}
