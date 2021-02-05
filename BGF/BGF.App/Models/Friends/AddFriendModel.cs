using System.ComponentModel.DataAnnotations;

namespace BGF.App.Models.Friends
{
    public class AddFriendModel
    {
        [Display(Name = "Id")]
        public string FriendId { get; set; }
    }
}
