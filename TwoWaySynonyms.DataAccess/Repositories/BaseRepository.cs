using System;

namespace TwoWaySynonyms.DataAccess.Repositories
{
    public abstract class BaseRepository
    {
        protected T ExecuteDbOperation<T>(Func<T> databaseOperation)
        {
            try
            {
                return databaseOperation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }
    }
}
