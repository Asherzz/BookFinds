using BookFind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookFind.Core
{
    internal class AppData
    {
        public static BookFindEntities Context = new BookFindEntities();
        public static Frame MainFrame = new Frame(); 
    }
}
