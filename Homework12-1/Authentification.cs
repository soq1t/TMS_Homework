using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework12_1
{
    internal static class Authentification
    {
        public static bool LogIn(string login, string password, string confirmPassword)
        {
            try
            {
                if (login.Length > 20)
                    throw new WrongLoginException("Длина логина должна быть менее 20 символов!");

                if (login.Contains(' '))
                    throw new WrongLoginException("Логин не может содержать пробелов!");

                if (password.Length > 20 || confirmPassword.Length > 20)
                    throw new WrongPasswordException("Длина пароля должна быть менее 20 символов!");

                if (password.Contains(' ') || confirmPassword.Contains(' '))
                    throw new WrongPasswordException("Пароль не может содержать пробелов!");

                if (!password.Any(char.IsDigit) || !confirmPassword.Any(char.IsDigit))
                    throw new WrongPasswordException(
                        "Пароль должен содержать как миниум одну цифру!"
                    );

                if (password != confirmPassword)
                    throw new WrongPasswordException("Пароли не совпадают!");

                ConsoleUtility.WriteLineColored("Ваш аккаунт успешно создан!", ConsoleColor.Green);
                return true;
            }
            catch (WrongLoginException ex)
            {
                ConsoleUtility.PrintError(ex.Message);
                return false;
            }
            catch (WrongPasswordException ex)
            {
                ConsoleUtility.PrintError(ex.Message);
                return false;
            }
        }
    }
}
