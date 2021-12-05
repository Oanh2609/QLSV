namespace QLSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtbl_am : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Khoas", "DienThoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Khoas", "DienThoai", c => c.Int(nullable: false));
        }
    }
}
