using System.Collections;

namespace ManavOtomasyonu
{
    internal class GreenGrocery
    {
        #region  not
        //static internal void MainMenu(ref ArrayList fruitStock, ref ArrayList vegetableStock)
        //{
        //    Console.Clear();
        //    ArrayList fruits = new ArrayList() { "Elma", "Armut", "Kiraz", "Dut", "Şeftali" };
        //    ArrayList vegetables = new ArrayList() { "Patates", "Soğan", "Marul", "Havuç", "Salatalık" };
        //    Console.WriteLine("Hal'e Hoşgeldiniz. Meyve Listesini Görmek için 1,\nSebze Listesini Görmek için 2 Tuşlayınız");
        //    string choice = Console.ReadLine();
        //    if (choice == "1")
        //    {
        //        Common.SubMenu(fruits, ref fruitStock);
        //    }
        //    else if (choice == "2")
        //    {
        //        Common.SubMenu(vegetables, ref vegetableStock);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Giriniz.");
        //        Thread.Sleep(1000);
        //        MainMenu(ref fruitStock, ref vegetableStock);
        //    }
        //    Console.WriteLine("Başka Bir Arzunuz Var Mı?");
        //    if (Console.ReadLine().ToLower() == "evet")
        //    {
        //        MainMenu(ref fruitStock, ref vegetableStock);
        //    }
        //    else
        //    {
        //        Console.WriteLine("İyi Günler");

        //    }
        //}
        #endregion

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
