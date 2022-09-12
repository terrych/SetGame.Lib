namespace SetGame.Api.Database.Read.QueryHandlers
{
    public interface IQueryHandler<T, U>
    {
        U Execute(T query);
    }
}
