using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    class BankAccount: IDisposable
    {
        private static int accountNumCounter = 0;
        private int accountNum;
        private decimal balance;
        private AccountType accountType;
        private Queue<BankTransaction> transactions;
        private bool disposed = false;
        public BankAccount() : this(0.0m, AccountType.Savings) { }
        public BankAccount(decimal balance) : this(balance, AccountType.Savings) { }
        public BankAccount(AccountType accountType) : this(0.0m, accountType) { }
        public BankAccount(decimal balance, AccountType accountType)
        {
            if (balance >= 0)
            {
                this.accountNum = GenerateAccountNumber();
                this.balance = balance;
                this.accountType = accountType;
                this.transactions = new Queue<BankTransaction>();
            }
            else
            {
                Console.WriteLine("Введите баланс правильно");
            }
        }
        private int GenerateAccountNumber()
        {
            return accountNumCounter++;
        }

        public string GetFullInfo()
        {
            return $"Номер счёта {accountNum}, Баланс {balance}, Тип счёта {accountType}";
        }
        public void AddMoney(decimal money)
        {
            if (money >= 0)
            {
                this.balance += money;
                transactions.Enqueue(new BankTransaction(money));
            }
            else
            {
                Console.WriteLine("Сумма для добавления должна быть положительной.");
            }
        }
        public void TakeMoney(decimal money)
        {
            if (money <= this.balance && money >= 0)
            {
                this.balance -= money;
                transactions.Enqueue(new BankTransaction(-money));
            }
            else { Console.WriteLine("Операция не прошла. Недостаточно средств."); }
        }
        public void TransferMoney(BankAccount targetAccount, decimal amount)
        {
            decimal initialBalance = this.balance;
            TakeMoney(amount);
            if (this.balance < initialBalance) 
            {
                targetAccount.AddMoney(amount); 
                Console.WriteLine($"Переведено {amount} на счет {targetAccount.accountNum}. Текущий баланс: {this.balance}");
            }
            else
            {
                Console.WriteLine("Перевод не выполнен. Недостаточно средств на счете.");
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    string filePath = $"Account_{accountNum}_Transactions.txt";
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        while (transactions.Count > 0)
                        {
                            BankTransaction transaction = transactions.Dequeue();
                            writer.WriteLine($"{transaction.TransactionDate}: {transaction.Amount}");
                        }
                    }
                    Console.WriteLine($"Транзакции для счёта {accountNum} записаны в файл {filePath}.");
                }
                disposed = true;
            }
        }
    }
}
