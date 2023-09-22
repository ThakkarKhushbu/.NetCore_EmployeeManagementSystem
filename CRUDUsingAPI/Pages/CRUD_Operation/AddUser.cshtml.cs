using CRUDUsingAPI.Data;
using CRUDUsingAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CRUDUsingAPI.Pages.CRUD_Operation
{
    public class AddUserModel : PageModel
    {
        public UserCRUDModel UserCRUD { get; set; }
        
        public string OnPostForTest(UserCRUDModel UserCRUD)
        {
            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            //Converting data to JSON from
            string json = JsonConvert.SerializeObject(UserCRUD);

            //Sending the data
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string result = client.UploadString(StaticData.API_URL + "AddUserInfo", json);
            return result;
           
        }
        public void OnPost(UserCRUDModel UserCRUD)
        {
            string result = OnPostForTest(UserCRUD);

            //Redirecting to List Page
            Response.Redirect("/CRUD_Operation/GetAll");
        }
    }
}
