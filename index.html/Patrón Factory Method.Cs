using System;
using System.Collections.Generic;

//Paso 1: Interfaz para el aire acondicionado
public interface IAireAcondicionado
{
    void Operacion();
}

//Paso 2: Clases concretas de aire acondicionado
public class EnfriamientoAdm : IAireAcondicionado
{
    private double temperatura;

    public EnfriamientoAdm(double temperatura)
    {
        this.temperatura = temperatura;
    }

    public void Operacion()
    {
        Console.WriteLine($"Enfriar la habitación a la temperatura requerida de {temperatura} grados");
    }
}

public class CalentamientoAdm : IAireAcondicionado
{
    private double temperatura;

    public CalentamientoAdm(double temperatura)
    {
        this.temperatura = temperatura;
    }

    public void Operacion()
    {
        Console.WriteLine($"Calentar la habitación a la temperatura requerida de {temperatura} grados");
    }
}

//Paso 3: Clase abstracta para la fábrica de aire acondicionado
public abstract class AireAcondicionadoFactory
{
    public abstract IAireAcondicionado Crear(double temperatura);
}

//Paso 4: Fábricas concretas para el enfriamiento y calentamiento
public class EnfriamientoFactory : AireAcondicionadoFactory
{
    public override IAireAcondicionado Crear(double temperatura)
    {
        return new EnfriamientoAdm(temperatura);
    }
}

public class CalentamientoFactory : AireAcondicionadoFactory
{
    public override IAireAcondicionado Crear(double temperatura)
    {
        return new CalentamientoAdm(temperatura);
    }
}

//Paso 5: Enumerado para las acciones
public enum Acciones
{
    Enfriar,
    Calentar
}

// Paso 6:Cliente para el Factory Method
public class AireAcondicionado
{
    private Dictionary<Acciones, AireAcondicionadoFactory> fabricas = new Dictionary<Acciones, AireAcondicionadoFactory>();

    public AireAcondicionado()
    {
        fabricas[Acciones.Enfriar] = new EnfriamientoFactory();
        fabricas[Acciones.Calentar] = new CalentamientoFactory();
    }

    public void EjecutaCreacion(Acciones accion, double temperatura)
    {
        IAireAcondicionado aireAcondicionado = fabricas[accion].Crear(temperatura);
        aireAcondicionado.Operacion();
    }
}

class Program
{
    static void Main(string[] args)
    {
        AireAcondicionado aireAcondicionado = new AireAcondicionado();
        aireAcondicionado.EjecutaCreacion(Acciones.Calentar, 40);
    }
}
