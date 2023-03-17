using CQRS.Core.Commands;

namespace Post.Cmd.API.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public string Comment { get; set; }
        public string Username { get; set; }
    }
}