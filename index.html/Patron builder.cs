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
    private Pizza _pizza = new Pizza();

    public void BuildTipoMasa()
    {
        _pizza.TipoMasa = "Delgada";
    }

    public void BuildSalsa()
    {
        _pizza.Salsa = "Tomate";
    }

    public void BuildQueso()
    {
        _pizza.Queso = "Mozzarella";
    }

    public void BuildIngredientes()
    {
        _pizza.Ingredientes.Add("Jamón");
        _pizza.Ingredientes.Add("Champiñones");
        _pizza.Ingredientes.Add("Aceitunas");
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

class Program
{
    // Paso 4: Uso del PizzaBuilder para construir una pizza
    static void Main(string[] args)
    {
        IPizzaBuilder pizzaBuilder = new PizzaBuilder();
        pizzaBuilder.BuildTipoMasa();
        pizzaBuilder.BuildSalsa();
        pizzaBuilder.BuildQueso();
        pizzaBuilder.BuildIngredientes();

        Pizza pizza = pizzaBuilder.GetPizza();

        // Paso 5: Resultado
        Console.WriteLine("Pizza construida:");
        Console.WriteLine($"Tipo de masa: {pizza.TipoMasa}");
        Console.WriteLine($"Salsa: {pizza.Salsa}");
        Console.WriteLine($"Queso: {pizza.Queso}");
        Console.WriteLine("Ingredientes:");
        foreach (var ingrediente in pizza.Ingredientes)
        {
            Console.WriteLine(ingrediente);
        }
    }
}
