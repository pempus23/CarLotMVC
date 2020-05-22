using System.Collections.Generic;

namespace AutoLotDAL.Repos
{
    public interface IRepo<T>
    {
        int Add(T entity);
        int AddRange(IList<T> entityes);
        int Save(T entity);
        int Delete(int id, byte[] timeStamp);
        int Delete(T entity);
        List<T> GetAll();
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);

    }
}
