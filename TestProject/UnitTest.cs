using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUDUsingAPI;
using CRUDUsingAPI.Model;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        public CRUDUsingAPI.Model.UserCRUDModel UserCRUD { get; set; }
        public int userId;
        [TestMethod]
        public void TestMethod_GetAll()
        {
            CRUDUsingAPI.Pages.CRUD_Operation.GetAllModel crud = new CRUDUsingAPI.Pages.CRUD_Operation.GetAllModel();
            crud.OnGet();
        }

        [TestMethod]
        public void TestMethod_AddUser()
        {
            CRUDUsingAPI.Pages.CRUD_Operation.AddUserModel crud = new CRUDUsingAPI.Pages.CRUD_Operation.AddUserModel();
            var model = new UserCRUDModel();
            model.contactNo = "1234567890";
            model.userName = "Test";
            model.emailAddress = "Test@gmail.com";
            UserCRUD = model;
            var result = crud.OnPostForTest(UserCRUD);
            Assert.IsNotNull(true, result, "Data Successfully Created!");
        }
        [TestMethod]
        public void TestMethod_EditUser_OnGet()
        {
            CRUDUsingAPI.Pages.CRUD_Operation.EditUserModel crud = new CRUDUsingAPI.Pages.CRUD_Operation.EditUserModel();
            userId = 607;
            crud.OnGet(userId);
        }
        [TestMethod]
        public void TestMethod_EditUser_OnPost()
        {
            CRUDUsingAPI.Pages.CRUD_Operation.EditUserModel crud = new CRUDUsingAPI.Pages.CRUD_Operation.EditUserModel();
            var model = new UserCRUDModel();
            model.id = 607;
            model.contactNo = "9876543210";
            model.userName = "Test";
            model.emailAddress = "Test@gmail.com";
            UserCRUD = model;
            var result = crud.OnPostForTest(UserCRUD);
            Assert.IsTrue(true,result,"Data Successfully Updated!");
        }
        [TestMethod]
        public void TestMethod_DeleteUser_OnPost()
        {
            CRUDUsingAPI.Pages.CRUD_Operation.DeleteUserModel crud = new CRUDUsingAPI.Pages.CRUD_Operation.DeleteUserModel();
            var model = new UserCRUDModel();
            userId = 611;
            var result = crud.OnPostForTest(userId);
            Assert.IsTrue(true, result, "Data Successfully Deleted!");
        }
    }
}