using Accounts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Accounts.Views.Helper
{
    public class AccountDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GroupCell { get; set; }
        public DataTemplate StanderdCell { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return string.IsNullOrEmpty(((Account)item).GroupName) ? StanderdCell : GroupCell;
        }
    }
}
