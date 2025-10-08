# Actividades asincrónicas

### Guía de preguntas de repaso conceptual

1. ¿Qué es un Framework?
2. ¿Qué son los frozen-spots en un Framework?
3. ¿Qué son los hot-spots en un Framework?
4. ¿Cómo se puede clasificar un Framework según su extensibilidad?
5. ¿Qué es un Framework de Caja Blanca?
6. ¿Qué es un Framework de Caja Negra?
7. ¿Qué ventajas posee utilizar un Framework?
8. ¿Qué problemas resuelve .NET Framework?
9. ¿Qué es y qué permite hacer el CLR?
10. ¿Qué es el MSIL?
11. ¿Qué es el CTS?
12. ¿Qué es el CLS?
13. ¿Dónde se encuentran las instancias de los objetos administrados por el GC?
14. ¿Cuáles son los dos métodos más notorios que deben implementar las clases para trabajar correctamente con la recolección de elementos no utilizados y matar las instancias administradas y no administradas?
15. ¿De dónde heredan las clases el método Finalize?
16. ¿Cuál es la firma que implementa el método “Finalize”?
17. ¿Qué método se utiliza para que el GC recolecte los elementos no utilizados?
18. ¿Qué método se utiliza para suspender el subproceso actual hasta que el subproceso que se está procesando en la cola de finalizadores vacíe dicha cola?
19. ¿Cuándo se ejecuta el método collect del GC que método se ejecuta en los objetos afectados?
20. ¿Qué método debería exponer una clase bien diseñada teniendo en consideración que no posee destructor?
21. ¿Cómo obtengo el método “Dispose”?
22. ¿Qué se programa en el método “Dispose”?
23. ¿Se pueden combinar el uso de “Dispose” y “Finalize”?
24. ¿A qué se denomina “Resurrección de Objetos”?
25. ¿A qué se denomina “Generación” en el contexto de la recolección de elementos no utilizados?
26. ¿Qué valores puede adoptar la “Generación” de un objeto?
27. ¿Cómo se puede obtener el número de veces que se ha producido la recolección  de  elementos  no  utilizados  para  la  generación  de  objetos especificada?
28. ¿Cómo se obtiene el número de generación actual de un objeto?
29. ¿Cómo se puede recuperar el número de bytes que se considera que están asignados en la actualidad?
30. ¿Qué utiliza para convertir un objeto en “no” válido para la recolección de elementos no utilizados desde el principio de la rutina actual hasta el momento en que se llamó a este método?
31. ¿Cómo se solicita que el sistema no llame al finalizador del objeto especificado?
32. ¿Cómo se solicita que el sistema llame al finalizador del objeto especificado, para el que previamente se ha llamado a “SuppressFinalize”?
33. ¿Cómo se obtiene el número máximo de generaciones que el sistema admite en la actualidad?

### Guía de ejercicios

1. Desarrollar un programa que genera varias instancias (una cantidad importante),  verifique la memoria utilizada, pase el GC y vuelva a verificar el espacio de memoria. ¿Qué se observa?

2. Desarrollar un programa que genere una instancia, pierda la referencia a la misma y aplicando la técnica de “resurrección de objetos” logre obtener la referencia a ese mismo objeto.
