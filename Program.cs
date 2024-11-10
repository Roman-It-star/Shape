using System;

public interface IRotatable // Определяю интерфейс IRotatable для фигур, которые можно вращать
{
    void Rotate();
}

public abstract class Shape // Базовый класс Shape, который содержит общие свойства и методы
{
    // Абстрактные методы для расчета периметра и площади,
    // которые должны быть реализованы в производных классах
    public abstract double CalcuLatePerimeter();
    public abstract double CalcuLateArea();
}
public class Triangle : Shape, IRotatable // Класс Triangle, производный от Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double a, double b, double c) // Конструктор, позволяющий создать треугольник с заданными сторонами
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double CalcuLatePerimeter() // Реализация метода для расчета периметра треугольника
    {
        return SideA + SideB + SideC;
    }

    public override double CalcuLateArea()     // Реализация метода для расчета площади треугольника (формула Герона)
    {
        double s = CalcuLatePerimeter() / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public void Rotate() // Метод интерфейса для вращения треугольника
    {
        Console.WriteLine("Треугольник вращается вокруг своего центра.");
    }
}

public class Circle : Shape // Класс Circle, производный от Shape
{
    public double Radius { get; set; }

    public Circle(double radius) // Конструктор, позволяющий создать окружность с заданным радиусом
    {
        Radius = radius;
    }

    public override double CalcuLatePerimeter() // Реализация метода для расчета периметра (длина окружности)
    {
        return 2 * Math.PI * Radius;
    }

    public override double CalcuLateArea() // Реализация метода для расчета площади окружности
    {
        return Math.PI * Radius * Radius;
    }

    public void PrintRadius() // Метод для вывода значения радиуса
    {
        Console.WriteLine($"Радиус окружности: {Radius}");
    }
}

public class Square : Shape, IRotatable // Класс Square, производный от Shape и реализующий интерфейс IRotatable
{
    public double Side { get; set; }

    public Square(double side) // Конструктор, позволяющий создать квадрат с заданной стороной
    {
        Side = side;
    }

    public override double CalcuLatePerimeter() // Реализация метода для расчета периметра квадрата
    {
        return 4 * Side;
    }

    public override double CalcuLateArea() // Реализация метода для расчета площади квадрата
    {
        return Side * Side;
    }

    public void PrintSide() // Метод для вывода значения стороны квадрата
    {
        Console.WriteLine($"Сторона квадрата: {Side}");
    }

    public void Rotate() // Метод интерфейса для вращения квадрата
    {
        Console.WriteLine("Квадрат вращается вокруг своего центра.");
    }
}

public class Program // Основная программа
{
    public static void Main(string[] args)
    {
        // Создаем объект треугольника и выводим его периметр и площадь
        Triangle triangle = new Triangle(2, 3, 5);
        Console.WriteLine($"Периметр треугольника: {triangle.CalcuLatePerimeter()}");
        Console.WriteLine($"Площадь треугольника: {triangle.CalcuLateArea()}");
        triangle.Rotate(); // Вращаем треугольник

        // Создаем объект окружности
        Circle circle = new Circle(5);
        Console.WriteLine($"Периметр окружности: {circle.CalcuLatePerimeter()}");
        Console.WriteLine($"Площадь окружности: {circle.CalcuLateArea()}");
        circle.PrintRadius(); // Выводим радиус окружности

        // Создаем объект квадрат и выводим его периметр и площадь
        Square square = new Square(4);
        Console.WriteLine($"Периметр квадрата: {square.CalcuLatePerimeter()}");
        Console.WriteLine($"Площадь квадрата: {square.CalcuLateArea()}");
        square.PrintSide(); // Выводим сторону квадрата
        square.Rotate(); // Вращаем квадрат
    }
}