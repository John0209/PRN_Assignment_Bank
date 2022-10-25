using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Interface.Bank;
using Assignment_1.ObjectData.Bank;
public interface InterfaceBank
{
    void CreateBank();
    void ShowListBank();
    void ShowListCustomerBank();
    void InserIntoBank(int bankId, int CustomerId);
}
