using Assignment_1.Function.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Function.Account;
using Assignment_1.ObjectData.Account;
using Assignment_1.ObjectData.Transaction;
public class FunctionAccount
{
    //Singleton Pattern
    private static FunctionAccount instance = null;
    private static readonly object instanceLock=new object();
    private FunctionAccount() { }
    public static FunctionAccount Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new FunctionAccount();
                }
                return instance;
            }
        }
    }

    //Get list Account
    public List<Account> GetListAccount()
    {
        List<Account> accountList = new List<Account>
        {
            new Account(123456789,15000000),
            new Account(123412343,30000000),
            new Account(123474573,12000000),
            new Account(123401932,55000000),
            new Account(123498513,78000000),
            new Account(123450921,32000000),
            new Account(123457235,27000000)
        };
        return accountList;
    }

    //Add Transaction To Account
    public List<Account> TransactionToAccount(int AccountId, int TransactionId, List<Transaction> listT, List<Account> listA)
    {
        for (int i = 0; i < listA.Count; i++)
        {
            if (AccountId == listA[i].Account_Id)
            {
                if (listA[i].Transactions_List == null)
                {
                    listA[i].Transactions_List = new List<Transaction>();
                }
                //Get Infor Account Insert Customer
                for (int y = 0; y < listT.Count; y++)
                {
                    if (TransactionId == listT[y].Transaction_Id)
                    {
                        listA[i].Transactions_List.Add(listT[y]);
                    }
                }
            }
        }//End For
        return listA;
    }

    //Sort Money Largest 
    public List<Account> SortMoneyLargest(List<Account> listA)
    {
        var sortingAccountMoney = listA.OrderByDescending(pro => pro.Account_Money).ToList();
        return sortingAccountMoney;
    }

    //

}
