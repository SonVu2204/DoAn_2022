using CapstoneModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace CreateDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteDatabase();
            CreateDatabase();

        }
        public static void CreateDatabase()
        {
            using (var dbcontext = new Context())
            {
                String databasename = dbcontext.Database.GetDbConnection().Database;// mydata

                Console.WriteLine("Tao : " + databasename);

                bool result = dbcontext.Database.EnsureCreated();
                string resultstring = result ? "Tao thanh cong" : "Da co truoc do ";
                Console.WriteLine($"CSDL {databasename} : {resultstring}");
            }
        }
        public static void DeleteDatabase()
        {
            using (var dbcontext = new Context())
            {
                String databasename = dbcontext.Database.GetDbConnection().Database;// mydata

                Console.WriteLine("Tao " + databasename);

                bool result = dbcontext.Database.EnsureDeleted();
                string resultstring = result ? "Xoa thanh cong" : "Khong xoa duoc";
                Console.WriteLine($"CSDL {databasename} : {resultstring}");
            }
        }

    }
}
