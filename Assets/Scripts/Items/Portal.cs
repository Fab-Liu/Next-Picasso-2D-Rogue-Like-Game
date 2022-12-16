using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportLocation;
    private bool inPortal;
    private Transform currentLocation;

    // Start is called before the first frame update
    void Start()
    {
        currentLocation = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inPortal)
            {
                currentLocation.position = teleportLocation.position;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            inPortal = true;
            GameObject portalDialog = GameObject.Find("Canvas (1)").transform.Find("PortalDialog").gameObject;
            portalDialog.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D myCollider2d)
    {
        if (myCollider2d.gameObject.CompareTag("Player"))
        {
            inPortal = false;
            GameObject portalDialog = GameObject.Find("Canvas (1)").transform.Find("PortalDialog").gameObject;
            portalDialog.SetActive(false);
        }
    }
}