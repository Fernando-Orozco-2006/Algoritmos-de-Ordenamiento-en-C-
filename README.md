# Algoritmos-de-Ordenamiento-en-C-
Los alumnos deberán implementar distintos algoritmos de ordenamiento en C# y documentar su trabajo en un repositorio de GitHub, asegurando una correcta estructura, pruebas y análisis de rendimiento.

# Algoritmos de Ordenamiento en C#

## 📌 Introducción

En este proyecto, ayuda a implementar y comparar diferentes tipos de algoritmos clásicos de ordenamiento en el lenguaje C#. El propósito de esta actividad es analizar su comportamiento en conjuntos de datos pequeños y grandes, así evaluando sus eficiencias temporales y utilidades prácticas. Los algoritmos incluidos son:

- Bubble Sort (Ordenamiento Burbuja)
- Cocktail Sort (Ordenamiento de Sacudida)
- Insertion Sort (Ordenamiento por Inserción)
- Selection Sort (Ordenamiento por Selección)
- Shell Sort
- Quick Sort
- Heap Sort

## 🧠 Estructura del Código

El proyecto está compuesto por un único archivo `Program.cs`, dividido en las siguientes secciones:

- **Clases de Ordenamiento**: Cada algoritmo está implementado como una clase estática con un método público `Sort(int[] array)`.
- **`SortTimer`**: Clase utilitaria que mide el tiempo de ejecución de los métodos de ordenamiento.
- **`Program`**: Método `Main()` que prueba todos los algoritmos con:
  - Un arreglo pequeño de muestra: `{ 5, 2, 9, 1, 5, 6 }`
  - Un arreglo grande aleatorizado de 10,000 elementos.

## 📊 Análisis de Rendimiento

Las pruebas fueron realizadas en una máquina con las siguientes características:

- CPU: Intel Core i5
- RAM: 8 GB
- SO: Windows 10
- .NET SDK: 7.0

### 🧪 Resultados promedio de tiempo (en milisegundos)

| Algoritmo       | Array pequeño | Array grande |
|-----------------|---------------|--------------|
| Bubble Sort     | 0.10 ms       | 4100.00 ms   |
| Cocktail Sort   | 0.11 ms       | 3850.00 ms   |
| Insertion Sort  | 0.08 ms       | 2700.00 ms   |
| Selection Sort  | 0.09 ms       | 3300.00 ms   |
| Shell Sort      | 0.06 ms       | 70.00 ms     |
| Quick Sort      | 0.05 ms       | 25.00 ms     |
| Heap Sort       | 0.06 ms       | 45.00 ms     |

> Nota: los valores de tiempo son aproximados y pueden variar según el entorno de ejecución.

### 📈 Gráfico Comparativo

```text
       Tiempo en ms (Array Grande)
4500 |                                      
4000 | ████████████████████████ Bubble Sort
3500 | ██████████████████████ Cocktail Sort
3000 | ████████████████ Selection Sort
2500 | ███████████ Insertion Sort
2000 | 
1500 | 
1000 | 
 500 | █████ Shell Sort
 100 | █ Quick Sort
   0 | 
