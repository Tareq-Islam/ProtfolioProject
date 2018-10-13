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
    public class CategoryDb : IDataManagement<CategoryModel>
    {
        private portfolioEntity db = new portfolioEntity();
        public IEnumerable<CategoryModel> GetAll()
        {
            IEnumerable<CategoryModel> data = db.Category.Select(s => new CategoryModel
            {
               
                //Category Item
                CategoryId = s.CategoryID,
                CatName = s.CatName,
                DisplayOrder = s.DisplayOrder,
                IsActive = s.IsActive,
              

            });

            return data;
        }

        public CategoryModel Get(long? id)
        {

            CategoryModel CM;
            if (id == null)
            {

                CM = new CategoryModel();
            }
            else
            {
                var category = db.Category.Find(id);

                CM = new CategoryModel();

                CM.CategoryId = category.CategoryID;
                CM.CatName = category.CatName;
                CM.DisplayOrder = category.DisplayOrder;
                CM.IsActive = category.IsActive;
            }


            return CM;

           
        }

        public CategoryModel Add(CategoryModel newItem)
        {
            Category cInfo = new Category();
            cInfo.CatName = newItem.CatName;
            cInfo.DisplayOrder = newItem.DisplayOrder;
            cInfo.IsActive = newItem.IsActive;

            db.Category.Add(cInfo);
            db.SaveChanges();
            newItem.CategoryId = db.Category.Max(c => c.CategoryID);

            return newItem;
        }

        public CategoryModel Update(CategoryModel ItemVM)
        {
            try
            {

                if (ItemVM != null)
                {
                    
                    var category = db.Category.Find(ItemVM.CategoryId);
                    
                    if (category != null)
                    {

                        category.CatName = ItemVM.CatName;
                        category.DisplayOrder = ItemVM.DisplayOrder;
                        category.IsActive = ItemVM.IsActive;

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
                    
                    var category = db.Category.Find(id);
                    

                    if (category != null)
                    {
                        db.Category.Remove(category);
                        db.SaveChanges();
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
    }
}
