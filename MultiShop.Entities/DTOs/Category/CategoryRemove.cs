using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultiShop.Entities.Concreate;

namespace MultiShop.Entities.DTOs.Category
{
    public class CategoryRemove
    {
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public List<CategoryLanguage>  CategoryLanguages{ get; set; }
    }
}
