using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.ObjectData.Transaction;

public class Transaction
{
    private int _Transaction_Id;
    private double _Transaction_Money;
    private string _Transaction_DateOnly;
    private string _Transaction_IsActive;

    public int Transaction_Id { get; set; }
    public double Transaction_Money { get; set; }
    public string Transaction_DateOnly { get; set; }
    public string Transaction_IsActive { get; set; }

    public Transaction()
    {
    }

    public Transaction(int transaction_Id, double transaction_Money, string transaction_DateOnly, string transaction_IsActive)
    {
        Transaction_Id = transaction_Id;
        Transaction_Money = transaction_Money;
        Transaction_DateOnly = transaction_DateOnly;
        Transaction_IsActive = transaction_IsActive;
    }
    public virtual string DisplayTransaction()
    => $"Id: {Transaction_Id},Date Transaction: {Transaction_DateOnly}, Money Transaction: {Transaction_Money}, Type Transaction: {Transaction_IsActive}";
}
