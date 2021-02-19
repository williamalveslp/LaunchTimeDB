using LaunchTimeDB.Domain.Entities;
using LaunchTimeDB.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LaunchTimeDB.DataStore.FakeData
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _usersDataList = new List<User>()
        {
            new User(1, "joaopedro","j!ao", "João Pedro"),
            new User(2, "carlosantonio", "$cHa579A#", "Carlos Antônio"),
            new User(3, "patriciaalmeida", "y&pac#al", "Patrícia Almeida"),
            new User(4, "lucasalves", "pg$csSf4", "Lucas Alves"),
            new User(5, "marciaabgail", "pg$csSf4", "Marcia Abgail"),
            new User(6, "marcelodasilva", "t%Ma%$silva", "Marcelo da Silva"),
            new User(7, "julianaalburquerque", "ju2019$a|7)", "Juliana Alburquerque")
        };

        public User Insert(User entity)
        {
            _usersDataList.Add(entity);
            return entity;
        }

        public User Update(User entity)
        {
            User user = null;
            foreach (var item in _usersDataList)
            {
                if (item.Id == entity.Id)
                {
                    item.Update(entity.UserName, entity.Password, entity.Name);
                    user = item;
                    break;
                }
            }
            return user;
        }

        public IList<User> GetAll()
        {
            return _usersDataList.OrderBy(f=> f.Name).ToList();
        }

        public User GetById(long entityId)
        {
            return _usersDataList.Where(f => f.Id == entityId).FirstOrDefault();
        }

        public void DeleteById(long entityId)
        {
            var user = GetById(entityId);
            if (user == null) return;
            _usersDataList.Remove(user);
        }

        public User GetLogin(string userName, string password)
        {
            var user = _usersDataList.Where(f => f.UserName == userName && f.Password == password).FirstOrDefault();
            return user;
        }
    }
}
