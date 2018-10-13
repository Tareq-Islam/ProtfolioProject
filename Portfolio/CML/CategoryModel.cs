using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML
{
    public class CategoryModel
    {
        public long CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string CatName { get; set; }
        [DisplayName("Display Order")]
        public Nullable<int> DisplayOrder { get; set; }
        [DisplayName("Active")]
        public Nullable<bool> IsActive { get; set; }
    }
}
