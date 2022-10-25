﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.ObjectData.Bank;
using Assignment_1.ObjectData.Customer;
using System.Net;
using System.Xml.Linq;

public class Bank
{
    private int _Bank_Id;
    private string _Bank_Name;
    private string _Bank_Address;
    private List<Customer> _Bank_List_Customer;

    public int Bank_Id { get; set; }
    public string Bank_Name { get; set; }
    public string Bank_Address { get; set; }
    public List<Customer> Bank_List_Customer { get; set; }

    public Bank()
    {
    }

    public Bank(int bank_Id, string bank_Name, string bank_Address)
    {
        Bank_Id = bank_Id;
        Bank_Name = bank_Name;
        Bank_Address = bank_Address;
    }

    public Bank(int bank_Id, string bank_Name, string bank_Address, List<Customer> bank_List_Customer)
    {
        Bank_Id = bank_Id;
        Bank_Name = bank_Name;
        Bank_Address = bank_Address;
        Bank_List_Customer = bank_List_Customer;
    }
    
    
    public virtual string DisplayBank()
    =>$"Id: {Bank_Id},Name: {Bank_Name}, Address:{Bank_Address}";
    public virtual string DisplayBankListCustomer()
    => $"Id: {Bank_Id},Name: {Bank_Name}, Address: {Bank_Address}, Customer: {Bank_List_Customer.ToString()}";
}
