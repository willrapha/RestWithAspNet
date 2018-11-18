using System.Collections.Generic;
using System.Linq;
using RestWithAspNetFiles.Data.Converter;
using RestWithAspNetFiles.Data.VO;
using RestWithAspNetFiles.Model;

namespace RestWithAspNetFiles.Data.Converters
{
    public class UserConverter : IParser<User,UserVO>, IParser<UserVO,User>
    {
        public UserVO Parse(User origin)
        {
            if(origin == null) return new UserVO();

            return new UserVO
            {
                Id = origin.Id,
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<UserVO> ParseList(List<User> origin)
        {
            if (origin == null) return new List<UserVO>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public User Parse(UserVO origin)
        {
            if(origin == null) return new User();

            return new User
            {
                Id = origin.Id,
                Login = origin.Login,
                AccessKey = origin.AccessKey
            };
        }

        public List<User> ParseList(List<UserVO> origin)
        {
            if(origin == null) return new List<User>();

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}