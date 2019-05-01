using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShootingScript : MonoBehaviour {

    public GameObject RayOriginPoint;
    public VRTK.VRTK_ControllerEvents controllerEvents;
    Animator TargetAnimator;
    private int count;
    public int TimerEndCount;
    public float fireRate = 1.25f;
    private float nextFire;
    [SerializeField] GameObject Bullet_Mark;
    [SerializeField] Timer timer;
    Collider m_Collider;


    // Use this for initialization
    void Start()
    {
        //geting to animator component
        TargetAnimator = GetComponent<Animator>();
        //ceting the count value to 0 on start
        count = 0;
    }
    // Update is called once per frame
    void Update () {

    //if the fire button or the ocules trigger button is pressed then fire unless the fire rate the fire rate 
        if (Input.GetButtonDown("Fire1") || controllerEvents.triggerPressed && Time.time >nextFire)
            {
            //adding the value of fire rate between shots
            nextFire = Time.time + fireRate;


            RaycastHit hit;
            if (Physics.Raycast(RayOriginPoint.transform.position, RayOriginPoint.transform.right, out hit))
            {
                //draw line were the ray cast is originating and log the name if what the ray cast hits
                Debug.DrawLine(RayOriginPoint.transform.position, hit.point, Color.red, 5);
                Debug.Log("Hit: " + hit.transform.name);

                //if the the ray hits a object with the Target tag
                if (hit.collider.tag == "Target")


                {

                    Debug.Log("Hit at Distance: " + hit.distance);
                    Debug.Log("Hit at Point: " + hit.point.ToString());

                    GameObject Temporary_Bullet_Mark_Game_Object;
                    Temporary_Bullet_Mark_Game_Object = Instantiate(Bullet_Mark, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
                    Temporary_Bullet_Mark_Game_Object.transform.rotation = Quaternion.LookRotation(Vector3.forward, hit.normal);
                    //set the ;pwer target bool to true which will then start the animation of the target lowering 
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("LowerTarget", true);
                    //stop the target from being hit again.
                    hit.collider.enabled = false;

                    Destroy(Temporary_Bullet_Mark_Game_Object, 3.0f);

                    //add one the the count value for each target hit.
                    count = count + 1;
                    Debug.Log(count);
                }
                //if the count value is equal to the time end count value then stip the timer
                if (count == TimerEndCount)
                {
                    timer.Finnish();
                }
            }
        }

    }
    
}
