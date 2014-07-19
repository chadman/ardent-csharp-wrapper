﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Ardent.Payments.Extensions;

namespace Ardent.Payments.Entity {
    public class CreditCard {
        /// <summary>
        /// Type of card
        /// </summary>
        [XmlIgnore]
        public Ardent.Payments.Enum.CardType? CardType { get; set; }

        /// <summary>
        /// Credit card account number
        /// </summary>
        [XmlIgnore]
        public string CardNumber { get; set; }

        /// <summary>
        /// Credit card expiration date. MMYY format
        /// </summary>
        [XmlIgnore]
        public string CardExpiration { get; set; }

        /// <summary>
        /// Credit card security code, cvv2, cvc, cid
        /// </summary>
        [XmlIgnore]
        public int CVV2 { get; set; }

        /// <summary>
        /// Set to true for doing small pre authorizations to determine a vlid card, AVS or CVV2. The transaction will be immediately voided.
        /// </summary>
        [XmlIgnore]
        public bool ValidateOnly { get; set; }

        /// <summary>
        /// The date the transaction is intended to post if not immediate
        /// </summary>
        [XmlIgnore]
        public DateTime? CloseDate { get; set; }

        internal List<Field> ToFields() {
            var fields = new List<Field>();

            fields.Add(new Field("card_name", this.CardType.HasValue ? this.CardType.ToDescription() : "yes"));
            fields.Add(new Field("card_number", this.CardNumber));
            fields.Add(new Field("card_exp", this.CardExpiration));
            fields.Add(new Field("cc_validate", this.ValidateOnly ? "1" : "0"));
            fields.Add(new Field("close_date", this.CloseDate.HasValue ? this.CloseDate.Value.ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/tttt")));

            return fields;
        }
    }
}
