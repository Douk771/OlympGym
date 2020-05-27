namespace Olymp1
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection.Emit;

    public class GymContext : DbContext
    {
        // Контекст настроен для использования строки подключения "GymContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Olymp1.DataModel.GymContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "GymContext" 
        // в файле конфигурации приложения.
        public GymContext()
            : base("name=GymContext")
        {
            

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GroupClasse> GroupClasses{ get; set; }
        public DbSet<GroupClassesJournal> GroupClassesJournals { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }
    }
}