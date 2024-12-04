using System;

public class Item : IReadOnlyItem
{
    private int _count;

    public Item(int id, int count)
    {
        ID = id;
        Count = count;
    }

    public int ID { get; }

    public int Count
    {
        get => _count;
        set
        {
            if (value < 0)
                throw new ArgumentException("Count cannot be negative");

            _count = value;
        }
    }
}
