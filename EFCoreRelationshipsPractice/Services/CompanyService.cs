﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Model;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            // get company from db
            var companies = this.companyDbContext
                .Companies.Include(company => company.Profile).ToList();

            // convert entity to dto(select类似于map)
            return companies.Select(companyEntity => new CompanyDto(companyEntity)).ToList();

            //throw new NotImplementedException();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            CompanyEntity companyEntity = companyDto.ToEntity();

            await this.companyDbContext.Companies.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();

            return companyEntity.Id;
            //throw new NotImplementedException();
        }

        public async Task DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}