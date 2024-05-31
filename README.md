# ACME School Management

## Descripción

Este proyecto proporciona un sistema básico para gestionar estudiantes y cursos en la escuela ACME. Permite registrar estudiantes adultos, registrar cursos, y permitir que los estudiantes se inscriban en cursos. La información se gestiona en memoria y no hay dependencias en bases de datos o servicios externos.
- He utilizado los patrones UnitOfWork y Repository para abstraer las operaciones relacionadas con la persistencia de datos. Esto facilitará la implementación de una base de datos en el futuro.
- Para abordar los problemas de persistencia y concurrencia, he empleado ConcurrentBag en lugar de una lista simple.
- Todo el código está desarrollado contra abstracciones, siguiendo los principios SOLID, lo que permite una mayor claridad y extensibilidad del código.
- Además, he creado un servicio que simula una pasarela de pago con una implementación por defecto, pensando en facilitar la creación de una implementación correcta en el futuro.
- Finalmente, he realizado pruebas unitarias independientes para toda la aplicación, utilizando librerías como FluentAssertions con la finalidad de que el lenguaje sea más orgánico y Moq para simular comportamientos convenientes para las pruebas. Estas pruebas heredan de una clase abstracta, lo que asegura que se sigan estándares consistentes al aplicarlas.

## Cosas por Mejorar

- Persistencia de datos en una base de datos.
- Integración con una pasarela de pago.
- Publicación de la funcionalidad como API.

## Bibliotecas Utilizadas

- [xUnit.net](https://xunit.net/) para pruebas unitarias.

## Tiempo Invertido

- Desarrollo: 4 horas.
- Investigación: 0 horas.
- Pruebas: 2 horas.
