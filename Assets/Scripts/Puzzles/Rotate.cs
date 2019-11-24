using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float RotateAmount;
    public float rotateTo;
    public bool canRotate;

    public void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Z) && canRotate)
        {
            
            rotateTo += RotateAmount;
            if(rotateTo >= 360)
            {
                rotateTo -= 360;
            }
        }



        if (Mathf.Abs(Mathf.FloorToInt(transform.rotation.eulerAngles.y)) != rotateTo)
        {
            RotateObjectY(this.gameObject, rotateTo, 2f);
            canRotate = false;
        } else {
            canRotate = true;
        }


    }
    //GameObject obj, float rotation, float speed
    public void RotateObjectX(GameObject obj, float rotation, float speed)
    {
        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(rotation, 0.0f, 0.0f), speed);
    }

    //GameObject obj, float rotation, float speed
    public void RotateObjectY(GameObject obj, float rotation, float speed)
    {
        obj.transform.rotation = Quaternion.RotateTowards(obj.transform.rotation, Quaternion.Euler(0.0f, rotation, 0.0f), speed);
    }

}
