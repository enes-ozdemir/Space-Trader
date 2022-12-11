using System.Security.Cryptography;
using DefaultNamespace;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private int _dangerLevel;
        private int maxDangerLevel = 100;
        private int _money;
        private int _reputation;
        private int maxReputation = 100;

        public GameUIManager gameUIManager;

        [SerializeField] private CustomerManager customerManager;
        [SerializeField] private WeaponManager weaponManager;

        private int _currentOffer;

        private void Start()
        {
            Pushable.onButtonPushed += ClickAction;

            gameUIManager.UpdateEverything(_dangerLevel, maxReputation, _reputation, maxReputation, _money);

            weaponManager.SpawnNewWeapon();

            customerManager.GetNewCustomer();

            _currentOffer =
                OfferManager.GetOfferForWeapon(customerManager.currentCustomer, weaponManager.currentWeapon);

            gameUIManager.UpdateUIForNewCustomer(customerManager.currentCustomer.crimeCountDictionary, _currentOffer,
                weaponManager.currentWeapon);

            gameUIManager.UpdateUIForWeapon(weaponManager.currentWeapon);
        }


        private void ClickAction(bool isSold)
        {
            if (isSold)
            {
                SellWeapon(weaponManager.currentWeapon, _currentOffer);
                customerManager.GetNewCustomer();
                weaponManager.SpawnNewWeapon();
                gameUIManager.UpdateUIForSold(_dangerLevel, maxDangerLevel, _reputation, maxReputation, _money);
            }
            else
            {
                WeaponSellDenied(weaponManager.currentWeapon);
                customerManager.GetNewCustomer();
                weaponManager.SpawnNewWeapon();
                gameUIManager.UpdateUIForDenied(_dangerLevel, maxReputation, _reputation, maxReputation);
            }

            _currentOffer =
                OfferManager.GetOfferForWeapon(customerManager.currentCustomer, weaponManager.currentWeapon);
            gameUIManager.UpdateUIForWeapon(weaponManager.currentWeapon);
            gameUIManager.UpdateUIForNewCustomer(customerManager.currentCustomer.crimeCountDictionary, _currentOffer,
                weaponManager.currentWeapon);
        }

        private void WeaponSellDenied(Weapon weapon)
        {
            _dangerLevel -= weapon.dangerLevel / 10;
            _reputation -= weapon.dangerLevel / 5;
        }

        private void SellWeapon(Weapon weapon, int offeredMoney)
        {
            //todo customer happy thing
            _dangerLevel += weapon.dangerLevel / 100;
            _money += offeredMoney;
            _reputation += (weapon.dangerLevel * 2 + (offeredMoney - weapon.money) * 3) / 100;
            customerManager.SendCustomerAway();
            CheckIfGameOver();
        }

        private void CheckIfGameOver()
        {
            if (_dangerLevel > maxDangerLevel || _reputation < 0)
            {
                Debug.Log("Game Over");
                //todo game over panel
                //todo destruct planet
            }
        }
    }
}