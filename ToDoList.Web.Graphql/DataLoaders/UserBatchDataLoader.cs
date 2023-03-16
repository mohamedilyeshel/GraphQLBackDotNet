using ToDoList.DataAccess.Repositories;
using ToDoList.Entities.Models;

namespace ToDoList.Web.Graphql.DataLoaders
{
    public class UserBatchDataLoader : BatchDataLoader<int, User>
    {
        public readonly UserRepository _userRepository;

        public UserBatchDataLoader(UserRepository userRepository, IBatchScheduler batchScheduler, DataLoaderOptions options) : base(batchScheduler, options)
        {
            _userRepository = userRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, User>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersByIds(keys);
            return users.ToDictionary(u => u.Id);
        }
    }
}
