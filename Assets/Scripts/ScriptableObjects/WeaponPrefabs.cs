using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponPrefabs")]
    public class WeaponPrefabs : ScriptableObject
    {
        public List<GameObject> Weapon;
        public List<GameObject> MeleeWeapon;
        public List<GameObject> Nuclear;
        public List<GameObject> Explosives;
        public List<GameObject> MedicalEquipment;
        public List<GameObject> Turret;
        public List<GameObject> ShipEquipment;
        public List<GameObject> Ammo;
        public List<GameObject> TacticalEquipment;
    }
}