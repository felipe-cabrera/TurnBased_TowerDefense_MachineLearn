using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimShot : MonoBehaviour {

    [SerializeField]
    GameObject bullet; // The bullet prefab (Object)

    TowerController tower; // This tower's main controller

    // Start the parameters to fire every 1 second
    void Start () {
        tower = gameObject.GetComponent<TowerController>(); 
    }
	

	public void NextRound () {
        AimToTarget();
    }

    void AimToTarget()
    {
        tower.UpdateTarget();
        if (tower.target != null)
        {
            // Rotate our Tower to the taget 
            Quaternion neededRotation = Quaternion.LookRotation(Vector3.forward, tower.target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, 1f);

            Shot();
        }
    }

    void Shot()
    {
        // Instantiate the bullet and send this tower as the Main Tower for that bullet.
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        bulletInstance.GetComponent<Bullet>().tower = this.tower;
        // Config the type of the bullet
        bulletInstance.GetComponent<BulletTypes>().BulletType = (BulletTypes.Types) tower.GetComponent<TowerTypes>().TowerType;

    }
}
