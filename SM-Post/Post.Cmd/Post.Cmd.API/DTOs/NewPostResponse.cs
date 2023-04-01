using Post.Common.DTOs;

namespace Post.Cmd.API.DTOs
{
    public class NewPostResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}