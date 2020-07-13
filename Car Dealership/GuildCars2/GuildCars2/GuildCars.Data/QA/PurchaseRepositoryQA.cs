using GuildCars.Data.Interface;
using GuildCars.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.QA
{
    public class PurchaseRepositoryQA : IPurchaseRepository
    {
        public void CreatePurchase(Purchases purchase)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchase(Purchases purchase)
        {
            throw new NotImplementedException();
        }

        public List<Purchases> ReadAllPurchases()
        {
            throw new NotImplementedException();
        }

        public Purchases ReadByPurchaseId(int purchaseId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchase(Purchases purchase)
        {
            throw new NotImplementedException();
        }
    }
}
