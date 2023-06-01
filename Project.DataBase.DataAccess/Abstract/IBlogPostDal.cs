using Project.Core.DataAccess;
using Project.DataBase.Entities.ComplexTypes;
using Project.DataBase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataBase.DataAccess.Abstract
{
    public interface IBlogPostDal : IEntityRepository<BlogPost>
    {
        public BlogAuthorJoin GetJoin(int? authorId,int postId);
    }
}
