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
    private DateOnly _Transaction_DateOnly;
    private Boolean _Transaction_IsActive;

    public int Transaction_Id { get; set; }
    public double Transaction_Money { get; set; }
    public DateOnly Transaction_DateOnly { get; set; }
    public Boolean Transaction_IsActive { get; set; }

    public Transaction()
    {
    }

    public Transaction(int transaction_Id, double transaction_Money, DateOnly transaction_DateOnly, bool transaction_IsActive)
    {
        Transaction_Id = transaction_Id;
        Transaction_Money = transaction_Money;
        Transaction_DateOnly = transaction_DateOnly;
        Transaction_IsActive = transaction_IsActive;
    }
}
