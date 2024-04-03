using System;
namespace ConsoleLabs
{
    public class Modelo
    {
        public Modelo()
        {

        }
        public String modelo;
        public String cod_modelo;
        public String cod_fornecedor;

        public Veiculo[] veiculos = new Veiculo[100];
        public int espacoLivreVeiculos;
    }
}