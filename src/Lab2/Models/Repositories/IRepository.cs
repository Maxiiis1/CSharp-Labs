namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Repositories;

public interface IRepository<T>
{
    void AddComponent(string name, T item);
    T GetComponents(string name);
}