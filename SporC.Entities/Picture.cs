using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporC.Entities
{
    public class Picture : BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

       public virtual Post? Post { get; set; }   
       public virtual User PicUser { get; set; }   
    }
}
