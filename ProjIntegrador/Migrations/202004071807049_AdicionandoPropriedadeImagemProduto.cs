namespace ProjIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoPropriedadeImagemProduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "ImagemProdudo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produto", "ImagemProdudo");
        }
    }
}
