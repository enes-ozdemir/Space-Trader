using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GalaxyUIPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dangerLevelText;
        [SerializeField] private Image dangerLevelImage;
        [SerializeField] private TextMeshProUGUI reputationText;
        [SerializeField] private Image reputationImage;

        public void UpdateDangerLevel(int currentDangerLevel, int maxDangerLevel)
        {
            if(currentDangerLevel==0) currentDangerLevel=1;
            dangerLevelText.text = $"{currentDangerLevel} / {maxDangerLevel}";
            dangerLevelImage.fillAmount = maxDangerLevel / currentDangerLevel;
        }

        public void UpdateReputation(int currentRep, int maxRep)
        {
            if(currentRep==0) currentRep=1;
            reputationText.text = $"{currentRep} / {maxRep}";
            reputationImage.fillAmount = maxRep / currentRep;
        }
    }
}