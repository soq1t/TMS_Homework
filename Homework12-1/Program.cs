using MyHomeworkToolkit;

namespace Homework12_1
{
    internal class Program
    {
        private static readonly ActionSelector _actions;

        static Program()
        {
            _actions = new ActionSelector();
            _actions.AddAction("Регистрация", Register);
            _actions.AddSeparator();
            _actions.AddExitProgramAction();
        }

        private static void Register()
        {
            string login = InputDataHandler.GetTextData("Введите логин");
            string password = InputDataHandler.GetTextData("Введите пароль");
            string passwordConfirm = InputDataHandler.GetTextData("Повторите пароль");

            Authentification.LogIn(login, password, passwordConfirm);
        }

        static void Main(string[] args)
        {
            _actions.SelectActionRepeated();
        }
    }
}
