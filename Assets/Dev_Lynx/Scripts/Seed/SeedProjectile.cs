using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeedProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields - Seed")]
        [SerializeField] GameObject plantToGrow;
        [SerializeField] int dirtLayer;

        Rigidbody rb;
        Quaternion spawnRotation;
        int currentLayer;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {

            if(collision.gameObject.CompareTag("Growth Surface")) {
                rb.isKinematic = true;
                spawnRotation = Quaternion.LookRotation(collision.contacts[0].normal);
                currentLayer = collision.gameObject.layer;
            }
        }

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public void GrowPlant() {
            if(plantToGrow != null && currentLayer == dirtLayer){
            GameObject plantPrefab = Instantiate(plantToGrow, transform.position, spawnRotation) as GameObject;
            }
            Destroy(gameObject);
        }

        #endregion
}
