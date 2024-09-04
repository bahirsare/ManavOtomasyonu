using System.Collections;

namespace ManavOtomasyonu
{
    internal class GreenGrocery
    {
        internal static void AddingStock(ArrayList collection, ref ArrayList stock, ref ArrayList greenGroceryStock)
        {
            int choice;
            double volume;
            Common.SelectingProducts(collection, out choice, out volume);
            int indexGreenGrocery = greenGroceryStock.IndexOf(collection[choice - 1]);
            if (indexGreenGrocery >= 0 && (double)greenGroceryStock[indexGreenGrocery + 1] >= volume)
            {
                double greenStock = (double)greenGroceryStock[indexGreenGrocery + 1] - volume;
                greenGroceryStock.RemoveAt(indexGreenGrocery + 1);
                greenGroceryStock.Insert(indexGreenGrocery + 1, greenStock);
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
            else
            {
                Console.WriteLine("Elimizde Kalmadı.");
            }
        }
    }
}
