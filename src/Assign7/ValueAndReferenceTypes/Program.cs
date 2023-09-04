namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Program class for ValueAndReferenceTypes
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main class for ValueAndReferenceTypes is initiated
        /// </summary>
        /// <param name="args">arguments</param>
        public static void Main(string[] args)
        {
            int id = 1;
            string name = "test";
            Menu menu = new Menu(id, name);
            int valuetype = 0;
            Console.WriteLine("The value of valuetype and referencetype before the method called");
            Tasks.Print(menu, valuetype);
            Tasks.Modify(menu, valuetype);
            Console.WriteLine("The value of valuetype and referencetype after the method called");
            Tasks.Print(menu, valuetype);
            Tasks tasks = new Tasks();
            Console.WriteLine("Press any key to view Stack memory");
            Console.ReadKey();
            Tasks.ArrayInteger();
            Console.WriteLine("Press any key to view Heap memory");
            Console.ReadKey();
            Tasks.Largearr();
            Console.WriteLine("press any key to Exit..");
            Console.ReadKey();
        }
    }
}