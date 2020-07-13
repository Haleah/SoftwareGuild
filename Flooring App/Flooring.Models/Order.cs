using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class Order
    {
        
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }//Area * CostPerSquareFoot
        public decimal LaborCost { get; set; }//Area * LaborCostPerSquareFoot
        public decimal Tax { get; set; }//(MaterialCost + LaborCost) * (TaxRate/100)
        public decimal Total { get; set; }//MaterialCost + LaborCost + Tax
        //last 4 need to be fiiled out after"work" is completed
    }
}
