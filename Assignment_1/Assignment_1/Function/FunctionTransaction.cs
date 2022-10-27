using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Function.Transaction;

using Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Transaction;
public class FunctionTransaction
{
    
    private static FunctionTransaction intance = null;
    private static readonly object instanceLock= new object();
    private FunctionTransaction() { }
    public static FunctionTransaction Instance
    {
        get
        {
            lock (instanceLock)
            {
                if(intance == null)
                {
                    intance = new FunctionTransaction();
                }
                return intance; 
            }
        }
    }

    //Get Id Bank
    public Transaction GetById(int transactionId, List<Transaction> listT)
    {
        Transaction tran = null;
        if (listT != null)
        {
            tran = listT.SingleOrDefault(pro => pro.Transaction_Id == transactionId);
        }
        return tran;
    }

    //Add List Transaction
    public List<Transaction> AddNewTransaction(List<Transaction> listT, int idTran)
    {
        //declace field
        int Transaction_Id;
        string Transaction_Date;
        double Transaction_Money;
        string Transaction_Type;

        //Enter Field
        Transaction_Id = idTran;
        Console.Write("Enter Transaction Date (dd/MM/yyyy):");
        Transaction_Date =Console.ReadLine();
        Console.Write("Enter Transaction Money:");
        Transaction_Money = double.Parse(Console.ReadLine());
        Console.Write("Enter Transaction Type (W: withdraw, D: deposit):");
        Transaction_Type = Console.ReadLine();

        //Add new Bank
        Transaction transaction = new Transaction(Transaction_Id, Transaction_Money, Transaction_Date, Transaction_Type);
       
        //Get by Id Transaction
        Transaction pro = GetById(Transaction_Id, listT);

        if (pro == null)
        {
            if (listT == null)
            {
                listT = new List<Transaction>();
            }
            listT.Add(transaction);
        }
        else
        {
            Console.WriteLine("Transaction is Exists");
        }
        return listT;
    }

    
}
