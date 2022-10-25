using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Function.Bank;
using Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Customer;
using System.Numerics;

public class FunctionBank
{
    //
    private static FunctionBank instance = null;
    private static readonly object instanceLock=new object();
    private FunctionBank() { }
    public static FunctionBank Instance
    {
        get
        {
            lock (instanceLock)
            {
                if(instance == null)
                {
                    instance = new FunctionBank();
                }
                return instance;
            }
        }
    }
    //Get Id Bank
    public Bank GetById(int BankId,List<Bank> listBank)
    {
        Bank bank = null;
        if (listBank != null) {
         bank = listBank.SingleOrDefault(pro => pro.Bank_Id==BankId);
        }
        return bank;
    }
    //Add New BAnk
    public List<Bank> AddNewBank(Bank bank,List<Bank> listBank)
    {
       Bank pro=GetById(bank.Bank_Id,listBank);
        if (pro == null)
        {
            if(listBank==null){
                listBank = new List<Bank>();
            }
            listBank.Add(bank);
        }
        else
        {
            Console.WriteLine("Bank is Exists");
        }
        return listBank;
    }
    //Customer Into Bank
    public List<Bank> IntoBank(int BankId, int CustomerId,List<Customer> listC, List<Bank> listB)
    {
        for (int i = 0; i < listB.Count; i++)
        {
            if (BankId == listB[i].Bank_Id)
            {
                if (listB[i].Bank_List_Customer == null)
                {
                    listB[i].Bank_List_Customer = new List<Customer>();
                }
                //Get Infor Customer Insert Into Bank
                for (int y = 0; y < listC.Count; y++)
                {
                    if (CustomerId == listC[i].Customer_Id)
                    {
                        listB[i].Bank_List_Customer.Add(listC[i]);
                    }
                }
            }
        }
        return listB;
    }
}
