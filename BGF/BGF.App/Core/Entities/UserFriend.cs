namespace BGF.App.Core.Entities
{
    public class UserFriend
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string FriendId { get; set; }
        public virtual User Friend { get; set; }
    }
}
