using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment_1.Function.Customer;

using Assignment_1.Function.Bank;
using Assignment_1.ObjectData.Customer;
using Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Account;
using System.Collections;

public class FunctionCustomer
{
    //Singleton Pattern
    private static FunctionCustomer instance = null;
    private static readonly object instanceLock = new object();
    private FunctionCustomer() { }
    public static FunctionCustomer Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new FunctionCustomer();
                }
                return instance;
            }
        }
    }
    //Get List Customer
    public List<Customer> GetListCustomer()
    {
        List<Customer> customer_List = new List<Customer>();
        customer_List.Add(new Customer(1, "John Son", "America"));
        customer_List.Add(new Customer(2, "Garen", "England"));
        customer_List.Add(new Customer(3, "Teemo", "London"));
        customer_List.Add(new Customer(4, "Wawick", "France"));
        customer_List.Add(new Customer(5, "Black Adam", "Russia"));
        return customer_List;
    }
    //Account Into Customer
    public List<Customer> IntoCustomer(int AccountId, int CustomerId, List<Customer> listC, List<Account> listA)
    {
        for (int i = 0; i < listC.Count; i++)
        {
            if (CustomerId == listC[i].Customer_Id)
            {
                if (listC[i].List_Account_Customer == null)
                {
                    listC[i].List_Account_Customer = new List<Account>();
                }
                //Get Infor Account Insert Customer
                for (int y = 0; y < listA.Count; y++)
                {
                    if (AccountId == listA[y].Account_Id)
                    {
                        listC[i].List_Account_Customer.Add(listA[y]);
                    }
                }
            }
        }//End For
        return listC;
    }

    //Print Information Customer
    public List<Customer> InformationCustomer(int CustomerId, List<Customer> listC, List<Bank> listB)
    {
        for (int i = 0; i < listC.Count; i++)
        {
            if (CustomerId == listC[i].Customer_Id)
            {
                //For List Bank
                if (listB != null) {
                    for (int y = 0; y < listB.Count; y++)
                    {
                        //For List Bank Have Customer Id
                        for (int x = 0; x < listB[y].Bank_List_Customer.Count; x++)
                        {
                            if (CustomerId == listB[y].Bank_List_Customer[x].Customer_Id)
                            {
                                if (listC[i].List_Name_Bank == null)
                                {
                                    listC[i].List_Name_Bank = new List<string>();
                                    //Add Name Bank 
                                    listC[i].List_Name_Bank.Add(listB[y].Bank_Name);
                                }
                                else
                                {
                                    //Check Trùng Name Bank
                                    int mask = 0;
                                    for (int z = 0; z < listC[i].List_Name_Bank.Count; z++)
                                    {
                                        if (Compare(listC[i].List_Name_Bank[z], listB[y].Bank_Name)==true)
                                        {
                                            mask = 1;
                                        }
                                    }
                                    //Add Name Bank 
                                    if(mask == 0) { 
                                    listC[i].List_Name_Bank.Add(listB[y].Bank_Name);
                                    }
                                }//end If list Name Bank null
                            }
                        }
                    }//End For List Bank
                }// End If List Bank != null
            }//End If Compare Customer Id
        }//End For List Customer
        return listC;
    }

    //Compare Name Bank, trả về true=1 if giống nhau
    bool Compare(string s1, string s2)
    {       
        return String.Compare(s1, s2) ==0 ;
    }
}
