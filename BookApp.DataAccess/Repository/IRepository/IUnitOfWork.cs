using BookUserWeb.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BBookWeb.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category{ get; }
        void Save();

    }
}
