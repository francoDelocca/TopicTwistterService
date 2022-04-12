using System;

namespace TopicTwisterService.shared.Application
{
    [Serializable]
    public class Response
    {
        public int success { get; set; }
        public string message { get; set; }
        public string data { get; set; }

        public Response()
        {
            this.success = 0;
        }
    }
}
