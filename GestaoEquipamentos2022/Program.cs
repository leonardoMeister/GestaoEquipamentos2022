using System;

namespace GestaoEquipamentos2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExecutarPrograma();
        }


        #region METODOS DE EQUIPAMENTOS

        #endregion


        #region  METODOS DE CHAMADOS

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

                                break;
                            case 2:

                                break;
                            case 3:

                                break;
                            case 4:

                                break;
                        }
                    #endregion

                    #region PARTE DE GESTÃO CHAMADOS
                    else if (opcaoMenu == 2)
                        switch (opcaoSubmenu)
                        {
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:

                                break;
                            case 4:

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
