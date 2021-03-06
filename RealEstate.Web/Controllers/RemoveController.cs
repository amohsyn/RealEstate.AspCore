﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Base;
using RealEstate.Services.ServiceLayer;
using RealEstate.Web.Pages.Manage.User;

namespace RealEstate.Web.Controllers
{
    [Route("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class RemoveController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;
        private readonly ICustomerService _customerService;
        private readonly IPropertyService _propertyService;
        private readonly IEmployeeService _employeeService;
        private readonly IDivisionService _divisionService;
        private readonly IItemService _itemService;
        private readonly IDealService _dealService;
        private readonly IPaymentService _paymentService;
        private readonly IReminderService _reminderService;
        private readonly IPictureService _pictureService;

        public RemoveController(
            IUserService userService,
            IFeatureService featureService,
            ILocationService locationService,
            ICustomerService customerService,
            IDivisionService divisionService,
            IPropertyService propertyService,
            IItemService itemService,
            IDealService dealService,
            IPaymentService paymentService,
            IEmployeeService employeeService,
            IReminderService reminderService,
            IPictureService pictureService
            )
        {
            _userService = userService;
            _customerService = customerService;
            _locationService = locationService;
            _featureService = featureService;
            _propertyService = propertyService;
            _divisionService = divisionService;
            _itemService = itemService;
            _dealService = dealService;
            _employeeService = employeeService;
            _paymentService = paymentService;
            _reminderService = reminderService;
            _pictureService = pictureService;
        }

        [Route("facility/remove")]
        public async Task<IActionResult> FacilityAsync(string id)
        {
            var model = await _featureService.FacilityRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Facility.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("property/picture/remove")]
        public async Task<IActionResult> PropertyPictureAsync(string id, string propertyId)
        {
            var model = await _pictureService.PictureRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Item.PictureModel).Page(), new
            {
                status = model.GetDisplayName(),
                id = propertyId
            });
        }

        [Route("dealRequest/reject")]
        public async Task<IActionResult> DealRequestAsync(string id)
        {
            var model = await _itemService.RequestRejectAsync(id, true);
            return RedirectToPage(typeof(Pages.Manage.DealRequest.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("employee/payment/remove")]
        public async Task<IActionResult> PaymentAsync(string id, string employeeId)
        {
            var model = await _paymentService.PaymentRemoveAsync(id, employeeId);
            return RedirectToPage(typeof(Pages.Manage.Employee.DetailModel).Page(), new
            {
                status = model.GetDisplayName(),
                id = employeeId
            });
        }

        [Route("division/remove")]
        public async Task<IActionResult> DivisionAsync(string id)
        {
            var model = await _divisionService.RemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Division.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("item/remove")]
        public async Task<IActionResult> ItemAsync(string id)
        {
            var model = await _itemService.ItemRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Item.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        //[Route("presence/remove")]
        //public async Task<IActionResult> PresenceAsync(string id)
        //{
        //    var model = await _employeeService.PresenceRemoveAsync(id);
        //    return RedirectToPage(typeof(Pages.Manage.Presence.IndexModel).Page(), new
        //    {
        //        status = model
        //    });
        //}

        //[Route("leave/remove")]
        //public async Task<IActionResult> LeaveAsync(string id)
        //{
        //    var model = await _employeeService.LeaveRemoveAsync(id);
        //    return RedirectToPage(typeof(Pages.Manage.Leave.IndexModel).Page(), new
        //    {
        //        status = model
        //    });
        //}

        [Route("employee/remove")]
        public async Task<IActionResult> EmployeeAsync(string id)
        {
            var model = await _employeeService.EmployeeRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Employee.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        //[Route("managementpercent/remove")]
        //public async Task<IActionResult> ManagementPercentAsync(string id)
        //{
        //    var model = await _paymentService.ManagementPercentRemoveAsync(id);
        //    return RedirectToPage(typeof(Pages.Manage.ManagementPercent.IndexModel).Page(), new
        //    {
        //        status = model
        //    });
        //}

        [Route("reminder/remove")]
        public async Task<IActionResult> ReminderAsync(string id)
        {
            var model = await _reminderService.ReminderRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Reminder.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("feature/remove")]
        public async Task<IActionResult> FeatureAsync(string id)
        {
            var model = await _featureService.FeatureRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Feature.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("customer/remove")]
        public async Task<IActionResult> CustomerAsync(string id)
        {
            var model = await _customerService.CustomerRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Customer.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("applicant/remove")]
        public async Task<IActionResult> ApplicantAsync(string id)
        {
            var model = await _customerService.ApplicantRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Applicant.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("district/remove")]
        public async Task<IActionResult> DistrictAsync(string id)
        {
            var model = await _locationService.DistrictRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.District.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("category/remove")]
        public async Task<IActionResult> CategoryAsync(string id)
        {
            var model = await _featureService.CategoryRemoveAsync(id);
            return RedirectToPage(typeof(Pages.Manage.Category.IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }

        [Route("user/deactivate")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> UserDeActivateAsync(string id)
        {
            var model = await _userService.RemoveAsync(id);
            return RedirectToPage(typeof(IndexModel).Page(), new
            {
                status = model.GetDisplayName()
            });
        }
    }
}