using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
   public class ProductViewModel 
   {
       [Display(Name = "Product ID")]
        public long ProductID { get; set; }
        public long fkCategoryID { get; set; }

       [Required(ErrorMessage = "Value is required!")]
       [MaxLength(20, ErrorMessage = "Maximum Value 20!")]
       [Display(Name = "Product Name")]
       [DataType(DataType.Text)]
        public string Name { get; set; }

       [Required(ErrorMessage = "Value is required!")]
       [MaxLength(150, ErrorMessage = "Maximum Value 150!")]
       [Display(Name = "Product Name")]
       [DataType(DataType.Text)]
        public string Description { get; set; }
        public string ProductFeature { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public IQueryable<CategoryViewModel> Categorys { get; set; }
        public IQueryable<MediaGalleryViewModel> Mediaes { get; set; }
   }
    public class CategoryViewModel
    {
        [Display(Name = "Category ID")]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = "Value is required!")]
        [MaxLength(20, ErrorMessage = "Maximum Value 20!")]
        [Display(Name = "Category Name")]
        [DataType(DataType.Text)]
        public string CatName { get; set; }

        [Display(Name = "Display Order")]
        [Range(1,10,ErrorMessage = "Range Value 1 to 10!")]
        public Nullable<int> DisplayOrder { get; set; }
        [Display(Name = "Active")]
        public Nullable<bool> IsActive { get; set; }
    }
    public class MediaGalleryViewModel
    {
        public long  MGID { get; set; }
        public Nullable<long> fkParentMGID { get; set; }
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ShortDetails { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsThumbnail { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
