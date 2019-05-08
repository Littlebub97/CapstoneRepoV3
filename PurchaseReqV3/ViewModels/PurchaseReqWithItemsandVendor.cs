using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseReqV3.Models;
using System.Web;

namespace PurchaseReqV3.ViewModels
{
    public class PurchaseReqWithItemsandVendor : Base
    {
        public string UserName { get; set; }

        public string ItemName { get; set; }

        public DateTime Date { get; set; }

        public Decimal Price { get; set; }

        public Decimal ActualPrice { get; set; }

    }
}