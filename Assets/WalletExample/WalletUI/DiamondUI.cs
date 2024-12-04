using System;
using TMPro;

public class DiamondUI : IDisposable
{
    private TMP_Text _diamondTextUI;
    private IReadOnlyVariable<int> _diamondCurrency;

    public DiamondUI(TMP_Text textUI, IReadOnlyVariable<int> diamondCurrency)
    {
        _diamondTextUI = textUI;

        _diamondCurrency = diamondCurrency;
        _diamondCurrency.Changed += OnCurrencyChanged;
    }

    public void Dispose() =>
       _diamondCurrency.Changed -= OnCurrencyChanged;

    private void OnCurrencyChanged(int currentValue) =>
        _diamondTextUI.text = "Diamond: " + currentValue.ToString();
}
