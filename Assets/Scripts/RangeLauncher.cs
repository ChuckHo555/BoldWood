using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeLauncher : MonoBehaviour
{
    public GameObject projectile;
    public Transform slashLaunch;
     public void Fire()
    {
        GameObject lauchingProjectile = Instantiate(projectile, slashLaunch.position, projectile.transform.rotation);
        Vector3 orginalScale = lauchingProjectile.transform.localScale;
        lauchingProjectile.transform.localScale = new Vector3(orginalScale.x * transform.localScale.x > 0 ? 1:-1, orginalScale.y, orginalScale.z);
    }
}
