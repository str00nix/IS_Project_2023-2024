using MusicStoreApplication.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<MusicApplicationUser> GetAll();
        MusicApplicationUser Get(string id);
        void Insert(MusicApplicationUser entity);
        void Update(MusicApplicationUser entity);
        void Delete(MusicApplicationUser entity);
    }
}
