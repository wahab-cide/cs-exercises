#nullable disable

public abstract class AbstractEnumerable<T> : IEnumerable<T>
{
    /**
     * Exposes the enumerator, which supports a simple iteration over a
     * collection of a specified type.
     *
     * To implement in an extending class, be sure to use the `override`
     * keyword.
     *
     * @tparam T The type of element yielded by the enumerator.
     * @return An implementation of `IEnumerator<T>`.
     */
    public abstract IEnumerator<T> GetEnumerator();

    /**
     * Exposes a non-generic enumerator. Required by the interface, but only
     * useful for legacy code. Returns the generic enumerator, as it can be
     * used in a non-generic context.
     *
     * @return An implementation of `IEnumerator`.
     */
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public abstract class AbstractEnumerator<T> : IEnumerator<T>
{
    /**
     * Advances the enumerator to the next element of the collection.
     * An extending method must use the `override` keyword.
     *
     * @return true if and only if the enumerator returns a valid
     *         element.
     */
    public abstract bool MoveNext();

    /**
     * Sets the enumerator to its initial position, before the first
     * element in the collection.
     * An extending method must use the `override` keyword.
     */
    public abstract void Reset();

    /**
     * Gets the element in the collection at the current position of
     * the enumerator.
     * An extending property must use the `override` keyword.
     *
     * @return an element.
     */
    public abstract T Current { get; }

    /**
     * A non-generic getter that gets the element in the collection at
     * the current position of the enumerator. Required by the interface,
     * but only useful for legacy code.  This implementation simply
     * calls the generic `Current` getter, which can be used in a non-
     * generic context.
     * An extending method must use the `override` keyword.
     *
     * @return an element.
     */
    object System.Collections.IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    /**
     * Performs application-defined tasks associated with freeing, releasing,
     * or resetting unmanaged resources. Required by the `IEnumerator<T>`
     * interface, which implements `IDisposable<T>`.  `AbstractEnumerator<T>`
     * provides a default implementation that does nothing.
     * An extending method must use the `override` keyword.
     */
    public void Dispose() { }
}