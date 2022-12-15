using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private int _dangerLevel = 10;
        private int maxDangerLevel = 100;
        private int _money = 100;
        private int _reputation = 50;
        private int maxReputation = 100;
        public int dayCount;

        public GameUIManager gameUIManager;

        [SerializeField] private CustomerManager customerManager;
        [SerializeField] private WeaponManager weaponManager;

        private int _currentOffer;
        private static int _profit = 0;

        [SerializeField] private GameObject endGameFleet;
        [SerializeField] private Transform endGameFleetGoalTransform;

        private void Start()
        {
            Pushable.onButtonPushed += ClickAction;
            Pushable.onInfoButtonPushed += BuyInfo;

            gameUIManager.UpdateEveryUI(_dangerLevel, maxReputation, _reputation, maxReputation, _money, _profit);

            weaponManager.SpawnNewWeapon();

            customerManager.GetNewCustomer();

            _currentOffer =
                OfferManager.GetOfferForWeapon(customerManager.currentCustomer, weaponManager.currentWeapon);

            gameUIManager.UpdateUIForNewCustomer(customerManager.currentCustomer, _currentOffer,
                weaponManager.currentWeapon);

            gameUIManager.UpdateUIForWeapon(weaponManager.currentWeapon);
        }

        private void BuyInfo()
        {
            if (_money > 1000)
            {
                _money -= 1000;
                gameUIManager.BuyInfo();
                gameUIManager.UpdateUIForMoney(_money, _profit);
            }
            else
            {
                gameUIManager.moneyPanel.transform.DOShakePosition(3f, 3f);
                Debug.Log("Not enough money");
            }
        }


        private void ClickAction(bool isSold)
        {
            if (isSold)
            {
                SellWeapon(weaponManager.currentWeapon, _currentOffer, customerManager.currentCustomer);
                AudioManager.Instance.buySuccess.Play();
                
                customerManager.SendCurrentCustomerAway();
                customerManager.GetNewCustomer();
                weaponManager.SpawnNewWeapon();
                gameUIManager.UpdateUIForSold(_dangerLevel, maxDangerLevel, _reputation, maxReputation, _money,
                    _profit);
            }
            else
            {
                AudioManager.Instance.buyDenied.Play();
                customerManager.SendCurrentCustomerAway();
                WeaponSellDenied(weaponManager.currentWeapon);
                customerManager.GetNewCustomer();
                weaponManager.SpawnNewWeapon();
                gameUIManager.UpdateUIForDenied(_dangerLevel, maxReputation, _reputation, maxReputation);
            }

            _currentOffer =
                OfferManager.GetOfferForWeapon(customerManager.currentCustomer, weaponManager.currentWeapon);
            gameUIManager.UpdateUIForWeapon(weaponManager.currentWeapon);
            gameUIManager.UpdateUIForNewCustomer(customerManager.currentCustomer, _currentOffer,
                weaponManager.currentWeapon);
        }

        private void WeaponSellDenied(Weapon weapon)
        {
            _dangerLevel -= weapon.dangerLevel / 100;
            var decreaseRep = ((weapon.dangerLevel * 4 + (weapon.money / 5) * 3) / 500) * 3;
            if (decreaseRep > 20) decreaseRep = 20;
            _reputation -= decreaseRep;

            if (_dangerLevel < 0) _dangerLevel = 0;

            CheckIfGameOver();
        }

        private void SellWeapon(Weapon weapon, int offeredMoney, Customer customer)
        {
            _profit += offeredMoney - weapon.money;
            
            var customerAdditionalValue = customer.dangerLevel / 500;
            if (customerAdditionalValue > 25) customerAdditionalValue = 25;
            var additionalDangerLevel = weapon.dangerLevel / 100 + customerAdditionalValue;
            _dangerLevel += additionalDangerLevel;
            _money += offeredMoney;
            Debug.Log("Danger level increased by: " + additionalDangerLevel);
            Debug.Log("Money gained: " + offeredMoney);
            
            var additionalRepLevel = (weapon.dangerLevel * 2 + (offeredMoney - weapon.money) * 3) / 500;
            if (additionalRepLevel < 5) additionalRepLevel = 5;
            _reputation += additionalRepLevel;
            if (_reputation >= 100) _reputation = 100;
            Debug.Log("Reputation  increased by: " + additionalRepLevel);

            CheckIfGameOver();
        }

        private void CheckIfGameOver()
        {
            if (_dangerLevel >= maxDangerLevel || _reputation < 0)
            {
                Debug.Log("Game Over");
                SpawnEndGameFleet();
            }
        }

        private void SpawnEndGameFleet()
        {
            endGameFleet.SetActive(true);
            endGameFleet.transform.DOMove(endGameFleetGoalTransform.position, 3f);
            
            AudioManager.Instance.reputationEnd.Play();
            AudioManager.Instance.worldEnd.Play();
            
            gameUIManager.GameOver();
            Pushable.isGameOver = true;
        }
    }
}