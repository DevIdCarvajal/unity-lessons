# Proyecto 1: Quantum Pong (Propuesta de solución)

## Versión 1: Mecánicas y objetos básicos

### Objetos

- Barra del jugador izquierdo
- Barra del jugador derecho
- Pelota
- Escenario
- Pared superior
- Pared inferior
- Límite izquierdo
- Límite derecho
- Puntuación del jugador izquierdo
- Puntuación del jugador derecho
- Efectos de sonido:
  - Golpear pelota
  - Pelota no atrapada

### Lógica

1. Barra de jugador
  1.1. Subir/bajar dentro de los límites (superior/inferior) de la pantalla
    - Cuando el jugador toque la tecla arriba/abajo
2. Pelota
  2.1. Avanzar en un sentido aleatorio en los ejes X e Y
    - Automáticamente al comienzo del turno
  2.2. Cambiar de sentido en el eje Y
    - Al rebotar contra una pared superior/inferior
  2.3. Cambiar de sentido en los ejes X e Y y aumentar su velocidad
    - Al rebotar contra una barra de jugador
  2.4. Destruirse
    - Al salir de los límites (laterales) de la pantalla
3. Puntuación
  3.1. Actualizarse
    - Al salir la pelota de los límites laterales
  3.2. Cargar siguiente turno
    - Si la puntuación actualizada no llega a 10
  3.3. Cargar mensaje de victoria y parar el juego
    - Si la puntuación actualizada llega a 10
4. Efectos de sonido
  4.1. Efecto 1
    4.1.1. Reproducirse una vez
      - Al chocar la pelota con una barra de jugador
  4.2. Efecto 2
    4.2.1. Reproducirse una vez
      - Al llegar la pelota a uno de los límites laterales

## Versión 2: Pantallas de inicio y fin

...

## Versión 3: Modo Quantum

...
