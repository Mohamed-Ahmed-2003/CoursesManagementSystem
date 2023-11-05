using CoursesManagementSystem.Data;
using CoursesManagementSystem.Models;
using CoursesManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesManagementSystem.Services
{
    public class TraineeService : ITraineeService
    {
        public static MyAppContext context = new MyAppContext();
        public bool Add(Trainee trainee)
        {
            if (IsEmailExisted(trainee.Email))
                return false;

            context.Trainees.Add(trainee);
            context.SaveChanges();
            return true;
        }

        public void Delete(int Id)
        {
            context.Trainees.Remove(GetTraineeById(Id));
            context.SaveChanges();
        }

        public Trainee GetTraineeById(int id)
        {
            return context.Trainees.Find(id);
        } 
        

        public bool IsEmailExisted(string email)
        {
            return context.Trainers.Any(x => x.Email == email) ||
            context.Trainees.Any(x => x.Email == email) ||
            context.Admins.Any(x => x.Email == email);

        }

        public IEnumerable<Trainee> ReadAll()
        {
            return context.Trainees;
        }

        public bool Update(int id ,Trainee modifiedtrainee)
        {
            var oldTrainee = GetTraineeById(id);
            if (oldTrainee == null) return false;

                oldTrainee.Name = modifiedtrainee.Name;
            if (oldTrainee.Email != modifiedtrainee.Email)
            {
                if (IsEmailExisted(modifiedtrainee.Email))
                    throw new Exception("This Email Already Exists");
                oldTrainee.Email = modifiedtrainee.Email;
            }

            context.SaveChanges();

            return true;
        }

     
    }
}