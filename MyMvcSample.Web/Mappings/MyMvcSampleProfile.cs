﻿using AutoMapper;
using MyMvcSample.Common.Mappings;
using MyMvcSample.Domain.Entities;
using MyMvcSample.ViewModels;
using MyMvcSample.ViewModels.Orders;
using MyMvcSample.ViewModels.Products;

namespace MyMvcSample.Mappings
{
    public class MyMvcSampleProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(model => model.NumOfOrderLineItems, conf => conf.MapFrom(o => o.OrderItems.Count));
            CreateMap<Order, OrderEditModel>();
            CreateMap<Order, OrderCreateModel>();

            CreateMap<OrderEditModel, Order>()
                .ForMember(o => o.CreatedBy, config => config.Ignore())
                .ForMember(o => o.CreatedOn, config => config.Ignore())
                .ForMember(o => o.UpdatedBy, config => config.Ignore())
                .ForMember(o => o.UpdatedOn, config => config.Ignore());

            CreateMap<int, OrderStatus>().ConvertUsing<IdToEntityTypeConverter<OrderStatus>>();
            CreateMap<OrderStatus, int>().ConvertUsing<EntityToIdTypeConverter<OrderStatus>>();
            CreateMap<OrderCreateModel, Order>();

            CreateMap<ProductCreateModel, Product>();
            CreateMap<Product, ProductCreateModel>();

            CreateMap<ProductEditModel, Product>();
            CreateMap<Product, ProductEditModel>();
        }
    }
}