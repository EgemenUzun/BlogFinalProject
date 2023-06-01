using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetbyUserName(string username);
        User GetbyUserId(int? Id);
    }
}
