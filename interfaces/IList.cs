public interface IList<E>
{
    public void insert(int i, E Value);

    public void RemoveAt(int i);
    public E Get(int i);
    public void Clear();
    public int Size();

}