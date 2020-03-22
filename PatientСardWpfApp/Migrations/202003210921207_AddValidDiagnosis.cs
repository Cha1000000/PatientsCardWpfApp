namespace PatientСardWpfApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddValidDiagnosis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "Diagnosis", c => c.String(maxLength: 100));
        }

        public override void Down()
        {
            AlterColumn("dbo.Visits", "Diagnosis", c => c.String());
        }
    }
}
