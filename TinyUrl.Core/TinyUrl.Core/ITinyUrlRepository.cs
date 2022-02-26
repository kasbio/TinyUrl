using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Core
{
    public interface ITinyUrlRepository<T> where T: TinyUrlBase
    {
        Task<RepositoryResult<T>> SaveAsync(string originalUrl ,string url);

    }


    public class RepositoryResult<T> where T : TinyUrlBase
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }


        public static RepositoryResult<T> Success(T data)
        {
            return new RepositoryResult<T>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static RepositoryResult<T> Fail(string message )
        {
            return new RepositoryResult<T>
            {
                IsSuccess = false,Message = message
            };
        }
    }
}
