using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFile.Areas.Admin.Models.ViewModel
{
   public class ProductViewModel 
   {
       [Display(Name = "Product ID")]
        public long ProductID { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

       [Required(ErrorMessage = "Value is required!")]
       [MaxLength(20, ErrorMessage = "Maximum Value 20!")]
       [Display(Name = "Product Name")]
       [DataType(DataType.Text)]
        public string ProductName { get; set; }

       [Required(ErrorMessage = "Value is required!")]
       [Display(Name = "Product Name")]
       [DataType(DataType.Text)]
        public string Description { get; set; }
        public string ProductFeature { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public long CategoryID { get; set; }    
        public long  MGID { get; set; }
        public Nullable<long> fkParentMGID { get; set; }
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ShortDetails { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsThumbnail { get; set; }
    }
}
