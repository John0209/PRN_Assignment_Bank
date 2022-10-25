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
    private int _Account_Money;
    private List<Transaction> _TransactionsList;

    public int Account_Id { get;set; }
    public int Account_Money { get;set; }
    public List<Transaction> TransactionsList { get; set; }

   
    public Account()
    {
    }

    public Account(int account_Id, int account_Money)
    {
        Account_Id = account_Id;
        Account_Money = account_Money;
    }

    public Account(int account_Id, int account_Money, List<Transaction> transactionsList)
    {
        Account_Id = account_Id;
        Account_Money = account_Money;
        TransactionsList = transactionsList;
    }
}
