using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private TextMeshProUGUI totalProfit;

        public void UpdateMoney(int money, int profit)
        {
            moneyText.text = money + " $";
            totalProfit.text = profit + " $";
        }
    }
}