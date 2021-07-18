namespace todo_list.DbInfrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
