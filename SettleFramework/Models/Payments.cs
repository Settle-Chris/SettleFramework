using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SettleFramework.Models
{
    public class Payments
    {
    }

    public class PaymentRequest
    {
        [Key]
        public Guid RequestID { get; set; }
        public float RequestAmount { get; set; }
        public virtual ApplicationUser RequestingUser { get; set; }
        public virtual ApplicationUser RequestedUser { get; set; }
        public string RequestedEmail { get; set; }
        public int RequestedPhone { get; set; }
        public string RequestFromNickName { get; set; }
        public string RequestFromFirstName { get; set; }
        public string RequestFromLastName { get; set; }
        public string RequestFromAddress1 { get; set; }
        public string RequestFromAddress2 { get; set; }
        public DateTime RequestTime { get; set; }
    }

    public class PaymentSent
    {
        [Key]
        public Guid RequestID { get; set; }
        public float RequestAmount { get; set; }
        public virtual ApplicationUser SendingUser { get; set; }
        public virtual ApplicationUser SentToUser { get; set; }
        public string SendToEmail { get; set; }
        public int SendToPhone { get; set; }
        public string SendToNickName { get; set; }
        public string SendToFirstName { get; set; }
        public string SendToLastName { get; set; }
        public string SendToAddress1 { get; set; }
        public string SendTOAddress2 { get; set; }
        public DateTime SentTime { get; set; }
    }

    public class PaymentTransaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        public virtual PaymentRequest Request { get; set; }
        public virtual PaymentSent Send { get; set; }
        public float TransactionAmount { get; set; }
        public float TransactionFeeAmount { get; set; }
        public bool TransactionSuccess { get; set; }
        public bool TransactionInformation { get; set; }
    }
}