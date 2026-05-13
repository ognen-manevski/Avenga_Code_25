namespace Class04.Generics.Helpers
{
    public static class GenericListHelper
    {
        public static void PrintItems<T>(List<T> items)
        {
            Console.WriteLine($"========== Print {typeof(T).Name}s ==========");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        //

        public static void PrintInfoForList<T>(List<T> items)
        {
            string elementType = typeof(T).Name;
            //string elementType2 = nameof(T);

            Console.WriteLine($"This list has {items.Count} elements and is of type {elementType}");
        }

    }
}
