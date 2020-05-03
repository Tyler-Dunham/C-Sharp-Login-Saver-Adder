using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Saver
{
    class SaveLogin
    {
        static void Main(string[] args)
        {
            //GET USER CHOICE 
            Console.Write("Get account details or create account?: ");
            string choice = Console.ReadLine();

            //IF CHOICE IS CREATE ACCOUNT
            while (choice.ToLower() == "create account")
            {
                //GET ACCOUNT INFO
                Console.Write("Account use: ");
                string AccountUsage = Console.ReadLine();
                Console.Write("Username: ");
                string AccountUsername = Console.ReadLine();
                Console.Write("Email: ");
                string AccountEmail = Console.ReadLine();
                Console.Write("Password: ");
                string AccountPassword = Console.ReadLine();

                //WRITE ACCOUNT INFO TO TXT FILE 
                using (StreamWriter AddLogin = new StreamWriter("C:/Coding/C#/Login Saver/logins.txt", true))
                {
                    if (AccountEmail == "")
                    {
                        AccountEmail = "Null";
                    }
                    
                    if (AccountUsername == "")
                    {
                        AccountUsername = "Null";
                    }

                    AddLogin.Write($"Account use: {AccountUsage}         ");
                    AddLogin.Write($"Username: {AccountUsername}          ");
                    AddLogin.Write($"Email: {AccountEmail}                                 ");
                    AddLogin.Write($"Password: {AccountPassword}" + Environment.NewLine);
                    AddLogin.Close();
                }

                //CONFIRM AND ASK AGAIN
                Console.WriteLine("Account added to text file!");
                Console.WriteLine();

                //ADD ANOTHER ACCOUNT
                Console.Write("Would you like to add another account? (y/n): ");
                string AskAgain = Console.ReadLine();

                if (AskAgain == "y")
                {
                    continue;
                }
                if (AskAgain == "n")
                {
                    break;
                }
            }

            //IF CHOICE IS GET ACCOUNT DETAILS
            while (choice.ToLower() == "get account details")
            {
                //GET ACCOUNT THEY ARE LOOKING FOR 
                Console.Write("What account are you looking for?: ");
                string AccountFind = Console.ReadLine();
                Console.WriteLine();
                
                //READ ALL LINES IN LOGINS FILE
                string[] lines = File.ReadAllLines("C:/Coding/C#/Login Saver/logins.txt");

                //IF ACCOUNTS FOUND OR NOT 
                foreach (string line in lines)
                {
                    if (line.Contains($"{AccountFind}"))
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine();
                Console.Write("Would you like to get information on other accounts: ? (y/n): ");
                string AskAgain = Console.ReadLine();

                if (AskAgain == "y")
                {
                    continue;
                }
                if (AskAgain == "n")
                {
                    break;
                }
            }
        }
    }
}