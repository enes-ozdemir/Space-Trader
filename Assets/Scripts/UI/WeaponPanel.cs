using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private TextMeshProUGUI descText;
        [SerializeField] private WeaponInfo _weaponInfo;

        public void UpdateWeaponInfo(Weapon weapon)
        {
            valueText.text = "Value: " + weapon.money;
            typeText.text = "Type: " + weapon.weaponType;
            descText.text = weapon.desc;
            var values = new WeaponValues();
            values.dangerLevel = weapon.dangerLevel;
            values.weaponType = weapon.weaponType;
            _weaponInfo.InitWeaponInfo(values);
        }
    }
}