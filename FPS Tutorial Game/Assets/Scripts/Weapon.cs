using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 30;
    [SerializeField] int weaponDamage = 30;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitImpact;
    [SerializeField] Ammo ammo;
    [SerializeField] bool infiniteAmmo = false;

    [SerializeField] int shotDelay = 0; 
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;    
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.GetCurrentAmmo(ammoType) > 0 || infiniteAmmo)
        {
            ammo.DecrementAmmo(ammoType);
            PlayMuzzleFlash();
            ProccessRaycast();
        }
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }


    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    private void ProccessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }


    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.5f);
    }
}
