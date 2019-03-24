using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public DbSet<Customer> Customers { get; set; }
    }
}