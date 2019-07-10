﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.Base;
using RealEstate.Base.Attributes;
using RealEstate.Resources;
using RealEstate.Services.ViewModels.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Services.ViewModels.Input
{
    public class PropertyInputViewModel : BaseInputViewModel
    {
        private string _ownershipsJson;
        private string _propertyFeaturesJson;
        private string _propertyFacilitiesJson;

        [Display(ResourceType = typeof(SharedResource), Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        [ValueValidation(RegexPatterns.SafeText)]
        public string Address { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Alley")]
        [ValueValidation(RegexPatterns.SafeText)]
        public string Alley { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "BuildingName")]
        [ValueValidation(RegexPatterns.SafeText)]
        public string BuildingName { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "BuildingNumber")]
        [ValueValidation(RegexPatterns.SafeText)]
        public string Number { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Floor")]
        public int Floor { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "FlatNumber")]
        public int Flat { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "PropertyCategory")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        public string CategoryId { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Description")]
        [ValueValidation(RegexPatterns.SafeText)]
        public string Description { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "District")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        public string DistrictId { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Display(ResourceType = typeof(SharedResource), Name = "Owners")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "FieldRequired")]
        [HiddenInput]
        public string OwnershipsJson
        {
            get => _ownershipsJson;
            set => _ownershipsJson = value.JsonSetAccessor();
        }

        public List<OwnershipJsonViewModel> Ownerships
        {
            get => OwnershipsJson.JsonGetAccessor<OwnershipJsonViewModel>();
            set => OwnershipsJson = value.JsonSetAccessor();
        }

        [Display(ResourceType = typeof(SharedResource), Name = "PropertyFeatures")]
        [HiddenInput]
        public string PropertyFeaturesJson
        {
            get => _propertyFeaturesJson;
            set => _propertyFeaturesJson = value.JsonSetAccessor();
        }

        public List<FeatureJsonValueViewModel> PropertyFeatures
        {
            get => PropertyFeaturesJson.JsonGetAccessor<FeatureJsonValueViewModel>();
            set => PropertyFeaturesJson = value.JsonSetAccessor();
        }

        [Display(ResourceType = typeof(SharedResource), Name = "PropertyFacilities")]
        [HiddenInput]
        public string PropertyFacilitiesJson
        {
            get => _propertyFacilitiesJson;
            set => _propertyFacilitiesJson = value.JsonSetAccessor();
        }

        public List<FacilityJsonViewModel> PropertyFacilities
        {
            get => PropertyFacilitiesJson.JsonGetAccessor<FacilityJsonViewModel>();
            set => PropertyFacilitiesJson = value.JsonSetAccessor();
        }
    }
}