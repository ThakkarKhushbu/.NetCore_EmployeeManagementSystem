using CRUDUsingAPI.Data;
using CRUDUsingAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace CRUDUsingAPI.Pages.CRUD_Operation
{
    public class EditUserModel : PageModel
    {
        //User information model to get the data
        public List<UserInfoModel> UserInfo { get; set; }
        public UserCRUDModel UserCRUD { get; set; }
        //public UserCRUDModel UserCRUDTemp { get; set; }
        public void OnGet(int userId)
        {
            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            string json = (new WebClient()).DownloadString(StaticData.API_URL + "GetTeamMembers");

            //binding the data with model
            UserInfo = JsonConvert.DeserializeObject<List<UserInfoModel>>(json);
            var temp = UserInfo.Find(u => u.id == userId);

            //assigning to another model
            var model = new UserCRUDModel();
            model.id = temp.id;
            model.contactNo = temp.contactNo;
            model.userName = temp.userName;
            model.emailAddress = temp.emailAddress;
            UserCRUD = model;


        }
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
            string result = client.UploadString(StaticData.API_URL + "UpdateUserInfo", json);
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
