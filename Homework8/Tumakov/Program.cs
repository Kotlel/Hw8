using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Task9_1();
            Task9_2_9_3();
            HTask9_1();
        }
        static void Task9_1()
        {
            Console.WriteLine("Упражнение 9.1");
            BankAccount defaultAccount = new BankAccount();
            Console.WriteLine(defaultAccount.GetFullInfo());

            BankAccount balanceAccount = new BankAccount(1500.0m);
            Console.WriteLine(balanceAccount.GetFullInfo());

            BankAccount currentAccount = new BankAccount(AccountType.Current);
            Console.WriteLine(currentAccount.GetFullInfo());

            BankAccount myAccount = new BankAccount(2500.0m, AccountType.Savings);
            Console.WriteLine(myAccount.GetFullInfo());
        }
        static void Task9_2_9_3()
        {
            Console.WriteLine("Упражнение 9.2-9.3");
            using (BankAccount myAccount = new BankAccount(1000.0m, AccountType.Current))
            {
                Console.WriteLine(myAccount.GetFullInfo());

                myAccount.AddMoney(500.0m);
                Console.WriteLine(myAccount.GetFullInfo());

                myAccount.TakeMoney(200.0m);
                Console.WriteLine(myAccount.GetFullInfo());

                using (BankAccount myFriendAccount = new BankAccount(200.0m, AccountType.Savings))
                {
                    Console.WriteLine(myFriendAccount.GetFullInfo());

                    myAccount.TransferMoney(myFriendAccount, 300.0m);
                    Console.WriteLine(myAccount.GetFullInfo());
                    Console.WriteLine(myFriendAccount.GetFullInfo());
                } 
            }
        }
        static void HTask9_1()
        {
            Console.WriteLine("Домашнее задание 9.1");
            Song mySong = new Song();
            Console.WriteLine("mySong: " + mySong.Title());

            Song myFriendSong = new Song("Unravel", "TK (Ling Tosite Sigure)");
            Console.WriteLine("myFriendSong: " + myFriendSong.Title());

            Song myNeighbourSong = new Song("Blue Bird", "Ikimonogakari", myFriendSong);
            Console.WriteLine("myNeighbourSong: " + myNeighbourSong.Title());

            
            bool areEqual = myFriendSong.Equals(myNeighbourSong);
            Console.WriteLine("Результат сравнения:" + areEqual);
        }
    }
}
