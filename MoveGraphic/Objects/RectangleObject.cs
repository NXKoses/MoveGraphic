using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGraphic.Objects
{
    internal class RectangleObject : ObjectBase
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public RectangleObject(int x, int y, int width, int height)
        {
            X = x; Y = y;
            Width = width; Height = height;
            Brush = new SolidBrush(Color.Gray);
        }


        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="e"></param>
        public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brush, GetDrawX(), GetDrawY(), Width, Height);
        }
    }
}
