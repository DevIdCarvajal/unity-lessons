# Virtual Darts (Unity Version)

## Escena 1: Inicio

### Objetos

- Título
- Imagen de fondo
- Botón de comienzo
- Música de fondo

### Lógica

1. Botón de comienzo
  1.1. Cambiar a la Escena 2
    - Cuando el jugador pinche en el botón
2. Música de fondo
  2.1. Reproducirse
    - Automáticamente al comienzo de la escena

## Escena 2: Juego

### Objetos

- Diana
- Dardo
- Puntuación

### Lógica

- Por cada turno y hasta 10 turnos:

  1. Diana
    1.1. Sumar puntuación
      - Cuando es impactada por un dardo

  2. Dardo
    2.1. Si no está en movimiento:

      2.1.1. Mover izquierda/derecha/arriba/abajo
        - Cuando el jugador pulsa la tecla iz/de/ar/ab
        - Si está dentro de los límites
  
      2.1.2. Lanzarse
        - Cuando el jugador pulsa la tecla espacio
  
    2.2. Si está en movimiento:

      2.2.1. Pararse (y pasar turno)
        - Cuando impacta con la diana
  
      2.2.2. Destruirse (y pasar turno)
        - Cuando no impacta con la diana
  
      2.2.3. Chocar (y pasar turno)
        - Cuando impacta con otro dardo

- Al llegar al último turno, cambiar a la Escena 3

## Escena 3: Fin

### Objetos

- Imagen de fondo
- Puntuación final
- Botón de volver a empezar

### Lógica

1. Botón de volver a empezar
  1.1. Cambiar a la Escena 1
    - Cuando el jugador pinche en el botón
2. Música de fondo
  2.1. Pararse
    - Cuando el jugador pinche en el botón

## Referencias

https://es.wikipedia.org/wiki/Diagrama_de_flujo
https://quaternions.online/

https://sketchfab.com/
http://archive.org/

https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html

https://gamedevtraum.com/en/game-development/basic-unity-engine-management/how-to-use-canvas-buttons-in-unity/
https://gamedevbeginner.com/how-to-play-audio-in-unity-with-examples/