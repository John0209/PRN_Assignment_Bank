using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment_1.Function.Customer;

using Assignment_1.Function.Bank;
using Assignment_1.ObjectData.Customer;
using Assignment_1.ObjectData.Bank;

public class FunctionCustomer
{
    //
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
    public List<Customer> GetListCustomer() {
        List<Customer> customer_List = new List<Customer>();
        customer_List.Add(new Customer(1, "John Son", "America"));
        customer_List.Add(new Customer(2, "Garen", "England"));
        customer_List.Add(new Customer(3, "Teemo", "London"));
        customer_List.Add(new Customer(4, "Wawick", "France"));
        customer_List.Add(new Customer(5, "Black Adam", "Russia"));
        return customer_List;
    }
    
}
