using System;
namespace ConsoleLabs
{
    public class Fornecedor

    {


        //public Fornecedor(String cnpj, String razao_social, String nome_fantasia, String endereco, String cod_fornecedor)
        //{
        //    this.cnpj = cnpj;
        //    this.razao_social = razao_social;
        //    this.nome_fantasia = nome_fantasia;
        //    this.endereco = endereco;
        //    this.cod_fornecedor = cod_fornecedor;
        //    modelos = new Modelo[100];
        //    espacoLivreModelos = 0;
        //}

        public String cnpj;
        public String razao_social;
        public String nome_fantasia;
        public String endereco;
        public String cod_fornecedor;
        public Modelo[] modelos = new Modelo[100];
        public int espacoLivreModelos;

    }
}