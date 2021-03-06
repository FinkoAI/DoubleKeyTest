﻿using System;
using System.Windows;
using System.Windows.Controls;
using TestApplication.UI.Model;

namespace TestApplication.UI.Content.TemplateSelectors
{
    public class SearchTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Подставляет шаблон поиска в зависимости от выбранного enum
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template;

            var filterType = item is FirstTabFilterTypes ? (FirstTabFilterTypes) item : FirstTabFilterTypes.FilterById;

            var element = container as FrameworkElement;

            switch (filterType)
            {
                case FirstTabFilterTypes.FilterById:
                    template = element.FindResource("SearchByIdTemplate") as DataTemplate;
                    break;
                case FirstTabFilterTypes.FilterByName:
                    template = element.FindResource("SearchByNameTemplate") as DataTemplate;
                    break;
                case FirstTabFilterTypes.FilterByBoth:
                    template = element.FindResource("SearchByBothTemplate") as DataTemplate;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return template;
        }
    }
}
