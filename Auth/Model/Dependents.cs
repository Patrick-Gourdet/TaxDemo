namespace Auth.Model
{
    public class Dependents
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string UserNameFriendsList { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public string Gender { get; set; }
        public int DependentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}