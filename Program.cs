
using System;
using System.Collections.Generic;

class Entrega
{
    public string Codigo { get; set; }
    public string Archivo { get; set; }
    public int Intentos { get; set; }
    public int Puntaje { get; set; }
    public string Observacion { get; set; }

    public Entrega(string codigo, string archivo,
                   int intentos, int puntaje, string observacion)
    {
        Codigo = codigo;
        Archivo = archivo;
        Intentos = intentos;
        Puntaje = puntaje;
        Observacion = observacion;
    }
}

class Program
{
    // 1. SUMATORIA RECURSIVA DE PUNTAJES
    static int SumarRecursivo(List<Entrega> lista, int indice)
    {
        if (indice >= lista.Count)
            return 0;

        return lista[indice].Puntaje +
               SumarRecursivo(lista, indice + 1);
    }

    // 2. SUMATORIA ITERATIVA
    static int SumarIterativo(List<Entrega> lista)
    {
        int suma = 0;

        for (int i = 0; i < lista.Count; i++)
        {
            suma += lista[i].Puntaje;
        }

        return suma;
    }

    // 3. BUSQUEDA RECURSIVA DE CODIGO
    static int BuscarCodigo(List<Entrega> lista,
                            string codigo, int indice)
    {
        if (indice >= lista.Count)
            return -1;

        if (lista[indice].Codigo.Equals(
            codigo, StringComparison.OrdinalIgnoreCase))
            return indice;

        return BuscarCodigo(lista, codigo, indice + 1);
    }

    // 4. CONTAR ARCHIVOS CON PALABRA CLAVE
    static int ContarArchivos(List<Entrega> lista,
                              string palabra, int indice)
    {
        if (indice >= lista.Count)
            return 0;

        int contador = lista[indice].Archivo.IndexOf(
            palabra, StringComparison.OrdinalIgnoreCase) >= 0
            ? 1 : 0;

        return contador +
               ContarArchivos(lista, palabra, indice + 1);
    }

    // 5. FUNCION ADICIONAL: FACTORIAL RECURSIVO
    static long Factorial(int numero)
    {
        if (numero < 0 || numero > 20)
            throw new ArgumentOutOfRangeException(
                nameof(numero), "Ingrese un número entre 0 y 20.");

        if (numero == 0 || numero == 1)
            return 1;

        return numero * Factorial(numero - 1);
    }

    static void Main()
    {
        // REGISTRO DE OCHO ENTREGAS
        List<Entrega> entregas = new List<Entrega>
        {
            new Entrega("E001", "tarea1.docx", 1, 16, "Correcto"),
            new Entrega("E002", "proyecto_v2.cs", 2, 18, "Revisado"),
            new Entrega("E003", "informe_final.pdf", 1, 20, "Excelente"),
            new Entrega("E004", "avance.docx", 3, 14, "Mejorable"),
            new Entrega("E005", "codigo_final.cs", 2, 17, "Correcto"),
            new Entrega("E006", "practica_v2.py", 1, 15, "Revisado"),
            new Entrega("E007", "resumen.docx", 1, 19, "Muy bueno"),
            new Entrega("E008", "entrega_final.docx", 2, 16, "Correcto")
        };

        Console.WriteLine("SISTEMA DE ANALISIS DE ENTREGAS");
        Console.WriteLine("--------------------------------");

        // MOSTRAR ENTREGAS
        foreach (Entrega e in entregas)
        {
            Console.WriteLine(
                $"{e.Codigo} | {e.Archivo} | " +
                $"Intentos: {e.Intentos} | Puntaje: {e.Puntaje}");
        }

        // SUMATORIA RECURSIVA E ITERATIVA
        int totalRecursivo = SumarRecursivo(entregas, 0);
        int totalIterativo = SumarIterativo(entregas);

        Console.WriteLine("\nRESULTADOS");
        Console.WriteLine("Total recursivo: " + totalRecursivo);
        Console.WriteLine("Total iterativo: " + totalIterativo);
        Console.WriteLine("Promedio: " +
            (double)totalRecursivo / entregas.Count);

        // BUSCAR CODIGO
        string codigo = "E005";
        int posicion = BuscarCodigo(entregas, codigo, 0);

        if (posicion != -1)
            Console.WriteLine("\nCodigo encontrado: " +
                              entregas[posicion].Codigo);
        else
            Console.WriteLine("\nCodigo no encontrado.");

        // CONTAR ARCHIVOS
        int finales = ContarArchivos(entregas, "final", 0);
        int versiones = ContarArchivos(entregas, "v2", 0);

        Console.WriteLine("\nArchivos con final: " + finales);
        Console.WriteLine("Archivos con v2: " + versiones);

        // FACTORIAL
        Console.WriteLine("\nFactorial de 5: " + Factorial(5));

        // PRUEBAS
        Console.WriteLine("\nPRUEBAS DEL SISTEMA");
        Console.WriteLine("-------------------");

        Console.WriteLine("Caso base factorial 0: " + Factorial(0));
        Console.WriteLine("Caso recursivo factorial 5: " + Factorial(5));
        Console.WriteLine("Sumatoria lista vacia: " +
            SumarRecursivo(new List<Entrega>(), 0));
        Console.WriteLine("Buscar E005: " +
            (BuscarCodigo(entregas, "E005", 0) != -1
                ? "Encontrado" : "No encontrado"));
        Console.WriteLine("Buscar E999: " +
            (BuscarCodigo(entregas, "E999", 0) != -1
                ? "Encontrado" : "No encontrado"));
        Console.WriteLine("Comparacion de sumas: " +
            (totalRecursivo == totalIterativo
                ? "Correcta" : "Incorrecta"));
    }
}
