using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class DashboardAppService : IDashboardAppService
    {
        private readonly IUserService _userService;

        public DashboardAppService(IUserService userService)
        {
            _userService = userService;
        }

        public StatisticsDataDto GetStatisticsData()
        {
            var model = new StatisticsDataDto();

            model.UserCount = _userService.GetCount();
            model.ServiceCount = 100;
            model.CategoryCount = 15;
            model.OrderCount = 3;

            return model;
        }
    }
}
