using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGobject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x+30 < GameObject.Find("/player").transform.position.x ) || (transform.position.y < -30))
        {
            Destroy(this.gameObject);
        }
    }
}
