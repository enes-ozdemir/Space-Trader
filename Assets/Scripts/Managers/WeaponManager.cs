using System;
using System.Collections.Generic;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class WeaponManager : MonoBehaviour
    {
        public Weapon currentWeapon;
        public Transform weaponTransform;
        public WeaponPrefabs weapons;
        public WeaponList weaponList;

        public void SpawnNewWeapon()
        {
            if (currentWeapon.gameObject != null) Destroy(currentWeapon.gameObject);
            
            currentWeapon = GetRandomWeaponObject();
            Debug.Log(
                $"{currentWeapon.weaponType} is created with danger level: {currentWeapon.dangerLevel} Money: {currentWeapon.money}");
            currentWeapon.gameObject = Instantiate(currentWeapon.gameObject, weaponTransform);
            currentWeapon.gameObject.transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1)
                .SetEase(Ease.Linear).SetRelative(true);
            
            currentWeapon.gameObject.SetActive(true);
        }

        private Weapon GetRandomWeaponObject()
        {
            var index = Random.Range(0, weaponList.weapons.Count-1);
            var weaponType = weaponList.weapons[index];
            var weapon = weaponType;

            return weapon.weaponType switch
            {
                WeaponType.Weapon => SetWeapon(weapon, weapons.Weapon),
                WeaponType.MeleeWeapon => SetWeapon(weapon, weapons.MeleeWeapon),
                WeaponType.Nuclear => SetWeapon(weapon, weapons.Nuclear),
                WeaponType.Explosives => SetWeapon(weapon, weapons.Explosives),
                WeaponType.MedicalEquipment => SetWeapon(weapon, weapons.MedicalEquipment),
                WeaponType.Turret => SetWeapon(weapon, weapons.Turret),
                WeaponType.Ammo => SetWeapon(weapon, weapons.Ammo),
                WeaponType.ShipEquipment => SetWeapon(weapon, weapons.ShipEquipment),
                WeaponType.TacticalEquipment => SetWeapon(weapon, weapons.TacticalEquipment),
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