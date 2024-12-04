using System.Collections.Generic;
using System.Linq;
using System;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<int>> _currencies = new();

    public Wallet()
    {
        _currencies.Add(CurrencyType.Coin, new ReactiveVariable<int>());
        _currencies.Add(CurrencyType.Diamond, new ReactiveVariable<int>());
        _currencies.Add(CurrencyType.Energy, new ReactiveVariable<int>());
    }

    public List<CurrencyType> CurrencyTypes => _currencies.Keys.ToList();

    public IReadOnlyVariable<int> GetCurrency(CurrencyType type) => _currencies[type];

    public bool HasEnoughForSpend(CurrencyType type, int amount) => _currencies[type].Value >= amount;

    public void Add(CurrencyType type, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        if (_currencies.ContainsKey(type) == false)
            throw new ArgumentException("Кошелек не поддерживает такую валюту");

        _currencies[type].Value += amount;
    }

    public void Spend(CurrencyType type, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        if (_currencies.ContainsKey(type) == false)
            throw new ArgumentException("Кошелек не поддерживает такую валюту");

        if (HasEnoughForSpend(type, amount) == false)
            throw new ArgumentOutOfRangeException("Не хватает средств для списания");

        _currencies[type].Value -= amount;
    }
}
