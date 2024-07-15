using MyHomeworkToolkit;
using MyHomeworkToolkit.ObjectSelecting;

namespace Homework7_2
{
    internal class Program
    {
        private static readonly ActionSelector _baseActions;

        private static readonly List<CreditCard> _cards;

        static Program()
        {
            _cards = new List<CreditCard>()
            {
                new CreditCard(CreditCard.GetRandomCardNumber(), money: 5000),
                new CreditCard(CreditCard.GetRandomCardNumber()),
                new CreditCard(CreditCard.GetRandomCardNumber(), overdraft: 500, money: 0),
            };

            _baseActions = new ActionSelector();

            _baseActions.AddAction("Зачислить деньги на карту", AddMoney);
            _baseActions.AddAction("Снять деньги с карты", WithdrawMoney);
            _baseActions.AddAction("Покинуть банк", ExitProgram);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                _baseActions.SelectAction(PrintBaseMessage);
            }
        }

        #region Base Actions
        private static void PrintBaseMessage()
        {
            ConsoleUtility.WriteLineColored("Добро пожаловать в наш банк!", ConsoleColor.Yellow);
            ConsoleUtility.WriteLineColored(
                "Информация о счетах нашего банка:",
                ConsoleColor.Yellow
            );

            Console.WriteLine();
            foreach (CreditCard card in _cards)
            {
                card.PrintCardInfo();
                Console.WriteLine();
            }

            ConsoleUtility.WriteLineColored("Выберите действие:", ConsoleColor.Yellow);
        }

        private static void ExitProgram() => Environment.Exit(0);

        private static void AddMoney()
        {
            CreditCard card = ObjectSelector<CreditCard>.SelectFromList(
                _cards,
                "Выберите счёт для зачисления денег:"
            );

            if (card != null)
            {
                Console.Clear();
                ConsoleUtility.WriteLineColored("Зачисление денег на счёт", ConsoleColor.Yellow);
                card.PrintCardInfo();

                Console.WriteLine();

                card.AddMoney();
                EndAction();
            }
        }

        private static void WithdrawMoney()
        {
            CreditCard card = ObjectSelector<CreditCard>.SelectFromList(
                _cards,
                "Выберите счёт для снятие денег:"
            );

            if (card != null)
            {
                Console.Clear();
                ConsoleUtility.WriteLineColored("Снятие денег со счёта", ConsoleColor.Yellow);
                card.PrintCardInfo();

                Console.WriteLine();

                card.WithdrawMoney();
                EndAction();
            }
        }

        #endregion

        private static void EndAction()
        {
            Console.WriteLine();
            ConsoleUtility.WriteLineColored(
                "Нажмите любую клавишу для продолжения...",
                ConsoleColor.Yellow
            );
            Console.ReadKey(true);
        }
    }
}
