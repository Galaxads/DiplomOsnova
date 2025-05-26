using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЗдоровьеВфокусе.Models;

namespace ЗдоровьеВфокусе
{
    class SavingDate
    {
        public static List<User> users = Helper.user015Context.Users.ToList();
        public static List<Achivka> achivkas = Helper.user015Context.Achivkas.OrderBy(x=>x.Id).ToList();
        public static List<Achivlist> achivlists = Helper.user015Context.Achivlists.OrderBy(x => x.Id).ToList();
        public static List<Bioinf> bioinfs = Helper.user015Context.Bioinfs.OrderBy(x => x.Id).ToList();
        public static List<Exercise> exercises = Helper.user015Context.Exercises.OrderBy(x => x.Id).ToList();
        public static List<Gender> genders = Helper.user015Context.Genders.OrderBy(x => x.Id).ToList();
        public static List<Listbioinf> listbioinfs = Helper.user015Context.Listbioinfs.OrderBy(x => x.Id).ToList();
        public static List<Listtrenirov> listtrenirovs = Helper.user015Context.Listtrenirovs.OrderBy(x => x.Id).ToList();
        public static List<Problem> problems = Helper.user015Context.Problems.OrderBy(x => x.Id).ToList();
        public static List<Problemslist> problemslists = Helper.user015Context.Problemslists.OrderBy(x => x.Id).ToList();
        public static List<Unicalplan> unicalplans = Helper.user015Context.Unicalplans.OrderBy(x => x.Id).ToList();
        public static List<Perosnalupr> perosnaluprs = Helper.user015Context.Perosnaluprs.OrderBy(x => x.Id).ToList();
        public static string Vseuprgruppa = "";
        public static string Slojnost = "none";
        public static int ipupr = -1;
        public static int day = -1;
        public static List<Exercise> exercisesunical = new List<Exercise>();


    }
}
