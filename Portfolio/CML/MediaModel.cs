using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML
{
    public class MediaModel
    {
        public long MGID { get; set; }
        public Nullable<long> fkParentMGID { get; set; }
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ShortDetails { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<bool> IsThumbnail { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
