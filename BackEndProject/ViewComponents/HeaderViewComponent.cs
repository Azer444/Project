using BackEndProject.Data;
using BackEndProject.Models;
using BackEndProject.Services;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;

        public HeaderViewComponent(LayoutService layout)
        {

            _layoutService = layout;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            Dictionary<string, string> settings = await _layoutService.GetDatasFromSetting();

            IEnumerable<Currency> currencies = await _layoutService.GetDatasFromCurrencies();

            IEnumerable<Language> languages = await _layoutService.GetDatasFromLanguage();

            HeaderVM model = new HeaderVM
            {
                Settings = settings,
                Currencies = currencies,
                Languages = languages
            };

            return await Task.FromResult(View(model));
        }
    }
}
