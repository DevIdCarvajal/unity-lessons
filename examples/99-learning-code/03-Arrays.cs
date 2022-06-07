using System;

namespace Arrays
{
  class Program
  {
    static void Main()
    {
      // ------------ Arrays ------------
      
      Console.WriteLine("------------ Ejemplo 1 ------------");
      
      int[] balls = { -87, 12 };

      Console.WriteLine("El primer número del array es el " + balls[0]);

      balls[0] = -7;

      Console.WriteLine("El primer número del array es el " + balls[0]);
      
      Console.WriteLine("------------ Ejemplo 2 ------------");
      
      string[] players = new string[4];

      players[1] = "David";

      Console.WriteLine("El  segundo jugadorse llama " + players[1]);
      
      // ------------ Bucle for y recorrer un array ------------

      Console.WriteLine("------------ Ejemplo 3 ------------");
      
      int[] scores = { 0, 0, 0 };
      //int[] scores = new int[3];

      Console.WriteLine("Puntuación Ronda 1");
      scores[0] = Convert.ToInt16( Console.ReadLine() );

      Console.WriteLine("Puntuación Ronda 2");
      scores[1] = Convert.ToInt16( Console.ReadLine() );

      Console.WriteLine("Puntuación Ronda 3");
      scores[2] = Convert.ToInt16( Console.ReadLine() );

      int totalScore = 0;

      // Desde el primer elemento hasta el último
      /*
      int i = 0;

      while (i < scores.Length) {
        //totalScore = totalScore + scores[i];
        totalScore += scores[i];

        i++;
      }
      */

      for (int i = 0; i < scores.Length; i++) {
        totalScore += scores[i];
      }

      /*
        // TODO
        
        Nota final:
          - Si la suma total de puntos va de  0 a 29 --> C
          - Si la suma total de puntos va de 30 a 59 --> B
          - Si la suma total de puntos va de 60 a 89 --> A
          - Si es 90 o más                           --> S
      */

      Console.WriteLine("Puntuación Total: " + totalScore);
    }
  }
}