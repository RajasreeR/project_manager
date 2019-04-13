using ProjectManagerApi.Entities.EntityModels;

namespace ProjectManagerApi.Models
{
    public class UserUpdateResponse
    {
        public UserModel User { get; set; }
        public Status Status { get; set; }
    }
}