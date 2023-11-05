using CoursesManagementSystem.Models;
using CoursesManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Data
{
    public class MyUserManager
    {
        private readonly UserManager<MyIdentityUser> _userManager;

        public MyUserManager()
        {
            var userStore = new UserStore<MyIdentityUser>(new MyAppContext());
            _userManager = new UserManager<MyIdentityUser>(userStore);
        }

        public async Task<MyIdentityUser> FindUserAsync(string email, string password)
        {
            return await _userManager.FindAsync(email, password);
        }

        public async Task<IdentityResult> CreateUserAsync(MyIdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public IEnumerable<string> GetRoles(string userId)
        {
            return _userManager.GetRoles(userId);
        }

        public async Task SignInAsync(MyIdentityUser user, HttpContextBase httpContext)
        {
            var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            // Add TrainerId or TraineeId claim based on the user's role
            var role = _userManager.GetRoles(user.Id).FirstOrDefault();
            if (role == "Trainer")
            {
                identity.AddClaim(new Claim("TrainerId", user.TrainerID.ToString()));
            }
            else if (role == "Trainee")
            {
                identity.AddClaim(new Claim("TraineeId", user.TraineeID.ToString()));
            }

            var authManager = httpContext.GetOwinContext().Authentication;
            authManager.SignIn(identity);
        }

        public async Task AddUserToRole(string userId, string role)
        {
            await _userManager.AddToRoleAsync(userId, role);
        }

        public async Task UpdateUserAsync(MyIdentityUser user)
        {
            await _userManager.UpdateAsync(user);
        }
        public async Task UpdateEmail(MyIdentityUser user)
        {
            await _userManager.UpdateAsync(user);
        }
        public async Task<MyIdentityUser> FindUserAsyncById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
        public async Task<IdentityResult> ChangePasswordAsync (string userID ,string currPassword ,string newPassword)
        {
            return await _userManager.ChangePasswordAsync(userID, currPassword, newPassword);
        }
        public void RegisterInBackground(RegisterViewModel model,string desc = null , string exp = null)
        {
            if (model == null) return;

            var user = new MyIdentityUser()
            {
                Email = model.Email,
                UserName = model.Email
            };

            IdentityResult creationState = _userManager.Create(user, model.Password);

            if (creationState.Succeeded)
            {
                _userManager.AddToRole(user.Id, model.AccountType);

                if (model.AccountType == "Trainee")  // Use lowercase "trainer" here
                {
                    var trainee = new Trainee { AddedDate = DateTime.Now, Email = model.Email, Name = model.Name };
                    user.Trainee = trainee;
                }
                else if (model.AccountType == "Trainer")  // Use lowercase "trainer" here
                {
                    var trainer = new Trainer { AddedDate = DateTime.Now, Name = model.Name, Email = model.Email ,Description = desc , Expertise = exp };
                    user.Trainer = trainer;
                }

                _userManager.Update(user);  // You might need to implement this method
            }
        }

    }

}