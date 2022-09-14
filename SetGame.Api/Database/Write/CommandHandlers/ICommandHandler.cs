namespace SetGame.Api.Database.Write.CommandHandlers
{
    public interface ICommandHandler<T>
    {
        void Execute(T command);
    }

    public interface ICommandHandler<T, U>
    {
        U Execute(T command);
    }
}
