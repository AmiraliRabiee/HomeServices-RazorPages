using App.Domain.Core.Contracts.AppService;
using App.Domain.Core.Dto;
using App.Domain.Core.Entites.OutputResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeServices_RazorPage.Pages.Client
{
    public class ClientIndexModel : PageModel
    {
        private readonly IBaseDataAppService _baseDataAppService;

        public ClientIndexModel(IBaseDataAppService baseDataAppService)
        {
            _baseDataAppService = baseDataAppService;
        }

        public SearchResultDto Result { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            //var searchResults = await _baseDataAppService.GetSearchResultById(id);
            //Result = searchResults.FirstOrDefault(r => r.Id == id);

            if (Result == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
