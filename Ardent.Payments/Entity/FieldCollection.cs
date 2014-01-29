﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Ardent.Payments.Entity {
    [XmlRoot("FIELDS")]
    public class FieldCollection {
        public FieldCollection() {
            this.Fields = new List<Field>();
        }

        [XmlElement("FIELD")]
        public List<Field> Fields { get; set; }

        public void Add(Field field) {
            this.Fields.Add(field);
        }

        public void AddRange(List<Field> fields) {
            this.Fields.AddRange(fields);
        }
    }
}
