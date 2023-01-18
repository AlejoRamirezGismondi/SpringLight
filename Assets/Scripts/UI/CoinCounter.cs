using DataPersistence;
using DataPersistence.Data;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinCounter : MonoBehaviour, IDataPersistence
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

        public void LoadData(GameData data)
        {
            coins = data.coins;
        }

        public void SaveData(GameData data)
        {
            data.coins = coins;
        }
    }
}
