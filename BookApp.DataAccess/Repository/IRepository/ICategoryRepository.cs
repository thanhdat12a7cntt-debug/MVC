using BBookWeb.DataAcess;
using BookUserWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookUserWeb.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category> 
    {
        void Update(Category obj);
        
    }
}
