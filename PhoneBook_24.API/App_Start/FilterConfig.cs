﻿using System.Web;
using System.Web.Mvc;

namespace PhoneBook_24.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
