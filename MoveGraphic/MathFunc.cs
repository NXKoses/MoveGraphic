using MoveGraphic.Objects;

namespace MoveGraphic
{
    internal static class MathFunc
    {
        /// <summary>
        /// 指定されたオブジェクトのX,YからX2,Y2までの距離を計算します。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>２点間の距離</returns>
        public static double TwoPointDistance(ObjectBase obj, int round)
        {
            return Math.Round(Math.Sqrt(Math.Pow(obj.X2 - obj.X, 2) + Math.Pow(obj.Y2 - obj.Y, 2)), round);
        }

        public static double TwoPointDistance(int x1 , int y1 , int x2 , int y2 ,int round)
        {
            return Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)), round);
        }
    }
}
