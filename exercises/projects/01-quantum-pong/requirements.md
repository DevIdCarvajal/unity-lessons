# Proyecto 1: Quantum Pong (Enunciado)

Se pide implementar con Unity un Pong con algunas modificaciones extra que lo hagan un juego más moderno.

Para ello, se deben implementar las siguientes versiones de manera que cumplan los siguientes requisitos:

## Versión 1: Mecánicas y objetos básicos

Para esta primera versión, que será lo más fiel posible al juego original, se tendrán en cuenta los siguientes elementos y acciones:

- El juego se desarrolla en un escenario en dos dimensiones que se presenta en su totalidad en la pantalla y es estático, de manera que siempre se ve todo lo que ocurre.

- Consta de dos jugadores humanos donde cada uno controla una "raqueta" en forma de barra que se mueve arriba y abajo con las teclas del teclado. Estas raquetas se sitúan en los extremos laterales del escenario y no pueden salirse de la pantalla, desplazándose solamente en el eje vertical.

- Cada jugador tiene un marcador de puntos que aparece en la parte superior, en su lado correspondiente, que empieza en cero y va creciendo de uno en uno.
  
- Existe también una pelota que aparece en el centro y avanza en el plano bidimensional del escenario siguiendo una dirección y sentido tanto vertical como horizontal con una velocidad de movimiento determinada, hacia uno de los jugadores elegido aleatoriamente.

- La pelota rebota tanto en las raquetas de los jugadores como en los límites superior e inferior. Cuando lo hace, emite un sonido característico. Además, cuando rebota en una raqueta, aumenta levemente su velocidad.

- Si un jugador no llega a la pelota, esta desaparece fuera del escenario y se anota un punto en el marcador del otro jugador. Además, se emite un sonido característico.

- Si la puntuación de cualquiera de los dos jugadores se ha visto incrementada y ha llegado a 10, el juego termina con un mensaje de victoria para el vencedor. En otro caso la pelota reaparece en el centro con la velocidad de movimiento del inicio de la partida, moviéndose hacia el jugador que anotó el punto.

---

## Versión 2: Pantallas de inicio y fin

En esta segunda versión se pide que el juego tenga una pantalla de inicio y una pantalla de fin, que deben contener los siguientes elementos de interfaz de usuario y comportamientos:

- Pantalla de inicio

  - Un botón de "Empezar", que carga el juego descrito en la Versión 2.
  - Un botón de "Salir", que cierra la aplicación y sale al sistema operativo.

- Pantalla de fin

  - Un botón de "Volver a jugar", que carga el juego descrito en la Versión 2.
  - Un botón de "Salir", que cierra la aplicación y sale al sistema operativo.
  - La puntuación final obtenida por ambos jugadores y un mensaje que indique cuál de ellos ha sido el vencedor.

---

## Versión 3: Modo Quantum

En esta última versión se pueden añadir uno o más de los siguientes:

- Que en la pantalla de inicio se pueda elegir entre:
  - 1P vs 2P (Humano contra humano): Este modo es exactamente la Versión 1.
  - 1P vs CPU (Humano contra máquina): Este modo implica desarrollar una inteligencia artificial (IA) para que controle una de las raquetas en lugar de un ser humano. Esta IA debe ser capaz de golpear la pelota la mayor parte de las veces pero también de fallar de vez en cuando.

- Power-ups: Aleatoriamente deben aparecer iconos de elementos que si son tocados por la bola, ocasionarán ciertos cambios temporales en la partida. Estos cambios perdurarán hasta que uno de los dos jugadores consiga puntuar. Cuando la bola toca un power-up, sigue su dirección y sentido normalmente, y los efectos del power-up se aplican de inmediato.

  - Velocidad del jugador: Si tras golpear la pelota, esta toca este power-up, la raqueta del jugador que acaba de golpearla tendrá más velocidad.
  
  - Velocidad de la pelota: Tras tocar este power-up, la pelota irá más deprisa.
  
  - Tamaño del jugador: Si tras golpear la pelota, esta toca este power-up, la raqueta del jugador que acaba de golpearla crecerá un poco.
  
  - Tamaño de la pelota: Tras tocar este power-up, la pelota será más pequeña.

- Tiempo: Un cronómetro que marca la duración completa de la partida, de manera que si se acaba el tiempo, aparece la pantalla de fin mostrando como ganador el que más puntos tiene. Si hay empate, lo indicará también.

- 4 jugadores: En esta versión, el escenario es cuadrado, no rectangular, y hay 4 raquetas, arriba, abajo, izquierda y derecha. Hay 4 marcadores de puntuación y la pelota no rebota en los límites del escenario, sino que siempre marca un punto para el último jugador que la golpeó, en caso de que la raqueta que esté en ese lado del cuadrado por el que se salió del escenario no consiga atraparla.

---

## Notas adicionales

En cualquiera de las tres versiones se pide lo siguiente:

1) Crear un repositorio de GitHub y subir el proyecto a dicho repositorio (excluyendo mediante .gitignore lo que proceda).

2) A medida que se vayan cerrando versiones, generar localmente los respectivos Builds y probar el proyecto en la máquina de desarrollo.

3) El juego debe ser desarrollado en 2.5D, es decir, en un pseudo-2D desarrollado en un entorno tridimensional. La estética y el look-and-feel es totalmente libre, no tiene por qué imitar completamente al juego original, si bien se recomienda trabajar con objetos y assets sencillos.