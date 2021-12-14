namespace QLSV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_tbl_CacBang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UseName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false),
                        RoleID = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UseName);
            
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
            
            CreateTable(
                "dbo.HeDaotaos",
                c => new
                    {
                        MaHeDT = c.String(nullable: false, maxLength: 128),
                        TenHeDT = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaHeDT);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        MaKhoaHoc = c.String(nullable: false, maxLength: 128),
                        TenKhoaHoc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhoaHoc);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        MaKhoa = c.String(nullable: false, maxLength: 128),
                        TenKhoa = c.String(nullable: false),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaKhoa);
            
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        MaLop = c.String(nullable: false, maxLength: 128),
                        TenLop = c.String(nullable: false),
                        MaKhoa = c.String(maxLength: 128),
                        MaHeDT = c.String(maxLength: 128),
                        MaKhoaHoc = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaLop)
                .ForeignKey("dbo.HeDaotaos", t => t.MaHeDT)
                .ForeignKey("dbo.Khoas", t => t.MaKhoa)
                .ForeignKey("dbo.KhoaHocs", t => t.MaKhoaHoc)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaHeDT)
                .Index(t => t.MaKhoaHoc);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaSinhVien = c.String(nullable: false),
                        TenSinhVien = c.String(nullable: false),
                        GioiTinh = c.String(),
                        NgaySinh = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        SVimages = c.String(),
                        MaLop = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lops", t => t.MaLop)
                .Index(t => t.MaLop);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "MaLop", "dbo.Lops");
            DropForeignKey("dbo.Lops", "MaKhoaHoc", "dbo.KhoaHocs");
            DropForeignKey("dbo.Lops", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.Lops", "MaHeDT", "dbo.HeDaotaos");
            DropForeignKey("dbo.Diems", "MaMonHoc", "dbo.MonHocs");
            DropIndex("dbo.SinhViens", new[] { "MaLop" });
            DropIndex("dbo.Lops", new[] { "MaKhoaHoc" });
            DropIndex("dbo.Lops", new[] { "MaHeDT" });
            DropIndex("dbo.Lops", new[] { "MaKhoa" });
            DropIndex("dbo.Diems", new[] { "MaMonHoc" });
            DropTable("dbo.SinhViens");
            DropTable("dbo.Roles");
            DropTable("dbo.Lops");
            DropTable("dbo.Khoas");
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.HeDaotaos");
            DropTable("dbo.MonHocs");
            DropTable("dbo.Diems");
            DropTable("dbo.Accounts");
        }
    }
}
