using Localization.Resources;
using System.ComponentModel.DataAnnotations;

namespace Localization.Models
{
    public class User
    {
 
        [Display(ResourceType =typeof(DataAnnotationsResource),Name ="ff")]

        public string?  FullName { get; set; }
    }
}
