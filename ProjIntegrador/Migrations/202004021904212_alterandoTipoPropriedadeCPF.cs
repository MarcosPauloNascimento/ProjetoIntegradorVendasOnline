namespace ProjIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterandoTipoPropriedadeCPF : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Funcionario", "CPF", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionario", "CPF", c => c.Long(nullable: false));
        }
    }
}
