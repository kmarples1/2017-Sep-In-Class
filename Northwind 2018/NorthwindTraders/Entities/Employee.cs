﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTraders.Entities
{
    [Table("Employees")]
    public class Employee
    {
        #region Column Mappings
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        //public string PhotoMimeType { get; set; } // Other version of database....
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        //public DateTime LastModified { get; set; } // Other version of database....
        #endregion

        #region Navigation Properties
        // DEMO: Foreign Key for Self-Referencing Relationships
        [ForeignKey("ReportsTo")]
        public virtual Employee Manager { get; set; }
        public ICollection<Employee> Subbordinates { get; set; }
            = new HashSet<Employee>();

        // DEMO: Many-to-Many Relationships
        public virtual ICollection<Territory> Territories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
            = new HashSet<Order>(); // This could have been set up in the constructor
        #endregion

        #region Constructors
        public Employee()
        {
            // DEMO: Good practice for Entity Constructors
            // For each navigational property that is a collection,
            // initialize it to an empty hash-set.
            Territories = new HashSet<Territory>();
        }
        #endregion

        // TODO: Non-mapped properties
        // FullName -> First Last
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        // FormalName -> Last, First
        public string FormalName { get { return $"{LastName}, {FirstName}"; } }
    }
}
