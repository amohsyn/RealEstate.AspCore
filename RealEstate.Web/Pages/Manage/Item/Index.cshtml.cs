﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using RealEstate.Base;
using RealEstate.Base.Enums;
using RealEstate.Resources;
using RealEstate.Services;
using RealEstate.Services.Extensions;
using RealEstate.Services.ViewModels;
using RealEstate.Services.ViewModels.Search;
using System.Threading.Tasks;
using RealEstate.Services.ServiceLayer;
using RealEstate.Services.ViewModels.ModelBind;

namespace RealEstate.Web.Pages.Manage.Item
{
    public class IndexModel : PageModel
    {
        private readonly IItemService _itemService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public IndexModel(
            IItemService itemService,
            IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _itemService = itemService;
            _localizer = sharedLocalizer;
        }

        [BindProperty]
        public ItemSearchViewModel SearchInput { get; set; }

        public PaginationViewModel<ItemViewModel> List { get; set; }

        public StatusEnum Status { get; set; }

        public string PageTitle => _localizer["Items"];

        public async Task OnGetAsync(string pageNo, string status, string id, string street, string itemCategory, string ownerName, string customerId,
            string features, string facilities, string propertyCategory, string district, bool deleted, string ownerMobile, string dateFrom, string dateTo, string creatorId, string hasFeature)
        {
            SearchInput = new ItemSearchViewModel
            {
                PageNo = pageNo.FixPageNumber(),
                Street = street,
                ItemCategory = itemCategory,
                Owner = ownerName,
                ItemId = id,
                CustomerId = customerId,
                FeaturesJson = features,
                FacilitiesJson = facilities,
                PropertyCategory = propertyCategory,
                District = district,
                IncludeDeletedItems = deleted,
                OwnerMobile = ownerMobile,
                CreationDateFrom = dateFrom,
                CreationDateTo = dateTo,
                CreatorId = creatorId,
                HasFeature = hasFeature
            };

            Status = !string.IsNullOrEmpty(status) && int.TryParse(status, out var statusInt)
                ? (StatusEnum)statusInt
                : StatusEnum.Ready;
            List = await _itemService.ItemListAsync(SearchInput).ConfigureAwait(false);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(typeof(IndexModel).Page(), SearchInput.GetSearchParameters());
        }
    }
}