using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Abstract factory #1
            //AbstractFactory factory1 = new ConcreteFactory1();
            //Client client1 = new Client(factory1);
            //client1.Run();

            //// Abstract factory #2
            //AbstractFactory factory2 = new ConcreteFactory2();
            //Client client2 = new Client(factory2);
            //client2.Run();

            AbstractFactory[] factories = new AbstractFactory[2];

            factories[0] = new ConcreteFactory1();
            factories[1] = new ConcreteFactory2();

            foreach(AbstractFactory factory in factories)
            {
                Client client = new Client(factory);
                client.Run();
            }

            // Wait for user input
            Console.ReadKey();
        }
    }
}
