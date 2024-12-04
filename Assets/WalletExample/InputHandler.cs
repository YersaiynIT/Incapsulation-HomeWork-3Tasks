using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _wallet.Add(CurrencyType.Coin, 8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _wallet.Add(CurrencyType.Diamond, 8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _wallet.Add(CurrencyType.Energy, 8);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _wallet.Spend(CurrencyType.Coin, 10);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _wallet.Spend(CurrencyType.Diamond, 10);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _wallet.Spend(CurrencyType.Energy, 10);
        }
    }
}
