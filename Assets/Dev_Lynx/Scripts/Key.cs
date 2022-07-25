using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
        #region Variables

        [Header("Collectible VFX Fields")]
        [SerializeField] float rotationSpeed;
        [SerializeField] float hoverAmp;
        [SerializeField] float hoverIntensity;
        [SerializeField] float hoverOffset;

        Vector3 originPos;

        [Header("Collection Event")]
        [SerializeField] UnityEvent onKeyCollected;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            originPos = transform.position;
        }

        void FixedUpdate() {
            CollectableVFX();
        }

        void OnTriggerEnter(Collider collider) {
            if(collider.gameObject.CompareTag("Player")) {
                onKeyCollected.Invoke();
            }
        }

        #endregion

        #region Private Methods

        private void CollectableVFX() {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            transform.localPosition = new Vector3(originPos.x, originPos.y + ((hoverAmp * Mathf.Sin(Time.time * hoverIntensity)) + hoverOffset), originPos.z);
        }

        #endregion

        #region Public Methods



        #endregion
}
