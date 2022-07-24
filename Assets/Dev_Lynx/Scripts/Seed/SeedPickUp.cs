using UnityEngine;

public class SeedPickUp : MonoBehaviour
{
        #region Variables

        [Header("Growth Variable Fields")]
        [SerializeField] Vector3 minScale;
        [SerializeField] Vector3 maxScale;
        [SerializeField] float scaleSpeed;
        [SerializeField] float scaleDuration;

        bool isGrowing;

        [Header("Essential Seed Variable Fields")]
        [SerializeField] Seed seed;
        [SerializeField] Collider seedCollider;
        [SerializeField] Rigidbody seedRB;
        [SerializeField] int seedsToAdd;


        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
                seedRB = GetComponent<Rigidbody>();
                seedCollider = GetComponent<CapsuleCollider>();
                transform.localScale = minScale;
                isGrowing = true;

                SetSeed();
        }

        void Update() {
                GrowSeed();
        }

        void OnCollisionEnter(Collision collision) {
                if(collision.gameObject.tag == "Player") {
                        WateringCan wateringCan = FindObjectOfType<WateringCan>();

                        if(wateringCan != null) {
                                seed.AddToStash(seedsToAdd);
                                Destroy(gameObject);
                        }
                }

        }

        #endregion

        #region Private Methods

        private void SetSeed() {
                seedCollider.enabled = false;
                seedRB.useGravity = false;
                seedRB.isKinematic = true;
        }

        private void GrowSeed() {
                if(isGrowing) {
                        transform.localScale = Vector3.Lerp(transform.localScale, maxScale, scaleSpeed * Time.deltaTime);
                }
                
                if(transform.localScale == maxScale) {
                        isGrowing = false;
                        SetPickUp();
                }
        }

        private void SetPickUp() {
                seedCollider.enabled = true;
                seedRB.useGravity = true;
                seedRB.isKinematic = false;
                Destroy(gameObject, 17.5f);
        }

        #endregion

        #region Public Methods



        #endregion
}
