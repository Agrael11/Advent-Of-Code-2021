using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day20
{
    /// <summary>
    /// Represents one picture
    /// </summary>
    internal class Picture
    {
        public int Width
        {
            get
            {
                return Data.GetLength(0);
            }
        }
        public int Height
        {
            get
            {
                return Data.GetLength(1);
            }
        }
        public bool Border { get; set; } = false;
        private bool[,] Data { get; set; } = new bool[0, 0];

        public Picture(bool[,] data)
        {
            Data = data;
        }

        /// <summary>
        /// Combine 3x3 area of bool pixels into integer. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetCombinedPixelAt(int x, int y)
        {
            int combined = 0;
            for (int newY = y - 1; newY <= y + 1; newY++)
            {
                for (int newX = x - 1; newX <= x + 1; newX++)
                {
                    combined <<= 1;
                    combined += GetPixelAt(newX, newY)?1:0;
                }
            }
            return combined;
        }

        /// <summary>
        /// Get pixel at coordinates. if outside of coordinates, return the "border" value.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool GetPixelAt(int x, int y)
        {
            if (x < 0  || x >= Width || y < 0 || y >= Height)
                return Border;
            return Data[x, y];
        }

        /// <summary>
        /// "Enhances" the image -n- times based on specified "algorythm"
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="algorythm"></param>
        /// <param name="times"></param>
        /// <returns></returns>
        public static Picture Enhance(Picture picture, bool[] algorythm,int times)
        {
            for (int i = 0; i < times; i++)
            {
                picture = Enhance(picture, algorythm);
            }
            return picture;
        }

        /// <summary>
        /// "Enhances" the image based on specified "algorythm"
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="algorythm"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static Picture Enhance(Picture picture, bool[] algorythm)
        {
            if (picture is null || algorythm is null)
                throw new NullReferenceException();

            //For every pixel in new image visible area (one bigger to every side than original one)
            //Get combine pixel data of 3x3 area and take correspodning pixel from algorythm.
            bool[,] data = new bool[picture.Width + 2, picture.Height + 2];
            for (int y = 0; y < data.GetLength(1); y++)
            {
                for (int x = 0; x < data.GetLength(0); x++)
                {
                    int newPixel = picture.GetCombinedPixelAt(x - 1, y - 1);
                    data[x, y] = algorythm[newPixel];
                }
            }

            //Depending on first & last bit in algorythm switch the invisible area
            bool border = picture.Border;
            picture = new(data);
            picture.Border = border;
            if (!picture.Border)
            {
                if (algorythm[0])
                {
                    picture.Border = true;
                }
            }
            else
            {
                if (!algorythm[^1])
                {
                    picture.Border = false;
                }
            }
            return picture;
        }
    }
}
