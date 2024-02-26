using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector2 startPos;
    float startPosZ;
    Vector2 camMove => (Vector2)cam.transform.position - startPos;
    float distanceFromCharacterZ => transform.position.z - target.transform.position.z;
    float clipping => (cam.transform.position.z + (distanceFromCharacterZ > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromCharacterZ / clipping);
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startPosZ = transform.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startPos + camMove * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startPosZ);
    }
}
