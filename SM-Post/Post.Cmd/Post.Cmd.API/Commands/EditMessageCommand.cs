using CQRS.Core.Commands;

namespace Post.Cmd.API.Commands
{
    public class EditMessageCommand : BaseCommand
    {
        public string Message { get; set; }
    }
}