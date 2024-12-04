using TMPro;
using UnityEngine;

public class BootstrapWalletExample : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;
    private CoinUI _coinUI;

    [SerializeField] private TMP_Text _diamondText;
    private DiamondUI _diamondUI;

    [SerializeField] private TMP_Text _energyText;
    private EnergyUI _energyUI;

    [SerializeField] private InputHandler _inputHandler;
    private Wallet _wallet;

    [SerializeField] private WalletView _walletView;

    private void Awake()
    {
        _wallet = new Wallet();
        
        IReadOnlyVariable<int> coinCurrency = _wallet.GetCurrency(CurrencyType.Coin);
        _coinUI = new CoinUI(_coinText, coinCurrency);

        IReadOnlyVariable<int> diamondCurrency = _wallet.GetCurrency(CurrencyType.Diamond);
        _diamondUI = new DiamondUI(_diamondText, diamondCurrency);

        IReadOnlyVariable<int> energyCurrency = _wallet.GetCurrency(CurrencyType.Energy);
        _energyUI = new EnergyUI(_energyText, energyCurrency);

        _inputHandler.Initialize(_wallet);
    }

    private void Start() =>
        _walletView.Show();
}
