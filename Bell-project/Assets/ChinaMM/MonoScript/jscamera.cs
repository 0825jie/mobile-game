using System;
using UnityEngine;

[Serializable, AddComponentMenu("Camera-Control/Mouse Orbit")]
public class jscamera : MonoBehaviour
{
    public float distance = 10f;
    public float maxDist = 50;
    public float minDist = 5;
    public Transform target;
    private float x;
    public float xSpeed = 250f;
    private float y;
    public int yMaxLimit = 80;
    public int yMinLimit = -20;
    public float ySpeed = 120f;
    public float zoomSpeed = 1;

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    public void Start()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        this.x = eulerAngles.y;
        this.y = eulerAngles.x;
        if (this.GetComponent<Rigidbody>() != null)
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    public void Update()
    {
        if (this.target != null)
        {
            Quaternion quaternion = Quaternion.Euler(this.y, this.x, (float) 0);
            Vector3 vector = ((Vector3) (quaternion * new Vector3((float) 0, (float) 0, -this.distance))) + this.target.position;
	        this.transform.rotation = quaternion;
	        this.transform.position = vector;
        }
        if (Input.GetMouseButton(1))
        {
            this.x += (Input.GetAxis("Mouse X") * this.xSpeed) * 0.02f;
            this.y -= (Input.GetAxis("Mouse Y") * this.ySpeed) * 0.02f;
            this.y = ClampAngle(this.y, (float) this.yMinLimit, (float) this.yMaxLimit);
        }
        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && (this.distance < this.maxDist))
        {
            this.distance += this.zoomSpeed;
            this.transform.Translate((Vector3) (Vector3.forward * -this.zoomSpeed));
        }
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && (this.distance > this.minDist))
        {
            this.distance -= this.zoomSpeed;
            this.transform.Translate((Vector3) (Vector3.forward * this.zoomSpeed));
        }
    }
}

