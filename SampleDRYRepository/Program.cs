using SampleDRYRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickRepository.Cache.Variable;

namespace SampleDRYRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get
            var variableUserCache = new VariableCacheRepository<User>(u => u.Id, x => x.Max(u => u.Id) + 1, GetUsers);
            var users = variableUserCache.Get();

            //Add
            variableUserCache.Add(new User()
            {
                Name = "NewUser"
            });
            users = variableUserCache.Get();

            //Update
            var userToUpdate = variableUserCache.Get().Last();
            userToUpdate.Name = "UpdatedUser";
            variableUserCache.Update(userToUpdate);
            users = variableUserCache.Get();

            //Delete
            var userToDelete = variableUserCache.Get().Last();
            variableUserCache.Delete(userToDelete);
            users = variableUserCache.Get();
        }

        public static IEnumerable<User> GetUsers()
        {
            yield return new User()
            {
                Id = 0,
                Name = "FirstUser"
            };
        }
    }
}
