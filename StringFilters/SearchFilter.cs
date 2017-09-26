using System;
using System.Text.RegularExpressions;


namespace StringFilters
{
    //Filtros de Busqueda
    public class SearchFilter
    {
        //Crea un cadena para buscar con el comando like en la base de datos
        //sustituye vocales por _
        //sustituye espacios por %
        //Reemplazar Vocales y Espacios
        public static string replaceVocalSpaces(string cadena)
        {
            string patron = "[\\s]{1,}";// se sustituye por %
            string patron2 = "[aeiouAEIOUÁÉÍÓÚáéíóúàèìòùÀÈÌÒÙ]{1,}";// Se sustituye por _
            Char charRange = '\"'; //Valor a Buscar
            int startIndex = cadena.IndexOf(charRange); //Primera Aparicion
            int endIndex = 0;
            string cadenaComillas = "";
            if (startIndex != -1)
            {
                startIndex = cadena.IndexOf(charRange); //Primera Aparicion
                endIndex = cadena.LastIndexOf(charRange); //Ultima Aparicion
                int length = (endIndex - 1) - startIndex; // Crear Rango entre el caractes
                cadenaComillas = cadena.Substring((startIndex + 1), length); //obtener el substring
            }
            //Reemplazar espacios en blanco y vocales
            string palabra = "%" + Regex.Replace(cadena, patron, "%") + "%";
            palabra = Regex.Replace(palabra, patron2, "_");
            char[] arregloCadena = palabra.ToCharArray();
            string result = "";
            for (int i = 0; i < arregloCadena.Length; i++)
            {
                if ((i + 1) == arregloCadena.Length)
                {
                    result = result + arregloCadena[i].ToString(); //asigna la ultima posición
                    //Salir Para Evitar BonusException
                }
                else if (startIndex == i && startIndex != -1)
                {
                    result = result + "%" + cadenaComillas;
                    i = endIndex + 1;
                }
                else
                {
                    if (arregloCadena[i] == arregloCadena[i + 1])
                    {
                        //Saltar Caracter Repetido
                    }
                    else
                    {
                        result = result + arregloCadena[i].ToString();
                    }
                }
            }
            return result;
        }
        //Agrega Contra barra al String para espapar comillas dobles
        //Escapar Commillas Dobles
        public static string escapeDoubleQuotes(string cadena)
        {
            char[] arregloCadena = cadena.ToCharArray();
            char comillas = '\"';
            string result = "";
            for (int i = 0; i < arregloCadena.Length; i++)
            {
                if (arregloCadena[i] == comillas)
                {
                    continue;
                }
                else
                {
                    result += arregloCadena[i];
                }
            }

            return result;

        }
    }
}
