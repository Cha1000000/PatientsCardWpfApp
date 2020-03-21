namespace PatientСardWpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelDateEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "Type", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "Type", c => c.String());
        }
    }
}
