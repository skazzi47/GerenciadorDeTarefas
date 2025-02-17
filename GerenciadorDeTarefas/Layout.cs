namespace Layout
{
    class Formatacao
    {
        public static void ImprimirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║   Gerenciador De Tarefas   ║");
            Console.WriteLine("╚════════════════════════════╝");
        }

        public static void Cor(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ResetColor();
        }
    }
}