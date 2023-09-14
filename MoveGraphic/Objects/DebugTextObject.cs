using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveGraphic.Objects
{
    static class DebugTextObject
    { 
        public static void Draw(ObjectBase obj, PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, $"Line, X: {obj.X}, Y: {obj.Y}\n X2: {obj.X}, Y2: {obj.Y}", new Font("Yu Gothic UI", 8), new Point(obj.X + 20, obj.Y - 20), Color.Black);
        }

    }
}
