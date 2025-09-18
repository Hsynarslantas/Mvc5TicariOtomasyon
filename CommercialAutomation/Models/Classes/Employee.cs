using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Employee
    {
        [Key] 
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string EmployeeImageUrl { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public virtual Department Department { get; set; }
        public string EmployeeSkills { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}