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

## Nivel 6

- Retomando el ejercicio del Nivel 3 (o escenario más o menos equivalente), se pide implementar un sistema de movimiento WASD y cámara con ratón en primera persona que permita al jugador moverse de izquierda a derecha, adelante y atrás.

- Además, debe poder saltar, agacharse y correr, pulsando las teclas Espacio, Ctrl Izquierdo y Shift Izquierdo respectivamente.

- El jugador podrá disparar con el click izquierdo del ratón siempre un disparo recto hacia delante desde donde esté y hacia donde esté mirando. Si impacta con un pato, ganará 1 punto. Si impacta con el DuckBoss, ganará 2 puntos.

- Los patos dispararán también, de manera que el disparo se originará en el pato y se dirigirá hacia la posición del jugador, pudiendo matarse entre ellos.

- Respawn: Añadir un contador de tiempo que cada 15 segundos (en tiempo real) instancie un nuevo pato en la escena, y cada minuto instancie un DuckBoss.

- Minimapa y jumbotron: Añadir un minimapa ortográfico superpuesto arriba a la derecha de la pantalla y además dentro del juego un jumbotron que cada 5 segundos vaya cambiando su proyección entre 3 posibles cámaras puestas alrededor del campo de batalla.

- Modo 2 jugadores con pantalla partida:
  - Antes de entrar en el juego, mostrar una Pantalla de Selección de Modo: "1 Jugador" o "2 Jugadores".
  - Si se elige el primer modo, se carga la misma escena en la que se ha estado trabajando en los requisitos anteriores.
  - Si se elige el segundo, se carga otra escena, que puede ser una copia de la anterior, solo que con las siguientes diferencias:
    - Hay dos jugadores, uno juega con teclas WASD y ratón y otro con mando (si no se tiene mando con qué probar, poner otras teclas).
    - La pantalla se divide a la mitad (en horizontal o vertical, como se desee).
    - Cada jugador tiene su propia puntuación.

  ### Versiones

  1. Sniper mode:
      - Cuando se hace clic el disparo traza un rayo y si impacta lo hace de inmediato, matando al pato al instante. Si no, no ocurre nada.
  
  2. Gun mode:
      - Cuando se hace clic el disparo instancia un proyectil cuya dirección será la del rayo generado. Si no hay impacto, se resta un punto y el disparo no ocurre.
  
  3. Raziel mode:
      - El juego comienza con 4 patos en el mundo real (el de los vivos) y 2 patos en el mundo espectral.
      - El jugador puede alternar entre estar en el mundo de los vivos y el de los muertos pulsando la tecla V.
      - En el mundo de los vivos:
        - Solo son visibles los patos vivos (los muertos no).
        - Se aplican las mismas reglas del "Gun mode" anterior.
        - Cuando un pato muere, va al mundo de los muertos (y por tanto deja de ser visible en el de los vivos).
      - En el mundo de los muertos:
        - Son visibles tanto los patos vivos como los muertos.
        - Se aplican las mismas reglas del "Gun mode" anterior, pero solo con los muertos, de manera que no es posible matar a un vivo desde este mundo espectral, ni del mismo modo ser impactado por un pato vivo en este plano.
        - Cuando un pato muerto es rematado, desaparece de toda existencia y da 1 punto (salvo el DuckBoss que da 2).

## Nivel 7

- Crear un personaje a partir de los modelos y animaciones de Mixamo que tenga los siguientes clips: en reposo, andar, correr, saltar.

- Crear las transiciones necesarias para generar la siguiente máquina de estados:

  1. En reposo <--> Andar
  2. Andar <--> Correr
  3. Cualquiera (excepto Saltar) --> Saltar
  4. Saltar --> La anterior (desde la que se saltó)

- Implementar las siguientes condiciones a cumplir para cada una de las transiciones anteriores:

  1. Mantener pulsada cualquiera de las teclas WASD.
  2. Mantener pulsada la tecla Shift Izquierdo.
  3. Pulsar una vez la tecla Espacio.
  4. Pasados 2 segundos desde el inicio del salto.

- Crear una escena 3D para un juego de plataformas (tipo Super Mario 3D) con escaleras, rampas, paredes y plataformas que se muevan.

- Usar el personaje creado con CharacterController para moverlo con el método Move, de manera que sea capaz de moverse por el escenario, saltar, hacer doble salto y tirar bolas de fuego con la mano. Cada movimiento debe cargar su animación correspondiente.

- Crear un segundo personaje que represente un enemigo y moverlo con el método SimpleMove de CharacterController.

- Cuando impacte una bola de fuego del personaje con el enemigo, este saldrá despedido hacia atrás y desaparecerá de la escena a los 1,5 segundos.

- Cuando un enemigo toque al personaje, este caerá muerto como una muñeca de trapo, perderá una vida (de 3, al perder todas se acaba el juego) y a los 3 segundos volverá a levantarse (si aún le quedan vidas).

- Crear un selector de personajes que permita elegir entre al menos 2 personajes distintos, con modelos 3D diferentes pero las mismas animaciones y mecánicas, alterando los valores para cada personaje de manera que estén lo más balanceados posible. Por ejemplo, un personaje podría saltar más alto pero correr menos, otro tirar bolas de fuego más rápidas, o de dos en dos, pero no tener doble salto, etc.

## Nivel 8

- Partiendo del proyecto de Kroz, crear con el editor una mazmorra que cumpla con la forma del mapa (solo el suelo, aunque se pueden meter rampas y muros con distintas formas si se desea).

- Añadir algunos (o todos, preferentemente) de los elementos del projecto Kroz:

      C: Comienzo  
      D: Dragón  
      P: Puerta  
      L: Llave  
      E: Espada oxidada  
      O: Oro  
      T: Trampa  
      Q: Quitaóxido  
      S: Sepulcro  
      I: Inscripción  
      R: Ratas  

- Establecer los obstáculos (por ejemplo, las ratas) y puntos de salto (por ejemplo, la trampa) que se consideren.

- Crear un sistema de navegación con un personaje y los elementos anteriores que permita moverlo haciendo point-and-click sobre la mazmorra con una perspectiva isométrica (que siga al personaje).

- Modificar la escena (añadiendo y modificando los objetos que sean necesarios) para que haya obstáculos en movimiento, saltos desde diferentes alturas y máscaras de área con distintos costes para el sistema de navegación, así como algunos agentes más (enemigos) que no puedan recorrer ciertas zonas concretas.

- Añadir un personaje no jugador (NPC) que sea aliado del personaje jugador, de manera que le siga siempre poniéndose detrás (como un buen escudero) y cuando esté cerca de un enemigo vaya hacia él y lo destruya, volviendo después al lado del jugador. Si hay un ítem cerca, también debe recogerlo y añadirlo al inventario del jugador.