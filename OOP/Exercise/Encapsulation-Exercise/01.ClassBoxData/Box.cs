
namespace _01.ClassBoxData
{
    using System;
    public class Box
    {
        private double length;
        private double width;
        private double height;
        private const string exceptionMessage = "{0} cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(exceptionMessage, nameof(Length)));
                }
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(exceptionMessage, nameof(Width)));

                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0) throw new ArgumentException(string.Format(exceptionMessage, nameof(Height)));

                this.height = value;
            }
        }

        public double SurfaceArea() => 2 * (length * width + length * height + width * height);

        public double LateralSurfaceArea() => 2 * (length * height + width * height);

        public double Volume() => length * width * height;
    }
}
