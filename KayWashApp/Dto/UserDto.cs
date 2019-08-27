using KayWashApp.Common;

namespace KayWashApp.Dto
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public UserStatus Status { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public byte[] Profile_Pic { get; set; }

        public int Note { get; set; } //number of stars ( from 1 to 5)

        public UserDto()
        {
                
        }

    }
}
