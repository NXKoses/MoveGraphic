using MoveGraphic.Objects;
using System.Diagnostics;

namespace MoveGraphic
{
    internal static class Program
    {
        /// <summary>
        /// ��ʏ�łǂꂭ�炢�\�������炷�̂�
        /// </summary>
        internal static int X_offset { get; set; } = 0;

        /// <summary>
        /// ��ʏ�łǂꂭ�炢�\�������炷�̂�
        /// </summary>
        internal static int Y_offset { get; set; } = 0;

        /// <summary>
        /// �g��{��
        /// </summary>
        internal static float DisplayScale { get; set; } = 1.0f;

        /// <summary>
        /// �`��I�u�W�F�N�g���X�g
        /// </summary>
        internal static List<ObjectBase> ObjectList = new();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static void SaveObject(List<ObjectBase> objectBase, string filepath)
        {
            for (int i = 0; i < objectBase.Count; i++)
            {
                //�^�ŕ�����
                switch (objectBase[i])
                {
                    case RectangleObject:
                        var rectangle = (RectangleObject)objectBase[i];
                        Debug.WriteLine($"Wid: {rectangle.Width}, Hei:{rectangle.Height}");
                        break;

                    case LineObject:
                        var line = (LineObject)objectBase[i];
                        break;
                    default:
                        break;
                }
                //�ۑ����邽�߂Ƀe�L�X�g�Ƃ�Json�Ƃ��ɏ������ޏ���������
            }
        }
    }
}

