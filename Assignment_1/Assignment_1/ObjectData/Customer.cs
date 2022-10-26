using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.ObjectData.Customer;
using Assignment_1.ObjectData.Account;
public class Customer
{
    private int _Customer_Id;
    private string _Customer_Name;
    private string _Customer_Address;
    private List<Account> _List_Account_Customer;
    private List<String> _Name_Bank;
  

    public int Customer_Id { get;set ; }

    public string Customer_Name { get;set ; }

    public string Customer_Address { get;set ; }
    
    public List<Account> List_Account_Customer { get;set ; }
    public List<String> List_Name_Bank { get; set; }

    public Customer()
    {
    }

    

    public Customer(int customer_Id, string customer_Name, string customer_Address)
    {
        Customer_Id = customer_Id;
        Customer_Name = customer_Name;
        Customer_Address = customer_Address;
    }

    //Get list Account In Customer
    public void ShowAccountList(int num)
    {
        if (List_Account_Customer != null)
        {
            Console.WriteLine($"Account: ");
            foreach (Account a in List_Account_Customer)
            {
                Console.WriteLine(" + " + a.DisplayAccount());
                if (num == 1)
                {
                    break;
                }
            }
        }// End If List Account In Customer != null
    }

    //Show Account have Transaction in  Customer
    public void ShowAccountHaveTransactionInCustomer()
    {
        if (List_Account_Customer != null)
        {
            foreach (Account a in List_Account_Customer)
            {
                Console.WriteLine($"Account: ");
                Console.WriteLine(" + " + a.DisplayAccount());
                a.ShowTransactionList();
            }
        }// End If List Account In Customer != null
    }

    //Get list Bank In Customer
    public void ShowBankList()
    {
        if (List_Name_Bank != null)
        {
            Console.WriteLine($"Bank: ");
            foreach (String a in List_Name_Bank)
            {
                Console.WriteLine(" + " + a.ToString());
            }
        }// End If List Account In Customer != null
    }
    //Show
    public virtual string DisplayCustomerId()
   => $"Id: {Customer_Id}";
    public virtual string DisplayCustomer()
   => $"Id: {Customer_Id},Name: {Customer_Name}, Address: {Customer_Address}";
   

}
