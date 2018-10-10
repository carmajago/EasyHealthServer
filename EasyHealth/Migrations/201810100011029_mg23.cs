namespace EasyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliadoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Cedula = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Contrasena = c.String(nullable: false),
                        Celular = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaYHora = c.DateTime(nullable: false),
                        ServicioPorMedicoFk = c.Int(nullable: false),
                        AfiliadoFk = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Afiliadoes", t => t.AfiliadoFk)
                .ForeignKey("dbo.ServicioPorMedicoes", t => t.ServicioPorMedicoFk, cascadeDelete: true)
                .Index(t => t.ServicioPorMedicoFk)
                .Index(t => t.AfiliadoFk);
            
            CreateTable(
                "dbo.ServicioPorMedicoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedicoFk = c.String(maxLength: 128),
                        ServicioFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.MedicoFk)
                .ForeignKey("dbo.Servicios", t => t.ServicioFk, cascadeDelete: true)
                .Index(t => t.MedicoFk)
                .Index(t => t.ServicioFk);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Cedula = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Contrasena = c.String(nullable: false),
                        Celular = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        CategoriaFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaFk, cascadeDelete: true)
                .Index(t => t.CategoriaFk);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Horas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoraInicio = c.String(nullable: false),
                        HoraFin = c.String(nullable: false),
                        DiaFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dias", t => t.DiaFk, cascadeDelete: true)
                .Index(t => t.DiaFk);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Horas", "DiaFk", "dbo.Dias");
            DropForeignKey("dbo.Citas", "ServicioPorMedicoFk", "dbo.ServicioPorMedicoes");
            DropForeignKey("dbo.ServicioPorMedicoes", "ServicioFk", "dbo.Servicios");
            DropForeignKey("dbo.Servicios", "CategoriaFk", "dbo.Categorias");
            DropForeignKey("dbo.ServicioPorMedicoes", "MedicoFk", "dbo.Medicos");
            DropForeignKey("dbo.Citas", "AfiliadoFk", "dbo.Afiliadoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Horas", new[] { "DiaFk" });
            DropIndex("dbo.Servicios", new[] { "CategoriaFk" });
            DropIndex("dbo.ServicioPorMedicoes", new[] { "ServicioFk" });
            DropIndex("dbo.ServicioPorMedicoes", new[] { "MedicoFk" });
            DropIndex("dbo.Citas", new[] { "AfiliadoFk" });
            DropIndex("dbo.Citas", new[] { "ServicioPorMedicoFk" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Horas");
            DropTable("dbo.Dias");
            DropTable("dbo.Categorias");
            DropTable("dbo.Servicios");
            DropTable("dbo.Medicos");
            DropTable("dbo.ServicioPorMedicoes");
            DropTable("dbo.Citas");
            DropTable("dbo.Afiliadoes");
        }
    }
}
