using System;

namespace HelloWorld
{
  class Program
  {
    static void Main()
    {
      // ------------ Números y strings ------------

      Console.WriteLine("------------ Ejemplo 1 ------------");
      
      const int profeDeUnity = 1;
      int alumnosEnClase = 11;

      Console.WriteLine("Hola amigos, somos " + (profeDeUnity + alumnosEnClase) );

      Console.WriteLine("------------ Ejemplo 2 ------------");

      char caracterNumero = '3';
      int numeroConvertido = Convert.ToInt32(caracterNumero);

      int edad = Convert.ToInt32(Console.ReadLine()); // 24
      string mensaje = "Tienes " + edad + " años"; // "Tienes 25 años"

      Console.WriteLine(mensaje);

      // ------------ Booleanos y condiciones ------------

      Console.WriteLine("------------ Ejemplo 3 ------------");

      bool connected = true;

      connected = !connected; // false
      connected = !connected; // true

      // Operadores lógicos
      // NOT (!), AND (&&), OR (||)

      bool isVisible = true;
      bool isActive = false;
      bool isAlive = true;

      bool show = isActive && (!isVisible || isAlive);

      Console.WriteLine(show);

      Console.WriteLine("------------ Ejemplo 4 ------------");

      bool isDead = true;
      int missiles = 10;

      // Condicional

      if ( !isDead && missiles > 0 ) {

        // Lógica de disparo
        Console.WriteLine("Payum, payum!");
      }
      else {

        // Otras cosas
        Console.WriteLine("Toy mueto");
      }

      // Bucle

      // 1) Valor inicial
      int times = 0;

      // 2) Condición de parada
      while ( times < 3 ) {

        Console.WriteLine("Bitelchús");

        // 3) Operación de cambio
        times++;
      }
    }
  }
}