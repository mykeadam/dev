using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewyorkTimes_BestSellers.Models;

namespace NewyorkTimes_BestSellers.ViewModel
{
   public class MainViewModel
    {
       public MainViewModel()
       { 
       
       }

      public BestSeller FictionBestSellers
       {
          get
           {
               return BestSeller.Current;
           }
       }

    }
}
