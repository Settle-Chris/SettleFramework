namespace SettleFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestsAndTransactions1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentRequests",
                c => new
                    {
                        RequestID = c.Guid(nullable: false),
                        RequestAmount = c.Single(nullable: false),
                        RequestedEmail = c.String(),
                        RequestedPhone = c.Int(nullable: false),
                        RequestFromNickName = c.String(),
                        RequestFromFirstName = c.String(),
                        RequestFromLastName = c.String(),
                        RequestFromAddress1 = c.String(),
                        RequestFromAddress2 = c.String(),
                        RequestTime = c.DateTime(nullable: false),
                        RequestedUser_Id = c.String(maxLength: 128),
                        RequestingUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestedUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestingUser_Id)
                .Index(t => t.RequestedUser_Id)
                .Index(t => t.RequestingUser_Id);
            
            CreateTable(
                "dbo.PaymentSents",
                c => new
                    {
                        RequestID = c.Guid(nullable: false),
                        RequestAmount = c.Single(nullable: false),
                        SendToEmail = c.String(),
                        SendToPhone = c.Int(nullable: false),
                        SendToNickName = c.String(),
                        SendToFirstName = c.String(),
                        SendToLastName = c.String(),
                        SendToAddress1 = c.String(),
                        SendTOAddress2 = c.String(),
                        SentTime = c.DateTime(nullable: false),
                        SendingUser_Id = c.String(maxLength: 128),
                        SentToUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.AspNetUsers", t => t.SendingUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SentToUser_Id)
                .Index(t => t.SendingUser_Id)
                .Index(t => t.SentToUser_Id);
            
            CreateTable(
                "dbo.PaymentTransactions",
                c => new
                    {
                        TransactionID = c.Guid(nullable: false),
                        TransactionAmount = c.Single(nullable: false),
                        TransactionFeeAmount = c.Single(nullable: false),
                        TransactionSuccess = c.Boolean(nullable: false),
                        TransactionInformation = c.Boolean(nullable: false),
                        Request_RequestID = c.Guid(),
                        Send_RequestID = c.Guid(),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.PaymentRequests", t => t.Request_RequestID)
                .ForeignKey("dbo.PaymentSents", t => t.Send_RequestID)
                .Index(t => t.Request_RequestID)
                .Index(t => t.Send_RequestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentTransactions", "Send_RequestID", "dbo.PaymentSents");
            DropForeignKey("dbo.PaymentTransactions", "Request_RequestID", "dbo.PaymentRequests");
            DropForeignKey("dbo.PaymentSents", "SentToUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentSents", "SendingUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentRequests", "RequestingUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaymentRequests", "RequestedUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PaymentTransactions", new[] { "Send_RequestID" });
            DropIndex("dbo.PaymentTransactions", new[] { "Request_RequestID" });
            DropIndex("dbo.PaymentSents", new[] { "SentToUser_Id" });
            DropIndex("dbo.PaymentSents", new[] { "SendingUser_Id" });
            DropIndex("dbo.PaymentRequests", new[] { "RequestingUser_Id" });
            DropIndex("dbo.PaymentRequests", new[] { "RequestedUser_Id" });
            DropTable("dbo.PaymentTransactions");
            DropTable("dbo.PaymentSents");
            DropTable("dbo.PaymentRequests");
        }
    }
}
