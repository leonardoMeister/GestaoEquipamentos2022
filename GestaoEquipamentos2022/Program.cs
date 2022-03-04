using System;

namespace GestaoEquipamentos2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CadastrarDadosTestesEquipamentos();
            CadastrarDadosTestesSolicitantes();
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
        static public bool RemoverEquipamento()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarEquipamento();
            if (index == -1) return false;

            if (RemovendoValoresVetoresEquipamentos(index))
            {
                ImprimaMaisFinalizacaoPRESSENTER("NÃO PODE REMOVER EQUIPAMENTO VINCULADO A UM CHAMADO.");
                return false;
            }

            PassarItensParaFrenteEquipamentos(index);

            ImprimaMaisFinalizacaoPRESSENTER("REMOÇÃO FEITA COM SUCESSO!", ConsoleColor.Green);
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

                    ImprimirColorido("\nEQUIPAMENTO ADICIONADO COM SUCESSO!", ConsoleColor.Green);
                }
                else
                {
                    nomeEquipamento[index] = nome;
                    precoAquisicao[index] = preco;
                    numeroSerie[index] = nunSerie;
                    dataFabricacao[index] = data;
                    fabricante[index] = stringFabricante;
                    ImprimirColorido("\nEQUIPAMENTO EDITADO COM SUCESSO!", ConsoleColor.Green);
                }
                ImprimaMaisFinalizacaoPRESSENTER();
                return true;
            }
        }
        static public void MostrarEquipamentos()
        {
            Console.Clear();
            ImprimirColorido("LISTA DE EQUIPAMENTOS:\n----------------------", ConsoleColor.Red);
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
                    ImprimirColorido("DADOS DO CHAMADO VINCULADO AO EQUIPAMENTO: \n-----------------------------------------------", ConsoleColor.Yellow);

                    int indexChamado = PegarIndexChamadoPeloId(id_do_chamado_em_equipamento[x]);
                    Console.Write($"Titulo: {tituloChamado[indexChamado]}\n");
                    Console.Write($"Data abertura: {dataAberturaChamado[indexChamado]}\n");
                    Console.Write($"Tempo aberto: {(DateTime.Now - dataAberturaChamado[indexChamado]).Days }\n");
                    Console.Write($"Id Chamado: {idChamado[indexChamado]}\n");



                }
                ImprimirColorido("\n--------------------------------------------------------------------------------------------\n", ConsoleColor.Blue);
            }
            ImprimaMaisFinalizacaoPRESSENTER();
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
                        ImprimaMaisFinalizacaoPRESSENTER("EQUIPAMENTO LOCALIZADO COM SUCESSO!", ConsoleColor.Green);
                        return x;
                    }
                }
                ImprimaMaisFinalizacaoPRESSENTER("NENHUM EQUIPAMENTO ENCONTRADO!\nTente Novamente.");
                return -1;
            }
        }
        #endregion




        #region   CHAMADOS
        #region DECLARACAO DE VARIAVEIS DO CHAMADO
        static public int[] id_do_solicitante_em_chamado = new int[1000];
        static public int[] id_do_equipamento_em_chamado = new int[1000];
        static public bool[] statusOpenClose = new bool[1000];
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
                        ImprimaMaisFinalizacaoPRESSENTER("CHAMADO LOCALIZADO COM SUCESSO!", ConsoleColor.Green);
                        return x;
                    }
                }
                ImprimaMaisFinalizacaoPRESSENTER("NENHUM EQUIPAMENTO ENCONTRADO!\nTente Novamente.");
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

            ImprimaMaisFinalizacaoPRESSENTER("REMOÇÃO FEITA COM SUCESSO!", ConsoleColor.Green);
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
        private static int PegaroOpcaoFiltroChamados()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("INFORME A OPCAO PARA FILTRO.");
                Console.WriteLine("Mostragem normal [1]");
                Console.WriteLine("Mostragem filtro Abertos [2]");
                Console.WriteLine("Mostragem filtro Fechados [3]");

                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao != 1 && opcao != 2 && opcao != 3)
                {
                    ImprimaMaisFinalizacaoPRESSENTER("OPCAO INVÁLIDA");
                    continue;
                }
                return opcao;
            }
        }
        private static void MostrarChamados()
        {
            int opcaoFiltro = PegaroOpcaoFiltroChamados();

            Console.Clear();
            ImprimirColorido("LISTA DE CHAMADOS: ", ConsoleColor.Red);
            ImprimirColorido("----------------------\n", ConsoleColor.Red);

            for (int x = 0; x < contadorChamados; x++)
            {
                //FILTROS DE FECHADO E ABERTO
                if (opcaoFiltro == 2 && statusOpenClose[x] != true) continue;
                if (opcaoFiltro == 3 && statusOpenClose[x] == true) continue;

                Console.Write($"Titulo: {tituloChamado[x]}\n");
                Console.Write($"Data abertura: {dataAberturaChamado[x]}\n");
                Console.Write($"Tempo aberto: {(DateTime.Now - dataAberturaChamado[x]).Days }\n");
                string aux = (statusOpenClose[x] == true) ? "Aberto" : "fechado";
                Console.Write($"Status: { aux}\n");
                Console.Write($"Id Chamado: {idChamado[x]}\n");

                ImprimirColorido("DADOS EQUIPAMENTO VINCULADO:\n------------------------------------------\n", ConsoleColor.Yellow);
                int indexEquipamento = PegarIndexEquipamentoPeloId(id_do_equipamento_em_chamado[x]);
                Console.Write($"Nome: {nomeEquipamento[indexEquipamento]} \n");
                Console.Write($"Preço: {precoAquisicao[indexEquipamento]}\n");
                Console.Write($"Serie: {numeroSerie[indexEquipamento]}\n");
                Console.Write($"Data Fab: {dataFabricacao[indexEquipamento]}\n");
                Console.Write($"Fabricante: {fabricante[indexEquipamento]}\n");
                Console.Write($"Id: {idEquipamento[indexEquipamento]}\n");

                ImprimirColorido("DADOS SOLICITANTE VINCULADO:\n------------------------------------------\n", ConsoleColor.Green);
                int indexSolicitante = PegarIndexSolicitantePeloId(id_do_solicitante_em_chamado[x]);
                Console.ResetColor();
                Console.Write($"Nome: {nomeSolicitante[indexSolicitante]}\n");
                Console.Write($"Telefone: {numeroTelefoneSolicitante[indexSolicitante]}\n");
                Console.Write($"Email: {emailSolicitante[indexSolicitante]}\n");
                Console.Write($"Id: {idSolicitante[indexSolicitante]}\n");

                ImprimirColorido("\n------------------------------------------------------------------------------------------------------------------\n", ConsoleColor.Blue);
            }
            ImprimaMaisFinalizacaoPRESSENTER();
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

                string str = "DADOS COLETADOS COM SUCESSO!\nPARA CONTINUAR LOCALIZE O EQUIPAMENTO DESEJADO.\n";
                ImprimaMaisFinalizacaoPRESSENTER(str, ConsoleColor.Green);

                int indexIdEquipamento = LocalizarEquipamento();

                str = "EQUIPAMENTO COLETADO COM SUCESSO!\nPARA CONTINUAR LOCALIZE O SOLICITANTE DESEJADO.\n";
                ImprimaMaisFinalizacaoPRESSENTER(str, ConsoleColor.Green);

                int indexIdSolicitante = LocalizarSolicitante();

                if (opcao == 1)
                {
                    tituloChamado[contadorChamados] = titulo;
                    descricaoChamado[contadorChamados] = descricao;
                    dataAberturaChamado[contadorChamados] = data;
                    idChamado[contadorChamados] = gerenciadorIdsChamados;
                    statusOpenClose[contadorChamados] = true;

                    id_do_equipamento_em_chamado[contadorChamados] = idEquipamento[indexIdEquipamento];
                    id_do_chamado_em_equipamento[indexIdEquipamento] = idChamado[contadorChamados];

                    id_do_solicitante_em_chamado[contadorChamados] = idSolicitante[indexIdSolicitante];
                    id_do_chamado_em_solicitante[indexIdSolicitante] = idChamado[contadorChamados];

                    contadorChamados++;
                    gerenciadorIdsChamados++;

                    ImprimirColorido("\nCHAMADO ADICIONADO COM SUCESSO!\n\nDADOS EQUIPAMENTO VINCULADO A CHAMADO ATUALIZADOS COM SUCESSO!", ConsoleColor.Green);
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

                    ImprimirColorido("\nCHAMADO EDITADO COM SUCESSO!\n\nDADOS EQUIPAMENTO VINCULADO A CHAMADO ATUALIZADOS COM SUCESSO!", ConsoleColor.Green);
                }
                ImprimaMaisFinalizacaoPRESSENTER();
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
            statusOpenClose[contadorChamados] = true;
            id_do_solicitante_em_chamado[contadorChamados] = 1;
            id_do_chamado_em_solicitante[0] = idChamado[contadorChamados];

            contadorChamados++;
            gerenciadorIdsChamados++;

            tituloChamado[contadorChamados] = "CHAMADO 2";
            descricaoChamado[contadorChamados] = "DESCRICAO CHAMADO 2";
            dataAberturaChamado[contadorChamados] = DateTime.Now;
            idChamado[contadorChamados] = gerenciadorIdsChamados;
            id_do_equipamento_em_chamado[contadorChamados] = 2;
            id_do_chamado_em_equipamento[1] = idChamado[contadorChamados];
            statusOpenClose[contadorChamados] = true;
            id_do_solicitante_em_chamado[contadorChamados] = 2;
            id_do_chamado_em_solicitante[1] = idChamado[contadorChamados];

            contadorChamados++;
            gerenciadorIdsChamados++;
        }
        private static void AbrirFecharChamado()
        {
            Console.Clear();
            Console.WriteLine("Para Fechar chamado [1] ");
            Console.WriteLine("Para Reabrir chamado [2] ");
            int opcao = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            int indexChamado = LocalizarChamado();

            if (opcao == 1) statusOpenClose[indexChamado] = false;
            else if (opcao == 2) statusOpenClose[indexChamado] = true;

            ImprimaMaisFinalizacaoPRESSENTER("OPERAÇÃO REALIZADA COM SUCESSO!", ConsoleColor.Green);
        }
        #endregion




        #region SOLICITANTES    
        #region DECLARACAO DE VARIAVEIS SOLICITANTES
        static public int[] id_do_chamado_em_solicitante = new int[1000];
        static public int[] idSolicitante = new int[1000];
        static public int contadorSolicitantes = 0;
        static public int gerenciadorIdsSolicitantes = 1;
        static public string[] nomeSolicitante = new string[1000];
        static public string[] emailSolicitante = new string[1000];
        static public string[] numeroTelefoneSolicitante = new string[1000];
        #endregion
        private static void PassarItensParaFrenteSolicitantes(int index)
        {
            while (true)
            {
                if (index == (nomeSolicitante.Length) - 1) break;
                if (nomeSolicitante[(index) + 1] == null) break;

                nomeSolicitante[index] = nomeSolicitante[(index) + 1];
                emailSolicitante[index] = emailSolicitante[(index) + 1];
                idSolicitante[index] = idSolicitante[(index) + 1];
                id_do_chamado_em_solicitante[index] = id_do_chamado_em_solicitante[(index) + 1];
                numeroTelefoneSolicitante[index] = numeroTelefoneSolicitante[(index) + 1];

                index++;
            }
        }
        private static bool RemovendoValoresVetoresSolicitantes(int index)
        {
            if (id_do_chamado_em_solicitante[index] != 0) return true;

            nomeSolicitante[index] = null;
            emailSolicitante[index] = null;
            numeroTelefoneSolicitante[index] = null;
            idSolicitante[index] = 0;
            id_do_chamado_em_solicitante[index] = 0;
            contadorSolicitantes--;
            return false;
        }
        private static int LocalizarSolicitante()
        {
            while (true)
            {
                int id = 0;

                Console.Clear();

                Console.WriteLine("LOCALIZADOR DE SOLICITANTES:");
                Console.WriteLine("---------------------------");

                Console.WriteLine("Informe o Id Solicitante: ");
                id = Convert.ToInt32(Console.ReadLine());

                for (int x = 0; x < contadorSolicitantes; x++)
                {
                    if (idSolicitante[x] == id)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("SOLICITANTE LOCALIZADO COM SUCESSO!");
                        Console.ResetColor();
                        Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                        Console.ReadKey();
                        Console.Clear();
                        return x;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NENHUM SOLICITANTE ENCONTRADO!\nTente Novamente.");
                Console.ResetColor();
                Console.WriteLine("\nPRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return -1;

            }
        }
        private static void CadastrarDadosTestesSolicitantes()
        {
            idSolicitante[contadorSolicitantes] = gerenciadorIdsSolicitantes;
            nomeSolicitante[contadorSolicitantes] = "Solicitante 1";
            emailSolicitante[contadorSolicitantes] = "emailSolicitante1";
            numeroTelefoneSolicitante[contadorSolicitantes] = "TelefoneSolicitante1";
            contadorSolicitantes++;
            gerenciadorIdsSolicitantes++;

            idSolicitante[contadorSolicitantes] = gerenciadorIdsSolicitantes;
            nomeSolicitante[contadorSolicitantes] = "Solicitante 2";
            emailSolicitante[contadorSolicitantes] = "emailSolicitante2";
            numeroTelefoneSolicitante[contadorSolicitantes] = "TelefoneSolicitante2";
            contadorSolicitantes++;
            gerenciadorIdsSolicitantes++;

            idSolicitante[contadorSolicitantes] = gerenciadorIdsSolicitantes;
            nomeSolicitante[contadorSolicitantes] = "Solicitante 3";
            emailSolicitante[contadorSolicitantes] = "emailSolicitante3";
            numeroTelefoneSolicitante[contadorSolicitantes] = "TelefoneSolicitante3";
            contadorSolicitantes++;
            gerenciadorIdsSolicitantes++;
        }
        private static int PegarIndexSolicitantePeloId(int idBusca)
        {
            for (int x = 0; x < contadorSolicitantes; x++)
            {
                if (idSolicitante[x] == idBusca) return x;
            }
            return -1;
        }
        private static bool EditarSolicitantes()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarSolicitante();
            if (index == -1) return false;

            CadastarNovoSolicitanteOuEditar(0, index);
            return true;
        }
        private static void RemoverSolicitantes()
        {
            Console.Clear();
            int index = 0;
            index = LocalizarSolicitante();
            if (index == -1) return;

            if (RemovendoValoresVetoresSolicitantes(index))
            {
                ImprimaMaisFinalizacaoPRESSENTER("NÃO PODE REMOVER SOLICITANTE VINCULADO A UM CHAMADO.", ConsoleColor.Red);
                return;
            }

            PassarItensParaFrenteSolicitantes(index);

            ImprimaMaisFinalizacaoPRESSENTER("REMOÇÃO FEITA COM SUCESSO!", ConsoleColor.Green);
            return;
        }
        private static void MostrarSolicitantes()
        {
            Console.Clear();

            ImprimirColorido("LISTA DE SOLICITANTES:", ConsoleColor.Red);
            ImprimirColorido("----------------------:", ConsoleColor.Red);

            for (int x = 0; x < contadorSolicitantes; x++)
            {
                Console.Write($"Nome: {nomeSolicitante[x]}\n");
                Console.Write($"Telefone: {numeroTelefoneSolicitante[x]}\n");
                Console.Write($"Email: {emailSolicitante[x]}\n");
                Console.Write($"Id: {idSolicitante[x]}\n");

                if (id_do_chamado_em_solicitante[x] != 0)
                {

                    ImprimirColorido("DADOS DO CHAMADO VINCULADO AO SOLICITANTE: ", ConsoleColor.Yellow);
                    ImprimirColorido("-----------------------------------------------: ", ConsoleColor.Yellow);

                    int indexChamado = PegarIndexChamadoPeloId(id_do_chamado_em_solicitante[x]);
                    Console.Write($"Titulo: {tituloChamado[indexChamado]}\n");
                    Console.Write($"Data abertura: {dataAberturaChamado[indexChamado]}\n");
                    Console.Write($"Tempo aberto: {(DateTime.Now - dataAberturaChamado[indexChamado]).Days }\n");
                    Console.Write($"Id Chamado: {idChamado[indexChamado]}\n");

                    ImprimirColorido("DADOS DO EQUIPAMENTO VINCULADO AO CHAMADO: ", ConsoleColor.Green);
                    ImprimirColorido("-----------------------------------------------", ConsoleColor.Green);

                    int indexEquipamento = PegarIndexEquipamentoPeloId(id_do_equipamento_em_chamado[indexChamado]);

                    Console.Write($"Nome: {nomeEquipamento[indexEquipamento]}\n");
                    Console.Write($"Preço: {precoAquisicao[indexEquipamento]}\n");
                    Console.Write($"Serie: {numeroSerie[indexEquipamento]}\n");
                    Console.Write($"Data Fab: {dataFabricacao[indexEquipamento]}\n");
                    Console.Write($"Fabricante: {fabricante[indexEquipamento]}\n");
                    Console.Write($"Id: {idEquipamento[indexEquipamento]}\n");

                }
                ImprimirColorido("\n----------------------------------------\n", ConsoleColor.Blue);
            }
            ImprimaMaisFinalizacaoPRESSENTER();
        }
        private static void CadastarNovoSolicitanteOuEditar(int opcao, int index = 0)
        {
            while (true)
            {
                Console.Clear();
                if (opcao == 1) Console.WriteLine("CADASTRO DE SOLICITANTES!");
                else Console.WriteLine("EDICAO DE SOLICITANTES!");

                Console.WriteLine("\nInforme o nome do Solicitante: ");
                string nome = Console.ReadLine();
                if (nome.Length < 6)
                {
                    Console.WriteLine("Nome muito curto Tente Novamente! ");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine("\nInforme o Email do Solicitante: ");
                string email = Console.ReadLine();

                Console.WriteLine("\nInforme o Numero Telefone do Solicitante: ");
                string numTelefone = Console.ReadLine();


                if (opcao == 1)
                {
                    nomeSolicitante[contadorSolicitantes] = nome;
                    emailSolicitante[contadorSolicitantes] = email;
                    numeroTelefoneSolicitante[contadorSolicitantes] = numTelefone;

                    idSolicitante[contadorSolicitantes] = gerenciadorIdsSolicitantes;
                    contadorSolicitantes++;
                    gerenciadorIdsSolicitantes++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSOLICITANTE ADICIONADO COM SUCESSO!");
                }
                else
                {
                    nomeSolicitante[index] = nome;
                    emailSolicitante[index] = email;
                    numeroTelefoneSolicitante[index] = numTelefone;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSOLICITANTE EDITADO COM SUCESSO!");
                }

                Console.ResetColor();
                Console.WriteLine("PRESS ENTER TO CONTINUE...");
                Console.ReadKey();
                Console.Clear();
                return;
            }
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
                                CadastarNovoSolicitanteOuEditar(1);
                                break;
                            case 2:
                                MostrarSolicitantes();
                                break;
                            case 3:
                                RemoverSolicitantes();
                                break;
                            case 4:
                                EditarSolicitantes();
                                break;
                        }
                    else if (opcaoMenu == 3)
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
                            case 6:
                                AbrirFecharChamado();
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
                        valorTexto = "Solicitantes";
                        break;
                    case 3:
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

                if (opcao == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Fechar ou Abrir chamado Existente [6]");
                }
                Console.ResetColor();

                opcao2 = Convert.ToInt32(Console.ReadLine());

                if (opcao2 == 6)
                {
                    Console.Clear();
                    return opcao2;
                }
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
                Console.WriteLine("Para Navegar no Menu Solicitantes [2]. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Para Navegar no Menu Chamados [3]. ");
                Console.ResetColor();
                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1 || opcao == 2 || opcao == 3)
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
        static public void ImprimaMaisFinalizacaoPRESSENTER(string text = "", ConsoleColor cor = ConsoleColor.Red)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.WriteLine("PRESS ENTER TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();
        }
        static public void ImprimirColorido(string text, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        #endregion
    }
}