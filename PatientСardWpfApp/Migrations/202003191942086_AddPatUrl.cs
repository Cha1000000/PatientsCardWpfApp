namespace PatientСardWpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatUrl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalCards", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalCards", "Birthday", c => c.String(maxLength: 10));
        }
    }
}
