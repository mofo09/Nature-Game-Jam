using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
        #region Variables

        [Header("Player Health Variable Fields")]
        [SerializeField] Image[] hearts;
        [SerializeField] Sprite heartFill;
        [SerializeField] Sprite heartEmpty;

        int maxHealth = 3;


        #endregion

        #region MonoBehaviour Callbacks

        void Update() {
            foreach(Image img in hearts) {
                img.sprite = heartEmpty;
            }

            for(int i = 0; i < maxHealth; i++) {
                hearts[i].sprite = heartFill;
            }
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public Methods

        public void TakeDamage() {
            maxHealth -= 1;

            if(maxHealth == 0) {
                //OnPlayerDeath;
            }
        }

        #endregion

}
