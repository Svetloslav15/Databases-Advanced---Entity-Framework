namespace CodeFirstExercise
{
    using HospitalDatabase.Data;
    using HospitalDatabase.Data.Models;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            HospitalDbContext dbContext = new HospitalDbContext();
            Visitation visitation = new Visitation();
            dbContext.Visitations.Add(visitation);
            dbContext.SaveChanges();
        }
    }
}
