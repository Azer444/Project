﻿using BackEndProject.Data;
using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.ViewComponents;

namespace BackEndProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetDatasFromSetting()
        {
            return await _context.Settings.ToDictionaryAsync(m => m.Key, m => m.Value);
        }

        public async Task<IEnumerable<Currency>> GetDatasFromCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<IEnumerable<Language>> GetDatasFromLanguage()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<IEnumerable<Social>> GetDatasFromSocial()
        {
            return await _context.Socials.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetDatasFromCategory()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
