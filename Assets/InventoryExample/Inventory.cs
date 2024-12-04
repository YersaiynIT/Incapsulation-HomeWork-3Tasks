using System;
using System.Linq;
using System.Collections.Generic;

public class Inventory
{
    private Dictionary<int, Item> _items = new();

    public Inventory(int maxSize)
    {
        MaxSize = maxSize;
    }

    public int MaxSize { get; }
    public int CurrentSize => _items.Values.Sum(item => item.Count);

    public IEnumerable<IReadOnlyItem> GetAllItems() => _items.Values.ToList();

    public bool IsEnoughSpaceFor(Item item) => CurrentSize + item.Count <= MaxSize;

    public bool HasItemBy(int id, int count) => 
        _items.ContainsKey(id) && _items[id].Count >= count;

    public void AddItem(Item item)
    {
        if (!IsEnoughSpaceFor(item))
            throw new Exception("Not enough space in inventory");

        if (_items.ContainsKey(item.ID))
            _items[item.ID].Count += item.Count;
        else
            _items.Add(item.ID, item);
    }

    public Item GetItemBy(int id, int count)
    {
        if (HasItemBy(id, count) == false)
            throw new Exception("Not enough items with the specified ID and count");

        Item selectedItem = new Item(id, count);

        _items[id].Count -= count;

        if (_items[id].Count <= 0)
            _items.Remove(id);

        return selectedItem;
    }
}
