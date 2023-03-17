using CQRS.Core.Commands;

namespace Post.Cmd.API.Commands
{
    public class DeletePostCommand : BaseCommand
    {
        public string Username { get; set; }
    }
}