﻿using Newtonsoft.Json;
using RealEstate.Services.BaseLog;
using RealEstate.Services.Database.Tables;
using RealEstate.Services.Extensions;
using System;

namespace RealEstate.Services.ViewModels.ModelBind
{
    public class UserPropertyCategoryViewModel : BaseLogViewModel
    {
        [JsonIgnore]
        public UserPropertyCategory Entity { get; }

        public UserPropertyCategoryViewModel(UserPropertyCategory entity)
        {
            if (entity == null)
                return;

            Entity = entity;
        }

        public Lazy<UserViewModel> User =>
            LazyLoadExtension.LazyLoad(() => Entity?.User.Into<User, UserViewModel>());

        public Lazy<CategoryViewModel> Category =>
            LazyLoadExtension.LazyLoad(() => Entity?.Category.Into<Category, CategoryViewModel>());
    }
}