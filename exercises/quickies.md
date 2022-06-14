# Ejercicios

## Nivel 1

- Crear en Unity una versión simulada del camino de toris rojos del santuario Fushimi Inari en Kyoto (Japón).
- Crear una lámpara de pie que muestre una luz en todas direcciones.

## Nivel 2

- Crear un proyecto Unity llamado "PoolRoom" que tenga las siguientes escenas:
    - Una diana con dardos.
    - Una mesa de billar con taco y bolas.
- Añadir los componentes y scripts necesarios para dotar de algún tipo de interacción a los elementos de cada una de las escenas.
- Añadir los scripts para mostrar por consola un sistema de puntuación en cada una de las escenas.

## Nivel 3

- Crear un juego de feria en el que una pistola que se mueve de izquierda a derecha dispare un proyectil "de agua" a un pato y si le impacta, el pato "caiga" (rote 90).
- Nivel 2 de dificultad: Que el pato se mueva.
- Nivel asiático: Que haya muchos patos.
- Nivel Dark Souls asiático: Que haya un sistema de puntuación.
- Nivel Modo Dios: Con una pantalla de inicio previa y música de fondo.

## Nivel 4

- Crear una cuna o péndulo de Newton usando el sistema de físicas con cuerpos rígidos y articulaciones de bisagra.

- Crear un juego de bolera en el que con las teclas se calcule el ángulo de lanzamiento de la bola por un lado, la posición inicial de la bola en la pista al lanzarla (izquierda-derecha) por otro, y con el espacio se lance la bola por la pista hacia los bolos.

- Crear un juego de ruleta de la suerte en el que se imprima una fuerza de rotación ("torque") a la ruleta y cuando se pare, saque por consola la puntuación del "gajo" en el que se paró.

- Crear un juego de billar con 3 bolas en el que con las teclas se calcule el ángulo de rotación y con el espacio dejándolo apretado la fuerza con la que se dispara la bola blanca.

## Nivel 5

- Retomando el ejercicio del Nivel 1 (o escenario más o menos equivalente), se pide implementar un sistema de movimiento WASD y cámara con ratón en primera persona que permita al jugador pasar por debajo de los toris.

- Añadir al proyecto anterior un sistema de puntuación que anote un punto por cada tori y lo muestre en un texto en la GUI arriba a la derecha.

- Modificar algunos toris para que estén al revés (con el travesaño a ras de suelo y las columnas hacia arriba, como formando una U).

- Dar al jugador la posibilidad de saltar por encima de los toris volteados. Cuando lo haga (sin pisarlos), estos darán doble puntuación al marcador de arriba a la derecha.

- Añadir un sistema de control de cámaras que tenga 3 cámaras: primera persona, tercera persona (detrás del personaje) y vista cenital. Para cambiar entre las cámaras, deberá hacerse con los 3 botones del ratón, asignando una cámara a cada botón.

NOTA: Los toris deben ser objetos colisionables, de manera que el jugador no pueda atraversarlos.