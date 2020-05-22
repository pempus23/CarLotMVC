using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using static System.Console;

namespace AutoLotDAL.Interception
{
    public class ConsoleWriterInterceptor : IDbCommandInterceptor
    {
        private void WriteInfo(bool IsAsync, string commandText)
        {
            WriteLine($"IsAsync: {IsAsync}, Command Text: {commandText}");
        }
        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync,command.CommandText);
        }
        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);

        }
        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);

        }
        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);

        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);

        }
        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);

        }
    }
}