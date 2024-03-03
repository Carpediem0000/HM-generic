using gen;
namespace HM_generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(8);
            tree.Add(15);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);

            tree.Print(true); // 137815
            tree.Print(false); // 15 8 7 3 1
            Console.WriteLine(tree.Contains(15)); // True
            Console.ReadKey();
        }
    }
}
