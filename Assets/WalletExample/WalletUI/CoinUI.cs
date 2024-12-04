using System;
using TMPro;

public class CoinUI : IDisposable
{
    private TMP_Text _coinTextUI;
    private IReadOnlyVariable<int> _coinCurrency;

    public CoinUI(TMP_Text textUI, IReadOnlyVariable<int> coinCurrency)
    {
        _coinTextUI = textUI;

        _coinCurrency = coinCurrency;
        _coinCurrency.Changed += OnCurrencyChanged;
    }

    public void Dispose() =>
       _coinCurrency.Changed -= OnCurrencyChanged;

    private void OnCurrencyChanged(int currentValue)
    {
        _coinTextUI.text = "Coin: " + currentValue.ToString();
    }
}

