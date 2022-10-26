using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Interface.Account;

public interface InterfaceAccount
{
    void GetListAccount();
    void ShowListAccount(int num);
    void ShowListTransactionInAccount(int AccountId);
    void ImplementTransaction(int idAccount);
}
