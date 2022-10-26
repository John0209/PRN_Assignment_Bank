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
    public List<Bank> AddNewBank(List<Bank> listBank)
    {
        //declace field
        int Bank_Id;
        String Bank_Name;
        String Bank_Address;

        //Enter Field
        Console.Write("Enter Bank Id:");
        Bank_Id = int.Parse(Console.ReadLine());
        Console.Write("Enter Bank Name:");
        Bank_Name = Console.ReadLine();
        Console.Write("Enter Bank Address:");
        Bank_Address = Console.ReadLine();

        //Add new Bank
        Bank bank = new Bank(Bank_Id, Bank_Name, Bank_Address);

        //Get by Id
        Bank pro=GetById(Bank_Id,listBank);

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
                    if (CustomerId == listC[y].Customer_Id)
                    {
                        listB[i].Bank_List_Customer.Add(listC[y]);
                    }
                }
            }
        }
        return listB;
    }
}
