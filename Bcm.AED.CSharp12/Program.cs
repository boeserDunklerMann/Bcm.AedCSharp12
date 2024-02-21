namespace Bcm.AED.CSharp12
{
    /// <summary>
    /// primäre Konstruktoren
    /// </summary>
	public struct Distance(double dx, double dy)
    {
        public readonly double Magnitude => Math.Sqrt(dx * dx + dy * dy);
        public readonly double Direction => Math.Atan2(dy, dx);

        public void Translate(double deltaX, double deltaY)
        {
            dx += (double)deltaX; dy += (double)deltaY;
        }

        public Distance() : this(0.0, 0.0)
        {

        }
        static void Main(string[] args)
        {
            Distance distance = new Distance(1, 1);
        }
    }
}