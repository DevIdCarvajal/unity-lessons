using System;

namespace FizzBuzz
{
  class Program
  {
    static void Main()
    {
      /*
        1) Contar hasta 100 --> while: inicial, condición y el cambio

        2) Calcular múltiplos de 3, de 5 y de 15 --> Operaciones aritméticas

          2.1) Calcular múltiplos de 3 --> Fizz
          2.2) Calcular múltiplos de 5 --> Buzz
          2.3) Calcular múltiplos de 15 --> FizzBuzz
          2.4) Decir el número en otro caso

        3) Salida (por Consola) dependiente del cálculo anterior --> Condicional
      */

      int i = 0;

      while (i < 100) {
        i++;

        if (i % 15 == 0) { // Si es múltiplo de 15
          Console.WriteLine("FizzBuzz");
        }
        else
        if (i % 3 == 0) { // Si es múltiplo de 3
          Console.WriteLine("Fizz");
        }
        else
        if (i % 5 == 0) { // Si es múltiplo de 5
          Console.WriteLine("Buzz");
        }
        else {
          Console.WriteLine(i);
        }
      }
    }
  }
}