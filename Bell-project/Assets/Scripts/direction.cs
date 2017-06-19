using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour {

    private Transform target;
    public float range = 20f;
    public string enemytag = "enemy";
    //private Enemy targetEnemy;
    public Transform partToRotate;

	// Use this for initialization
	void Start () {
        InvokeRepeating("updatetarget", 0f, 0.5f);

        
	}

    void updatetarget()
    { GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortest = Mathf.Infinity;
        GameObject nearest = null;

        foreach  (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy< shortest)
            { shortest = distanceToEnemy;
                nearest = enemy; }


        }
        if (nearest != null && shortest <= range)
        {
            target = nearest.transform;
           // targetEnemy = nearest.GetComponent<Enemy>();

        }
        else {
            target = null;
        }

    }




	// Update is called once per frame
	void Update () {
		if(target == null)
        return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); ;
	}


     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);    
    }

}
