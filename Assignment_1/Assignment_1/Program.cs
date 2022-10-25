namespace Program;

using Assignment_1.Function.Bank;
using Assignment_1.Function.Customer;
using Assignment_1.Interface.Bank;
using Assignment_1.Interface.Choice;
using Assignment_1.Interface.Customer;
using Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Customer;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Content cx = new Content();
        Console.WriteLine("1. Add New Bank\n2. Print Information Customer\n" +
            "3. Deposit - Withdraw\n4. Print Transaction\n5. List Account Largest Balance\n" +
            "6. Sort Ascending By Balance\n7. Display Customer Have Largeest Transaction\n" +
            "0. Exit\n");
        switch (cx.ChoiceMenu(0, 7))
        {
            case 0:
                break;
            case 1:
                cx.CreateBank();
                cx.ShowListBank();
                SubCase1:
                Console.WriteLine("------->\n1. Insert Many Customer Into Branch\n"+
                    "2. Insert Many Account Into One Customer\n0. Exit");
                //if 0 => Exit
                if (cx.ChoiceMenu(0, 2) == 0)
                {
                    break;
                }
                //if 1 insert Customer => Bank
                if (cx.ChoiceMenu(0, 2)==1)
                {
                    cx.GetCustomer();
                    cx.ShowListCustomer();
                    //Enter Bank & Customer Id to Insert
                    Console.Write(">>>\n1. Enter Bank Id:");
                    int bankId=int.Parse(Console.ReadLine());
                    Console.Write(">>>\n2. Enter Customer Id:");
                    int customerId = int.Parse(Console.ReadLine());
                    //Call Function Insert Into Bank
                    cx.InserIntoBank(bankId, customerId);
                    //Show List Bank New Insert Customer
                    cx.ShowListCustomerBank();
                    // Back Sub Menu
                    goto SubCase1;
                }
                //if 2 Insert Account => Customer
                else
                {

                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }
    class Content : InterfaceBank, InterfaceChoice, InterfaceCustomer
    {
        //List Object
        List<Bank> ListBank;
        List<Customer> ListCustomer;
        //Add List
        public void CreateBank()
        {
            int Bank_Id;
            String Bank_Name;
            String Bank_Address;
            Console.Write("Enter Bank Id:");
            Bank_Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Bank Name:");
            Bank_Name = Console.ReadLine();
            Console.Write("Enter Bank Address:");
            Bank_Address = Console.ReadLine();
            Bank bank = new Bank(Bank_Id, Bank_Name, Bank_Address);
            ListBank = FunctionBank.Instance.AddNewBank(bank, ListBank);
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
                Console.WriteLine(b.Display());
            }
        }
        //Show List Customer
        public void ShowListCustomer()
        {
            Console.WriteLine(" ======== List Customer ========");
            foreach (Customer b in ListCustomer)
            {
                Console.WriteLine(b.Display());
            }
        }
        // Show List Bank Have Customer 
        public void ShowListCustomerBank()
        {
            Console.WriteLine(" ======== List Bank ========");
            foreach (Bank b in ListBank)
            {
                Console.WriteLine(b.DisplayBankListCustomer());
            }
        }
        //Get Customer
        public void GetCustomer()
        {
            ListCustomer = new List<Customer>();
            ListCustomer = FunctionCustomer.Instance.GetListCustomer();
        }
        //Insert Customer Into Bank
        public void InserIntoBank(int bankId, int CustomerId)
        {
            ListBank = FunctionBank.Instance.IntoBank(bankId, CustomerId, ListCustomer, ListBank);
        }
        
    }
}
