﻿using System.Collections.Generic;
using SpyStore.Models.Entities;

namespace SpyStore.MVC.ViewModels
{
    public class CartViewModel
    {
        public Customer Customer { get; set; }
        public IList<CartRecordViewModel> CartRecords { get; set; }
    }
}
