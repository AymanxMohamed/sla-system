using ICommand = System.Windows.Input.ICommand;

namespace SlaSystem.Application.Authentication.Commands;

public sealed record LoginCommand(UserName UserName, Password Password) : ICommand<User>;
