using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
        #region Variables

        [Header("UI Variable Fields")]
        [SerializeField] TMP_Text seedClip;
        [SerializeField] TMP_Text seedStash;
        [SerializeField] Image waterAmmo;

        WateringCan wateringCan;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            wateringCan = FindObjectOfType<WateringCan>();
        }

        void Update() {
            //HandleHealth();
            HandleSeedAmmo();
            HandleWaterAmmo();
        }

        #endregion

        #region Private Methods

        private void HandleSeedAmmo() {
            seedClip.text = wateringCan.currentSeedData.GetClip().ToString();
            seedStash.text = wateringCan.currentSeedData.GetStash().ToString();
        }

        private void HandleWaterAmmo() {
            float waterRatio = (float)wateringCan.currentWater / (float)wateringCan.maxWater;
            Vector3 targetAmmo = new Vector3(waterRatio, 1f, 1f);

            waterAmmo.rectTransform.localScale = Vector3.Lerp(waterAmmo.rectTransform.localScale, targetAmmo, 5f * Time.deltaTime);
        }

        #endregion

        #region Public Methods



        #endregion
        
    
}
