
namespace HunterGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hunter's name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a name.");
                name = Console.ReadLine();
            }
            Hunter hunter = new Hunter(name);
            hunter.ShowInfo();
            Menu menu = new Menu(hunter);
            menu.Run();
        }
    }
}
