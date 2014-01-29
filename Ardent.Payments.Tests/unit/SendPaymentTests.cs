using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
































































































































































using System.Threading.Tasks;
using NUnit.Framework;
using Ardent.Payments.Entity;
using Ardent.Payments;
using Ardent.Payments.Enum;
using Shouldly;

namespace Ardent.Payments.Tests.unit {
    [TestFixture]
    public class SendPaymentTests {

        [Test]
        public void unit_send_payment_success() {
            var transaction = new Transaction("1264", "a91c38c3-7d7f-4d29-acc7-927b4dca0dbe");
            transaction.OperationType = OperationType.Sale;
            transaction.OrderID = "1231231254643523434";
            transaction.OrderTotal = 29.99;
            transaction.RemoteIPAddress = "192.168.1.1";

            transaction.CreditCard = new CreditCard {
                CardType =CardType.Visa,
                CardNumber = "44111111111111111",
                CVV2 = 123,
                CardExpiration = 1214,
                CloseDate = DateTime.Now
            };

            transaction.BillingAddress = new BillingAddress {
                PersonName = "Joe Test",
                Street = "123 Test St",
                Zipcode = "12345-6789"
            };

            transaction.LineItems.Add(new LineItem {
                ItemSku = "1111",
                Description = "Test sku",
                Quantity = 1,
                Price = 29.99
            });

            var results = TransactionManager.RequestPayment(transaction);
            results.ShouldNotBe(string.Empty);
        }
    }
}
