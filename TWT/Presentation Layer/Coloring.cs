using System;
using System.Drawing;

namespace TWT
{
    public static class Coloring
    {
        public static Color SetColors(float value)
        {
            int red = 255, green = 255, blue = 255;

            if (float.IsNaN(value))
                return Color.Gray;
            if(value > 0)
            {   //0 to 0.5
                if(value < 0.5)
                {
                    red = 255;
                    green = 255;
                    blue = Convert.ToInt32(255 - 255 * value * 2);
                }
                //0.5 to 1.5
                else if (value >= 0.5)
                {
                    red = 255;
                    blue = 0;
                    green = Convert.ToInt32(255 - 255 * (value - 0.5f));
                }
            }
            else if(value < 0)
            {
                //0 to -0.5
                if (value > -0.5)
                {
                    blue = 255;
                    green = 255;
                    red = Convert.ToInt32(255 - 255 * Math.Abs(value * 2));
                }
                //-0.5 to -1.5
                else if (value <= -0.5)
                {
                    blue = 255;
                    red = 0;
                    green = Convert.ToInt32(255 - 255 * Math.Abs((value + 0.5f)));
                }
            }
            return Color.FromArgb(IsOutofByte(red), IsOutofByte(green), IsOutofByte(blue));
        }

        private static int IsOutofByte(int value)
        {
            if (value < 0)
                return 0;
            if (value > 255)
                return 255;
            return value;
        }
    }
}
