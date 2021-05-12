using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public void Update()
    {
        #region UI Elements
        moneyText.text = "$" + Coin.money.ToString(); // Score Counter Text is equal to Integer Score
        #endregion

    }
}
