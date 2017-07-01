using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMvaWebApp.Services
{
    public interface IRequestId
    {
        string Id { get; }
    }

    public interface IRequestIdFactory
    {
        string MakeRequestId();
    }


    public class RequestId : IRequestId
    {
        private readonly string _reqeustId;

        public RequestId(IRequestIdFactory requestIdFactory)
        {
            _reqeustId = requestIdFactory.MakeRequestId();
        }

        public string Id => _reqeustId;
    }

    public class RequestIdFactory : IRequestIdFactory
    {
        private int _reqeustId;

        public string MakeRequestId()
        {
            return Interlocked.Increment(ref _reqeustId).ToString();
        }
    }
}
