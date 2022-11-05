using BackEndProject.Models;
using BackEndProject.Services;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        public FooterViewComponent(LayoutService layoutService)
        {
            _layoutService = layoutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Dictionary<string, string> setting = await _layoutService.GetDatasFromSetting();
            IEnumerable<Category> categories = await _layoutService.GetDatasFromCategory();
            FooterVM model = new FooterVM
            {
                SettingDatas = setting,
                Categories = categories

            };

            return await Task.FromResult(View(model));
        }
    }
}
