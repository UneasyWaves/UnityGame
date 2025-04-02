using UnityEngine;
using TMPro;
using System.Collections;
// https://www.youtube.com/watch?v=wZ2UUOC17AY&list=WL&index=1
// Jack Glenn-Kennedy  T00063898   March 14 2025
// check 7:50 to complete
public class ProjectileGun : MonoBehaviour
{
   // bullet
   public GameObject bullet;
   public float shootForce, upwardForce;

   //gun stats
   public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
   public int magazineSize, bulletsPerTap;
   public bool allowButtonHold;
   int bulletsLeft, bulletsShot;

   bool shooting, readyToShoot, reloading;

   public Camera fpsCam;
   public Transform attackPoint;

   // maybe dont need this part?
   public GameObject muzzleFlash;
   public TextMeshProUGUI ammunitionDisplay;

   // vid says 'bug fixing'
   public bool allowInvoke = true;

 
    

    private void Awake()
    {
        // make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    
    }

    private void Update()
    {
        MyInput();   
        // set ammo display if it exists
        if(ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft/ bulletsPerTap + "/" + magazineSize / bulletsPerTap);
        }

    }

    private void MyInput()
    {
        if(allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

       //reloading
       if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
       if(readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

       
        // shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            // set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }


    }

    private void Shoot()
    {
        readyToShoot = false;
        Ray ray1 = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit1;

        Vector3 targetPoint;
        if(Physics.Raycast(ray1, out hit1))
            targetPoint = hit1.point;
        else 
            targetPoint = ray1.GetPoint(75);  // just a point away from the player
        
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x,y,0);

        // instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        // instantiate muzzle flash, if you have it
        if(muzzleFlash != null)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        bulletsLeft--;
        bulletsShot++;

        if(allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }


    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

}
