using System.Collections.Generic;

namespace StudentResponses
{
    public class BrokerResponse<T>
    {
        public T Body { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
