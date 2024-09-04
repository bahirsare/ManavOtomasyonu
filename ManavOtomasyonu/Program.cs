using System.Collections;

namespace ManavOtomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList fruitStockGrocery = new ArrayList();
            ArrayList vegetableStockGrocery = new ArrayList();
            ArrayList fruitStockClient = new ArrayList();
            ArrayList vegetableStockClient = new ArrayList();
            MainMenu(ref fruitStockGrocery, ref vegetableStockGrocery, ref fruitStockClient, ref vegetableStockClient, "hal");

        }
        static internal void MainMenu(ref ArrayList fruitStockGrocery, ref ArrayList vegetableStockGrocery, ref ArrayList fruitStockClient, ref ArrayList vegetableStockClient, string type)
        {
            Console.Clear();
            ArrayList fruits = new ArrayList() { "Elma", "Armut", "Kiraz", "Dut", "Şeftali" };
            ArrayList vegetables = new ArrayList() { "Patates", "Soğan", "Marul", "Havuç", "Salatalık" };
            Console.WriteLine($"*********{type.ToUpper()}********\nHoşgeldiniz. Meyve Listesini Görmek için 1,\nSebze Listesini Görmek için 2 Tuşlayınız");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                if (type.ToLower() == "hal")
                {
                    Common.SubMenu(fruits, ref fruitStockGrocery, ref fruitStockGrocery, false);
                }
                else if (type.ToLower() == "manav")
                {
                    Common.SubMenu(fruits, ref fruitStockClient, ref fruitStockGrocery, true);
                }
                else if (type.ToLower() == "client")
                {
                    Common.ListingProducts(fruitStockClient);
                }
            }
            else if (choice == "2")
            {
                if (type.ToLower() == "hal")
                {
                    Common.SubMenu(vegetables, ref vegetableStockGrocery, ref vegetableStockGrocery, false);
                }
                else if (type.ToLower() == "manav")
                {
                    Common.SubMenu(vegetables, ref vegetableStockClient, ref vegetableStockGrocery, true);
                }
                else if (type.ToLower() == "client")
                {
                    Common.ListingProducts(vegetableStockClient);
                }
            }
            else
            {
                Console.WriteLine("Hatalı Giriş Yaptınız Lütfen Tekrar Giriniz.");
                Thread.Sleep(1000);
                MainMenu(ref fruitStockGrocery, ref vegetableStockGrocery, ref fruitStockClient, ref vegetableStockClient, type);
            }
            Console.WriteLine("Başka Bir Arzunuz Var Mı?");
            if (Console.ReadLine().ToLower() == "evet")
            {
                MainMenu(ref fruitStockGrocery, ref vegetableStockGrocery, ref fruitStockClient, ref vegetableStockClient, type);
            }
            else
            {
                if (type == "hal")
                {
                    Console.WriteLine("İyi Günler");
                    Thread.Sleep(1000);
                    type = "manav";
                    MainMenu(ref fruitStockGrocery, ref vegetableStockGrocery, ref fruitStockClient, ref vegetableStockClient, type);
                }
                else if (type == "manav")
                {
                    Console.WriteLine("Afiyet olsun");
                    Thread.Sleep(1000);
                    Common.ListingProducts(fruitStockClient, vegetableStockClient);
                    Environment.Exit(0);
                }
            }
        }
    }
}
