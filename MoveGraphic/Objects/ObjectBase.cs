using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGraphic.Objects
{
    internal class ObjectBase
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        /// <summary>
        /// 描画するときのブラシ
        /// </summary>
        public Pen pen { get; set; } = new(Color.Black, 2);

        /// <summary>
        /// 描画するときのブラシ
        /// </summary>
        public SolidBrush Brush { get; set; }

        /// <summary>
        /// 色を変更します。
        /// </summary>
        /// <param name="newcolor"></param>
        public void ChangeColor(Color newcolor)
        {
            pen.Color = newcolor;
        }
    }
}
