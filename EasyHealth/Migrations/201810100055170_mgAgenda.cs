namespace EasyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgAgenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dias", "MedicoFk", c => c.String(maxLength: 128));
            CreateIndex("dbo.Dias", "MedicoFk");
            AddForeignKey("dbo.Dias", "MedicoFk", "dbo.Medicos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dias", "MedicoFk", "dbo.Medicos");
            DropIndex("dbo.Dias", new[] { "MedicoFk" });
            DropColumn("dbo.Dias", "MedicoFk");
        }
    }
}
