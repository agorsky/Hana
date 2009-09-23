using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hana.Model {
    public class Category {
        public Category(){}
        public Category(string desc) {
            Description = desc;
        }
        public string Description { get; set; }
        public int ID { get; set; }

        public override bool Equals(object obj) {
            if (obj.GetType() == typeof(Category)) {
                var comp = (Category)obj;
                return comp.Description.Equals(Description, StringComparison.InvariantCultureIgnoreCase);
            }

            return base.Equals(obj);
        }
    }
}
