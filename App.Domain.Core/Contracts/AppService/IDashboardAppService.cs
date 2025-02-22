using App.Domain.Core.Dto.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IDashboardAppService
    {
        StatisticsDataDto GetStatisticsData();
    }
}
