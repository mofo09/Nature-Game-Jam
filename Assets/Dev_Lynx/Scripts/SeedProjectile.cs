using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeedProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields - Seed")]
        [SerializeField] GameObject plantToGrow;

        Rigidbody rb;

        [Header("Raycast Variable Fields")]
        [SerializeField] float sphereRadius;
        [SerializeField] LayerMask layerMask;

        float maxDistance = 2f;
        float currentHitDistance;
        Vector3 origin;
        Vector3 direction;
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision) {

            if(collision.gameObject.tag == "Wall") {
                rb.isKinematic = true;
                spawnRotation = Quaternion.LookRotation(collision.contacts[0].normal);
            }
            
        }

        #endregion

        #region Private Methods

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
        }

        #endregion

        #region Public Methods

        public void GrowPlant() {
            if(plantToGrow != null){
            GameObject plantPrefab = Instantiate(plantToGrow, transform.position, spawnRotation) as GameObject;
            }
            Destroy(gameObject);
        }

        #endregion
}
