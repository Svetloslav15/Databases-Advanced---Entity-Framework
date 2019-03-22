namespace P01_StudentSystem 
{
    using P01_StudentSystem.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new StudentSystemContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
