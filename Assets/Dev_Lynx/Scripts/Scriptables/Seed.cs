using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "Seeds")]
public class Seed : ScriptableObject
{
    public string seedType;
    public GameObject seedPrefab;
    public int clipSize;    //How many are ready to fire on startup? How many can be fired before reloading?
    public int ammo;        //How much reserve ammo it starts with? (default to 0)
    int clip;
    int stash;

    public void Initialize() {
        stash = ammo;
        clip = clipSize;
    }

    public bool canFireSeed() {
        if(clip > 0) {
            clip -= 1;
            return true;
        } else {
            return false;
        }
    }

    public void Reload() {
        stash += clip;
        clip = Mathf.Min(clipSize, stash);
        stash -= clip;
    }

    public int GetClip() {
        return clip;
    }

    public int GetStash() {
        return stash;
    }

    public void AddToStash(int amount) {
        stash += amount;
    }
}
