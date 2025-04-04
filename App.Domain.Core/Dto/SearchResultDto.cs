using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dto
{
    public class SearchResultDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
    }
}
