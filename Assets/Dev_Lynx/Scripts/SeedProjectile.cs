using UnityEngine;
using System.Collections;

public class SeedProjectile : MonoBehaviour
{
        #region Variables

        [Header("Projectile Variable Fields")]
        [SerializeField] float projectileSpeed;

        Rigidbody rb;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            rb.velocity = gameObject.transform.forward * projectileSpeed;
        }

        private void OnCollisionEnter(Collision collision) {

            if(collision.gameObject.tag == "Wall") {
                StartCoroutine(StickToWall());
            }
            
        }

        #endregion

        #region Private Methods

        private IEnumerator StickToWall() {
            yield return new WaitForSeconds(0.0005f);
            rb.isKinematic = true;
        }
        
        #endregion

        #region Public Methods



        #endregion
}
