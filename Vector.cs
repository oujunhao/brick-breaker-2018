namespace BrickBreaker
{
    public class Vector
    {
        public double x;
        public double y;

        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public void Multiply(Vector newVector)
        {
            x *= newVector.x;
            y *= newVector.y;
        }

        public void Divide(Vector newVector)
        {
            x /= newVector.x;
            y /= newVector.y;
        }

        public void Subtract(Vector newVector)
        {
            x -= newVector.x;
            y -= newVector.y;
        }

        public void Add(Vector newVector)
        {
            x += newVector.x;
            y += newVector.y;
        }
    }
}