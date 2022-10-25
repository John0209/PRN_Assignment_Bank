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

    public int Customer_Id { get;set ; }

    public string Customer_Name { get;set ; }

    public string Customer_Address { get;set ; }

    public List<Account> List_Account_Customer { get;set ; }

    public Customer()
    {
    }

    public Customer(int customer_Id, string customer_Name, string customer_Address)
    {
        Customer_Id = customer_Id;
        Customer_Name = customer_Name;
        Customer_Address = customer_Address;
    }


    public Customer(int customer_Id, string customer_Name, string customer_Address, List<Account> list_Account_Customer)
    {
        Customer_Id = customer_Id;
        Customer_Name = customer_Name;
        Customer_Address = customer_Address;
        List_Account_Customer = list_Account_Customer;
    }
    public virtual string DisplayCustomer()
   => $"Id: {Customer_Id},Name: {Customer_Name}, Address:{Customer_Address}";

    public override string? ToString()
        => $"Id: {Customer_Id},Name: {Customer_Name}, Address:{Customer_Address}";
}
