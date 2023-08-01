using System;

void sayHello() {
  Console.WriteLine("Ola k ase");
}

sayHello();
sayHello();
sayHello();

// ----------------------------------

int sumar(int numero1, int numero2) {

  int resultado = numero1 + numero2;

  return resultado;
}

Console.WriteLine( sumar(2, 3) );
Console.WriteLine( sumar(5, 6) );