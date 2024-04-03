using System;
namespace ConsoleLabs
{
    public class Encomenda
    {
        public Encomenda()
        {
        }
        public DateTime data_encomenda;
        public DateTime data_retirada;
        public Cliente cliente;
        public Veiculo veiculo;
        public bool cancelada = false;
        public bool vendido = false;

    }
}