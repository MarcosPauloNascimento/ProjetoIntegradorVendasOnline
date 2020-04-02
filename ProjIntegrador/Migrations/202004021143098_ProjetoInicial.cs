namespace ProjIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjetoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        CPF = c.Long(nullable: false),
                        Telefone = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 100),
                        Bairro = c.String(maxLength: 100),
                        CEP = c.String(maxLength: 100),
                        Estado = c.String(maxLength: 100),
                        Cidade = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        TotalVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FormaPagamento = c.Int(nullable: false),
                        ValorDesconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataVenda = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        VendedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.VendedorId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Interessado",
                c => new
                    {
                        InteressadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100),
                        Telefone = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAgendamento = c.DateTime(nullable: false),
                        DataVisita = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InteressadoId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Vendedor",
                c => new
                    {
                        VendedorId = c.Int(nullable: false, identity: true),
                        Comissao = c.Int(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VendedorId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        CPF = c.Long(nullable: false),
                        Nome = c.String(maxLength: 100),
                        DataContratacao = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId)
                .Index(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Instalacao",
                c => new
                    {
                        InstalacaoId = c.Int(nullable: false, identity: true),
                        DataInstalacao = c.DateTime(nullable: false),
                        Observacao = c.String(maxLength: 100),
                        EnderecoId = c.Int(nullable: false),
                        InstaladorId = c.Int(nullable: false),
                        VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstalacaoId)
                .ForeignKey("dbo.Endereco", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Instalador", t => t.InstaladorId, cascadeDelete: true)
                .ForeignKey("dbo.Venda", t => t.VendaId)
                .Index(t => t.EnderecoId)
                .Index(t => t.InstaladorId)
                .Index(t => t.VendaId);
            
            CreateTable(
                "dbo.Instalador",
                c => new
                    {
                        InstaladorId = c.Int(nullable: false, identity: true),
                        FuncionarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InstaladorId)
                .ForeignKey("dbo.Funcionario", t => t.FuncionarioId, cascadeDelete: true)
                .Index(t => t.FuncionarioId);
            
            CreateTable(
                "dbo.ItensVenda",
                c => new
                    {
                        VendaId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.VendaId, t.ProdutoId })
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .Index(t => t.VendaId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.VendaFuncionario",
                c => new
                    {
                        VendaId = c.Int(nullable: false),
                        VendedorId = c.Int(nullable: false),
                        ValorComissao = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.VendaId, t.VendedorId })
                .ForeignKey("dbo.Venda", t => t.VendaId, cascadeDelete: true)
                .ForeignKey("dbo.Vendedor", t => t.VendedorId)
                .Index(t => t.VendaId)
                .Index(t => t.VendedorId);
            
            CreateTable(
                "dbo.InteressadoProduto",
                c => new
                    {
                        Interessado_InteressadoId = c.Int(nullable: false),
                        Produto_ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Interessado_InteressadoId, t.Produto_ProdutoId })
                .ForeignKey("dbo.Interessado", t => t.Interessado_InteressadoId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_ProdutoId, cascadeDelete: true)
                .Index(t => t.Interessado_InteressadoId)
                .Index(t => t.Produto_ProdutoId);
            
            CreateTable(
                "dbo.ProdutoVenda",
                c => new
                    {
                        Produto_ProdutoId = c.Int(nullable: false),
                        Venda_VendaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produto_ProdutoId, t.Venda_VendaId })
                .ForeignKey("dbo.Produto", t => t.Produto_ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Venda", t => t.Venda_VendaId, cascadeDelete: true)
                .Index(t => t.Produto_ProdutoId)
                .Index(t => t.Venda_VendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VendaFuncionario", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.VendaFuncionario", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.ItensVenda", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.ItensVenda", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Instalacao", "VendaId", "dbo.Venda");
            DropForeignKey("dbo.Instalacao", "InstaladorId", "dbo.Instalador");
            DropForeignKey("dbo.Instalador", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Instalacao", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Venda", "VendedorId", "dbo.Vendedor");
            DropForeignKey("dbo.Vendedor", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.ProdutoVenda", "Venda_VendaId", "dbo.Venda");
            DropForeignKey("dbo.ProdutoVenda", "Produto_ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.InteressadoProduto", "Produto_ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.InteressadoProduto", "Interessado_InteressadoId", "dbo.Interessado");
            DropForeignKey("dbo.Interessado", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Venda", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "EnderecoId", "dbo.Endereco");
            DropIndex("dbo.ProdutoVenda", new[] { "Venda_VendaId" });
            DropIndex("dbo.ProdutoVenda", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.InteressadoProduto", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.InteressadoProduto", new[] { "Interessado_InteressadoId" });
            DropIndex("dbo.VendaFuncionario", new[] { "VendedorId" });
            DropIndex("dbo.VendaFuncionario", new[] { "VendaId" });
            DropIndex("dbo.ItensVenda", new[] { "ProdutoId" });
            DropIndex("dbo.ItensVenda", new[] { "VendaId" });
            DropIndex("dbo.Instalador", new[] { "FuncionarioId" });
            DropIndex("dbo.Instalacao", new[] { "VendaId" });
            DropIndex("dbo.Instalacao", new[] { "InstaladorId" });
            DropIndex("dbo.Instalacao", new[] { "EnderecoId" });
            DropIndex("dbo.Funcionario", new[] { "EnderecoId" });
            DropIndex("dbo.Vendedor", new[] { "FuncionarioId" });
            DropIndex("dbo.Interessado", new[] { "EnderecoId" });
            DropIndex("dbo.Venda", new[] { "VendedorId" });
            DropIndex("dbo.Venda", new[] { "ClienteId" });
            DropIndex("dbo.Cliente", new[] { "EnderecoId" });
            DropTable("dbo.ProdutoVenda");
            DropTable("dbo.InteressadoProduto");
            DropTable("dbo.VendaFuncionario");
            DropTable("dbo.ItensVenda");
            DropTable("dbo.Instalador");
            DropTable("dbo.Instalacao");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Vendedor");
            DropTable("dbo.Interessado");
            DropTable("dbo.Produto");
            DropTable("dbo.Venda");
            DropTable("dbo.Endereco");
            DropTable("dbo.Cliente");
        }
    }
}
