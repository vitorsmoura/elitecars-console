using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleLabs
{

    class Program
    //tipo[] nome_vetor = new tipo[tamanho];
    {
        static ConsoleColor originalColor = Console.BackgroundColor;
        static ConsoleColor originalColorText = Console.ForegroundColor;

        const string COD_FORNECEDOR_HONDA = "01";
        const string COD_FORNECEDOR_CHEVROLET = "02";
        const string codModeloCivic = "H01";
        const string codModeloFit = "H02";
        const string codModeloCorsa = "C01";
        //static void carregaCliente()
        //{
        //    Cliente c1 = new Cliente();
        //    c1.nome = "thiago";
        //    c1.cpf = "001";


        //    clientes[espacoLivreCliente] = c1;

        //    espacoLivreCliente++;

        //    Cliente c2 = new Cliente();
        //    c2.nome = "rafael";
        //    c2.cpf = "002";


        //    clientes[espacoLivreCliente] = c2;

        //    espacoLivreCliente++;
        //}


        static void salvarBancoDeDados()
        {
            BancoDeDados.SalvaFornecedores(fornecedores, espacoLivreFornecedor);
            BancoDeDados.SalvaCliente(clientes, espacoLivreCliente);
            BancoDeDados.SalvaEncomendas(encomendas, espacoLivreEncomenda);
           
        }


        static void carregarcadCliEfornecedores()
        {
            espacoLivreFornecedor = BancoDeDados.CarregaFornecedores(fornecedores);
            espacoLivreCliente = BancoDeDados.CarregaCliente(clientes);
            espacoLivreEncomenda = BancoDeDados.CarregaEncomenda(encomendas, clientes, espacoLivreCliente, fornecedores, espacoLivreFornecedor);

        }




        static Encomenda[] encomendas = new Encomenda[100];
        static int espacoLivreEncomenda = 0;
        static Cliente[] clientes = new Cliente[50];
        static int espacoLivreCliente = 0;
        //static Veiculo[] veiculos = new Veiculo[50];
        static Fornecedor[] fornecedores = new Fornecedor[50];
        static int espacoLivreFornecedor = 0;
        //static int espacoLivreVeiculo = 0;

        // metodo principal
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false; // deixa o cursor do mouse não visivel durante o loading
            Console.SetCursorPosition(1, 1);

            for (int i = 0; i <= 100; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    Console.Write("");
                }
                Console.WriteLine("        ");
                 Console.WriteLine("      ________________________________________________________________________________________    ");
                Console.WriteLine("     |                                                                                        |    ");
                Console.WriteLine("     |    ********  ******* ***    ***     **    **  **  ***    **  *******   **********      |    ");
                Console.WriteLine("     |    **    **  **      ** *  * **     **    **  **  ** *   **  **    **  **    * **      |    ");
                Console.WriteLine("     |    **  ***   ****    **  **  **     **    **  **  **  *  **  **    **  **  *   **      |    ");
                Console.WriteLine("     |    **    **  **      **      **     **    **  **  **   * **  **    **  ** *    **      |    ");
                Console.WriteLine("     |    ********  ******* **      **       ****    **  **    ***  *******   **********      |    ");
                Console.WriteLine("     |________________________________________________________________________________________|    ");
                Console.WriteLine("     |                                                                                        |    ");
                Console.WriteLine("     |                               ELITE SOFTWARES APRESENTA:                               |    ");
                Console.WriteLine("     |                                    ELITE CARS  1.0                                     |    ");
                Console.WriteLine("     |________________________________________________________________________________________|    ");
                Console.WriteLine("     |                                                                                        |    ");
                Console.WriteLine("     |                                  CARREGANDO O SISTEMA...                               |    ");
                Console.WriteLine("     |________________________________________________________________________________________|    ");
                Console.WriteLine("  ");
                Console.WriteLine("                                                " + i + " %                                            ");
                Console.SetCursorPosition(1, 1);
                System.Threading.Thread.Sleep(5);
            }

            carregarcadCliEfornecedores();
            

            

            int opcaoSelecionadaMenuPrincipal = 0;
            int totalOpcoes = 4;

            bool sair = false;
            Console.CursorVisible = false;
            while (sair != true)
            {
                desenhaMenuPrincipal(opcaoSelecionadaMenuPrincipal);

                ConsoleKeyInfo teclaDigitada = Console.ReadKey();

                switch (teclaDigitada.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaMenuPrincipal++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaMenuPrincipal--;
                        break;
                    case ConsoleKey.Enter:
                        {
                            //abre o menu de marcas disponiveis
                            if (opcaoSelecionadaMenuPrincipal == 0)
                            {
                                exibeMenuFabricantesDisponiveis();
                                salvarBancoDeDados();
                            }
                            //abre o menu de cadastro
                            if (opcaoSelecionadaMenuPrincipal == 1)
                            {
                                Console.Clear();
                                cadastro();
                                salvarBancoDeDados();
                                Console.ReadKey();
                            }
                            //abre o menu do gerente
                            if (opcaoSelecionadaMenuPrincipal == 2)
                            {
                                bool voltar = false;
                                int opcaoSelecionadaGerente = 0;
                                acessoMenuGerente(opcaoSelecionadaGerente);
                                while (voltar != true)
                                {
                                    Console.Clear();
                                    int totalopcoesGerente = 4;
                                    gerente(opcaoSelecionadaGerente);

                                    ConsoleKeyInfo teclaDigitadaGerente = Console.ReadKey();

                                    switch (teclaDigitadaGerente.Key)
                                    {
                                        case ConsoleKey.DownArrow:
                                            opcaoSelecionadaGerente++;
                                            break;
                                        case ConsoleKey.UpArrow:
                                            opcaoSelecionadaGerente--;

                                            break;
                                        case ConsoleKey.Enter:
                                            {
                                                switch (opcaoSelecionadaGerente)
                                                {
                                                    case 0://abre o menu para criar um novo fornecedor
                                                        {
                                                            Console.Clear();
                                                            criaFornecedor();
                                                            salvarBancoDeDados();
                                                            break;
                                                        }
                                                    case 1://cadastrar modelo
                                                        {
                                                            int opcaoSelecionadaMarcas=0;
                                                            exibeCadastroModelo(opcaoSelecionadaMarcas);
                                                            salvarBancoDeDados();

                                                            break;
                                                        }
                                                    case 2://menu cria veiculo
                                                        {
                                                            int opcaoSelecionadaMarcas = 0;
                                                            int opcaoSelecionadaModelo = 0;
                                                            exibeCadastroVeiculo(opcaoSelecionadaMarcas, opcaoSelecionadaModelo);
                                                            salvarBancoDeDados();
                                                            break;

                                                        }
                                                    case 3://exibe encomendas
                                                        int opcaoSelecionadaEncomenda = 0;
                                                        exibeMenuEncomendas(opcaoSelecionadaEncomenda);
                                                        salvarBancoDeDados();
                                                        break;

                                                    case 4://sair
                                                        System.Threading.Thread.Sleep(1500);
                                                        voltar = true;
                                                        salvarBancoDeDados();
                                                        break;
                                                }
                                                break;

                                            }

                                    }
                                    if (opcaoSelecionadaGerente < 0 || opcaoSelecionadaGerente > totalopcoesGerente)
                                    {
                                        opcaoSelecionadaGerente = 0;
                                    }
                                }


                            }

                            //sair do programa
                            if (opcaoSelecionadaMenuPrincipal == 3)
                            {

                                Console.Clear();
                                Console.CursorVisible = false;
                                Console.WriteLine("        ");
                             Console.WriteLine("      ________________________________________________________________________________________    ");
                             Console.WriteLine("     |                                                                                        |    ");
                             Console.WriteLine("     |                          ELITE SOFTWARES AGRADECE SUA PREFERÊNCIA!                     |    ");
                             Console.WriteLine("     |________________________________________________________________________________________|    ");
                             Console.WriteLine("     |                                                                                        |    ");
                             Console.WriteLine("     |                                  ENCERRANDO O SISTEMA...                               |    ");
                             Console.WriteLine("     |________________________________________________________________________________________|    ");
                             Console.WriteLine("  ");
                                salvarBancoDeDados();
                                System.Threading.Thread.Sleep(3000);
                                sair = true;

                            }


                        }



                        break;
                }
                if (opcaoSelecionadaMenuPrincipal < 0 || opcaoSelecionadaMenuPrincipal >= totalOpcoes)
                {
                    opcaoSelecionadaMenuPrincipal = 0;
                }
            }
        }

        private static void exibeMenuFabricantesDisponiveis()
        {

            bool sairMenuCarro = false;
            int opcaoSelecionadaFabricante = 0;

            int totalOpcoes = espacoLivreFornecedor;

            while (sairMenuCarro != true)
            {
                desenhaMenuFabricantes(opcaoSelecionadaFabricante);
                ConsoleKeyInfo teclaDigitadaMenuMarcas = Console.ReadKey();
                switch (teclaDigitadaMenuMarcas.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaFabricante++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaFabricante--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaFabricante >= espacoLivreFornecedor)
                            sairMenuCarro = true;
                        else
                        {
                            exibeMenuModelos(opcaoSelecionadaFabricante);
                        }
                        break;


                }



                if (opcaoSelecionadaFabricante < 0 || opcaoSelecionadaFabricante > totalOpcoes)
                {
                    opcaoSelecionadaFabricante = 0;
                }
            }

        }


        private static void exibeMenuModelos(int opcaoSelecionadaFornecedor)


        {
            bool sairMenuModelos = false;
            int opcaoSelecionadaModelo = 0;


            int totalOpcoesModelos = fornecedores[opcaoSelecionadaFornecedor].espacoLivreModelos + 1;
            int ultimaOpcaoPossivel = totalOpcoesModelos - 1;

            while (sairMenuModelos != true)
            {

                Console.Clear();
                desenhaMenuModelo(fornecedores[opcaoSelecionadaFornecedor], opcaoSelecionadaModelo, totalOpcoesModelos);
                ConsoleKeyInfo teclaDigitadaMenuModelo = Console.ReadKey();
                switch (teclaDigitadaMenuModelo.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaModelo++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaModelo--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();

                        if (opcaoSelecionadaModelo == ultimaOpcaoPossivel)
                        {
                            sairMenuModelos = true;
                        }
                        else
                        {

                            //Console.WriteLine(fornecedores[opcaoSelecionadaFornecedor].modelos[opcaoSelecionadaModelo].veiculos

                            Fornecedor fornecedorSelecionado = fornecedores[opcaoSelecionadaFornecedor];
                            Modelo modeloSelecionado = fornecedorSelecionado.modelos[opcaoSelecionadaModelo];

                            exibeMenuVeiculos(modeloSelecionado);



                        }


                        break;
                }

                if (opcaoSelecionadaModelo < 0 || opcaoSelecionadaModelo > ultimaOpcaoPossivel)
                {
                    opcaoSelecionadaModelo = 0;
                }

            }
        }


        static void desenhaMenuPrincipal(int opcaoSelecionada)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.WriteLine("        ");
             Console.WriteLine("        ");
            Console.WriteLine("            ______________________________________________________________________________________________    ");
            Console.WriteLine("           |                                                                                              |     ");
            Console.WriteLine("           |      *******  **       **  ********** *******      *****   ******   ********   ********      |     ");
            Console.WriteLine("           |      **       **       **      **     **         **       **    **  **    **   **            |     ");
            Console.WriteLine("           |      ****     **       **      **     ****       **       ********  ********   ********      |     ");
            Console.WriteLine("           |      **       **       **      **     **         **       **    **  **    **         **      |     ");
            Console.WriteLine("           |      *******  *******  **      **     *******      *****  **    **  **     **  ********      |     ");
            Console.WriteLine("           |______________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                              |     ");
            Console.WriteLine("           |                   2018 - ELITE SOFTWARES SOCIEDADE EMPRESÁRIA COPYRIGHT                      |     ");
            Console.WriteLine("           |______________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                              |     ");
            Console.WriteLine("           |                           ** M E N U   P R I N C I P A L **                                  |     ");
            Console.WriteLine("           |______________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                              |     ");

            String[] opcaoMenuPrincipal = new String[4];//vetor opcoes

            opcaoMenuPrincipal[0] = "                   -->   MENU DE CONSULTA PARA COMPRA DE VEICULO <--                          ";
            opcaoMenuPrincipal[1] = "                   -->  CADASTRO DO CLIENTE PARA REALIZAR COMPRA <--                          ";
            opcaoMenuPrincipal[2] = "                   -->             ÁREA DO GERENTE               <--                          ";
            opcaoMenuPrincipal[3] = "                   -->            ENCERRAR O SISTEMA             <--                          ";

            String comecoLinha = "           |";
            for (int i = 0; i < 4; i++)
            {
                if (opcaoSelecionada == i)
                {
                    Console.Write(comecoLinha);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(opcaoMenuPrincipal[i]);
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("|");
                }
                else
                {
                    Console.Write(comecoLinha);
                    Console.Write(opcaoMenuPrincipal[i]);
                    Console.WriteLine("|");
                }
            }

            Console.WriteLine("           |______________________________________________________________________________________________|     ");
            Console.WriteLine("                                                                                                                ");
            Console.WriteLine("                               ____________________________________________________     ");
            Console.WriteLine("                              |                                                    |");
            Console.WriteLine("                              |                     * ATENÇÃO *                    |");
            Console.WriteLine("                              |  É necessário cadastrar o cliente para encomendar  |");
            Console.WriteLine("                              |        algum veículo disponível no sistema.        | ");
            Console.WriteLine("                              |____________________________________________________|     ");

        }//Menu principal
        static void desenhaMenuFabricantes(int opcaoSelecionadaMarcas)//menu que exibira as marcas disponiveis para compra 
        {

            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("        ");
            Console.WriteLine("        ");
            Console.WriteLine("            ___________________________________________________________________________________________________________________      ");
            Console.WriteLine("           |                                                                                                                   |     ");
            Console.WriteLine("           |      *******   ******    ********  ********   **     *****   ******   ***    **  ********  *******  ********      |     ");
            Console.WriteLine("           |      **       **    **   **    **  **    **   **   **       **    **  ** *   **     **     **       **            |     ");
            Console.WriteLine("           |      ****     ********   *******   ********   **   **       ********  **  *  **     **     ****     ********      |     ");
            Console.WriteLine("           |      **       **    **   **    **  **    **   **   **       **    **  **   * **     **     **             **      |     ");
            Console.WriteLine("           |      **       **    **   ********  **     **  **     *****  **    **  **    ***     **     *******  ********      |     ");
            Console.WriteLine("           |___________________________________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                                                   |    ");
            Console.WriteLine("           |                                      *****                      *****                                             |    ");
            Console.WriteLine("           |                                      *****                      *****   *****                                     |    ");
            Console.WriteLine("           |                                  ***   *      ****************    *     *****                                     |    ");
            Console.WriteLine("           |                                  ***   *     ******************   *       ***                                     |    ");
            Console.WriteLine("           |                                  *********   *************************     **                                     |    ");
            Console.WriteLine("           |                                 *****************         ********************                                    |    ");
            Console.WriteLine("           |                                 *****************         ********************                                    |    ");
            Console.WriteLine("           |                                  *********   *************************     **                                     |    ");
            Console.WriteLine("           |                                  ***   *     ******************   *       ***                                     |    ");
            Console.WriteLine("           |                                  ***   *      ****************    *     *****                                     |    ");
            Console.WriteLine("           |                                      *****                      *****   *****                                     |    ");
            Console.WriteLine("           |                                      *****                      *****                                             |    ");
            Console.WriteLine("           |___________________________________________________________________________________________________________________|    ");
            Console.WriteLine("           |                                                                                                                   |     ");
            Console.WriteLine("           |                                        LISTA DE FABRICANTES DISPONÍVEIS:                                          |     ");
            Console.WriteLine("           |___________________________________________________________________________________________________________________|     ");



            int totalOpcoesCarros = espacoLivreFornecedor - 1;


            for (int i = 0; i <= totalOpcoesCarros; i++)
            {
                if (opcaoSelecionadaMarcas == i)
                {

                    Console.Write("           | -->  ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(fornecedores[i].nome_fantasia);
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("           |___________________________________________________________________________________________________________________|    ");
                }
                else
                {
                    Console.Write("           | -->  ");
                    Console.WriteLine(fornecedores[i].nome_fantasia);
                    Console.WriteLine("           |___________________________________________________________________________________________________________________|    ");
                }


            }
            if (opcaoSelecionadaMarcas > totalOpcoesCarros)
            {

                Console.Write("           | -->  ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Voltar");
                Console.BackgroundColor = originalColor;
                Console.WriteLine("           |___________________________________________________________________________________________________________________|    ");
            }
            else
            {
                Console.Write("           | -->  ");
                Console.WriteLine("Voltar");
                Console.WriteLine("           |___________________________________________________________________________________________________________________|    ");
            }





        }
        static void cadastro()//cadastro
        {
            Console.CursorVisible = false;
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |                C A D A S T R O  -  C L I E N T E                |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine(" ");
            Console.Write("      | --> Nome completo: ");
            string respcadnome = (Console.ReadLine());
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Endereço: ");
            string respEndereco = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Telefone: ");
            string telefonecli = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Data de nascimento: ");
            string dataNascimento = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Digite seu cpf: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Nome do pai: ");
            string nome_pai = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Nome da mãe: ");
            string nome_mae = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");

            Cliente cliente1 = new Cliente();
            cliente1.nome_mae = nome_mae;
            cliente1.nome_pai = nome_pai;
            cliente1.cpf = cpf;
            cliente1.data_nascimento = dataNascimento;
            cliente1.telefone = telefonecli;
            cliente1.nome = respcadnome;
            cliente1.endereco = respEndereco;

            clientes[espacoLivreCliente] = (cliente1);

            espacoLivreCliente++;


            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |                CADASTRO REALIZADO COM SUCESSO!!!                |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            System.Threading.Thread.Sleep(1000);
        }
        static void gerente(int opcaoSelecionadaGerente)//area destinada ao gerente
        {
            Console.Clear();
            Console.CursorVisible = false;


            Console.WriteLine("              _________________________________________________________________     ");
            Console.WriteLine("             |                                                                 |    ");
            Console.WriteLine("             |                 ÁREA RESTRITA AO GERENTE E SÓCIOS               |    ");
            Console.WriteLine("             |_________________________________________________________________|    ");
            Console.WriteLine("             |                                                                 |    ");

            String[] opcaoMenuGerente = new String[5];
            opcaoMenuGerente[0] = ("                  CADASTRO DE FORNECEDOR                   ");
            opcaoMenuGerente[1] = ("                  CADASTRO DE MODELO                       ");
            opcaoMenuGerente[2] = ("                  CADASTRO DE VEICULO                      ");
            opcaoMenuGerente[3] = ("                  MENU DE ENCOMENDAS                       ");
            opcaoMenuGerente[4] = ("                       SAIR                                ");
            for (int i = 0; i < 5; i++)
            {
                if (opcaoSelecionadaGerente == i)
                {
                    Console.Write("             | -->  ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(opcaoMenuGerente[i]);
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("|     ");
                }
                else
                {
                    Console.Write("             | -->  ");
                    Console.Write(opcaoMenuGerente[i]);
                    Console.WriteLine("|     ");
                }
            }

            Console.WriteLine("             |_________________________________________________________________|    ");
            Console.WriteLine("                                                                         ");






        }
        static void desenhaMenuModelo(Fornecedor fornecedor, int opcaoSelecionadaModelo, int totalOpcoes)//menu que exibira os carros de uma marca especifica que estão disponiveis
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("            ______________________________________________________________________________________________________     ");
            Console.WriteLine("           |                                                                                                      |     ");
            Console.WriteLine("           |                 ***    ***  ********  *******    *******  **       ********  ********                |     ");
            Console.WriteLine("           |                 ** *  * **  **  * **  **     **  **       **       **  * **  **                      |     ");
            Console.WriteLine("           |                 **  **  **  ** *  **  **     **  ****     **       ** *  **  ********                |      ");
            Console.WriteLine("           |                 **      **  **    **  **     **  **       **       **    **        **                |     ");
            Console.WriteLine("           |                 **      **  ********  *******    *******  *******  ********  ********                |     ");
            Console.WriteLine("           |______________________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                                      |    ");
            Console.WriteLine("           |                                  *****                      *****                                    |    ");
            Console.WriteLine("           |                                  *****                      *****   *****                            |    ");
            Console.WriteLine("           |                              ***   *      ****************    *     *****                            |    ");
            Console.WriteLine("           |                              ***   *     ******************   *       ***                            |    ");
            Console.WriteLine("           |                              *********   *************************     **                            |    ");
            Console.WriteLine("           |                            *****************         ********************                            |    ");
            Console.WriteLine("           |                            *****************         ********************                            |    ");
            Console.WriteLine("           |                              *********   *************************     **                            |    ");
            Console.WriteLine("           |                              ***   *     ******************   *       ***                            |    ");
            Console.WriteLine("           |                              ***   *      ****************    *     *****                            |    ");
            Console.WriteLine("           |                                  *****                      *****   *****                            |    ");
            Console.WriteLine("           |                                  *****                      *****                                    |    ");
            Console.WriteLine("           |______________________________________________________________________________________________________|    ");
            Console.WriteLine("           |                                                                                                      |    "); 
            Console.WriteLine("           |                                             " + fornecedor.nome_fantasia +" - MODELOS                                        ");
            Console.WriteLine("           |______________________________________________________________________________________________________|    ");


            totalOpcoes = fornecedor.espacoLivreModelos - 1;


            for (int i = 0; i <= totalOpcoes; i++)
            {
                if (opcaoSelecionadaModelo == i)
                {

                    Console.Write("           | -->  ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(fornecedor.modelos[i].modelo);
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("           |______________________________________________________________________________________________________|    ");
                }
                else
                {
                    Console.Write("           | -->  ");
                    Console.WriteLine(fornecedor.modelos[i].modelo);
                    Console.WriteLine("           |______________________________________________________________________________________________________|    ");
                }


            }
            if (opcaoSelecionadaModelo > totalOpcoes)
            {

                Console.Write("           | -->  ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Voltar");
                Console.BackgroundColor = originalColor;
                Console.WriteLine("           |______________________________________________________________________________________________________|    ");
            }
            else
            {
                Console.Write("           | -->  ");
                Console.WriteLine("Voltar");
                Console.WriteLine("           |______________________________________________________________________________________________________|    ");
            }




        }
        
        static void criaFornecedor()
        {
            Console.CursorVisible = false;
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |          C A D A S T R O  -  F O R N E C E D O R                |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine(" ");
            Console.Write("      | --> Nome Fantasia: ");
            string nomeFantasiaFornecedor = (Console.ReadLine());
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Razão Social: ");
            string razaoSocialFornecedor = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> CNPJ: ");
            string cnpjFornecedor = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Endereço do Fornecedor: ");
            string enderecoFornecedor = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | --> Codigo do Fornecedor: ");
            string codigoFornecedor = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");

            Fornecedor fornecedor1 = new Fornecedor();
            fornecedor1.nome_fantasia = nomeFantasiaFornecedor;
            fornecedor1.razao_social = razaoSocialFornecedor;
            fornecedor1.cnpj = cnpjFornecedor;
            fornecedor1.endereco = enderecoFornecedor;
            fornecedor1.cod_fornecedor = codigoFornecedor;

            fornecedores[espacoLivreFornecedor] = fornecedor1;
            espacoLivreFornecedor++;

        }
        static void acessoMenuGerente(int opcaoSelecionadaGerente)
        {
            int cond = 1;

            while (cond == 1)
            {
                string senha = "";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = false;
                Console.WriteLine("   __________________________________________________ ");
                Console.WriteLine("  |                                                  |");
                Console.WriteLine("  |   DIGITE A SENHA DE ACESSO - ÁREA RESTRITA       |");
                Console.WriteLine("  |__________________________________________________|");
                Console.WriteLine(" ");
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                while (tecla.Key != ConsoleKey.Enter)
                {
                    senha = senha + tecla.KeyChar;
                    Console.Write("*");
                    tecla = Console.ReadKey(true);
                }
                if (senha == "elite")
                {
                    gerente(opcaoSelecionadaGerente);
                    cond = 0;
                }

                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.CursorVisible = false;
                    Console.WriteLine("   __________________________________________________ ");
                    Console.WriteLine("  |                                                  |");
                    Console.WriteLine("  |                  SENHA INVÁLIDA!!                |");
                    Console.WriteLine("  |__________________________________________________|");
                    System.Threading.Thread.Sleep(1500);

                }


            }



        }
        static void cadastraModelo(string CodFornecedor)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |                C A D A S T R O  -  M O D E L O                  |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine(" ");
            Console.Write("      | * Nome do Modelo:");      
            string nomeVeic = (Console.ReadLine());
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      |");
            Console.Write("      | * Codigo Modelo:      ");
            string CodModelo = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      |");


            Modelo modelo = new Modelo();
            modelo.modelo = nomeVeic;
            modelo.cod_fornecedor = CodFornecedor;
            modelo.cod_modelo = CodModelo;
            for (int i = 0; i < espacoLivreFornecedor; i++)
            {
                if (fornecedores[i].cod_fornecedor == CodFornecedor)
                {
                    fornecedores[i].modelos[fornecedores[i].espacoLivreModelos] = modelo;
                    fornecedores[i].espacoLivreModelos++;
                }
            }





        }
        static void exibeCadastroModelo(int opcaoSelecionadaMarcas)
        {
            bool sairMenuCadastroModelos = false;
            while (sairMenuCadastroModelos != true)
            {

                Console.Clear();

                desenhaMenuFabricantes(opcaoSelecionadaMarcas);
                Console.WriteLine("");
                Console.WriteLine("               ^ SELECIONE ACIMA O FORNECEDOR DO MODELO DO QUAL VOCÊ DESEJA CADASTRAR  ^");

                ConsoleKeyInfo teclaDigitadaMenuCadastroModelo = Console.ReadKey();
                switch (teclaDigitadaMenuCadastroModelo.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaMarcas++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaMarcas--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaMarcas >= espacoLivreFornecedor)
                        {
                            sairMenuCadastroModelos = true;
                        }
                        else
                        {
                            
                            cadastraModelo(fornecedores[opcaoSelecionadaMarcas].cod_fornecedor);
                            
                        }
                        break;
                }
                   if (opcaoSelecionadaMarcas > espacoLivreFornecedor || opcaoSelecionadaMarcas < 0)
                   {
                    opcaoSelecionadaMarcas = 0;
                   }
            }
        }
        static void cadastraVeiculo(string codModelo, string CodFornecedor)
        {
            Console.Clear();
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |             C A D A S T R O  -  V E I C U L O                   |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine(" ");
            Console.Write("      | * Nome Veiculo: ");
            string nomeVeic = (Console.ReadLine());
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | * Numero de portas: ");
            string n_portasVeic = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | * Placa: ");
            string placaVeic = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | * Cor: ");
            string corVeic = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | * Ano: ");
            string anoVeic = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine(" ");
            Console.Write("      | * Codigo veiculo: ");
            string codVeic = Console.ReadLine();
            Console.WriteLine("  __________________________________________________________________");
            Console.WriteLine("    ");

            Veiculo infoVeic = new Veiculo();
            infoVeic.modelo = codModelo;
            infoVeic.nome_veic = nomeVeic;
            infoVeic.codfornecedor = CodFornecedor;
            infoVeic.numerodeportas = n_portasVeic;
            infoVeic.placa = placaVeic;
            infoVeic.cor = corVeic;
            infoVeic.ano = anoVeic;
            infoVeic.cod_veiculo = codVeic;
            for (int i = 0; i < espacoLivreFornecedor; i++)
            {
                if (fornecedores[i].cod_fornecedor == CodFornecedor)
                {

                    for (int j = 0; j < fornecedores[i].espacoLivreModelos; j++)
                    {
                        if (fornecedores[i].modelos[j].cod_modelo == codModelo)
                        {
                            fornecedores[i].modelos[j].veiculos[fornecedores[i].modelos[j].espacoLivreVeiculos] = infoVeic;
                            fornecedores[i].modelos[j].espacoLivreVeiculos++;
                        }
                    }
                }
            }


        }
        static void exibeCadastroVeiculo(int opcaoSelecionadaMarcas, int opcaoSelecionadaModelo)
        {
            bool sairMenuCadastroVeiculos = false;
            while (sairMenuCadastroVeiculos != true)
            {

                Console.Clear();

                desenhaMenuFabricantes(opcaoSelecionadaMarcas);
                Console.WriteLine("");
                Console.WriteLine("               ^ SELECIONE ACIMA O FORNECEDOR DO MODELO DO QUAL VOCÊ DESEJA CADASTRAR  ^");

                ConsoleKeyInfo teclaDigitadaMenuCadastroVeiculo = Console.ReadKey();
                switch (teclaDigitadaMenuCadastroVeiculo.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaMarcas++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaMarcas--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaMarcas >= espacoLivreFornecedor)
                        {
                            sairMenuCadastroVeiculos = true;
                        }
                        else
                        {
                            bool sairMenuModelos = false;
                            while (sairMenuModelos != true)
                            {
                                Console.Clear();
                                desenhaMenuModelo(fornecedores[opcaoSelecionadaMarcas], opcaoSelecionadaModelo, espacoLivreFornecedor);
                                Console.WriteLine("");
                                Console.WriteLine("               ^ SELECIONE ACIMA O MODELO DO VEÍCULO DO QUAL VOCÊ DESEJA CADASTRAR  ^");
                                ConsoleKeyInfo teclaDigitadaMenuModelo = Console.ReadKey();
                                switch (teclaDigitadaMenuModelo.Key)
                                {
                                    case ConsoleKey.DownArrow:
                                        opcaoSelecionadaModelo++;
                                        break;
                                    case ConsoleKey.UpArrow:
                                        opcaoSelecionadaModelo--;
                                        break;
                                    case ConsoleKey.Enter:
                                        Console.Clear();

                                        if (opcaoSelecionadaModelo >= fornecedores[opcaoSelecionadaMarcas].espacoLivreModelos)
                                        {
                                            sairMenuModelos = true;
                                        }
                                        else
                                        {
                                            cadastraVeiculo(fornecedores[opcaoSelecionadaMarcas].modelos[opcaoSelecionadaModelo].cod_modelo, fornecedores[opcaoSelecionadaMarcas].cod_fornecedor);

                                        }
                                    break;
                                }
                                if (opcaoSelecionadaModelo > fornecedores[opcaoSelecionadaMarcas].espacoLivreModelos || opcaoSelecionadaModelo < 0)
                                {
                                    opcaoSelecionadaModelo = 0;
                                }


                            }
                            

                        }
                        break;
                }
                if (opcaoSelecionadaMarcas > espacoLivreFornecedor || opcaoSelecionadaMarcas < 0)
                {
                    opcaoSelecionadaMarcas = 0;
                }
            }
        }

        static void desenhaMenuVeiculos(Modelo modelo, int totalOpcoesVeiculos, int opcaoSelecionadaVeiculo)
        { 
            Console.Clear();
            Console.WriteLine("            ______________________________________________________________________________________________________     ");
            Console.WriteLine("           |                                                                                                      |     ");
            Console.WriteLine("           |                 ***    ***  ********  *******    *******  **       ********  ********                |     ");
            Console.WriteLine("           |                 ** *  * **  **  * **  **     **  **       **       **  * **  **                      |     ");
            Console.WriteLine("           |                 **  **  **  ** *  **  **     **  ****     **       ** *  **  ********                |      ");
            Console.WriteLine("           |                 **      **  **    **  **     **  **       **       **    **        **                |     ");
            Console.WriteLine("           |                 **      **  ********  *******    *******  *******  ********  ********                |     ");
            Console.WriteLine("           |______________________________________________________________________________________________________|     ");
            Console.WriteLine("           |                                                                                                      |    ");
            Console.WriteLine("           |                                  *****                      *****                                    |    ");
            Console.WriteLine("           |                                  *****                      *****   *****                            |    ");
            Console.WriteLine("           |                              ***   *      ****************    *     *****                            |    ");
            Console.WriteLine("           |                              ***   *     ******************   *       ***                            |    ");
            Console.WriteLine("           |                              *********   *************************     **                            |    ");
            Console.WriteLine("           |                            *****************         ********************                            |    ");
            Console.WriteLine("           |                            *****************         ********************                            |    ");
            Console.WriteLine("           |                              *********   *************************     **                            |    ");
            Console.WriteLine("           |                              ***   *     ******************   *       ***                            |    ");
            Console.WriteLine("           |                              ***   *      ****************    *     *****                            |    ");
            Console.WriteLine("           |                                  *****                      *****   *****                            |    ");
            Console.WriteLine("           |                                  *****                      *****                                    |    ");
            Console.WriteLine("           |______________________________________________________________________________________________________|    ");
            Console.WriteLine("           |                                                                                                      |    ");
            Console.WriteLine("           |                                  " + modelo.modelo + " - VEÍCULOS DISPONÍVEIS                                            ");
            Console.WriteLine("           |______________________________________________________________________________________________________|    ");




            totalOpcoesVeiculos = modelo.espacoLivreVeiculos - 1;


            for (int i = 0; i <= totalOpcoesVeiculos; i++)
            {
                if (opcaoSelecionadaVeiculo == i)
                {
                    Console.Write("           |  *  ");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(modelo.veiculos[i].nome_veic + (modelo.veiculos[i].status_encomenda? (modelo.veiculos[i].vendido? ""  : "  (Não disponível)") : "  (Disponivel)") + (modelo.veiculos[i].vendido? "  (Vendido)" : "")) ;
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("           |______________________________________________________________________________________________________|    ");
                }
                else
                {
                    Console.Write("           |  *  ");
                    Console.WriteLine(modelo.veiculos[i].nome_veic + (modelo.veiculos[i].status_encomenda? (modelo.veiculos[i].vendido? "" : "  (Não disponível)") : "  (Disponivel)") + (modelo.veiculos[i].vendido? "  (Vendido)" : ""));
                    Console.WriteLine("           |______________________________________________________________________________________________________|    ");
                }



            }
            if (opcaoSelecionadaVeiculo > totalOpcoesVeiculos)
            {

                Console.Write("           |  *  ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Voltar");
                Console.BackgroundColor = originalColor;
                Console.WriteLine("           |______________________________________________________________________________________________________|    ");
            }
            else
            {
                Console.Write("           |  *  ");
                Console.WriteLine("Voltar");
                Console.WriteLine("           |______________________________________________________________________________________________________|    ");

            }

        }
        static void exibeMenuVeiculos(Modelo modelo)
        {

            int opcaoSelecionadaVeiculo = 0;
            int totalOpcoesVeiculos = modelo.espacoLivreVeiculos;

            bool sairMenuVeiculos = false;
            while (sairMenuVeiculos != true)
            {
                Console.Clear();
                desenhaMenuVeiculos(modelo, totalOpcoesVeiculos, opcaoSelecionadaVeiculo);
                ConsoleKeyInfo teclaDigitadaMenuVeiculo = Console.ReadKey();
                switch (teclaDigitadaMenuVeiculo.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaVeiculo++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaVeiculo--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaVeiculo > totalOpcoesVeiculos - 1)
                        {
                            sairMenuVeiculos = true;
                        }
                        else
                        {
                            for (int i = 0; i < totalOpcoesVeiculos; i++)
                            {
                                if (opcaoSelecionadaVeiculo == i)
                                {
                                    exibeInfoVeic(modelo.veiculos[i]);

                                }
                            }
                        }
                        break;
                }
                if (opcaoSelecionadaVeiculo > totalOpcoesVeiculos || opcaoSelecionadaVeiculo <= -1)
                {
                    opcaoSelecionadaVeiculo = 0;
                }
            }



        }
        static void desenhaInfoVeic(Veiculo veiculo, int opcaoSelecionadaInfo)
        {
            Console.Clear();
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |" + (veiculo.nome_veic + "- INFORMAÇÕES").PadRight(65) + "|");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |" + ("               Cod Modelo:      " + veiculo.modelo).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Cod Fornecedor:  " + veiculo.codfornecedor).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Placa:           " + veiculo.placa).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               N* Portas:       " + veiculo.numerodeportas).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Cor:             " + veiculo.cor).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Ano:             " + veiculo.ano).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Cod Veiculo:     " + veiculo.cod_veiculo).PadRight(65) + "|    ");
            Console.WriteLine("  |_________________________________________________________________|    ");

            int totalOpcoesInfo = 1;
            for (int i = 0; i < totalOpcoesInfo; i++)
            {
                if (opcaoSelecionadaInfo == i)
                {


                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  |           Encomendar");
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("  |_________________________________________________________________|    ");
                }
                else
                {

                    Console.WriteLine("  |           Encomendar");
                    Console.WriteLine("  |_________________________________________________________________|   ");
                }
                if (opcaoSelecionadaInfo == 1)
                {

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  |            Voltar");
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("  |_________________________________________________________________|    ");
                }
                else
                {

                    Console.WriteLine("  |            Voltar");
                    Console.WriteLine("  |_________________________________________________________________|   ");
                }

            }

        }
        static void exibeInfoVeic(Veiculo veiculo)
        {
            int opcaoSelecionadaInfo = 0;
            bool sairMenuInfoVeic = false;
            while (sairMenuInfoVeic != true)
            {
                Console.Clear();
                desenhaInfoVeic(veiculo, opcaoSelecionadaInfo);
                ConsoleKeyInfo teclaDigitadaMenuInfo = Console.ReadKey();
                switch (teclaDigitadaMenuInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaInfo++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaInfo--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaInfo == 1)
                        {
                            sairMenuInfoVeic = true;

                        }
                        else
                        {
                            if (veiculo.status_encomenda == false && veiculo.vendido == false)
                            {


                                Console.Clear();
                                Console.WriteLine("  --> Digite o CPF do cliente:");
                                string cpfCliente = (Console.ReadLine());
                                acessoEncomenda(cpfCliente, veiculo);
                                Console.ReadKey();
                            }
                            else
                            {

                            }
                        }
                        break;

                }
                if (opcaoSelecionadaInfo > 1 || opcaoSelecionadaInfo <= -1)
                {
                    opcaoSelecionadaInfo = 0;
                }

            }
        }
        static void acessoEncomenda(String cpfCliente, Veiculo veiculo)
        {
            for (int i = 0; i < espacoLivreCliente; i++)
            {
                if (clientes[i].cpf == cpfCliente)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("           ___________________________________________________________");
                    Console.WriteLine("          |                                                           |");
                    Console.WriteLine("          |       Veículo encomendado por: " + clientes[i].nome + "   |");
                    Console.WriteLine("          |___________________________________________________________|");
                    Encomenda e1 = new Encomenda();
                    e1.data_encomenda = DateTime.Now;
                    e1.cliente = clientes[i];
                    e1.veiculo = veiculo;

                    encomendas[espacoLivreEncomenda] = e1;
                    espacoLivreEncomenda++;
                    veiculo.status_encomenda = true;
                    
                    return;
                }
                
            }

            Console.Clear();
            Console.WriteLine("           ___________________________________________________________");
            Console.WriteLine("          |                                                           |");
            Console.WriteLine("          |                 Cliente não cadastrado!                   |");
            Console.WriteLine("          |___________________________________________________________|");
            
        }
        static void desenhaEncomendas(int opcaoSelecionadaEncomenda)
        {
            Console.Clear();
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |                 CONTROLE - VEÍCULOS ENCOMENDADOS                |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");

            for (int i = 0; i < espacoLivreEncomenda; i++)
            {
                if (opcaoSelecionadaEncomenda == i)
                {


                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  |          " + encomendas[i].veiculo.nome_veic+ " - "+ encomendas[i].cliente.nome + ""+(encomendas[i].vendido? "  (Vendido)" : ""  )+""+(encomendas[i].cancelada ? "   (Cancelada)" : "")+" ");
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("  |_________________________________________________________________|    ");
                }
                else
                {

                    Console.WriteLine("  |          " + encomendas[i].veiculo.nome_veic + " - " + encomendas[i].cliente.nome + "" + (encomendas[i].vendido ? "  (Vendido)" : "") + "" + (encomendas[i].cancelada ? "   (Cancelada)" : "") + " ");
                    Console.WriteLine("  |_________________________________________________________________|   ");
                }
                
            }
            if (opcaoSelecionadaEncomenda >= espacoLivreEncomenda)
            {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("  |            Voltar");
                Console.BackgroundColor = originalColor;
                Console.WriteLine("  |_________________________________________________________________|    ");
            }
            else
            {

                Console.WriteLine("  |            Voltar");
                Console.WriteLine("  |_________________________________________________________________|   ");
            }
        }
        static void exibeMenuEncomendas(int opcaoSelecionadaEncomenda)
        {
            opcaoSelecionadaEncomenda = 0;
            int totalOpcoesMenuEncomenda = espacoLivreEncomenda - 1;
            bool sairMenuEncomenda = false;
            while (sairMenuEncomenda != true)
            {
                Console.Clear();
                desenhaEncomendas(opcaoSelecionadaEncomenda);
                ConsoleKeyInfo teclaDigitadaMenuEncomenda = Console.ReadKey();
                switch (teclaDigitadaMenuEncomenda.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaEncomenda++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaEncomenda--;
                        break;
                    case ConsoleKey.Enter:
                        if(opcaoSelecionadaEncomenda > totalOpcoesMenuEncomenda)
                        {
                            sairMenuEncomenda = true;
                        }
                        else
                        {
                            
                            exibeMenuInfoEncomenda(encomendas[opcaoSelecionadaEncomenda], opcaoSelecionadaEncomenda);
                            
                        }
                        


                        break;



                }

            }
        }
        static void desenhaMenuInfoEncomenda(Encomenda encomenda, int opcaoSelecionadaInfoEncomenda)
        {
            Console.Clear();
            Console.WriteLine("   _________________________________________________________________     ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |" + (encomenda.veiculo.nome_veic + " - M O D E L O S").PadRight(65) + "|");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |         *****************         ********************          |    ");
            Console.WriteLine("  |          *********   *************************     **           |    ");
            Console.WriteLine("  |          ***   *     ******************   *       ***           |    ");
            Console.WriteLine("  |          ***   *      ****************    *     *****           |    ");
            Console.WriteLine("  |              *****                      *****   *****           |    ");
            Console.WriteLine("  |              *****                      *****                   |    ");
            Console.WriteLine("  |_________________________________________________________________|    ");
            Console.WriteLine("  |                                                                 |    ");
            Console.WriteLine("  |" + ("               Nome:      " + encomenda.cliente.nome).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               CPF:  " + encomenda.cliente.cpf).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Telefone:           " + encomenda.cliente.telefone).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Endereco:       " + encomenda.cliente.endereco).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Placa:             " + encomenda.veiculo.placa).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Ano:             " + encomenda.veiculo.ano).PadRight(65) + "|    ");
            Console.WriteLine("  |" + ("               Cod Veiculo:     " + encomenda.veiculo.cod_veiculo).PadRight(65) + "|    ");
            Console.WriteLine("  |_________________________________________________________________|    ");

            
            
                if (opcaoSelecionadaInfoEncomenda == 0)
                {


                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  |   Autorizar encomenda");
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("  |_________________________________________________________________|    ");
                }
                else
                {

                    Console.WriteLine("  |   Autorizar encomenda");
                    Console.WriteLine("  |_________________________________________________________________|   ");
                }
                if (opcaoSelecionadaInfoEncomenda == 1)
                {


                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("  |   Cancelar encomenda");
                    Console.BackgroundColor = originalColor;
                    Console.WriteLine("  |_________________________________________________________________|    ");
                }
                else
                {

                    Console.WriteLine("  |   Cancelar encomenda");
                    Console.WriteLine("  |_________________________________________________________________|   ");
                }



            
            if (opcaoSelecionadaInfoEncomenda == 2)
            {

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("  |            Voltar");
                Console.BackgroundColor = originalColor;
                Console.WriteLine("  |_________________________________________________________________|    ");
            }
            else
            {

                Console.WriteLine("  |            Voltar");
                Console.WriteLine("  |_________________________________________________________________|   ");
            }
        }
        static void exibeMenuInfoEncomenda(Encomenda encomenda, int opcaoSelecionadaInfoEncomenda)
        {
            bool sairMenuInfoEncomenda = false;
            int totalOpcoesInfoEncomenda = 2;
            opcaoSelecionadaInfoEncomenda = 0;
            while (sairMenuInfoEncomenda != true)
            {
                Console.Clear();
                desenhaMenuInfoEncomenda(encomenda, opcaoSelecionadaInfoEncomenda);

                for (int i = 0; i < totalOpcoesInfoEncomenda; i++) ;
                ConsoleKeyInfo teclaDigitadaMenuEncomenda = Console.ReadKey();
                switch (teclaDigitadaMenuEncomenda.Key)
                {
                    case ConsoleKey.DownArrow:
                        opcaoSelecionadaInfoEncomenda++;
                        break;
                    case ConsoleKey.UpArrow:
                        opcaoSelecionadaInfoEncomenda--;
                        break;
                    case ConsoleKey.Enter:
                        if (opcaoSelecionadaInfoEncomenda == 0)
                        {
                            if (!encomenda.cancelada && !encomenda.vendido)
                            {
                                Console.Clear();
                                Console.WriteLine("           ___________________________________________________________");
                                Console.WriteLine("          |                                                           |");
                                Console.WriteLine("          |                 --> Baixa bem sucedida!                   |");
                                Console.WriteLine("          |___________________________________________________________|");
                                Console.ReadKey();
                                encomenda.veiculo.vendido = true;
                                encomenda.vendido = true;
                            }
                        }
                        if (opcaoSelecionadaInfoEncomenda == 1)
                        {
                            if (!encomenda.cancelada && !encomenda.vendido)
                            {

                                encomenda.veiculo.status_encomenda = false;
                                encomenda.cancelada = true;
                                Console.Clear();
                                Console.WriteLine("           ___________________________________________________________");
                                Console.WriteLine("          |                                                           |");
                                Console.WriteLine("          |           --> Encomenda cancelada com sucesso!            |");
                                Console.WriteLine("          |___________________________________________________________|");
                                Console.ReadKey();
                            }
                        }
                        if(opcaoSelecionadaInfoEncomenda == 2)
                        {
                            sairMenuInfoEncomenda = true;
                        }
                        break;
                }
            }
        }
    }
}