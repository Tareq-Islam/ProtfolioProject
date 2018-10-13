using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CML;
using DAL.DBModel;
using WebFile.Models;

namespace DAL.DBClass
{
    public class Cpmdb:IDataManagement<CategoryProductMediaRModel>
    {
        private portfolioEntity db = new portfolioEntity();
        private portfolioEntity mdb = new portfolioEntity();
       
        public IEnumerable<CategoryProductMediaRModel> GetAll()
        {
            


            var data = from p in db.Product
                join c in db.Category on p.fkCategoryID equals c.CategoryID
                join r in db.ProductMGRef on p.ProductID equals r.fkProductID into pr
                from prm in pr.DefaultIfEmpty()
                from m in db.MediaGallery.Where(m => prm != null && m.MGID == prm.fkMGID).DefaultIfEmpty()
                //select new { p.Name, he = m == null ? String.Empty : m.Caption };
            select( new CategoryProductMediaRModel
            {
                //Product Item
                ProductId = p.ProductID,
                ProductName = p.Name,
                ProductFeature = p.ProductFeature,
                Description = p.Description,
                IsActive = p.IsActive,
               DisplayOrder = p.DisplayOrder,
                //Category Item
                CategoryName = c.CatName,
               
                
                //Media Item
              
                IsDefault = m == null ? false : m.IsDefault,
                FilePathOrLink = m.FilePathOrLink,


                ProductMrId = prm.ProductMGRefID
               
            });

            return data;
        }

        public CategoryProductMediaRModel Get(long? id)
        {
            long ID = Convert.ToInt64(id);
            CategoryProductMediaRModel PGet;
            if (id == null)
            {

                PGet = new CategoryProductMediaRModel();
            }
            else
            {
                var data = from p in db.Product
                           where p.ProductID == ID
                           join c in db.Category on p.fkCategoryID equals c.CategoryID
                           join pmr in db.ProductMGRef on p.ProductID equals pmr.fkProductID
                           join m in db.MediaGallery on pmr.fkMGID equals m.MGID

                           select (new CategoryProductMediaRModel
                           {
                               ProductId = p.ProductID,
                               ProductName = p.Name,
                               ProductFeature = p.ProductFeature,
                               Description = p.Description,
                               DisplayOrder = p.DisplayOrder,
                               IsActive = p.IsActive,
                               CategoryName = c.CatName,
                               IsThumbnail = m.IsThumbnail,
                               IsDefault = m.IsDefault,
                               ProductMrId = pmr.ProductMGRefID,
                               Caption = m.Caption,
                               ShortDetails = m.ShortDetails,
                               FilePathOrLink = m.FilePathOrLink,
                               MediaId = m.MGID,
                               CategoryId = p.fkCategoryID

                        });
                PGet = new CategoryProductMediaRModel();
                foreach (var item in data)
                {
                    PGet.ProductId = item.ProductId;
                    PGet.ProductName = item.ProductName;
                    PGet.ProductFeature = item.ProductFeature;
                    PGet.Description = item.Description;
                    PGet.DisplayOrder = item.DisplayOrder;
                    PGet.IsActive = item.IsActive;
                    PGet.CategoryName = item.CategoryName;
                    PGet.IsDefault = item.IsDefault;
                    PGet.IsThumbnail = item.IsThumbnail;
                    PGet.Caption = item.Caption;
                    PGet.ShortDetails = item.ShortDetails;
                    PGet.CategoryId = item.CategoryId;
                    PGet.MediaId = item.MediaId;
                    PGet.FilePathOrLink = item.FilePathOrLink;
                }
            }
           




            return PGet;

        }

