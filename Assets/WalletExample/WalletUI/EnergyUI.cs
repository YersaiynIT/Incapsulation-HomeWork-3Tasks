using System;
using TMPro;

public class EnergyUI : IDisposable
{
    private TMP_Text _energyTextUI;
    private IReadOnlyVariable<int> _energyCurrency;

    public EnergyUI(TMP_Text textUI, IReadOnlyVariable<int> energyCurrency)
    {
        _energyTextUI = textUI;

        _energyCurrency = energyCurrency;
        _energyCurrency.Changed += OnCurrencyChanged;
    }

    public void Dispose() =>
        _energyCurrency.Changed -= OnCurrencyChanged;

    private void OnCurrencyChanged(int currentValue) =>
        _energyTextUI.text = "Energy: " + currentValue.ToString();
}




