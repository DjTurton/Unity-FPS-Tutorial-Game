﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public void DecrementAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount -= 1;
    }

    public void IncreaseAmmo(AmmoType ammoType, int amount)
    {
        GetAmmoSlot(ammoType).ammoAmount += amount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }

        }
        return null;
    }

}