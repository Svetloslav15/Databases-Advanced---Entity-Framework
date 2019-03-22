namespace BillsPaymentSystem.App
{
    using BillsPaymentSystem.Data;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                DbInitializer.Seed(context);
            }
        }
    }
}
