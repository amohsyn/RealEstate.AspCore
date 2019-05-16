﻿using Newtonsoft.Json;
using RealEstate.Services.BaseLog;
using RealEstate.Services.Database.Tables;
using RealEstate.Services.Extensions;
using System;
using System.Collections.Generic;

namespace RealEstate.Services.ViewModels.ModelBind
{
    public class PropertyViewModel : BaseLogViewModel
    {
        [JsonIgnore]
        public Property Entity { get; }

        public PropertyViewModel(Property entity)
        {
            if (entity == null)
                return;

            Entity = entity;
        }

        public string Address => Entity?.Address;
        public string Street => Entity?.Street;

        public string Alley => Entity?.Alley;

        public string BuildingName => Entity?.BuildingName;
        public string Number => Entity?.Number;
        public int Floor => Entity?.Floor ?? 0;
        public int Flat => Entity?.Flat ?? 0;
        public GeolocationViewModel Geolocation => Entity != null ? new GeolocationViewModel(Entity.Geolocation) : default;

        public string Description => Entity?.Description;

        public PropertyOwnershipViewModel CurrentPropertyOwnership() => PropertyOwnerships?.LazyLoadLast();

        public Lazy<CategoryViewModel> Category =>
            LazyLoadExtension.LazyLoad(() => Entity?.Category.Map<Category, CategoryViewModel>());

        public Lazy<DistrictViewModel> District =>
            LazyLoadExtension.LazyLoad(() => Entity?.District.Map<District, DistrictViewModel>());

        public Lazy<List<ItemViewModel>> Items =>
            LazyLoadExtension.LazyLoad(() => Entity?.Items.Map<Item, ItemViewModel>());

        public Lazy<List<PropertyOwnershipViewModel>> PropertyOwnerships =>
            LazyLoadExtension.LazyLoad(() => Entity?.PropertyOwnerships.Map<PropertyOwnership, PropertyOwnershipViewModel>());

        public Lazy<List<PictureViewModel>> Pictures =>
            LazyLoadExtension.LazyLoad(() => Entity?.Pictures.Map<Picture, PictureViewModel>());

        public Lazy<List<PropertyFacilityViewModel>> PropertyFacilities =>
            LazyLoadExtension.LazyLoad(() => Entity?.PropertyFacilities.Map<PropertyFacility, PropertyFacilityViewModel>());

        public Lazy<List<PropertyFeatureViewModel>> PropertyFeatures =>
            LazyLoadExtension.LazyLoad(() => Entity?.PropertyFeatures.Map<PropertyFeature, PropertyFeatureViewModel>());
    }
}