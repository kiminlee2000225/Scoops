using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{

    public Rigidbody2D rb;
    public float degrees;
    public BulletHandler bullet;
    public GameObject turret;
    // the empty game object where the bullet should be spawned
    public GameObject bulletSpawn;
    // the position of the bulletSpawn object
    Vector3 bulletSpawnPosition;
    // the bullet's rotation
    Quaternion bulletRotation;
    // the speed that the bullet will travel at
    public int speed;
    // the rotation of the turret when the bullet should be fired
    Vector3 turretRotation;
    // the transform component of the bullet
    public Transform bulletTransform;
    // can the turret be shot? True if hasn't been shot yet
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        // get the bullet's rigid body
        rb = bullet.GetComponent<Rigidbody2D>();
        // get the quaternion of the bullet so it's rotated correctly
        bulletRotation = bulletSpawn.transform.rotation;
        // get the initial turret rotation
        turretRotation = turret.transform.up;
        // when the scene is started, you can shoot
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        // sets the bullet spawn position to be the position of the spawn object
        bulletSpawnPosition = bulletSpawn.transform.position;
        // if the user presses space, shoot the bullet
        if (Input.GetKeyUp(KeyCode.UpArrow) && canShoot == true) {
            bullet.docked = false; 
            // shooting is done, can't shoot again
            canShoot = false;
            // gets the rotation of the turret at the time space is called
            turretRotation = turret.transform.up;

            // get the rigidbody component of the bullet to add a speed
            rb = bullet.GetComponent<Rigidbody2D>();

            // removes the barrel-parent as a parent for the bullet, as it's 
            // now been fired and shouldn't rotate when the mouse is moved
            bulletTransform = bullet.transform;
            bulletTransform.parent = null;

            // add a force based on a determined speed value and the x and y 
            // components of the velocity
            rb.AddForce(new Vector2(turretRotation.x * speed, 
                                    turretRotation.y * speed));
        }

    }
}
