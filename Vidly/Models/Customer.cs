using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Please Enter Customer's Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Required(AllowEmptyStrings = false)]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        [Min18YearsIfAMember]
        [Display(Name = "Birth Of Date")]
        public DateTime? BirthDate { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }


        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}