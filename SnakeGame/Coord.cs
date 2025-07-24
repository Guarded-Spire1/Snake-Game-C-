

namespace SnakeGame
{
    public class Coord
    {
        private int x;
        private int y;
        public int X { get => x; }
        public int Y { get => y; }
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void ChangeCoords(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;

            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Coord other) return false;
            return X == other.X && Y == other.Y;
        }
        public bool IsAt(int x, int y) => X == x && Y == y;
    }


}
