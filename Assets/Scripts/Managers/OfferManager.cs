using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public static class OfferManager
    {
        public static int GetOfferForWeapon(Customer customer, Weapon weapon)
        {
            int originalValue = weapon.money;
            float luckFactor = Random.Range(0.8f, 2f);
            originalValue = (int) (originalValue * luckFactor);
            if (customer.isWanted) originalValue *= 2;
            if (weapon.weaponType == WeaponType.Nuclear) originalValue *= 2;
            if (customer.crimeCountDictionary.Count == 5) originalValue = (int) (originalValue * 1.3);

            if (originalValue <= 0) originalValue = weapon.money;

            return originalValue;
        }
    }
}