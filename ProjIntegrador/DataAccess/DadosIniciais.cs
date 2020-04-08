using ProjIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjIntegrador.DataAccess
{
    public class DadosIniciais : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            List<Endereco> listaEndereco = new List<Endereco>()
            {
                new Endereco()
                {

                    Descricao = "Rua Antonio Bissi Filho",
                    Numero = 370,
                    Complemento = "A",
                    Bairro = "Parque Ortolândia",
                    CEP = "13184-040",
                    Estado = "SP",
                    Cidade = "Hortolândia",
                },
                new Endereco()
                {

                    Descricao = "Rua Pastor Hugo Gegembauer",
                    Numero = 37,
                    Bairro = "Parque Ortolândia",
                    CEP = "13184-010",
                    Estado = "SP",
                    Cidade = "Hortolândia",
                }
            };

            listaEndereco.ForEach(e => context.Endereco.Add(e));
            context.SaveChanges();

            List<Produto> listaProdutos = new List<Produto>()
            {
                new Produto()
                {
                    Descricao = "Filtro A",
                    Valor = 150.99m,
                    Quantidade = 4,
                    Status = StatusEnum.Ativo,
                },
                new Produto()
                {
                    Descricao = "Filtro B",
                    Valor = 110.50m,
                    Quantidade = 14,
                    Status = StatusEnum.Ativo,
                },
                new Produto()
                {
                    Descricao = "Filtro C",
                    Valor = 169.00m,
                    Quantidade = 0,
                    Status = StatusEnum.Inativo,
                },
            };

            listaProdutos.ForEach(p => context.Produto.Add(p));
            context.SaveChanges();

            List<Funcionario> listaFuncionarios = new List<Funcionario>()
            {
                new Funcionario()
                {
                    CPF = "080.222.046-40",
                    Nome = "José da Silva Sauro",
                    Endereco = listaEndereco.SingleOrDefault(e => e.CEP == "13184-010"),
                    DataContratacao = new DateTime(2000, 01, 01),
                    Status = StatusEnum.Ativo
                },
                new Funcionario()
                {
                    CPF = "084.832.096-40",
                    Nome = "Marcos Paulo do Nascimento",
                    Endereco = listaEndereco.SingleOrDefault(e => e.CEP == "13184-040"),
                    DataContratacao = new DateTime(2010, 01, 01),
                    Status = StatusEnum.Ativo
                }
            };

            listaFuncionarios.ForEach(f => context.Funcionario.Add(f));
            context.SaveChanges();

            List<Instalador> listaInstalador = new List<Instalador>()
            {
                new Instalador()
                {
                    Funcionario = listaFuncionarios.SingleOrDefault(f => f.CPF == "080.222.046-40"),
                }
            };

            listaInstalador.ForEach(i => context.Instalador.Add(i));
            context.SaveChanges();

            List<Vendedor> listaVendedor = new List<Vendedor>()
            {
                new Vendedor()    
                {
                    Funcionario = listaFuncionarios.SingleOrDefault(f => f.CPF == "084.832.096-40"),
                }
            };

            listaVendedor.ForEach(v => context.Vendedor.Add(v));
            context.SaveChanges();
        }
    }
}