using CoursesManagementSystem.Areas.Admin.Models;
using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services;
using CoursesManagementSystem.Services.Interfaces;
using CoursesManagementSystem.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace CoursesManagementSystem.Controllers
{

    public class AccountController : Controller
    {
        private readonly MyUserManager _userManager;
        private readonly TraineeService traineeService = new TraineeService();
        private readonly TrainerService trainerService = new TrainerService();

        public AccountController()
        {
            _userManager = new MyUserManager();
        }
     
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Course");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }




        [HttpPost]
        public async Task<ActionResult> Login(string ReturnUrl, ViewModels.LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindUserAsync(model.EmailAddress, model.Password);
                    if (user != null)
                    {
                        // Avoid capturing the context
                        await Task.Run(() => _userManager.SignInAsync(user, HttpContext));

                        var role = _userManager.GetRoles(user.Id).FirstOrDefault();

                        // routing 
                        if (!string.IsNullOrEmpty(ReturnUrl))
                            return Redirect(ReturnUrl);

                        if (role == "Admin")
                            return RedirectToAction("Index", "Course", new { area = "Admin" });

                        else if (role == "Trainee")
                            return RedirectToAction("Index", "Course", new { area = "" });

                        else if (role == "Trainer")
                            return RedirectToAction("Index", "Course", new { area = "Instructor" });
                    }
                }
                model.Message = "Email-Address or password is incorrect";
                return View(model);
            }
            catch
            {
                // Log the exception or handle it appropriately
                ModelState.AddModelError("", "An error occurred during login.");
                return View(model);
            }
        }



        public ActionResult Logout()
        {

            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignOut("ApplicationCookie");
            Session.Abandon();
            return RedirectToAction("Login", "Account", new { area = "" });

        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Course");
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyIdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };


                IdentityResult creationState = await _userManager.CreateUserAsync(user, model.Password);

                if (creationState.Succeeded)
                {
                    await _userManager.AddUserToRole(user.Id, model.AccountType);

                    if (model.AccountType == "Trainee")
                    {
                        var trainee = new Trainee { AddedDate = DateTime.Now, Email = model.Email, Name = model.Name };
                        user.Trainee = trainee;
                        // Save the user to update the Trainee property
                        await _userManager.UpdateUserAsync(user);
                        return RedirectToAction("Index", "Course", new { area = "" });
                    }
                    else if (model.AccountType == "Trainer")
                    {
                        var trainer = new Trainer { AddedDate = DateTime.Now, Name = model.Name, Email = model.Email };
                        user.Trainer = trainer;
                        await _userManager.UpdateUserAsync(user);

                        return RedirectToAction("Index", "Course", new { area = "Instructor" });
                    }

                }
                else
                {
                    foreach (var error in creationState.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            return View(model);
        }


        


        public ActionResult Settings()
        {
            var traineeIdClaim = GetClaimValue("TraineeId");
            var trainerIdClaim = GetClaimValue("TrainerId");
            var model = new UpdateAccountViewModel();

            if (traineeIdClaim != null)
            {
                var trainee = traineeService.GetTraineeById(int.Parse(traineeIdClaim.Value));
                model.Id = trainee.Id;
                model.Name = trainee.Name;
                model.IdentityUpdate = new IdentityUpdateViewModel()
                {
                    Email = trainee.Email,
                    ChangePassword = new ChangePasswordViewModel()
                };
            }
            
            else if (trainerIdClaim != null)
            {
                var trainer = trainerService.GetTrainerById(int.Parse(trainerIdClaim.Value));

                model.Id = trainer.Id;
                model.Name = trainer.Name;
                model.Description = trainer.Description;
                model.SocialLinks = trainer.SocialLinks;

                model.IdentityUpdate = new IdentityUpdateViewModel()
                {
                    Email = trainer.Email,
                    ChangePassword = new ChangePasswordViewModel()
                };
            }

            return View(model);
        }

        private Claim GetClaimValue(string claimType)
        {
            return ClaimsPrincipal.Current
                .Identities
                .First()
                .Claims
                .FirstOrDefault(c => c.Type.Equals(claimType, StringComparison.OrdinalIgnoreCase));
        }


        [HttpPost]
        public async Task<ActionResult> UpdateAccount(UpdateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.Identity.GetUserId();
                    var user = await _userManager.FindUserAsyncById(userId);

                    // Check if the user is a trainee
                    var isTrainee = User.IsInRole("Trainee");

                    // Check if the user is a trainer
                    var isTrainer = User.IsInRole("Trainer");

                    if (isTrainee)
                    {
                        // Handle trainee-specific updates
                        var currTrainee = traineeService.GetTraineeById(model.Id);

                        if (model.IdentityUpdate.Email != currTrainee.Email)
                        {
                            user.Email = model.IdentityUpdate.Email;
                            user.UserName = model.IdentityUpdate.Email;

                            await _userManager.UpdateUserAsync(user);
                        }

                        if (!string.IsNullOrEmpty(model.IdentityUpdate.ChangePassword.NewPassword))
                        {
                            var changePasswordResult = await _userManager.ChangePasswordAsync(
                                userId,
                                model.IdentityUpdate.ChangePassword.CurrentPassword,
                                model.IdentityUpdate.ChangePassword.NewPassword
                            );

                            if (!changePasswordResult.Succeeded)
                            {
                                ModelState.AddModelError(string.Empty, "Password change failed. Please check your current password and try again.");
                                return View("Settings", model);
                            }

                            return RedirectToAction("Logout");
                        }

                        currTrainee.Name = model.Name;
                        currTrainee.Email = model.IdentityUpdate.Email;
                        traineeService.Update(model.Id, currTrainee);
                    }
                    else if (isTrainer)
                    {
                        // Handle trainer-specific updates
                        var currTrainer = trainerService.GetTrainerById(model.Id);

                        // Update common fields
                        user.Email = model.IdentityUpdate.Email;
                        user.UserName = model.IdentityUpdate.Email;

                        await _userManager.UpdateUserAsync(user);

                        // Update trainer-specific fields
                        currTrainer.Name = model.Name;
                        currTrainer.Description = model.Description;
                        currTrainer.Expertise = model.Expertise;
                        currTrainer.SocialLinks = model.SocialLinks;
                        trainerService.Update(model.Id, currTrainer);
                    }
                    else
                    {
                        // Handle other roles if necessary
                    }

                    // Redirect to the appropriate profile or settings page
                    return RedirectToAction("Settings");
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately, log them, or display an error message
                    ModelState.AddModelError(string.Empty, "An error occurred while updating settings.");
                }
            }

            return View("Settings", model);
        }



    }
}