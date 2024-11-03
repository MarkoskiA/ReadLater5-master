using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DTOs
{
    //Dto is used when we sent object to the external source
    //In the future maybe we will not want to sent all the data that bookmark contains
    public class BookmarkDto
    {
        public int ID { get; set; }

        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
