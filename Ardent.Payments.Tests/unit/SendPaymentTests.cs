using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Ardent.Payments.Entity;
using Ardent.Payments;
using Ardent.Payments.Enum;
using Shouldly;
using System.Configuration;

namespace Ardent.Payments.Tests.unit {
    [TestFixture]
    public class SendPaymentTests {
        private string _transactionCenterID = string.Empty;
        private string _gatewayID = string.Empty;
        private int _processorID = 0;

        [TestFixtureSetUp]
        public void Setup() {
            _transactionCenterID = ConfigurationManager.AppSettings["Transaction.Center.ID"];
            _gatewayID = ConfigurationManager.AppSettings["Gateway.ID"];
            _processorID = int.Parse(ConfigurationManager.AppSettings["Processor.ID"]);
        }

        [Test]
        public void unit_send_payment_success() {
            Random rgen = new Random();
            var transaction = new TransactionRequest(_transactionCenterID, _gatewayID);
            transaction.OperationType = OperationType.Sale;
            transaction.OrderID = string.Format("{0}", rgen.Next(0, 1000) + rgen.Next(1000, 5000));
            transaction.OrderTotal = 2.00;
            transaction.ProcessorID = _processorID;

            transaction.CreditCard = new CreditCard {
                CardType = CardType.Visa,
                CardNumber = "4716389275666851",
                CardExpiration = "1214",
                CloseDate = DateTime.Now
            };

            transaction.BillingAddress = new BillingAddress {
                PersonName = "Joe Test",
                Street = "123 Test St",
                State = "TX",
                Country = "USA",
                Zipcode = "12345-6789"
            };

            //transaction.LineItems.Add(new LineItem {
            //    ItemSku = "1111",
            //    Description = "Test sku",
            //    Quantity = 1,
            //    Price = 2.00
            //});

            var results = TransactionManager.RequestPayment(transaction);
            results.Status.ShouldBe(1);
        }
    }
}
