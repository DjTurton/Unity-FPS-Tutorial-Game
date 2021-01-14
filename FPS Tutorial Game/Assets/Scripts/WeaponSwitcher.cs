using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 0;
    [SerializeField] List<GameObject> weapons;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProccessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void ProccessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentWeapon ++;
            currentWeapon = currentWeapon % weapons.Count;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon --;
            if (currentWeapon < 0)
            {
                currentWeapon = weapons.Count - 1;
            }
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (var weapon in weapons)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else 
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }


}
