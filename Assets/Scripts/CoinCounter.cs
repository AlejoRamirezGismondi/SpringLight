using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        coinsText.text = coins.ToString();
    }

    public void AddCoins(int n)
    {
        coins += n;
        UpdateText();
    }

    public void SubstractCoins(int n)
    {
        coins -= n;
        UpdateText();
    }
}
