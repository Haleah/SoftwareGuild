using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interface
{
    public interface IPurchaseRepository
    {
        List<Purchases> ReadAllPurchases();
        Purchases ReadByPurchaseId(int purchaseId);
        void CreatePurchase(Purchases purchase);
        void UpdatePurchase(Purchases purchase);
        void DeletePurchase(Purchases purchase);
    }
}
