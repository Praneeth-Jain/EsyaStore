using EsyaStore.Data.Context;
using EsyaStore.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EsyaStore.Pages.EcomUI
{
    public class HomepageModel : PageModel
    {
        public readonly ApplicationDbContext _context;

        public List<Products> listOfProducts { get; set; }
        public List<Products> listOf3 { get; set; }

        public HomepageModel(ApplicationDbContext context)
        {
            _context = context;
            // Initialize listOf3 as an empty list
            listOf3 = new List<Products>();
        }

        public void OnGet()
        {
            // Get all products from the database
            listOfProducts = _context.products.ToList();

            // Initialize random number generator
            Random rnd = new Random();

            // Add three random products to listOf3
            listOf3.Add(listOfProducts[rnd.Next(0, listOfProducts.Count)]);
            listOf3.Add(listOfProducts[rnd.Next(0, listOfProducts.Count)]);
            listOf3.Add(listOfProducts[rnd.Next(0, listOfProducts.Count)]);
        }
    }
}
