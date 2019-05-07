using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseReqV3.Models
{
    public class Approval:Base
    {
        public int? PurchaseRequisitionId { get; set; }
        public PurchaseRequisition purchaseRequisition { get; set; }


        public enum APPROVALSTATUS { Approved, Rejected, Cancelled, Shipped, CannotProcess, Delivered, Processing }

        public APPROVALSTATUS ApprovalStatus { get; set; }

        public string ReasonForDenial { get; set; }
    }
}