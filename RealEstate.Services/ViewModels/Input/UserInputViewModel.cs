﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.Base;
using RealEstate.Base.Attributes;
using RealEstate.Base.Enums;
using RealEstate.Resources;
using RealEstate.Services.ViewModels.Json;

namespace RealEstate.Services.ViewModels.Input
{
    public class UserInputViewModel : BaseInputViewModel
    {
        private string _userPropertyCategoriesJson;
        private string _userItemCategoriesJson;

        [Display(ResourceType = typeof(SharedResource), Name = "Username")]
        [ValueValidation(RegexPatterns.EnglishText)]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        [MinLength(4, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "MinLength")]
        public string Username { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "MinLength")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Role")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        public Role Role { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        [Display(ResourceType = typeof(SharedResource), Name = "Employee")]
        public string EmployeeId { get; set; }

        [HiddenInput]
        public string UserPropertyCategoriesJson
        {
            get => _userPropertyCategoriesJson;
            set => _userPropertyCategoriesJson = JsonExtensions.InitJson(value);
        }

        public List<UserPropertyCategoryJsonViewModel> UserPropertyCategories
        {
            get => JsonExtensions.Deserialize<List<UserPropertyCategoryJsonViewModel>>(UserPropertyCategoriesJson);
            set => UserPropertyCategoriesJson = value.Serialize();
        }

        [HiddenInput]
        public string UserItemCategoriesJson
        {
            get => _userItemCategoriesJson;
            set => _userItemCategoriesJson = JsonExtensions.InitJson(value);
        }

        public List<UserItemCategoryJsonViewModel> UserItemCategories
        {
            get => JsonExtensions.Deserialize<List<UserItemCategoryJsonViewModel>>(UserItemCategoriesJson);
            set => UserItemCategoriesJson = value.Serialize();
        }
    }
}