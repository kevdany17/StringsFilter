using System;


namespace StringFilters
{
    class TestClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa Una Palabra");
            String palabra = Console.ReadLine();
            Console.WriteLine("Filtrar Cadena...");
            Console.WriteLine("Cadena Filtrada Lista para ocupar con SQL: {0}", SearchFilter.replaceVocalSpaces(palabra));
            Console.Read();
        }
    }
}
