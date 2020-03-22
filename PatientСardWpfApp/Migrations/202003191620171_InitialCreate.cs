namespace PatientСardWpfApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalCards",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 25),
                    Surname = c.String(nullable: false, maxLength: 25),
                    Patronymic = c.String(nullable: false, maxLength: 25),
                    Sex = c.String(nullable: false, maxLength: 4),
                    Birthday = c.String(maxLength: 10),
                    Adress = c.String(nullable: false, maxLength: 50),
                    Phone = c.String(nullable: false, maxLength: 12),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Visits",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    PatientId = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    Type = c.String(),
                    Diagnosis = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Visits");
            DropTable("dbo.PersonalCards");
        }
    }
}
