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
    public class TrainerService : ITrainerService
    {
        public static MyAppContext context = new MyAppContext();
        public bool Add(Trainer trainer)
        {
            if (IsEmailExisted(trainer.Email))
                return false;

            context.Trainers.Add(trainer);
            context.SaveChanges();
            return true;
        }

        public void Delete(int Id)
        {
            context.Trainers.Remove(GetTrainerById(Id));
            context.SaveChanges();
        }

        public Trainer GetTrainerById(int id)
        {
            return context.Trainers.Find(id);
        }

        public bool IsEmailExisted(string email)
        {
            return context.Trainers.Any(x => x.Email == email) ||
            context.Trainees.Any(x => x.Email == email) ||
            context.Admins.Any(x => x.Email == email);

        }

        public IEnumerable<Trainer> ReadAll()
        {
            return context.Trainers;
        }

        public bool Update(int id ,Trainer modifiedtrainer)
        {
            var oldTrainer = GetTrainerById(id);
            if (oldTrainer == null) return false;

                oldTrainer.Name = modifiedtrainer.Name;
            if (oldTrainer.Email != modifiedtrainer.Email)
            {
                if (IsEmailExisted(modifiedtrainer.Email))
                    throw new Exception("This Email Already Exists");
                oldTrainer.Email = modifiedtrainer.Email;
            }

                oldTrainer.Website = modifiedtrainer.Website;
                oldTrainer.Description = modifiedtrainer.Description;
            context.SaveChanges();

            return true;
        }

     
    }
}