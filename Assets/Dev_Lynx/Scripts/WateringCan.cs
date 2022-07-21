using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class WateringCan : MonoBehaviour
{
        #region Variables

        [Header("Watering Can - General Variables")]
        [SerializeField] Camera cam;
        [SerializeField] Transform barrelPoint;
        [SerializeField] float projectileSpeed;

        Vector3 destination;
        bool waterInput;
        bool seedInput;

        [Header("Watering Can - Seed Ammo Swapping")]

        [Header("Watering Can - Seed")]
        [SerializeField] List<Seed> seeds = new List<Seed>();
        [SerializeField] UnityEvent OnSeedProjectile;

        [HideInInspector] public Seed currentSeedData;
        int currentSeed;

        [Header("Watering Can - Water")]
        [SerializeField] GameObject waterPrefab;
        [SerializeField] UnityEvent OnWaterProjectile;
        [SerializeField] int startingWater; //If we decide to not start the player at max water on startup
        [SerializeField] int waterProjectileSetAmount;

        [HideInInspector] public int maxWater = 100; 
        [HideInInspector] public int currentWater;

        #endregion

        #region MonoBehaviour Callbacks

        void Start() {
            currentWater = maxWater;
            foreach (Seed s in seeds) {
                s.Initialize();
            }
            EquipSeed(0);
        }

        void Update() {
            HandleShooting();
            HandleReload();
            currentWater = Mathf.Clamp(currentWater, 0, maxWater);
        }

        #endregion

        #region Private Methods

        private void HandleShooting() {
            waterInput = Input.GetButtonDown("Fire1");
            seedInput = Input.GetButtonDown("Fire2");
            
            if(waterInput && canShootWater()) {
                ShootProjectile(waterPrefab);
                currentWater -= waterProjectileSetAmount;
                OnWaterProjectile.Invoke();

                //Debug.Log("Firing water! There is " + currentWater + " water left.");
            }

       
            if(seedInput && canShootSeed()) {
                ShootProjectile(currentSeedData.seedPrefab);
                OnSeedProjectile.Invoke(); 

                //Debug.Log("Firing seed!");
            }         
    }

        private void HandleReload() {
            if(Input.GetKeyDown(KeyCode.X)) {
                ReloadSeed();
            }
        }

        private bool canShootWater() {
            return currentWater >= (maxWater / waterProjectileSetAmount);
        }

        private bool canShootSeed() {
            return currentSeedData.canFireSeed(); 
        }

        private void ShootProjectile (GameObject projectile) {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo)) {
                destination = hitInfo.point;
            } else {
                destination = ray.GetPoint(1000f);
            }

            var firedProjectile = Instantiate(projectile, barrelPoint.position, Quaternion.identity) as GameObject;
            firedProjectile.GetComponent<Rigidbody>().velocity = (destination - barrelPoint.position).normalized * projectileSpeed;
        }

        private void EquipSeed(int s_index) {      
            currentSeed = s_index;
            currentSeedData = seeds[currentSeed];
        }

        private void ReloadSeed() {
            currentSeedData.Reload();
        }

        #endregion

        #region Public Methods

        

        #endregion
}
