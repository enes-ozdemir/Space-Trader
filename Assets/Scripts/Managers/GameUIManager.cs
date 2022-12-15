using ScriptableObjects;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GalaxyUIPanel galaxyUIPanel;
        [SerializeField] public MoneyPanel moneyPanel;
        [SerializeField] private WeaponPanel weaponPanel;
        [SerializeField] private CustomerPanel customerPanel;
        [SerializeField] private GameObject gameOverPanel;

        public void UpdateUIForNewCustomer(Customer customer, int offer, Weapon weapon)
        {
            customerPanel.UpdateCrimeList(customer);
            weaponPanel.UpdateWeaponInfo(weapon);
            customerPanel.UpdateOfferText(offer, weapon.money);
        }

        public void GameOver() => gameOverPanel.SetActive(true);

        public void UpdateUIForSold(int dangerLevel, int maxDangerLevel, int gainedRep, int maxRep, int money,
            int profit)
        {
            moneyPanel.UpdateMoney(money, profit);
            galaxyUIPanel.UpdateDangerLevel(dangerLevel, maxDangerLevel);
            galaxyUIPanel.UpdateReputation(gainedRep, maxRep);
        }

        public void UpdateUIForDenied(int dangerLevel, int maxDangerLevel, int lostRep, int maxRep)
        {
            galaxyUIPanel.UpdateDangerLevel(dangerLevel, maxDangerLevel);
            galaxyUIPanel.UpdateReputation(lostRep, maxRep);
        }

        public void UpdateEveryUI(int dangerLevel, int maxDangerLevel, int gainedRep, int maxRep, int money, int profit)
        {
            moneyPanel.UpdateMoney(money, profit);
            galaxyUIPanel.UpdateDangerLevel(dangerLevel, maxDangerLevel);
            galaxyUIPanel.UpdateReputation(gainedRep, maxRep);
        }

        public void UpdateUIForWeapon(Weapon weapon) => weaponPanel.UpdateWeaponInfo(weapon);

        public void UpdateUIForMoney(int money, int profit) => moneyPanel.UpdateMoney(money, profit);

        public void BuyInfo() => customerPanel.InfoBought();
    }
}