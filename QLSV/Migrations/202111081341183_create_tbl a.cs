namespace QLSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tbla : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(nullable: false),
                        MaMonHoc = c.String(maxLength: 128),
                        HocKi = c.String(nullable: false),
                        DiemA = c.Double(nullable: false),
                        DiemB = c.Double(nullable: false),
                        DiemC = c.Double(nullable: false),
                        DiemTB = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MonHocs", t => t.MaMonHoc)
                .Index(t => t.MaMonHoc);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMonHoc = c.String(nullable: false, maxLength: 128),
                        TenMonHoc = c.String(nullable: false),
                        SoTin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaMonHoc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Diems", "MaMonHoc", "dbo.MonHocs");
            DropIndex("dbo.Diems", new[] { "MaMonHoc" });
            DropTable("dbo.MonHocs");
            DropTable("dbo.Diems");
        }
    }
}
