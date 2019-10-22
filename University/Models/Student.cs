using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace University.Models
{
	public class Student : Person
	{
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Enrollment Date")]
		public DateTime EnrollmentDate { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }

		private bool _val = true;
		[DefaultValue(true)]
		public bool Active
		{
			get
			{
				return _val;
			}
			set
			{
				_val = value;
			}
		}
	}
}