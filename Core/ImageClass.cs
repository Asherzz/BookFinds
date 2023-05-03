using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookFind.Model;

namespace BookFind.Model
{
public partial class Product
    {

        public List<ProductPhoto> photos
        { 
            get 
            {
                return ProductPhoto.ToList();
            } 
        }
    }
}
