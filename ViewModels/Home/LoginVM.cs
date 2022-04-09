using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.ViewModels.Home
{
    /// <summary>
    /// Class UserCreateVM.
    /// </summary>
    public class UserCreateVM
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        [DisplayName("Username: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [DisplayName("Password: ")]
        [Required(ErrorMessage = "*This field is Required!")]
        public string Password { get; set; }
    }
}
