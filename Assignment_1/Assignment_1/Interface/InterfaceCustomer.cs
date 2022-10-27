using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Interface.Customer;

public interface InterfaceCustomer
{
    void GetCustomer();
    void ShowListCustomer(int num);
    void ShowListAccountInCustomer(int customerId,int i);
    void ShowListCustomerHaveTransaction(int i);
    void InserIntoCustomer(int accountId, int customerId);
    void LargestTransaction();
    void SortAscendingSumMoney();
    void PrintInformationCustomer(int idCus);
}
