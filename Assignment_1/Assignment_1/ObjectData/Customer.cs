using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.ObjectData.Customer;

using Assignment_1.Function.Account;
using Assignment_1.ObjectData.Account;
public class Customer
{
    private int _Customer_Id;
    private string _Customer_Name;
    private string _Customer_Address;
    private List<Account> _List_Account_Customer;
    private List<String> _Name_Bank;
    private double _Sum_Money;

    public int Customer_Id { get;set ; }

    public string Customer_Name { get;set ; }

    public string Customer_Address { get;set ; }
    public double Sum_Money { get;set ; }
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

    //Sorting Account Money Discending
    public void SortingMoneyAccountDiscending()
    {
        if (List_Account_Customer != null)
        {
            List_Account_Customer = FunctionAccount.Instance.SortMoneyLargest(List_Account_Customer);
        }
    }

    //Get list Account In Customer
    public void ShowAccountList(int num)
    {
        if (List_Account_Customer != null)
        {
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

    //Show List Customer Account have Transaction 
    public void ShowAccountHaveTransactionInCustomer(int i)
    {
        if (List_Account_Customer != null)
        {
            foreach (Account a in List_Account_Customer)
            {
                Console.WriteLine(" + " + a.DisplayAccount());
                a.ShowTransactionList();
                if (i == 1)
                    {
                        break;
                    }
            }
        }// End If List Account In Customer != null
    }

    //Get list Bank In Customer
    public void ShowBankList()
    {
        if (List_Name_Bank != null)
        {
            foreach (String a in List_Name_Bank)
            {
                Console.WriteLine(" + <- Bank ->: " + a.ToString());
            }
        }// End If List Account In Customer != null
    }

    //Display information Customer
    public virtual string DisplayCustomerId()
   => $"<- Customer -> Id: {Customer_Id}";
    public virtual string DisplayCustomer()
   => $"<- Customer -> Id: {Customer_Id},Name: {Customer_Name}, Address: {Customer_Address}";
    public virtual string DisplayCustomerSumMoney()
    => $"<- Customer -> Id: {Customer_Id},Name: {Customer_Name}, Address: {Customer_Address}, SumMoney: {Sum_Money}";

}
