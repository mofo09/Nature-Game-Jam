using UnityEngine;

public class BouncePad : MonoBehaviour
{
        #region Variables

        [Header("Bounce Variable Fields")]
        
        [SerializeField] int bounceForce;

        #endregion

        #region MonoBehaviour Callbacks


        void OnCollisionEnter(Collision collision) {
            if(collision.gameObject.CompareTag("Player")) {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }

        #endregion

}
