namespace ProjIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandoPropriedadeDetalheProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "DetalheProduto", c => c.String(maxLength: 100));
            DropColumn("dbo.Produto", "DetalhesProduto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "DetalhesProduto", c => c.String(maxLength: 100));
            DropColumn("dbo.Produto", "DetalheProduto");
        }
    }
}
