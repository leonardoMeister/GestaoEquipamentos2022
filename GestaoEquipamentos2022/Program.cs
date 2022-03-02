using System;

namespace GestaoEquipamentos2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CadastrarDadosTestesEquipamentos();
            CadastrarDadosTestesChamados();

            ExecutarPrograma();
        }

        #region    EQUIPAMENTOS

        #region DECLARACAO DE VARIAVEIS EQUIPAMENTO
        static public string[] nomeEquipamento = new string[1000];
        static public double[] precoAquisicao = new double[1000];
        static public int[] numeroSerie = new int[1000];
        static public DateTime[] dataFabricacao = new DateTime[1000];
        static public string[] fabricante = new string[1000];
        static int[] idEquipamento = new int[1000];
        static public int contadorEquipamentos = 0;
        static public int gerenciadorIdsEquipamentos = 1;
        static public int[] id_do_chamado_em_equipamento = new int[1000];
        #endregion

        #region METODOS DE EQUIPAMENTOS
        static public bool RemoverEquipamento()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarEquipamento();
            if (index == -1) return false;

            if (RemovendoValoresVetoresEquipamentos(index))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NÃO PODE REMOVER EQUIPAMENTO VINCULADO A UM CHAMADO.");
                Console.ResetColor();
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            PassarItensParaFrenteEquipamentos(index);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("REMOÇÃO FEITA COM SUCESSO!");
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        static public bool EditarEquipamento()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarEquipamento();
            if (index == -1) return false;

            CadastarNovoEquipamentoOuEditar(0, index);
            return true;
        }
        private static bool RemovendoValoresVetoresEquipamentos(int index)
        {
            if (id_do_chamado_em_equipamento[index] != 0) return true;

            nomeEquipamento[index] = null;
            precoAquisicao[index] = 0;
            numeroSerie[index] = 0;
            dataFabricacao[index] = DateTime.MinValue;
            fabricante[index] = null;
            idEquipamento[index] = 0;
            id_do_chamado_em_equipamento[index] = 0;
            contadorEquipamentos--;
            return false;
        }
        private static void PassarItensParaFrenteEquipamentos(int index)
        {
            int contadorAuxEquipe = 0;

            while (true)
            {
                if (index == (nomeEquipamento.Length) - 1) break;
                if (nomeEquipamento[(index) + 1] == null) break;

                nomeEquipamento[index] = nomeEquipamento[(index) + 1];
                precoAquisicao[index] = precoAquisicao[(index) + 1];
                numeroSerie[index] = numeroSerie[(index) + 1];
                dataFabricacao[index] = dataFabricacao[(index) + 1];
                fabricante[index] = fabricante[(index) + 1];
                idEquipamento[index] = idEquipamento[(index) + 1];
                id_do_chamado_em_equipamento[index] = id_do_chamado_em_equipamento[(index) + 1];

                index++;
            }
        }
        static void CadastrarDadosTestesEquipamentos()
        {
            nomeEquipamento[0] = "equipamento 1";
            precoAquisicao[0] = 1300.2;
            numeroSerie[0] = 1992312;
            dataFabricacao[0] = DateTime.Now;
            fabricante[0] = "veronica";
            idEquipamento[0] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;

            nomeEquipamento[1] = "equipamento 2";
            precoAquisicao[1] = 3000.90;
            numeroSerie[1] = 1992314;
            dataFabricacao[1] = DateTime.Now;
            fabricante[1] = "maria";
            idEquipamento[1] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;

            nomeEquipamento[2] = "equipamento 3";
            precoAquisicao[2] = 10000;
            numeroSerie[2] = 1992100;
            dataFabricacao[2] = DateTime.Now;
            fabricante[2] = "joaninha";
            idEquipamento[2] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;

            nomeEquipamento[3] = "equipamento 4";
            precoAquisicao[3] = 1300.2;
            numeroSerie[3] = 1992312;
            dataFabricacao[3] = DateTime.Now;
            fabricante[3] = "veronica";
            idEquipamento[3] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;

            nomeEquipamento[4] = "equipamento 5";
            precoAquisicao[4] = 3000.90;
            numeroSerie[4] = 1992314;
            dataFabricacao[4] = DateTime.Now;
            fabricante[4] = "maria";
            idEquipamento[4] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;

            nomeEquipamento[5] = "equipamento 6";
            precoAquisicao[5] = 10000;
            numeroSerie[5] = 1992100;
            dataFabricacao[5] = DateTime.Now;
            fabricante[5] = "joaninha";
            idEquipamento[5] = gerenciadorIdsEquipamentos;
            contadorEquipamentos++;
            gerenciadorIdsEquipamentos++;
        }
        static public bool CadastarNovoEquipamentoOuEditar(int opcao, int index = 0)
        {
            while (true)
            {
                Console.Clear();
                if (opcao == 1) Console.WriteLine("CADASTRO DE EQUIPAMENTO!");
                else Console.WriteLine("EDICAO DE EQUIPAMENTO!");

                Console.WriteLine("\nInforme o nome do Equipamento: ");
                string nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    Console.WriteLine("Nome muito curto Tente Novamente! ");
                    Console.ReadKey();
                    continue;
                }
                Console.WriteLine("\nInforme o Preco do Equipamento: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\nInforme o Numero Serie do Equipamento: ");
                int nunSerie = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nInforme a Data defabricação do Equipamento: [2022/02/20]");
                string stringData = Console.ReadLine();

                DateTime data = new DateTime(Convert.ToInt32(stringData.Substring(0, 4)), Convert.ToInt32(stringData.Substring(5, 2)), Convert.ToInt32(stringData.Substring(8, 2)));

                Console.WriteLine("\nInforme o Fabricante do Equipamento:");
                string stringFabricante = Console.ReadLine();
                if (opcao == 1)
                {
                    nomeEquipamento[contadorEquipamentos] = nome;
                    precoAquisicao[contadorEquipamentos] = preco;
                    numeroSerie[contadorEquipamentos] = nunSerie;
                    dataFabricacao[contadorEquipamentos] = data;
                    fabricante[contadorEquipamentos] = stringFabricante;
                    idEquipamento[contadorEquipamentos] = gerenciadorIdsEquipamentos;
                    contadorEquipamentos++;
                    gerenciadorIdsEquipamentos++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEQUIPAMENTO ADICIONADO COM SUCESSO!");
                }
                else
                {
                    nomeEquipamento[index] = nome;
                    precoAquisicao[index] = preco;
                    numeroSerie[index] = nunSerie;
                    dataFabricacao[index] = data;
                    fabricante[index] = stringFabricante;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nEQUIPAMENTO EDITADO COM SUCESSO!");
                }

                Console.ResetColor();
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
        }
        static public void MostrarEquipamentos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LISTA DE EQUIPAMENTOS:");
            Console.WriteLine("----------------------");
            Console.ResetColor();
            for (int x = 0; x < contadorEquipamentos; x++)
            {
                Console.Write($"Nome: {nomeEquipamento[x]}\n");
                Console.Write($"Preço: {precoAquisicao[x]}\n");
                Console.Write($"Serie: {numeroSerie[x]}\n");
                Console.Write($"Data Fab: {dataFabricacao[x]}\n");
                Console.Write($"Fabricante: {fabricante[x]}\n");
                Console.Write($"Id: {idEquipamento[x]}\n");

                if (id_do_chamado_em_equipamento[x] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("DADOS DO CHAMADO VINCULADO AO EQUIPAMENTO: ");
                    Console.WriteLine("-----------------------------------------------");
                    Console.ResetColor();

                    int indexChamado = PegarIndexChamadoPeloId(id_do_chamado_em_equipamento[x]);
                    Console.Write($"Titulo: {tituloChamado[indexChamado]}\n");
                    Console.Write($"Data abertura: {dataAberturaChamado[indexChamado]}\n");
                    Console.Write($"Tempo aberto: {(DateTime.Now - dataAberturaChamado[indexChamado]).Days }\n");
                    Console.Write($"Id Chamado: {idChamado[indexChamado]}\n");



                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n----------------------------------------\n");
                Console.ResetColor();
            }
            Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
            Console.ReadKey();
        }
        static public int PegarIndexEquipamentoPeloId(int idEquipe)
        {
            for (int x = 0; x < contadorEquipamentos; x++)
            {
                if (idEquipamento[x] == idEquipe) return x;
            }
            return -1;
        }
        static public int LocalizarEquipamento()
        {
            while (true)
            {

                int id = 0;

                Console.Clear();

                Console.WriteLine("LOCALIZADOR DE EQUIPAMENTOS:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("\n\nInforme o Nome Equipamento: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Informe o Id Equipamento: ");
                id = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < contadorEquipamentos; x++)
                {
                    if (nomeEquipamento[x].ToLower() == nome.ToLower() && idEquipamento[x] == id)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("EQUIPAMENTO LOCALIZADO COM SUCESSO!");
                        Console.ResetColor();
                        Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        Console.Clear();
                        return x;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NENHUM EQUIPAMENTO ENCONTRADO!\nTente Novamente.");
                Console.ResetColor();
                Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return -1;

            }
        }
        #endregion
        #endregion

        #region   CHAMADOS
        #region DECLARACAO DE VARIAVEIS DO CHAMADO
        static public int[] id_do_equipamento_em_chamado = new int[1000];
        static public int contadorChamados = 0;
        static public int gerenciadorIdsChamados = 1;
        static int[] idChamado = new int[1000];
        static string[] tituloChamado = new string[1000];
        static string[] descricaoChamado = new string[1000];
        static DateTime[] dataAberturaChamado = new DateTime[1000];
        #endregion
        private static bool RemovendoValoresVetoresChamados(int index)
        {
            id_do_equipamento_em_chamado[index] = 0;
            idChamado[index] = 0;
            tituloChamado[index] = null;
            descricaoChamado[index] = null;
            dataAberturaChamado[index] = DateTime.MinValue;
            contadorChamados--;
            return true;
        }
        private static bool EditarChamados()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarChamado();
            if (index == -1) return false;

            CadastarNovoChamadoOuEditar(0, index);
            return true;
        }
        private static int LocalizarChamado()
        {
            while (true)
            {

                int id = 0;

                Console.Clear();

                Console.WriteLine("LOCALIZADOR DE CHAMADOS:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Informe o Id Chamado desejado: ");
                id = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < contadorChamados; x++)
                {
                    if (idChamado[x] == id)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CHAMADO LOCALIZADO COM SUCESSO!");
                        Console.ResetColor();
                        Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        Console.Clear();
                        return x;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NENHUM EQUIPAMENTO ENCONTRADO!\nTente Novamente.");
                Console.ResetColor();
                Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return -1;

            }
        }
        private static bool RemoverChamados()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarChamado();
            if (index == -1) return false;

            int idEquip = id_do_equipamento_em_chamado[index];
            int indexEquip = PegarIndexEquipamentoPeloId(idEquip);
            RemovendoValoresVetoresChamados(index);
            id_do_chamado_em_equipamento[indexEquip] = 0;

            PassarItensParaFrenteChamados(index);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("REMOÇÃO FEITA COM SUCESSO!");
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();

            return true;
        }
        private static void PassarItensParaFrenteChamados(int index)
        {
            while (true)
            {
                if (index == (nomeEquipamento.Length) - 1) break;
                int indexNovo = index + 1;
                if (tituloChamado[indexNovo] == null) break;

                id_do_equipamento_em_chamado[index] = id_do_equipamento_em_chamado[indexNovo];
                idChamado[index] = idChamado[indexNovo];
                tituloChamado[index] = tituloChamado[indexNovo];
                descricaoChamado[index] = descricaoChamado[indexNovo];
                dataAberturaChamado[index] = dataAberturaChamado[indexNovo];

                index++;
            }
        }
        private static int PegarIndexChamadoPeloId(int idBusca)
        {
            for (int x = 0; x < contadorChamados; x++)
            {
                if (idChamado[x] == idBusca) return x;
            }
            return -1;
        }
        private static void MostrarChamados()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("LISTA DE CHAMADOS:");
            Console.WriteLine("----------------------\n");
            Console.ResetColor();
            for (int x = 0; x < contadorChamados; x++)
            {
                Console.Write($"Titulo: {tituloChamado[x]}\n");
                Console.Write($"Data abertura: {dataAberturaChamado[x]}\n");
                Console.Write($"Tempo aberto: {(DateTime.Now - dataAberturaChamado[x]).Days }\n");
                Console.Write($"Id Chamado: {idChamado[x]}\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"DADOS EQUIPAMENTO VINCULADO:\n------------------------------------------\n");
                Console.ResetColor();
                int indexEquipamento = PegarIndexEquipamentoPeloId(id_do_equipamento_em_chamado[x]);
                Console.Write($"Nome: {nomeEquipamento[indexEquipamento]} \n");
                Console.Write($"Preço: {precoAquisicao[indexEquipamento]}\n");
                Console.Write($"Serie: {numeroSerie[indexEquipamento]}\n");
                Console.Write($"Data Fab: {dataFabricacao[indexEquipamento]}\n");
                Console.Write($"Fabricante: {fabricante[indexEquipamento]}\n");
                Console.Write($"Id: {idEquipamento[indexEquipamento]}\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n----------------------------------------\n");
                Console.ResetColor();
            }
            Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
            Console.ReadKey();
        }
        private static void CadastarNovoChamadoOuEditar(int opcao, int index = 0)
        {
            while (true)
            {
                Console.Clear();
                if (opcao == 1) Console.WriteLine("CADASTRO DE CHAMADO!");
                else Console.WriteLine("EDICAO DE CHAMADO!");

                Console.WriteLine("\nInforme o titulo do Chamado: ");
                string titulo = Console.ReadLine();

                Console.WriteLine("\nInforme a descricao do Chamado: ");
                string descricao = Console.ReadLine();

                DateTime data = DateTime.Now;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DADOS COLETADOS COM SUCESSO!\n");
                Console.WriteLine("PARA FINALIZAR LOCALIZE O EQUIPAMENTO DESEJADO.");
                Console.ResetColor();
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadKey();

                int indexIdEquipamento = LocalizarEquipamento();


                if (opcao == 1)
                {
                    tituloChamado[contadorChamados] = titulo;
                    descricaoChamado[contadorChamados] = descricao;
                    dataAberturaChamado[contadorChamados] = data;
                    idChamado[contadorChamados] = gerenciadorIdsChamados;

                    id_do_equipamento_em_chamado[contadorChamados] = idEquipamento[indexIdEquipamento];
                    id_do_chamado_em_equipamento[indexIdEquipamento] = idChamado[contadorChamados];

                    contadorChamados++;
                    gerenciadorIdsChamados++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCHAMADO ADICIONADO COM SUCESSO!");
                    Console.WriteLine("\nDADOS EQUIPAMENTO VINCULADO A CHAMADO ATUALIZADOS COM SUCESSO!");
                }
                else
                {
                    tituloChamado[index] = titulo;
                    descricaoChamado[index] = descricao;
                    dataAberturaChamado[index] = data;

                    int idEquip = id_do_chamado_em_equipamento[index];
                    int indexEquiAntigo = PegarIndexEquipamentoPeloId(idEquip);
                    id_do_chamado_em_equipamento[indexEquiAntigo] = 0;

                    id_do_equipamento_em_chamado[index] = idEquipamento[indexIdEquipamento];
                    id_do_chamado_em_equipamento[indexIdEquipamento] = idChamado[index];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCHAMADO EDITADO COM SUCESSO!");
                    Console.WriteLine("\nDADOS EQUIPAMENTO VINCULADO A CHAMADO ATUALIZADOS COM SUCESSO!");
                }

                Console.ResetColor();
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        public static void CadastrarDadosTestesChamados()
        {
            tituloChamado[contadorChamados] = "CHAMADO 1";
            descricaoChamado[contadorChamados] = "DESCRICAO CHAMADO 1";
            dataAberturaChamado[contadorChamados] = new DateTime(2022, 02, 15);
            idChamado[contadorChamados] = gerenciadorIdsChamados;
            id_do_equipamento_em_chamado[contadorChamados] = 1;
            id_do_chamado_em_equipamento[0] = idChamado[contadorChamados];
            contadorChamados++;
            gerenciadorIdsChamados++;

            tituloChamado[contadorChamados] = "CHAMADO 2";
            descricaoChamado[contadorChamados] = "DESCRICAO CHAMADO 2";
            dataAberturaChamado[contadorChamados] = DateTime.Now;
            idChamado[contadorChamados] = gerenciadorIdsChamados;
            id_do_equipamento_em_chamado[contadorChamados] = 2;
            id_do_chamado_em_equipamento[1] = idChamado[contadorChamados];
            contadorChamados++;
            gerenciadorIdsChamados++;
        }
        #endregion

        private static void ExecutarPrograma()
        {
            while (true)
            {
                int opcaoMenu = OpcaoMenuPrincipal();

                while (true)
                {
                    int opcaoSubmenu = OpcaoSubMenu(opcaoMenu);

                    if (opcaoSubmenu == 5) break;


                    #region PARTE DE GESTÃO DE EQUIPAMENTOS 
                    if (opcaoMenu == 1)
                        switch (opcaoSubmenu)
                        {
                            case 1:
                                CadastarNovoEquipamentoOuEditar(1);
                                break;
                            case 2:
                                MostrarEquipamentos();
                                break;
                            case 3:
                                RemoverEquipamento();
                                break;
                            case 4:
                                EditarEquipamento();
                                break;
                        }
                    #endregion

                    #region PARTE DE GESTÃO CHAMADOS
                    else if (opcaoMenu == 2)
                        switch (opcaoSubmenu)
                        {
                            case 1:
                                CadastarNovoChamadoOuEditar(1);
                                break;
                            case 2:
                                MostrarChamados();
                                break;
                            case 3:
                                RemoverChamados();
                                break;
                            case 4:
                                EditarChamados();
                                break;
                        }
                    #endregion
                }

            }
        }

        #region OPCOES  DE ESCRITAS E MENU
        static public int OpcaoSubMenu(int opcao)
        {
            Console.Clear();

            int opcao2 = 0;
            while (true)
            {
                string valorTexto = "";
                switch (opcao)
                {
                    case 1:
                        valorTexto = "Equipamentos";
                        break;
                    case 2:
                        valorTexto = "Chamados";
                        break;
                }
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"-- Gestão de {valorTexto}: --");
                Console.WriteLine("-----------------------------\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Para Adição de {valorTexto} [1]");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Para Listagem dos {valorTexto} [2]");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Para Remoção de {valorTexto} [3]");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Para Edição de {valorTexto} [4]");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Voltar ao Menu Principal [5]");
                Console.ResetColor();

                opcao2 = Convert.ToInt32(Console.ReadLine());
                if (opcao2 >= 1 && opcao2 <= 5)
                {
                    Console.Clear();
                    return opcao2;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Valor Fora de escopo!\nTente Novamente");
                    Console.ResetColor();
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadKey();
                    Console.Clear();
                }


            }
        }
        static public int OpcaoMenuPrincipal()
        {
            int opcao = 0;
            while (true)
            {
                Console.WriteLine("Seja Bem Vindo ao Sistema Gestão Equipamentos 1.0 ! \n\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Para Navegar no Menu Equipamentos [1]. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Para Navegar no Menu Chamados [2]. ");
                Console.ResetColor();
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1 || opcao == 2)
                {
                    Console.Clear();
                    return opcao;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nValor Fora de escopo!\nTente Novamentezn");
                    Console.ResetColor();
                    Console.WriteLine("PRESS ENTER TO CONTINUE...");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();

            }
        }
        #endregion
    }
}