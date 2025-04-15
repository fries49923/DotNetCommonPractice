namespace FakeEnumTest
{

    /*
     
    // 以下為Kotlin的程式碼
    // 此C#範例是仿造一樣的格式完成的
    // 可以視為類似一種可以帶參數的enum

    sealed class Destination {
      data class Receiver(val id:Long): Destination()
      data class Topic(val name:String): Destination()
    }

    class Messenger {
        fun sendText(destination: Destination, text: String) {
            when (destination) {
                is Destination.Receiver -> println("Sending text to receiver with id ${destination.id}: $text")
                is Destination.Topic -> println("Sending text to topic with name ${destination.name}: $text")
            }
        }

    fun sendData(destination: Destination, data: Map<String, String>) {
        when (destination) {
            is Destination.Receiver -> println("Sending data to receiver with id ${destination.id}: $data")
            is Destination.Topic -> println("Sending data to topic with name ${destination.name}: $data")
            }
        }
    }

    //example usage:
    messenger.sendText(Receiver(13L), "Hello world")
    messenger.sendText(Topic("notice"), "Hello world")

    */


    internal class Program
    {
        static void Main(string[] args)
        {
            // ex1
            var messenger = new Messenger();
            messenger.SendText(new Destination.Receiver(13L), "Hello world");
            messenger.SendText(new Destination.Topic("notice"), "Hello world");

            // ex2
            Destination dest = new Destination.Receiver(123L);
            if (dest is Destination.Receiver)
            {
                Console.WriteLine("Destination state is Receiver.");
            }
            else if (dest is Destination.Topic)
            {
                Console.WriteLine("Destination state is Topic.");
            }

            Console.ReadKey();
        }
    }

    public abstract class Destination
    {
        public sealed class Receiver : Destination
        {
            public long Id { get; }
            public Receiver(long id)
            {
                Id = id;
            }
        }

        public sealed class Topic : Destination
        {
            public string Name { get; }
            public Topic(string name)
            {
                Name = name;
            }
        }
    }

    public class Messenger
    {
        public void SendText(Destination destination, string text)
        {
            switch (destination)
            {
                case Destination.Receiver receiver:
                    Console.WriteLine($"Sending text to receiver with id {receiver.Id}: {text}");
                    break;
                case Destination.Topic topic:
                    Console.WriteLine($"Sending text to topic with name {topic.Name}: {text}");
                    break;
            }
        }

        public void SendData(Destination destination, Dictionary<string, string> data)
        {
            switch (destination)
            {
                case Destination.Receiver receiver:
                    Console.WriteLine($"Sending data to receiver with id {receiver.Id}: {data}");
                    break;
                case Destination.Topic topic:
                    Console.WriteLine($"Sending data to topic with name {topic.Name}: {data}");
                    break;
            }
        }
    }
}
