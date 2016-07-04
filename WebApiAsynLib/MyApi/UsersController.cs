using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using WebAsyncApiTest.MyApi;

namespace WebApiAsynLib.MyApi
{
    [RoutePrefix("api/v1/MySweetApi")]
    public class UsersController : ApiController
    {
        [Route("Users")]
        public async Task<IList<User>> GetUsersAsync()
        {
            var accept = "application/json";
            var uri = "http://jsonplaceholder.typicode.com/users";
            var req = (HttpWebRequest)WebRequest.Create(uri);
            req.Accept = accept;
            var content = new MemoryStream();
            List<User> users;
            using (WebResponse response = await req.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {

                    // Read the bytes in responseStream and copy them to content.
                    await responseStream.CopyToAsync(content);
                    string result = Encoding.UTF8.GetString(content.ToArray());
                    users = JsonConvert.DeserializeObject<List<User>>(result);
                }
            }
            return users;
        }
    }
}
