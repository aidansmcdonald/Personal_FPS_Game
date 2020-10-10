using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get current position of game object (player)
        Vector3 pos = transform.position;

        //speed in x direction is increased by Input.GetAxis("Horizontal") over time, 
        //where horizontal is 'name' in project settings input
        pos.x += moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        //Above code for vertical axis
        pos.z += moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        //Sets game object's (player) position to the new position
        transform.position = pos;

    }
}
