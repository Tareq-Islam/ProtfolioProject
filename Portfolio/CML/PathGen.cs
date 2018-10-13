using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CML
{
    public static class PathGen
    {
        public static string PathGena(HttpPostedFileBase file)
        {
            string path=string.Empty;
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    path = "/img/upload/" + fileName;
                    string pathGen = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("/img/upload/"), fileName ?? throw new InvalidOperationException());
                    file.SaveAs(pathGen);
                }
              
               
            }
            catch(Exception)
            {
               //
              
            }
            return path;
        }
    }
}
