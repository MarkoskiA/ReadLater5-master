using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Request
{
    //Request is used when we get Bookmark object from the external source
    //In the future maybe we will not be able to retrieve the whole bookmark object because we sent the Dto firstly
    public class BookmarkRequest
    {
        public int ID { get; set; }

        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
