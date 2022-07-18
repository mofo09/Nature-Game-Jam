using UnityEngine;
using System.Collections;

public class SeedProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields - Seed")]
        [SerializeField] GameObject plantToGrow;
        [SerializeField] float projectileSpeed;

        Rigidbody rb;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision) {

            if(collision.gameObject.tag == "Wall") {
                rb.isKinematic = true;
            }
            
        }

        #endregion

        #region Private Methods

        

        #endregion

        #region Public Methods

        public void GrowPlant() {
            if(plantToGrow != null){
            GameObject plantPrefab = Instantiate(plantToGrow, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        #endregion
}
