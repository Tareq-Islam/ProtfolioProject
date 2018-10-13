using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML
{
    public class CategoryProductMediaRModel
    {
        [DisplayName("Product ID")]
        public long ProductId { get; set; }
        
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [DisplayName("Category Name")]
       
        public string CategoryName { get; set; }

        public string Description { get; set; }
        [DisplayName("Product Feature")]
        public string ProductFeature { get; set; }
        [DisplayName("Display Order")]
        public Nullable<int> DisplayOrder { get; set; }
        [DisplayName("Active")]
        public Nullable<bool> IsActive { get; set; }
        
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ShortDetails { get; set; }
        [DisplayName("Default")]
        public Nullable<bool> IsDefault { get; set; }
        [DisplayName("Thumbnail")]
        public Nullable<bool> IsThumbnail { get; set; }

        public long ProductMrId { get; set; }
        public long CategoryId { get; set; }
        public long MediaId { get; set; }
    }
}
