using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLabs
{
   public  class BancoDeDados
    {
        public static void SalvaCliente(Cliente[] clientes, int totalClientes)
        {
            StreamWriter wrCliente = new StreamWriter("clientes.txt", false);
            for (int i = 0; i < totalClientes; i++)
            {
                String registroCliente = clientes[i].nome + ";" + clientes[i].telefone + ";" + clientes[i].endereco + ";" + clientes[i].data_nascimento + ";" + clientes[i].cpf + ";" + clientes[i].nome_pai + ";" + clientes[i].nome_mae;
                wrCliente.WriteLine(registroCliente);


            }
            wrCliente.Close();
        }
        public static void SalvaFornecedores(Fornecedor[] fornecedores, int totalFornecedores)
        {

            StreamWriter wr = new StreamWriter("fornecedores.txt",false);
            StreamWriter wrModelos = new StreamWriter("modelos.txt", false);
            StreamWriter wrVeiculos = new StreamWriter("veiculos.txt", false);
            
            for (int i = 0; i < totalFornecedores; i++)
            {
                String registroFornecedor = fornecedores[i].cnpj + ";" + fornecedores[i].razao_social +";" + fornecedores[i].nome_fantasia + ";" + fornecedores[i].endereco + ";" + fornecedores[i].cod_fornecedor;

                wr.WriteLine(registroFornecedor);


                SalvaModelos(fornecedores[i].modelos, fornecedores[i].espacoLivreModelos, wrModelos, wrVeiculos);
            }


            wr.Close();
            wrModelos.Close();
            wrVeiculos.Close();
        }
        public static void SalvaEncomendas(Encomenda[] encomendas, int totalEncomendas)
        {
            StreamWriter wrEncomenda = new StreamWriter("Encomendas.txt");

            for(int i =0; i < totalEncomendas; i++)
            {
                String registraEncomenda = encomendas[i].data_encomenda.ToString("dd/MM/yyyy") + ";" + encomendas[i].data_retirada.ToString("dd/MM/yyyy") + ";" + encomendas[i].cliente.cpf + ";" + encomendas[i].veiculo.cod_veiculo + ";" + encomendas[i].veiculo.modelo + ";" + encomendas[i].veiculo.codfornecedor + ";" + encomendas[i].cancelada.ToString() + ";" + encomendas[i].vendido.ToString();
                wrEncomenda.WriteLine(registraEncomenda);
            }
            wrEncomenda.Close();
        }
        static void SalvaModelos(Modelo[] modelos, int totalModelos, StreamWriter wrModelos,StreamWriter wrVeiculos )
        {
           


            for (int i = 0; i < totalModelos; i++)
            {
                String registroModelo = modelos[i].modelo + ";" + modelos[i].cod_modelo + ";"+ modelos[i].cod_fornecedor;

                wrModelos.WriteLine(registroModelo);

                SalvaVeiculos(modelos[i].veiculos,modelos[i].espacoLivreVeiculos, wrVeiculos);
              
            }


          
        }
        static void SalvaVeiculos(Veiculo[] veiculos, int totalVeiculos, StreamWriter wrVeiculos)
        {
            for (int i =0; i< totalVeiculos; i++)
            {
                String restraVeiculo = veiculos[i].modelo + ";" + veiculos[i].codfornecedor + ";" + veiculos[i].numerodeportas + ";" + veiculos[i].placa + ";" + veiculos[i].cor + ";" + veiculos[i].ano + ";" + veiculos[i].cod_veiculo + ";" + veiculos[i].nome_veic + ";" + veiculos[i].status_encomenda + ";" + veiculos[i].vendido;
                wrVeiculos.WriteLine(restraVeiculo);
                
            }
        }

        public static int CarregaFornecedores(Fornecedor[] fornecedores)
        {
            StreamReader srFornecedor = new StreamReader("fornecedores.txt");
            int totalFornecedores = 0;

            while (!srFornecedor.EndOfStream)
            {
                String registroFornecedor =  srFornecedor.ReadLine();

                String[] vetorFornecedor = registroFornecedor.Split(';');

                Fornecedor fornecedor = new Fornecedor();

                fornecedor.cnpj = vetorFornecedor[0];
                fornecedor.razao_social = vetorFornecedor[1];
                fornecedor.nome_fantasia = vetorFornecedor[2];
                fornecedor.endereco = vetorFornecedor[3];
                fornecedor.cod_fornecedor = vetorFornecedor[4];

                fornecedor.espacoLivreModelos = CarregaModelos(fornecedor.cod_fornecedor, fornecedor.modelos);

                fornecedores[totalFornecedores] = fornecedor;
                totalFornecedores++;

            }

            srFornecedor.Close();

            return totalFornecedores;
        }


        static int CarregaModelos(String codFornecedor, Modelo[] modelos)
        {
            StreamReader srModelo = new StreamReader("modelos.txt");
            int totalModelos = 0;

            while (!srModelo.EndOfStream)
            {
                String registroModelo = srModelo.ReadLine();

                String[] vetorModelo = registroModelo.Split(';');

                if(vetorModelo[2] == codFornecedor)
                {
                    Modelo modelo = new Modelo();

                    modelo.modelo = vetorModelo[0];
                    modelo.cod_modelo = vetorModelo[1];
                    modelo.cod_fornecedor = codFornecedor;

                  modelo.espacoLivreVeiculos =   CarregaVeiculos(codFornecedor, modelo.cod_modelo, modelo.veiculos);

                    modelos[totalModelos] = modelo;
                    totalModelos++;

                }


            }

            srModelo.Close();

            return totalModelos;
        }


        static int CarregaVeiculos(String codFornecedor, String codModelo, Veiculo[] veiculos)
        {
            StreamReader srVeiculo = new StreamReader("veiculos.txt");
            int totalVeiculos = 0;

            while (!srVeiculo.EndOfStream)
            {
                String registroVeiculo = srVeiculo.ReadLine();

                String[] vetorVeiculo = registroVeiculo.Split(';');

                if (vetorVeiculo[1] == codFornecedor && vetorVeiculo[0] == codModelo)
                {
                    Veiculo veiculo = new Veiculo();

                    veiculo.modelo = vetorVeiculo[0];
                    veiculo.codfornecedor = vetorVeiculo[1];
                    veiculo.numerodeportas = vetorVeiculo[2];
                    veiculo.placa = vetorVeiculo[3];
                    veiculo.cor = vetorVeiculo[4];
                    veiculo.ano = vetorVeiculo[5];
                    veiculo.cod_veiculo = vetorVeiculo[6];
                    veiculo.nome_veic = vetorVeiculo[7];
                    veiculo.status_encomenda = bool.Parse(vetorVeiculo[8]);
                    veiculo.vendido = bool.Parse(vetorVeiculo[9]);

                    veiculos[totalVeiculos] = veiculo;
                    totalVeiculos++;

                }


            }

            srVeiculo.Close();

            return totalVeiculos;
        }
        public static int CarregaCliente(Cliente[] clientes)
        {
            StreamReader srCliente = new StreamReader("clientes.txt");
            int totalClientes = 0;
            while (!srCliente.EndOfStream)
            {
                String cadastroCliente = srCliente.ReadLine();
                String[] vetorCliente = cadastroCliente.Split(';');

                Cliente ccliente = new Cliente();
                ccliente.nome = vetorCliente[0];
                ccliente.telefone = vetorCliente[1];
                ccliente.endereco = vetorCliente[2];
                ccliente.data_nascimento = vetorCliente[3];
                ccliente.cpf = vetorCliente[4];
                ccliente.nome_pai = vetorCliente[5];
                ccliente.nome_mae = vetorCliente[6];

                clientes[totalClientes] = ccliente;
                totalClientes++;
            }
            srCliente.Close();
            return totalClientes;
          
        }
        public static int CarregaEncomenda(Encomenda[] encomendas, Cliente[] clientes,int totalClientes, Fornecedor[] fornecedores, int totalFornecedores)
        {
            StreamReader srEncomenda = new StreamReader("Encomendas.txt");
            int totalEncomendas = 0;
            while (!srEncomenda.EndOfStream)
            {
                String cadastroEncomenda = srEncomenda.ReadLine();
                String[] vetorEncomenda = cadastroEncomenda.Split(';');

                Encomenda cadencomenda = new Encomenda();
                cadencomenda.data_encomenda = DateTime.ParseExact(vetorEncomenda[0], "dd/MM/yyyy",CultureInfo.InvariantCulture);
                cadencomenda.data_retirada = DateTime.ParseExact(vetorEncomenda[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                
                for (int i = 0; i < totalClientes; i++)
                {
                    if (clientes[i].cpf == vetorEncomenda[2])
                    {
                        cadencomenda.cliente = clientes[i];
                    }

                }
                for(int i = 0; i < totalFornecedores; i++)
                {
                    if (fornecedores[i].cod_fornecedor == vetorEncomenda[5])
                    {
                        for(int j = 0; j < fornecedores[i].espacoLivreModelos; j++)
                        {
                            if (fornecedores[i].modelos[j].cod_modelo == vetorEncomenda[4])
                            {
                                for (int k = 0; k < fornecedores[i].modelos[j].espacoLivreVeiculos; k++)
                                {
                                    if (fornecedores[i].modelos[j].veiculos[k].cod_veiculo == vetorEncomenda[3])
                                    {
                                        cadencomenda.veiculo = fornecedores[i].modelos[j].veiculos[k];
                                    }
                                }
                            }
                        }
                    }
                
                }
                cadencomenda.cancelada = bool.Parse(vetorEncomenda[6]);
                cadencomenda.vendido = bool.Parse(vetorEncomenda[7]);

                encomendas[totalEncomendas] = cadencomenda;
                totalEncomendas++;
            }
            srEncomenda.Close();
            return totalEncomendas;
        }
    }
}
