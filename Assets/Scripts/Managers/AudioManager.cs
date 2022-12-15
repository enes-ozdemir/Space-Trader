using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Singleton

        public static AudioManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        #endregion

        public AudioSource buySuccess;
        public AudioSource buyDenied;
        public AudioSource worldEnd;
        public AudioSource reputationEnd;
    }
}