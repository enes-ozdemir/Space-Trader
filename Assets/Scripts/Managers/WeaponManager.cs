using System;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class WeaponManager : MonoBehaviour
    {
        public Weapon currentWeapon;
        [SerializeField] private GameObject lightField;
        public Transform weaponTransform;
        public WeaponPrefabs weapons;
        public WeaponList weaponList;

        public void SpawnNewWeapon()
        {
            if (currentWeapon.gameObject != null) currentWeapon.gameObject.SetActive(false);
            
            currentWeapon = GetRandomWeaponObject();
            Debug.Log(
                $"{currentWeapon.weaponType} is created with danger level: {currentWeapon.dangerLevel} Money: {currentWeapon.money}");
            var weapon = Instantiate(currentWeapon.gameObject, weaponTransform);
            weapon.transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1)
                .SetEase(Ease.Linear).SetRelative(true);
            lightField.SetActive(true);
            lightField.transform.DOScale(0, 0);
            lightField.transform.DOScale(1.5f, 2f).Loops();
            
            currentWeapon.gameObject.SetActive(true);
        }

        private Weapon GetRandomWeaponObject()
        {
            var index = Random.Range(0, 10);
            var weaponType = weaponList.weapons[index];
            var weapon = weaponType;

            return weapon.weaponType switch
            {
                WeaponType.Bombs => SetWeapon(weapon, weapons.Bombs),
                WeaponType.Medical => SetWeapon(weapon, weapons.Medical),
                WeaponType.Rifles => SetWeapon(weapon, weapons.Rifles),
                WeaponType.DeathBombs => SetWeapon(weapon, weapons.DeathBombs),
                WeaponType.Pistols => SetWeapon(weapon, weapons.Pistols),
                WeaponType.HeavyArtilery => SetWeapon(weapon, weapons.HeavyArtilery),
                WeaponType.NiceMedical => SetWeapon(weapon, weapons.NiceMedical),
                WeaponType.Artifact => SetWeapon(weapon, weapons.Artifact),
                WeaponType.Swords => SetWeapon(weapon, weapons.Swords),
                WeaponType.ShipParts => SetWeapon(weapon, weapons.ShipParts),
                WeaponType.ExpensiveShipParts => SetWeapon(weapon, weapons.ExpensiveShipParts),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private Weapon SetWeapon(WeaponValues type, List<GameObject> typeList)
        {
            var moneyLuck = Random.Range(1f, 1.5f);
            
            var weaponToSpawn = new Weapon
            {
                weaponType = type.weaponType,
                name = type.ToString(),
                desc = "",
                dangerLevel = type.dangerLevel,
                money = (int)(type.dangerLevel * moneyLuck),
                gameObject = typeList[GetRandomNumber(typeList.Count - 1)]
            };
            return weaponToSpawn;
        }

        private int GetRandomNumber(int limit) => Random.Range(0, limit);
    }
}