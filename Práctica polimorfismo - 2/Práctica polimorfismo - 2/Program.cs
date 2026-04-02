using System;
using System.Collections.Generic;

namespace PolimorfismoAves
{
    // 1. CLASE PRINCIPAL (Clase Base)
    public class Ave
    {
        // Atributos que heredarán todas las clases derivadas
        public string Nombre { get; set; }
        public string Familia { get; set; }

        // Constructor de la clase base
        public Ave(string nombre, string familia)
        {
            Nombre = nombre;
            Familia = familia;
        }

        // Métodos que permiten que las clases derivadas los modifiquen
        public virtual void Volar()
        {
            Console.WriteLine($"{Nombre} está volando de forma genérica.");
        }

        public virtual void HacerSonido()
        {
            Console.WriteLine($"{Nombre} hace un sonido de ave.");
        }

        public virtual void Comer()
        {
            Console.WriteLine($"{Nombre} está comiendo comida genérica de ave.");
        }
    }

    // 2. CLASES DERIVADAS (Clases Polimorfas)

    public class Aguila : Ave
    {
        // El constructor llama al constructor de la clase base usando "base"
        public Aguila(string nombre) : base(nombre, "Accipítridos") { }

        // "override" sobrescribe el comportamiento del método original
        public override void Volar()
        {
            Console.WriteLine($"{Nombre} vuela a gran altura buscando presas.");
        }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} emite un chillido agudo y penetrante.");
        }

        public override void Comer()
        {
            Console.WriteLine($"{Nombre} desgarra carne con su pico afilado.");
        }
    }

    public class Pinguino : Ave
    {
        public Pinguino(string nombre) : base(nombre, "Esfeníscidos") { }

        public override void Volar()
        {
            // El pingüino modifica el método volar porque no puede hacerlo en el aire
            Console.WriteLine($"{Nombre} no puede volar en el aire, pero 'vuela' bajo el agua nadando rápidamente.");
        }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} hace un graznido ruidoso para comunicarse en la colonia.");
        }

        public override void Comer()
        {
            Console.WriteLine($"{Nombre} traga peces y krill enteros.");
        }
    }

    public class Loro : Ave
    {
        public Loro(string nombre) : base(nombre, "Psitácidas") { }

        public override void Volar()
        {
            Console.WriteLine($"{Nombre} revolotea ágilmente de rama en rama.");
        }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} repite palabras: '¡Hola! ¡Dame galleta!'.");
        }

        public override void Comer()
        {
            Console.WriteLine($"{Nombre} rompe semillas de girasol con su pico curvo.");
        }
    }

    // 3. PROGRAMA PRINCIPAL
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- DEMOSTRACIÓN DE POLIMORFISMO ---");

            // Creamos una lista del tipo de la clase BASE (Ave)
            // Pero instanciamos las clases DERIVADAS. Aquí ocurre el polimorfismo.
            List<Ave> reservaDeAves = new List<Ave>
            {
                new Aguila("Cazador"),
                new Pinguino("Tux"),
                new Loro("Paco")
            };

            // Iteramos sobre la lista de aves
            foreach (Ave miAve in reservaDeAves)
            {
                Console.WriteLine($"Especie/Familia: {miAve.Familia}");

                // Aunque la variable es de tipo 'Ave', se ejecutará el método 
                // modificado específico de la clase (Águila, Pingüino o Loro).
                miAve.HacerSonido();
                miAve.Volar();
                miAve.Comer();

                Console.WriteLine(new string('-', 50));
            }

            Console.ReadLine();
        }
    }
}