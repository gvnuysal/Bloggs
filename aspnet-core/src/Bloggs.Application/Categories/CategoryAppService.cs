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

        public async Task<ListResultDto<CategoryDto>> GetAll(CategoryDto input)
        {
            var categories = await _repository.GetAll().ToListAsync();

            return new ListResultDto<CategoryDto>(ObjectMapper.Map<List<CategoryDto>>(categories));
        }
    }
}
