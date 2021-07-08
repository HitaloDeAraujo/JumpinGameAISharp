namespace JumpinGameAISharp
{
    public class Bot : World
    {
        NeuralNetwork _brain;

        public Bot(NeuralNetwork brain)
        {
            _brain = brain;

            this.r = 32;
            this.y = height - this.r / 2;
            this.x = 64;

            this.gravity = 0.9;
            this.vy = 0;
            this.vx = 0;

            this.ax = 0;
            this.ay = 0;

            this.score = 0;
            this.fitness = 0;

            if (brain.isValid())
            {
                brain = brain.copy();
            }
            else
            {
                brain = new NeuralNetwork(6, 8, 2);
            }
        }

        public void Dispose()
        {
            _brain.dispose();
        }

        public void Show()
        {
            Stroke(81, 219, 146);
            Fill(81, 219, 146, 100);
            Ellipse(this.x, this.y, this.r, this.r);
        }

        public void Mutate()
        {
            _brain.mutate(0.1);
        }

        public void Think(Bar[] bars)
        {
            Bar closestBar = null;
            double closestD = double.MaxValue;
            for (int i = 0; i < bars.Length; i++)
            {
                double d = bars[i].x + bars[i].w - this.x;
                if (d < closestD && d > 0)
                {
                    closestBar = bars[i];
                    closestD = d;
                }
            }

            double posBar = 0;
            double heiBar = 0;
          if (closestBar != null)
            {
                    if (closestBar.x <= width)
                {
                    posBar = closestBar.x;
                    heiBar = closestBar.top;
                }
            }

            if (this.y == height - this.r / 2)
            {
                double[] inputs = new double[6];
                inputs[0] = this.vx / 10;
                inputs[1] = this.vy / 10;
                inputs[2] = this.x / width;
                inputs[3] = this.y / height;
                inputs[4] = posBar / width;
                inputs[5] = heiBar / height;

                var output = _brain.predict(inputs);

                this.ax = output[0];
                this.ay = output[1];
            }
            else
            {
                this.ax = 0;
                this.ay = 0;
            }
        }

        public bool OffScreen()
        {
            if (this.y < 0) return true;
            if (this.x > width || this.x < 0) return true;

            return false;
        }

        public bool HitGround()
        {
            if (this.y + this.r / 2 >= height) return true;
            return false;
        }

        public void Update()
        {
            this.score++;

            this.vy = this.vy + this.gravity - this.ay;
            this.y += this.vy;

            this.vx += this.ax;
            this.x += this.vx;
        }
    }
}