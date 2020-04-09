namespace ProjIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandoPropriedadeProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "DetalhesProduto", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "DetalhesProduto");
        }
    }
}
