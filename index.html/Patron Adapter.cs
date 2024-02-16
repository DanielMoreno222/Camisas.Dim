using System;
using System.Collections.Generic;

// Paso 1: Definición de la clase Pizza
public class Pizza
{
    public string TipoMasa { get; set; }
    public string Salsa { get; set; }
    public string Queso { get; set; }
    public List<string> Ingredientes { get; set; }

    public Pizza()
    {
        Ingredientes = new List<string>();
    }
}

// Paso 2: Definición de la interfaz IPizzaBuilder
public interface IPizzaBuilder
{
    void BuildTipoMasa();
    void BuildSalsa();
    void BuildQueso();
    void BuildIngredientes();
    Pizza GetPizza();
}

// Paso 3: Implementación del PizzaBuilder
public class PizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza;

    public PizzaBuilder()
    {
        _pizza = new Pizza();
    }

    public void BuildTipoMasa()
    {
        _pizza.TipoMasa = "masa delgada";
    }

    public void BuildSalsa()
    {
        _pizza.Salsa = "salsa de tomate";
    }

    public void BuildQueso()
    {
        _pizza.Queso = "queso mozzarella";
    }

    public void BuildIngredientes()
    {
        _pizza.Ingredientes.Add("jamón");
        _pizza.Ingredientes.Add("champiñones");
        _pizza.Ingredientes.Add("aceitunas");
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

// Paso 4: Uso del PizzaBuilder para construir una pizza
class Program
{
    static void Main(string[] args)
    {
        // Creamos una instancia de PizzaBuilder
        IPizzaBuilder pizzaBuilder = new PizzaBuilder();

        // Utilizamos los métodos del builder para construir la pizza
        pizzaBuilder.BuildTipoMasa();
        pizzaBuilder.BuildSalsa();
        pizzaBuilder.BuildQueso();
        pizzaBuilder.BuildIngredientes();

        // Obtenemos la pizza completa
        Pizza pizza = pizzaBuilder.GetPizza();

        // Paso 5: Resultado
        Console.WriteLine("¡Se ha construido una deliciosa pizza con los siguientes ingredientes y características!");
        Console.WriteLine($"Tipo de masa: {pizza.TipoMasa}");
        Console.WriteLine($"Salsa: {pizza.Salsa}");
        Console.WriteLine($"Queso: {pizza.Queso}");
        Console.WriteLine("Ingredientes:");
        foreach (var ingrediente in pizza.Ingredientes)
        {
            Console.WriteLine("- " + ingrediente);
        }
    }
}
