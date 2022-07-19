using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class WateringCan : MonoBehaviour
{
        #region Variables

        [Header("Watering Can - General Variables")]
        [SerializeField] Transform barrelPoint;
        [SerializeField] int startingWater; //If we decide to not start the player at max water on startup
        [SerializeField] int waterProjectileSetAmount;

        [HideInInspector] public int maxWater = 100; 
        [HideInInspector] public int currentWater;
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
                ShootWater();
            }

       
            if(seedInput && canShootSeed()) {
                ShootSeed();
            }         
    }

        private void HandleReload() {
            if(Input.GetKeyDown(KeyCode.X)) {
                ReloadSeed();
            }
        }


        private void ShootWater() {
            currentWater -= waterProjectileSetAmount;
            Instantiate(waterPrefab, barrelPoint.position, barrelPoint.rotation);
            Debug.Log("Firing water! There is " + currentWater + " water left.");
            OnWaterProjectile.Invoke();
        }

        private bool canShootWater() {
            return currentWater >= (maxWater / waterProjectileSetAmount);
        }

        private void ShootSeed() {
            Debug.Log("Firing seed!");
            Instantiate(currentSeedData.seedPrefab, barrelPoint.position, barrelPoint.rotation);
            OnSeedProjectile.Invoke(); 
        }

        private bool canShootSeed() {
            return currentSeedData.canFireSeed(); 
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
