namespace PatientСardWpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalCards", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalCards", "Phone", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
