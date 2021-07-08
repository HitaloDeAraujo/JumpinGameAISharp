namespace JumpinGameAISharp
{
    public class World
    {
        public static double height;
        public static double width;

        public double top { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double w { get; set; }
        public double speed { get; set; }
        public double score { get; set; }
        public double gravity { get; set; }
        public double vy { get; set; }
        public double ay { get; set; }
        public double vx { get; set; }
        public double ax { get; set; }
        public double r { get; set; }
        public double fitness { get; set; }

        public const int CORNER = 5;

        public World()
        {
        }

        /// <summary>
        /// Stroke
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        public void Stroke(double r, double g, double b)
        {
        }

        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <param name="alpha"></param>
        public void Fill(double r, double g, double b)
        {
        }

        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="r">Red</param>
        /// <param name="g">Green</param>
        /// <param name="b">Blue</param>
        /// <param name="alpha"></param>
        public void Fill(double r, double g, double b, double alpha)
        {
        }

        /// <summary>
        /// Ellipse
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public void Ellipse(double x, double y, double width, double height)
        {
        }

        /// <summary>
        /// RectMode
        /// </summary>
        /// <param name="corner">Corner</param>
        public void RectMode(double corner)
        {
        }

        /// <summary>
        /// Rect
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public void Rect(double x, double y, double width, double height)
        {
        }
    }
}