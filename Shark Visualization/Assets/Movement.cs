using UnityEngine;

public class Movement: MonoBehaviour
{
    //Needed to calculate velocity of non rigidbody
    float timeCounter;
    Vector3 previous;
    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;

    // Needed for circular oscillation 
    public float width;
    public float height;
    public float length;
    public float speed;

    //x,y,z needed for variation in plane
    public float x;
    public float y;
    public float z;

    private void Start()
    {

        timeCounter = 0;
        PrevPos = transform.position;
        NewPos = transform.position;
    }

    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x_osc = Mathf.Cos(timeCounter) * width + x;
        float y_osc = Mathf.Sin(timeCounter) * height + y;
        float z_osc = Mathf.Sin(timeCounter) * length + z;

        //Calculate velocity
        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation

        //Apply transformations
        Quaternion rotation = Quaternion.LookRotation(ObjVelocity, Vector3.up);
        transform.rotation = rotation;
        transform.position = new Vector3(x_osc, y_osc, z_osc);
    }
}