using System.Collections.Generic;
using DefaultNamespace;
using UI;
using UnityEngine;

namespace Managers
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private GalaxyUIPanel galaxyUIPanel;
        [SerializeField] private MoneyPanel moneyPanel;
        [SerializeField] private WeaponPanel weaponPanel;
        [SerializeField] private CustomerPanel customerPanel;

        public void UpdateUIForNewCustomer(Dictionary<Crime,int> crimeList,int offer,Weapon weapon)
        {
            customerPanel.UpdateCrimeList(crimeList);
            weaponPanel.UpdateWeaponInfo(weapon);
            customerPanel.UpdateOfferText(offer,weapon.money);
        }
    
        public void UpdateUIForSold(int dangerLevel,int maxDangerLevel,int gainedRep,int maxRep,int money)
        {
            moneyPanel.UpdateMoney(money);
            galaxyUIPanel.UpdateDangerLevel(dangerLevel,maxDangerLevel);
            galaxyUIPanel.UpdateReputation(gainedRep,maxRep);
        }
        public void UpdateUIForDenied(int dangerLevel,int maxDangerLevel,int lostRep,int maxRep)
        {
            galaxyUIPanel.UpdateDangerLevel(dangerLevel,maxDangerLevel);
            galaxyUIPanel.UpdateReputation(lostRep,maxRep);
        }

        public void UpdateEverything(int dangerLevel,int maxDangerLevel,int gainedRep,int maxRep,int money)
        {
            moneyPanel.UpdateMoney(money);
            galaxyUIPanel.UpdateDangerLevel(dangerLevel,maxDangerLevel);
            galaxyUIPanel.UpdateReputation(gainedRep,maxRep);
        }

        public void UpdateUIForWeapon(Weapon weapon)
        {
            weaponPanel.UpdateWeaponInfo(weapon);
        }
    
    

    }
}