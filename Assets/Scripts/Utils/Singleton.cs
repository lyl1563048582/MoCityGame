public static class Singleton<T> where T : new()
{
    public static readonly T Inst = new T();
}