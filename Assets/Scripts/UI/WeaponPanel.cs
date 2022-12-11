using DefaultNamespace;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private TextMeshProUGUI dangerLevelText;
        [SerializeField] private TextMeshProUGUI descText;

        public void UpdateWeaponInfo(Weapon weapon)
        {
            valueText.text = "Value: " + weapon.money;
            typeText.text = "Type: " + weapon.weaponType;
            dangerLevelText.text = "Danger Level: " + weapon.dangerLevel;
            descText.text = weapon.desc;
        }
    }
}