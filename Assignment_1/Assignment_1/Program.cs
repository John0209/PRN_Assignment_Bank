namespace Program;

using Assignment_1.Function.Account;
using Assignment_1.Function.Bank;
using Assignment_1.Function.Customer;
using Assignment_1.Function.Transaction;
using Assignment_1.Interface.Account;
using Assignment_1.Interface.Bank;
using Assignment_1.Interface.Choice;
using Assignment_1.Interface.Customer;
using Assignment_1.Interface.Transaction;
using Assignment_1.ObjectData.Account;
using Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Customer;
using Assignment_1.ObjectData.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Content cx = new Content();
        cx.GetCustomer();
        cx.GetListAccount();
    Menu:
        while (true) {
            Console.WriteLine(" ======== Menu ========");
            Console.WriteLine("1. Add New Bank\n2. Print Information Customer\n" +
            "3. Deposit - Withdraw\n4. Print Transaction\n5. List Account Largest Balance\n" +
            "6. Sort Ascending By Balance\n7. Display Customer Have Largeest Transaction\n" +
            "0. Exit\n");
            int choiceMenu = cx.ChoiceMenu(0, 7);
        switch (choiceMenu)
        {
            case 0:
                break;
            case 1:
                    cx.CreateBank();
                    cx.ShowListBank();
            SubCase1:
                Console.WriteLine("------->\n1. Insert Many Customer Into Branch\n" +
                    "2. Insert Many Account Into One Customer\n0. Exit\n");

                int choice = cx.ChoiceMenu(0, 2);
                //if 0 => Exit
                if (choice == 0)
                {
                    break;
                }
                //if 1 insert Customer => Bank
                if (choice ==1)
                {
                    cx.ShowListCustomer(0);

                    //Enter Bank & Customer Id to Insert
                    Console.Write(">>>\n2. Enter Customer Id:");
                    int customerId = int.Parse(Console.ReadLine());
                    Console.Write(">>>\n1. Enter Bank Id:");
                    int bankId = int.Parse(Console.ReadLine());

                        //Call Function Insert Into Bank
                        cx.InserIntoBank(bankId, customerId);

                    //Show List Bank New Insert Customer
                    cx.ShowListCustomerInBank(bankId);

                    // Back Sub Menu
                    goto SubCase1;
                }
                //if 2 Insert Account => Customer
                else
                {
                    cx.ShowListAccount(0);
                    cx.ShowListCustomer(0);

                    //Enter Account & Customer Id to Insert
                    Console.Write(">>>\n1. Enter Account Id:");
                    int accountId = int.Parse(Console.ReadLine());
                    Console.Write(">>>\n2. Enter Customer Id:");
                    int customerId = int.Parse(Console.ReadLine());

                    //Call Function Insert Into Bank
                    cx.InserIntoCustomer(accountId, customerId);

                    //Show List Bank New Insert Customer
                    cx.ShowListAccountInCustomer(customerId,0);

                    // Back Sub Menu
                    goto SubCase1;
                }
                break;
            case 2:
                    cx.ShowListCustomer(1);

                    //Enter Customer Id want print infor
                    Console.Write(">>>\nEnter Customer Id You Want Print Information:");
                    int idCus= int.Parse(Console.ReadLine());

                    //Call Function Print
                    cx.PrintInformationCustomer(idCus);

                    //Show Customer
                    cx.ShowListAccountInCustomer(idCus,0);
                    break;
            case 3:
                    cx.ShowListAccount(1);

                    //Enter Account Id
                    Console.Write(">>>\nEnter Account Id You Want Implement Transaction:");
                    int idAcc= int.Parse(Console.ReadLine());

                    //Cretae Transaction
                    cx.CreateTransaction();

                    //Call Function
                    cx.ImplementTransaction(idAcc);

                    //Show Customer
                    cx.ShowListTransactionInAccount(idAcc);
                    break;
            case 4:
                    //Show List Customer Have Account Implement Transaction
                    cx.ShowListCustomerHaveTransaction(0);
                break;
            case 5:
                    //Show List Customer Have Account Largest Money At Bank
                    cx.ShowListCustomerHaveLargestMoney();
                break;
            case 6:
                    //Do Sum Money
                    cx.SortAscendingSumMoney();

                    //Show List Sort Customer Ascending Sum Money
                    cx.ShowListSortAscendingCustomerSumMoney();
                break;
            case 7:
                    cx.LargestTransaction();
                    //Show List Customer Have Largest Transaction
                    cx.ShowListCustomerHaveTransaction(1);
                        
                break;
        }
            if (choiceMenu == 0)
            {
                break;
            }
            else
            {
                goto Menu;
            }
        }
    }
    class Content : InterfaceBank, InterfaceChoice, InterfaceCustomer, InterfaceAccount, InterfaceTransaction
    {
        //List Object
        List<Bank> ListBank;
        List<Customer> ListCustomer;
        List<Account> ListAccount;
        List<Transaction> ListTransaction;
        int idTransaction = 1;
        //Add List
        public void CreateBank()
        {
            ListBank = FunctionBank.Instance.AddNewBank(ListBank);
        }

        //Add List
        public void CreateTransaction()
        {
            ListTransaction = FunctionTransaction.Instance.AddNewTransaction(ListTransaction,idTransaction);
            idTransaction++;
        }

        //Choice List Menu
        public int ChoiceMenu(int min, int max)
        {
            
            int num = 0;
        choice:
            try
            {
                Console.Write("Your Choice: ");
                num = int.Parse(Console.ReadLine());
                if (num < min || num > max)
                {
                    Console.WriteLine("Please enter Your Choice >= " + min + " and <= " + max);
                    goto choice;
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return num;
        }

        //Show List Bank
        public void ShowListBank()
        {
            Console.WriteLine(" ======== List Bank ========");
            foreach (Bank b in ListBank)
            {
                Console.WriteLine(b.DisplayBank());
            }
        }

        //Show List Customer
        public void ShowListCustomer(int num)
        {
            if (num == 0)
            {
                Console.WriteLine(" ======== List Customer ========");
                foreach (Customer b in ListCustomer)
                {
                    Console.WriteLine(b.DisplayCustomer());
                }
            }
            else
            {
                Console.WriteLine(" ======== List Customer Id========");
                foreach (Customer b in ListCustomer)
                {
                    Console.WriteLine(b.DisplayCustomerId());
                }
            }
        }

        // Show List Bank Have Customer 
        public void ShowListCustomerInBank(int bankId)
        {
            Console.WriteLine(" ======== List Bank ========");
            foreach (Bank b in ListBank)
            {
                if (b.Bank_Id == bankId) { 
                Console.WriteLine(b.DisplayBank());
                b.ShowBankListCustomer();
                }
            }
        }

        // Show List Customer Have Account
        public void ShowListAccountInCustomer(int customerId,int i)
        {
            Console.WriteLine(" ======== List Customer ========");
            foreach (Customer c in ListCustomer)
            {
                if (c.Customer_Id == customerId)
                {
                    Console.WriteLine(c.DisplayCustomer());
                    c.ShowBankList();
                    c.ShowAccountList(i);
                }
            }
        }

        // Show List Account
        public void ShowListAccount(int num)
        {
            if (num == 0)
            {
                Console.WriteLine(" ======== List Account ========");
                foreach (Account a in ListAccount)
                {
                    Console.WriteLine(a.DisplayAccount());
                }
            }
            else
            {
                Console.WriteLine(" ======== List Account Id ========");
                foreach (Account a in ListAccount)
                {
                    Console.WriteLine(a.DisplayAccountId());
                }
            }
        }

        // Show List Account Have Transaction
        public void ShowListTransactionInAccount(int AccountId)
        {
            Console.WriteLine(" ======== List Account ========");
            foreach (Account c in ListAccount)
            {
                if (c.Account_Id == AccountId)
                {
                    Console.WriteLine(c.DisplayAccount());
                    c.ShowTransactionList();
                }
            }
        }

        //Show List Customer Account Have Transaction
        public void ShowListCustomerHaveTransaction(int i)
        {
            Console.WriteLine(" ======== List Customer ========");
            foreach (Customer c in ListCustomer)
            {
                Console.WriteLine(c.DisplayCustomer());
                if (c.List_Account_Customer != null)
                {
                    c.ShowAccountHaveTransactionInCustomer(i);
                    if (i == 1)
                        {
                            break;
                        }
                    Console.WriteLine("( --------------------------- )");
                }
            }
        }

        //Show Customer Account Have Largest Money 
        public void ShowListCustomerHaveLargestMoney()
        {
            Console.WriteLine(" ======== List Account Have Largest Money At Bank ========");
            foreach (Bank b in ListBank)
            {
                    Console.WriteLine(b.DisplayBank());
                    b.ShowAccountLargestMoney();
                Console.WriteLine(    "( --------------------------- )"     );
            }
        }

        //Show Sort List Customer Ascending Sum Money
        public void ShowListSortAscendingCustomerSumMoney()
        {
            Console.WriteLine(" ======== List Sort Customer Ascending Sum Money ========");

            foreach (Customer b in ListCustomer)
            {
                PrintInformationCustomer(b.Customer_Id);
                Console.WriteLine(b.DisplayCustomerSumMoney());
                b.ShowBankList();
                b.ShowAccountList(0);
                Console.WriteLine("( --------------------------- )");
            }
        }

        //Get Customer
        public void GetCustomer()
        {
            ListCustomer = new List<Customer>();
            ListCustomer = FunctionCustomer.Instance.GetListCustomer();
        }

        //Get Account
        public void GetListAccount()
        {
            ListAccount = new List<Account>();
            ListAccount = FunctionAccount.Instance.GetListAccount();
        }

        //Insert Customer Into Bank
        public void InserIntoBank(int bankId, int CustomerId)
        {
            ListBank = FunctionBank.Instance.IntoBank(bankId, CustomerId, ListCustomer, ListBank);
        }
       
        //Insert Account Into Customer
        public void InserIntoCustomer(int accountId, int customerId)
        {
            ListCustomer = FunctionCustomer.Instance.IntoCustomer(accountId, customerId, ListCustomer, ListAccount);
        }

        //Print Information Customer
        public void PrintInformationCustomer(int idCus)
        {
            ListCustomer = FunctionCustomer.Instance.InformationCustomer(idCus, ListCustomer, ListBank);
        }

        //Implement Transaction 
        public void ImplementTransaction(int idAccount)
        {

            //get Id Transaction
            int idTransaction = ListTransaction[ListTransaction.Count-1].Transaction_Id;

            ListAccount = FunctionAccount.Instance.TransactionToAccount(idAccount, idTransaction, ListTransaction,ListAccount) ;
        }

        //Sort Customer Ascending Sum Money
        public void SortAscendingSumMoney()
        {
            //Do Sum Money
           FunctionCustomer.Instance.SumMoney(ListCustomer);

            //Sort Ascending
            ListCustomer = FunctionCustomer.Instance.SortCustomerAscendingSumMoney(ListCustomer);
        }

        //Customer Largest Transaction
        public void LargestTransaction()
        {
            ListCustomer = FunctionCustomer.Instance.CustomerHaveTransactionLargest(ListCustomer);
        }
    }
}
