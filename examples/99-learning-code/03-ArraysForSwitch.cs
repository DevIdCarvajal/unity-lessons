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
      
      // ------------ Bucles for, foreach y recorrer un array ------------

      Console.WriteLine("------------ Ejemplo 3 ------------");
      
      int[] scores = { 0, 0, 0 };
      //int[] scores = new int[3];

      for (int i = 0; i < scores.Length; i++) {

        Console.WriteLine("Puntuación Ronda " + (i+1));
        scores[i] = Convert.ToInt16( Console.ReadLine() );
      }

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

      for (int j = 0; j < scores.Length; j++) {
        totalScore += scores[j];
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

      Console.WriteLine("------------ Ejemplo 4 ------------");
      
      // Dado un array de letras, escribir todas por consola

      char[] letters = { 'a', 'b', 'c', 'b' };
      
      foreach (char letter in letters) {
        
        Console.WriteLine(letter);
      }
      
      Console.WriteLine("------------ Ejemplo 5 ------------");
      
      // Dado otro array de letras, escribir por consola la posición del array en la que está la primera 'b'
      int position = -1;
      char[] moreLetters = { 'a', 'b', 'c', 'b' };
      
      // Versión sin break
      
      int k = 0;
      bool foundB = false;
      
      while(k < moreLetters.Length && !foundB) {
        
        if(moreLetters[k] == 'b') {
          position = k;

          foundB = true;
        }
        
        k++;
      }

      Console.WriteLine(position);

      // Versión con break

      for (int l = 0; l < moreLetters.Length; l++) {
        
        if(moreLetters[l] == 'b') {
          position = l;
          break;
        }
      }
      
      Console.WriteLine(position);
      
      // ------------ Switch ------------

      Console.WriteLine("------------ Ejemplo 6 ------------");
      
      int option = Convert.ToInt16( Console.ReadLine() );

      /*
      if(option == 1) {
        Console.WriteLine("Arcade");
      }
      else
      if(option == 2) {
        Console.WriteLine("VS");
      }
      else
      if(option == 3) {
        Console.WriteLine("Options");
      }
      else
      if(option == 4) {
        Console.WriteLine("Quit");
      }
      else {
        Console.WriteLine("Por favor, escriba del 1 al 4");
      }
      */

      switch (option) {
        case 1:
          Console.WriteLine("Arcade");
          break;
        case 2:
          Console.WriteLine("VS");
          break;
        case 3:
          Console.WriteLine("Options");
          break;
        case 4:
          Console.WriteLine("Quit");
          break;
        default:
          Console.WriteLine("Por favor, escriba del 1 al 4");
          break;
      }
    }
  }
}