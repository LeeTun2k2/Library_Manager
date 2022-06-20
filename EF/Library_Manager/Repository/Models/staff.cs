using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Library_Manager.Repository.Models
{
    [Table("Staff")]
    public partial class staff
    {
        [Key]
        [Column("Staff_id")]
        [StringLength(8)]
        public string StaffId { get; set; }
        [Required]
        [Column("Staff_name")]
        [StringLength(60)]
        public string StaffName { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(5)]
        public string Sex { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("Phone_no")]
        [StringLength(11)]
        public string PhoneNo { get; set; }
        [StringLength(60)]
        public string Addr { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required]
        [StringLength(12)]
        public string Salary { get; set; }


        public static List<staff> GetAll()
        {
            MoDbContext db = new MoDbContext();
            return db.staff.ToList();
        }

        public void Add()
        {
            MoDbContext context = new MoDbContext();
            context.staff.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            MoDbContext context = new MoDbContext();
            context.staff.Update(this);
            context.SaveChanges();
        }

        public static void Delete(string id)
        {
            MoDbContext context = new MoDbContext();
            staff db = context.staff.Where(p => p.StaffId == id).FirstOrDefault();
            if (db != null)
            {
                //  context.Students.Attach(db);
                context.staff.Remove(db);
                context.SaveChanges();
            }
            else
                MessageBox.Show("Không tồn tại ID");
        }

        public static List<staff> Search(
            string Staff_id,
            string Staff_name,
            string Birthday,
            string Sex,
            string Email,
            string Phone_no,
            string Addr,
            string StartDate,
            string Salary
            )
        {
            MoDbContext db = new MoDbContext();
            return db.staff.Where(
                p =>
                (Staff_id != "") ? (p.StaffId.Trim() == Staff_id) : (true) &&
                (Staff_name != "") ? (p.StaffName.Trim() == Staff_name) : (true) &&
                (Birthday != "") ? (p.Birthday.ToShortDateString() == DateTime.Parse(Birthday).ToShortDateString()) : (true) &&
                (Sex != "") ? (p.Sex.Trim() == Sex) : (true) &&
                (Email != "") ? (p.Email.Trim() == Email) : (true) &&
                (Phone_no != "") ? (p.PhoneNo.ToString().Trim() == Phone_no) : (true) &&
                (Addr != "") ? (p.Addr.ToString().Trim() == Addr) : (true) &&
                (StartDate != "") ? (p.StartDate.ToShortDateString() == DateTime.Parse(StartDate).ToShortDateString()) : (true) &&
                (Salary != "") ? (p.Salary.Trim() == Salary) : (true) 
                ).ToList();
        }
    }
}
