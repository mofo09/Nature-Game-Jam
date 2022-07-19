using UnityEngine;

public class Tree : MonoBehaviour
{
        #region Variables

        [SerializeField] GameObject seedPickUpPrefab;
        [SerializeField] Vector2 seedAmountMinMax;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            InvokeRepeating("GrowSeeds", 0.1f, 15f);
        }

        #endregion

        #region Private Methods

            private void GrowSeeds() {
                int numberOfSeeds = Random.Range((int)seedAmountMinMax.x, (int)seedAmountMinMax.y);

                for(int i = 0; i < numberOfSeeds; i++) {
                    Vector3 spawnPos = transform.position + (Random.onUnitSphere * 1.5f);
                    Instantiate(seedPickUpPrefab, spawnPos, Quaternion.identity);
                }
            }

        #endregion

        #region Public Methods



        #endregion
}
