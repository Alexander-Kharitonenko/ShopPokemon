using System;

namespace DTO
{
    public class UserDTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; }
        public uint NumberEmailSent { get; set; }
    }
}
