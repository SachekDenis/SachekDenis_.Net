﻿using System.Reflection;
using AutoMapper;
using ComputerStore.BusinessLogicLayer.MapperProfile;
using ComputerStore.DataAccessLayer.Context;
using ComputerStore.DataAccessLayer.Models.Identity;
using ComputerStore.DataAccessLayer.Repo;
using ComputerStore.WebUI.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerStore.WebUI.AppConfiguration
{
    public static class DependencyInjectionConfigurator
    {
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration config)
        {
            var businessAssembly = Assembly.Load("ComputerStore.BusinessLogicLayer");

            services.AddDbContext<StoreContext>(options => options.UseSqlServer(config.GetConnectionString("StoreConnection")))
                    .Scan(scan => scan.FromAssemblies(businessAssembly)
                                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Manager")))
                                      .AsSelf()
                                      .WithScopedLifetime())
                    .Scan(scan => scan.FromAssemblies(businessAssembly)
                                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Validator")))
                                      .AsImplementedInterfaces()
                                      .WithTransientLifetime())
                    .AddAutoMapper(typeof(StoreProfile), typeof(ViewModelsProfile))
                    .AddScoped(typeof(IRepository<>), typeof(StoreRepository<>));

            services.AddIdentity<IdentityBuyer, IdentityRole>(options => { options.Password.RequireNonAlphanumeric = false; })
                    .AddEntityFrameworkStores<StoreContext>();
        }
    }
}