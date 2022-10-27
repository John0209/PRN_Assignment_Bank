using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.ObjectData.Account;
using Assignment_1.ObjectData.Transaction;
public class Account
{
    private int _Account_Id;
    private double _Account_Money;
    private List<Transaction> _TransactionsList;

    public int Account_Id { get;set; }
    public double Account_Money { get;set; }
    public List<Transaction> Transactions_List { get; set; }

   
    public Account()
    {
    }

    public Account(int account_Id, int account_Money)
    {
        Account_Id = account_Id;
        Account_Money = account_Money;
    }

    public Account(int account_Id, double account_Money, List<Transaction> transactionsList)
    {
        Account_Id = account_Id;
        Account_Money = account_Money;
        Transactions_List = transactionsList;
    }
    public void ShowTransactionList()
    {
        if (Transactions_List != null) { 
        foreach (Transaction t in Transactions_List)
        {
            Console.WriteLine(" + " + t.DisplayTransaction());
        }
        }//end If Transaction list not null
    }

    //Show
    public virtual string DisplayAccountId()
   => $"<- Account -> Id: {Account_Id}";
    public virtual string DisplayAccount()
   => $"<- Account -> Id: {Account_Id},Money: {Account_Money}";
}
