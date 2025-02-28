using App.Domain.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entites.Service
{
    public class ExpertHouseWork
    {
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }

        public int HouseWorkId { get; set; }
        public HouseWork HouseWork { get; set; }
    }

}
