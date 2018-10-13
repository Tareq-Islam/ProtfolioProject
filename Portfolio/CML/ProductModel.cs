using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML
{
    public class ProductModel
    {
        public long ProductID { get; set; }
        public long fkCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductFeature { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
