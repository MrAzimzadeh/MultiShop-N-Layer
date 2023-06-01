using MultiShop.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs.Category
{
    public class CategoryCreateDTO
    {

        public List<CategoryLanguage> CategoryLanguages { get; set; }
        public string PhotoUrl { get; set; }
    }
}
