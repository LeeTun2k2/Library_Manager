using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library_Manager.Repository.Models
{
    [Table("AuthenticationSystem")]
    public partial class AuthenticationSystem
    {
        [Column("Staff_id")]
        [StringLength(8)]
        public string StaffId { get; set; }
        [Key]
        [StringLength(15)]
        public string Username { get; set; }
        [Required]
        [Column("Pass_word")]
        [StringLength(20)]
        public string PassWord { get; set; }





        public static List<AuthenticationSystem> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.AuthenticationSystems.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.AuthenticationSystems.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.AuthenticationSystems.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            AuthenticationSystem db = context.AuthenticationSystems.Where(p => p.StaffId == id).FirstOrDefault();
            if (db != null)
            {
                //  context.Students.Attach(db);
                context.AuthenticationSystems.Remove(db);
                context.SaveChanges();
            }
            else
                System.Windows.MessageBox.Show("Không tồn tại ID");
        }

        public static AuthenticationSystem getAuthentication(string username)
        {
            MoDbContext context = new MoDbContext();
            return context.AuthenticationSystems.Where((p) => p.Username == username).FirstOrDefault();
        }

        public static List<AuthenticationSystem> Search(string username, string password)
        {
            MoDbContext db = new MoDbContext();
            return db.AuthenticationSystems.Where(
                p => p.Username.Trim() == username && p.PassWord.Trim() == password
                ).ToList();
        }
    }
}
