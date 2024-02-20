using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public GameObject player;
    public float cameraOffset = 5;
    public Vector3 characterPosition;
    public float smoothing = 2;
    public float directionX;

    void Start()
    {
    }
    void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        characterPosition = new Vector3(player.transform.position.x, player.transform.position.y +1f, transform.position.z);
        if(directionX > 0f)
    {
            characterPosition = new Vector3(characterPosition.x + cameraOffset, characterPosition.y, characterPosition.z);
        }
        else if (directionX < 0f)
        {
            characterPosition = new Vector3(characterPosition.x - cameraOffset, characterPosition.y, characterPosition.z);

        }
        transform.position = Vector3.Lerp(transform.position, characterPosition, smoothing * Time.deltaTime);

    }
   
}


