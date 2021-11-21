namespace QLSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adoluommim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "SVimages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "SVimages");
        }
    }
}
