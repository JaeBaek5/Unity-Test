using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0,7f, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
