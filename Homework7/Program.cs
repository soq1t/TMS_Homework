using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework7
{
    internal class Program
    {
        private static Inventory _inventory;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            InitInventory();
            InitBaseActions();
            InitProductActions();

            SelectBaseActions();
        }

        #region Initialization

        private static void InitInventory()
        {
            _inventory = new Inventory();

            _inventory.AddProduct(new Product("Картошка"));
            _inventory.AddProduct(new Product("Морковь", (double)150));
            _inventory.AddProduct(new Product("Свекла", 50));
            _inventory.AddProduct(new Product("Капуста", 100, 30));
        }
        #endregion

        #region Base Actions
        private static ActionSelector _baseActions;

        private static void PrintBaseMessage()
        {
            ConsoleUtility.WriteLineColored(
                "Добро пожаловать на склад магазина \"Всё или ничего\"!",
                ConsoleColor.Green
            );
            Console.WriteLine();
            _inventory.PrintProducts();
            ConsoleUtility.WriteLineColored("Выберите интересующее действие", ConsoleColor.Yellow);
        }

        private static void InitBaseActions()
        {
            _baseActions = new ActionSelector();

            _baseActions.AddAction("Действия с продукцией склада", SelectProductActions);
            _baseActions.AddAction("Уйти со склада", ExitProgram);
        }

        private static void ExitProgram()
        {
            Console.Clear();
            Environment.Exit(0);
        }

        private static void SelectBaseActions()
        {
            Console.Clear();
            _baseActions.SelectAction(PrintBaseMessage);

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения...",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectBaseActions();
        }
        #endregion

        #region Product Actions
        private static ActionSelector _productActions;

        private static void InitProductActions()
        {
            _productActions = new ActionSelector();

            _productActions.AddAction("Изменить количество товара", ChangeProductAmount);
            _productActions.AddAction("Изменить стоимость товара", ChangeProductPrice);
            _productActions.AddAction("Вернуться на главную", SelectBaseActions);
        }

        private static void PrintProductMessage()
        {
            _inventory.PrintProducts();
            Console.WriteLine();
            ConsoleUtility.WriteLineColored("Выберите интересующее действие", ConsoleColor.Yellow);
        }

        private static void SelectProductActions()
        {
            Console.Clear();
            _productActions.SelectAction(PrintProductMessage);

            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения...",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
            SelectProductActions();
        }

        private static void ChangeProductPrice()
        {
            Product product = ObjectSelector<Product>.SelectFromList(_inventory.Products);

            if (product != null)
            {
                Console.WriteLine();
                product.PrintPrice();

                bool isSucceed = true;
                double newPrice = 0;
                do
                {
                    ConsoleUtility.WriteColored(
                        "Введите новую стоимость продукта: ",
                        ConsoleColor.Green
                    );
                    isSucceed = double.TryParse(Console.ReadLine(), out newPrice);

                    if (!isSucceed)
                    {
                        ConsoleUtility.WriteLineColored(
                            "Неверное значение стоимости продукта!",
                            ConsoleColor.Red
                        );
                        Console.WriteLine();
                    }
                    else
                    {
                        isSucceed = product.SetPrice(newPrice);
                        if (!isSucceed)
                            Console.WriteLine();
                    }
                } while (!isSucceed);
            }
        }

        private static void ChangeProductAmount()
        {
            Product product = ObjectSelector<Product>.SelectFromList(_inventory.Products);

            if (product != null)
            {
                Console.WriteLine();
                product.PrintAmount();

                bool isSucceed = true;
                int newAmount = 0;
                do
                {
                    ConsoleUtility.WriteColored(
                        "Введите количество продукта: ",
                        ConsoleColor.Green
                    );
                    isSucceed = Int32.TryParse(Console.ReadLine(), out newAmount);

                    if (!isSucceed)
                    {
                        ConsoleUtility.WriteLineColored(
                            "Неверное значение количества продукта!",
                            ConsoleColor.Red
                        );
                        Console.WriteLine();
                    }
                    else
                    {
                        isSucceed = product.SetAmount(newAmount);
                        if (!isSucceed)
                            Console.WriteLine();
                    }
                } while (!isSucceed);
            }
        }

        #endregion
    }
}
