using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        public void UpdateMoney(int money)
        {
            moneyText.text = money + " $";
        }
    }
}