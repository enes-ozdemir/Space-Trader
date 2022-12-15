using UnityEngine;

namespace Managers
{
    public class WeaponInfoManager : MonoBehaviour
    {
        [SerializeField] private WeaponList weaponList;
        [SerializeField] private WeaponInfo weaponInfo;
        [SerializeField] private Transform parent;

        private void Awake()
        {
            foreach (var weapon in weaponList.weapons)
            {
                var info = Instantiate(weaponInfo, parent);
                info.InitWeaponInfo(weapon);
            }
        }
    }
}