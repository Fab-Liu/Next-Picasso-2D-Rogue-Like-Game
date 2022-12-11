using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private float BulletCoolDown = 0.5f;
    
    private float LastShoot = 0;


    public GameObject bulltePrefab; //发射子弹

    public float FaceDirection;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        //HandleInput();
    }

    protected void HandleInput()
    {
        if (Input.GetMouseButton(0) && Time.time >= LastShoot + BulletCoolDown)
        {
            // Shoot();
        }
    }

    // private void Shoot()
    // {
    //     FaceDirection = Input.GetAxisRaw("Horizontal");
    //     BulletController bc = bullet.GetComponent<BulletController>();
    //     GameObject bullet =
    //         Instantiate(bulltePrefab, bc.rbody.position, Quaternion.identity);
        
    //     if (bc != null)
    //     {
    //         bc.Move(new Vector2(FaceDirection, 1), 300);
    //     }
    //     Debug.Log("发射了");
    //     LastShoot = Time.time;
    // }
}
