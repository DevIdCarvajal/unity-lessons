# Teteris Dosdé

## Objetos

- Piezas
- Escenario y Fondo
- Límite izquierdo
- Límite derecho
- Límite superior
- Límite inferior
- Puntuación
- Efectos de sonido

### Lógica

1. Pieza
    - Aparecer en el límite superior, elegida aleatoriamente
        - Si es la primera (al principio del juego)
        - Si es la segunda o sucesivas, cuando se haya colocado la pieza anterior
    - Mover un paso a la izquierda/derecha (dentro de los límites)
        - Cuando el jugador pulse la tecla Izquierda/Derecha
    - Mover un paso hacia abajo
        - Mientras el jugador pulse la tecla Abajo
        - Cada 2 segundos, y después, cada vez más deprisa
            - Cada 3000 puntos
    - Rotar hacia la izquierda/derecha (dentro de los límites)
        - Cuando el jugador pulse la tecla Ctrl-Izda/Espacio
    - Parar
        - Cuando choque con el límite inferior
        - Cuando choque con otra pieza por debajo
    - Hacer una o más líneas
        - Cuando se cubran 1 o más filas tras colocar la pieza
2. Puntuación
    - Actualizarse al hacer una o más líneas:
        - 1 línea:  100 puntos
        - 2 líneas: 250 puntos
        - 3 líneas: 375 puntos
        - 4 líneas: 500 puntos
3. Efectos de sonido
    - Música de fondo
    - Rotar la pieza
    - Colocar la pieza
    - Hacer una o más líneas
4. Fin del juego
    - Cuando la última pieza colocada sobresalga del límite superior
5. Cambio de skin (nivel)
    - Cada 9000 puntos