
using UnityEngine;
using System.Collections.Generic;

public class KeyManager : MonoBehaviour
{
        #region Variables

        public int currentKeys;
        GameObject[] keys;
        int totalKeys;

        #endregion

        #region MonoBehaviour Callbacks

        void Update() {
            totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;

            currentKeys = totalKeys;
        }

        #endregion



}
