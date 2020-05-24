using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Bloggs.Authorization.Roles;
using Bloggs.Categories.Dto;
using Bloggs.Domain.Entities;
using Bloggs.Roles;
using Bloggs.Roles.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bloggs.Categories
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category,long> _repository;

        public CategoryAppService(IRepository<Category,long> repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDto> CreateCategory(CreateCategoryDto input)
        {
            var category = ObjectMapper.Map<Category>(input);
            await _repository.InsertAsync(category);
           
            return ObjectMapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAll(CategoryDto input)
        {
            var categories = await _repository.GetAll().ToListAsync();

            var result= ObjectMapper.Map<List<CategoryDto>>(categories);

            return result;
        }
    }
}
