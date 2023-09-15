namespace MoveGraphic
{
    internal static class Program
    {
        /// <summary>
        /// âÊñ è„Ç≈Ç«ÇÍÇ≠ÇÁÇ¢ï\é¶ÇÇ∏ÇÁÇ∑ÇÃÇ©
        /// </summary>
        public static int X_offset { get; set; } = 0;

        /// <summary>
        /// âÊñ è„Ç≈Ç«ÇÍÇ≠ÇÁÇ¢ï\é¶ÇÇ∏ÇÁÇ∑ÇÃÇ©
        /// </summary>
        public static int Y_offset { get; set; } = 0;

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
    }
}