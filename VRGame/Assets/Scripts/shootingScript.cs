using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour {

    [SerializeField] int damageDelt = 20;
    [SerializeField] LayerMask layerMask;
    public VRTK.VRTK_ControllerEvents controllerEvents;


	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; //hiding the curser by turning its visability to false
        // |=  adds a ignoraycast layer to out layermask list.
        layerMask |= Physics.IgnoreRaycastLayer;
        layerMask = ~layerMask; 

    }
	
	// Update is called once per frame
	void Update () {
        //checking each turn to see if the escape button has been pressed 
        if (Input.GetKey(KeyCode.Escape)) 
        {
            //if it has then make the curser visible and unlock it.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        } //checking that the fire button that is configured in unity has been pressed
        if (Input.GetButtonDown("Fire1") || controllerEvents.triggerPressed )
        {
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //make a raycast with a line starting from center of camera
            //viewrPointToRay converts a point on the screen to draw a ray from. 
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            //creating a local variable to store infomation from the raycast
            RaycastHit hitInfo;
            //the 100 indicates the distance the raycast will shoot adding ~ layermask makes the ray objects in thes layer
            if(Physics.Raycast (mouseRay, out hitInfo,100, layerMask))
            {
                print("Hit: " + hitInfo.collider.name);
                //send the raycast and if the raycast hit something, print out the name to console
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 5.0f);
               

            }
        }
		
	}
}
