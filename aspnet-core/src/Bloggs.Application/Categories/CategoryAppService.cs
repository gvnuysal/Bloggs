using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using Bloggs.Authorization.Roles;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;
using Bloggs.Roles;
using Bloggs.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bloggs.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, long, PagedCategoryResultRequestDto, CategoryDto, CategoryDto, CategoryDto>
    {
        public CategoryAppService(IRepository<Category,long> repository):base(repository)
        {

        }
        public override async Task<CategoryDto> CreateAsync(CategoryDto input)
        {
           return await base.CreateAsync(input);
        }

    }
}
