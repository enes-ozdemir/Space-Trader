using UnityEngine;

namespace ScriptableObjects
{
    public struct Weapon
    {
        public GameObject gameObject;
        public string name;
        public int dangerLevel;
        public string desc;
        public int money;
        public WeaponType weaponType;
    }

    public enum WeaponType
    {
        Weapon,
        MeleeWeapon,
        Nuclear,
        Explosives,
        MedicalEquipment,
        Turret,
        ShipEquipment,
        Ammo,
        TacticalEquipment,
    }
}