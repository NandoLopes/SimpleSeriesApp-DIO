using DIO.Series.Enum;

namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Listed();
        T GetById(int id);
        void Create(T entity);
        void ChangeDeletion(int id, DeletionStatusEnum state);
        void Update(int Id, T entity);
        int NextId();
    }
}