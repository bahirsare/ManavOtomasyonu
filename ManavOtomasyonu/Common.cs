using System.Collections;

namespace ManavOtomasyonu
{
    internal class Common
    {
        static internal void ListingProducts(ArrayList collection)
        {
            Console.Clear();
            Console.WriteLine("Ürünler:");
            int i = 1;
            foreach (var item in collection)
            {
                Console.WriteLine($"{i}.{item} ");
                i++;
            }
        }
        static internal void ListingProducts(ArrayList collection, ArrayList collection2)
        {
            collection.AddRange(collection2);
            Console.Clear();
            Console.WriteLine("Ürünler:");
            int i = 1;
            int j = 1;
            foreach (var item in collection)
            {
                if (i % 2 != 0)
                {
                    Console.Write($"{j}.{item} ");
                    j++;
                }
                else
                {
                    Console.Write($"{item} kg\n");
                }
                i++;
            }
        }
        static internal void SelectingProducts(ArrayList collection, out int choice, out double volume)
        {
            ListingProducts(collection);
            Console.WriteLine("Hangi Ürünü İstiyorsunuz?");
            int.TryParse(Console.ReadLine(), out choice);
            if (choice > collection.Count || choice == 0)
            {
                Console.WriteLine("Geçersiz Değer Girdiniz.");
                Thread.Sleep(1000);
                Console.Clear();
                SelectingProducts(collection, out choice, out volume);
            }
            else
            {
                Console.WriteLine("Kaç Kilo İstiyorsunuz?");
                double.TryParse(Console.ReadLine(), out volume);
                if (volume <= 0)
                {
                    Console.WriteLine("Geçersiz Değer!!");
                    Thread.Sleep(1000);
                    SelectingProducts(collection, out choice, out volume);
                }
            }
        }
        static void AddingStock(ArrayList collection, ref ArrayList stock)
        {
            int choice;
            double volume;
            Common.SelectingProducts(collection, out choice, out volume);
            if (stock.IndexOf(collection[choice - 1]) >= 0)
            {
                int index = stock.IndexOf(collection[choice - 1]);
                volume += (double)stock[index + 1];
                stock.RemoveAt(index + 1);
                stock.Insert(index + 1, volume);
            }
            else
            {
                stock.Add(collection[choice - 1]);
                stock.Add(volume);
            }
        }

        static internal void SubMenu(ArrayList collection, ref ArrayList stock, ref ArrayList greenGroceryStock, bool isgreenGrocery)
        {
            if (isgreenGrocery)
            {
                GreenGrocery.AddingStock(collection, ref stock, ref greenGroceryStock);
            }
            else
            {

                AddingStock(collection, ref stock);
            }

        }

    }
}

