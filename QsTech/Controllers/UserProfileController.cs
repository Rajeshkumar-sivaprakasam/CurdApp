using QsTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QsTech.Controllers
{
    public class UserProfileController : Controller
    {
        private Models.AppContext _context;
        public UserProfileController()
        {
            _context = new Models.AppContext();
        }
        // GET: UserProfile
        //https://localhost:44386/userprofile/userprofileview
        public ActionResult UserProfileView()
        {
            var users = _context.UserProfiles.ToList();
            return View(users);
        }
        public  ActionResult UserInfo()
        {
            return View(new UserProfile { Id = 0 } );
        }

        public ActionResult SaveUser(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
                return View("UserInfo", userProfile);
            if (userProfile.Id == 0)
                _context.UserProfiles.Add(userProfile);
            else
            {
                var userFromDb = _context.UserProfiles.FirstOrDefault(u => u.Id == userProfile.Id);

                if (userFromDb == null)
                    return HttpNotFound();
                userFromDb.Name = userProfile.Name;
                userFromDb.Address = userProfile.Address;
                userFromDb.Age = userProfile.Age;
            }
            _context.SaveChanges();
            return RedirectToAction("UserProfileView");
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}