        public CategoryProductMediaRModel Add(CategoryProductMediaRModel newItem)
        {

            try
            {
                if (newItem != null)
                {
                    //Product Table insert
                    Product pInfo = new Product();
                    pInfo.Name = newItem.ProductName;
                    pInfo.Description = newItem.Description;
                    pInfo.DisplayOrder = newItem.DisplayOrder;
                    pInfo.IsActive = newItem.IsActive;
                    pInfo.ProductFeature = newItem.ProductFeature;
                    pInfo.fkCategoryID = newItem.CategoryId;

                    db.Product.Add(pInfo);
                  
                  
                

                    //Media Gallery insert
                    MediaGallery mInfo = new MediaGallery();
                    mInfo.Caption = newItem.Caption;
                    mInfo.FilePathOrLink = newItem.FilePathOrLink;
                    mInfo.IsDefault = newItem.IsDefault;
                    mInfo.IsActive = newItem.IsActive;
                    mInfo.IsThumbnail = newItem.IsThumbnail;
                    mInfo.ShortDetails = newItem.ShortDetails;


                    db.MediaGallery.Add(mInfo);

                    db.SaveChanges();

                    newItem.ProductId = db.Product.Max(p => p.ProductID);
                    newItem.MediaId = db.MediaGallery.Max(m => m.MGID);
                }

                if ((newItem.ProductId > 0)&& (newItem.MediaId > 0))
                {

                    help(newItem.ProductId, newItem.MediaId);

                    
                }
                   
                
          



             }
            catch (Exception ex)
            {
                
                throw;
            }

           
            return newItem;
        }

    public CategoryProductMediaRModel Update(CategoryProductMediaRModel ItemVM)
    {
            try
            {

                if (ItemVM != null)
                {
                    var product = db.Product.Find(ItemVM.ProductId);
                  
                    var media = db.MediaGallery.Find(ItemVM.MediaId);
                    if (product != null)
                    {

                        product.Name = ItemVM.ProductName;
                        product.Description = ItemVM.Description;
                        product.DisplayOrder = ItemVM.DisplayOrder;
                        product.IsActive = ItemVM.IsActive;
                        product.ProductFeature = ItemVM.ProductFeature;
                        product.fkCategoryID = ItemVM.CategoryId;

                        db.SaveChanges();

                    }
                  
                    if (media != null)
                    {

                        media.Caption = ItemVM.Caption;
                        media.FilePathOrLink = ItemVM.FilePathOrLink;
                        media.ShortDetails = ItemVM.ShortDetails;
                        media.IsDefault = ItemVM.IsDefault;
                        media.IsThumbnail = ItemVM.IsThumbnail;
                       

                        db.SaveChanges();
                    }
                   
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return ItemVM;
   }

    public void Remove(long? id)
        {
            
            try
            {
               if (id > 0)
                {
                    CategoryProductMediaRModel obj = new CategoryProductMediaRModel();
                    var data = from p in db.Product
                        where p.ProductID == id
                        join pmr in db.ProductMGRef on p.ProductID equals pmr.fkProductID
                        join m in db.MediaGallery on pmr.fkMGID equals m.MGID
                        select (new CategoryProductMediaRModel{ProductMrId = pmr.ProductMGRefID, MediaId = m.MGID});

                    foreach (var item in data)
                    {
                        obj.ProductMrId = item.ProductMrId;
                        obj.MediaId = item.MediaId; 
                            
                    }

                   
                    var pRef = db.ProductMGRef.Find(obj.ProductMrId);
                    var media = db.MediaGallery.Find(obj.MediaId);
                    var product = db.Product.Find(id);
                   

                    if (pRef != null)
                    {
                        db.ProductMGRef.Remove(pRef);
                        db.SaveChanges();

                       
                       
                        if (product.ProductID > 0)
                        {

                            db.Product.Remove(product);
                            db.SaveChanges();
                        }
                        if (media.MGID > 0)
                        {
                            db.MediaGallery.Remove(media);
                            db.SaveChanges();
                        }
                    }
                   
                   
                    else
                    {
                        //not yet
                    }
                }
                else
                {
                    //not yet
                }
            }
            catch (Exception ex)
            {

                throw;
            }

           
            
        }
        public void help(long pId, long MId)
        {

            //Product and Media Gallery Ref
            ProductMGRef PMGRef = new ProductMGRef();
            PMGRef.fkProductID = pId;
            PMGRef.fkMGID = MId;
            mdb.ProductMGRef.Add(PMGRef);

            
            mdb.SaveChanges();
        }
    }
}

