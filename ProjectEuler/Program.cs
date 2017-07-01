using System;

namespace ProjectEuler
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                var projectEulerRunner = new ProjectEulerAppRunner();
                projectEulerRunner.Run();
            }
            catch (Exception exception)
            {
                var errorMessage = "Exception: " + exception.Message;
                throw new Exception(errorMessage);
            }
        }
    }
}
