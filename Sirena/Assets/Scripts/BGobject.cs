using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGobject : MonoBehaviour
{
    void Update()
    {
        if((transform.position.x+30 < GameObject.Find("/player").transform.position.x ) || (transform.position.y < -30))
        {
            Destroy(this.gameObject);
        }
    }
}
