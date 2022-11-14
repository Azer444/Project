using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Helper
{
    public class Pagination<T>
    {
        public List<T> Datas { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

        public Pagination(List<T> datas,int currentPage,int totalPages)
        {
            Datas = datas;
            CurrentPage = currentPage;
            TotalPage = totalPages;

        }

        public bool HasPrevious 
        { 
            get
            {
                return CurrentPage > 1;
            } 
        }
        public bool HasNext 
        {
            get
            {
            return CurrentPage > TotalPage;
            
            } 
        }
    }
}
