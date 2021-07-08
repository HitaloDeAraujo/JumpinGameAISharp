using System;

namespace JumpinGameAISharp
{
    public class Bar : World
    {
        Random random = new Random();

        public Bar(double pos)
        {
            this.top = random.Next((int)(height / 6), (int)((2 / 3) * height));
            this.x = width + pos;
            this.w = 80;
            this.speed = 8;
        }

        public bool Hits(Bot bot)
        {
            if (bot.y > height - this.top)
                if (bot.x > this.x && bot.x < this.x + this.w)
                    return true;

            return false;
        }

        public void show()
        {
            Stroke(240, 38, 95);
            Fill(240, 38, 95);
            RectMode(CORNER);
            Rect(this.x, height - this.top, this.w, this.top);
        }

        public void Update()
        {
            this.x -= this.speed;
        }

        public bool Offscreen()
        {
            return this.x < -this.w;
        }
    }
}