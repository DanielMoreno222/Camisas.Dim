using System;

// Paso 1: Crear un implementador abstracto (IMessageSender)
public interface IMessageSender
{
    void SendMessage(string message);
}

// Paso 2: Creación de implementadores concretos (SmsMessageSender y EmailMessageSender)
public class SmsMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Enviando mensaje por SMS: {message}");
    }
}

public class EmailMessageSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Enviando mensaje por Email: {message}");
    }
}

// Paso 3: Creación de abstracción (AbstractMessage)
public abstract class AbstractMessage
{
    protected IMessageSender messageSender;

    public AbstractMessage(IMessageSender sender)
    {
        messageSender = sender;
    }

    public abstract void SendMessage(string message);
}

// Paso 4: Creación de abstracción concreta (MensajeCorto y MensajeLargo)
public class MensajeCorto : AbstractMessage
{
    public MensajeCorto(IMessageSender sender) : base(sender)
    {
    }

    public override void SendMessage(string message)
    {
        if (message.Length >= 10 && message.Length <= 20)
        {
            messageSender.SendMessage(message);
        }
        else
        {
            Console.WriteLine("El mensaje no puede ser enviado. Debe tener entre 10 y 20 caracteres.");
        }
    }
}

public class MensajeLargo : AbstractMessage
{
    public MensajeLargo(IMessageSender sender) : base(sender)
    {
    }

    public override void SendMessage(string message)
    {
        messageSender.SendMessage(message);
    }
}

// Paso 5: Cliente
class Program
{
    static void Main(string[] args)
    {
        // Cliente elige el tipo de mensaje
        Console.WriteLine("¿Qué tipo de mensaje desea enviar? (corto/largo)");
        string tipoMensaje = Console.ReadLine().ToLower();

        AbstractMessage mensaje;

        // Crea objeto AbstractMessage según el tipo elegido
        switch (tipoMensaje)
        {
            case "corto":
                mensaje = new MensajeCorto(new SmsMessageSender());
                mensaje.SendMessage("Mensaje corto");
                break;
            case "largo":
                mensaje = new MensajeLargo(new EmailMessageSender());
                mensaje.SendMessage("Mensaje largo");
                break;
            default:
                Console.WriteLine("Tipo de mensaje no válido");
                return;
        }
    }
}
