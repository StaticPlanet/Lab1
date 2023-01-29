using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;

    float speed = 10.0f;

    const float StoppingRange = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);

        if((transform.position - player.position).magnitude > StoppingRange)
        {
            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);   
        }
        
    }
}
