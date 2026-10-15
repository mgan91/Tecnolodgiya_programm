/// <summary>
/// Объект, у которого есть срок годности.
/// </summary>
public interface IExpirable
{
    /// <summary>
    /// Проверяет, истёк ли срок годности.
    /// </summary>
    bool IsExpired();
}