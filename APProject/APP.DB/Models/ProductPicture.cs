using System;
using System.Collections.Generic;
using System.Text;

namespace APP.DB.Models
{
    class ProductPicture
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
