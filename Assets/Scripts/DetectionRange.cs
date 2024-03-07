using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionRange : MonoBehaviour
{
    Collider2D collider2D;
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    public UnityEvent noColliders;
    // Start is called before the first frame update

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();  
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        detectedColliders.Remove(collision);
        if (detectedColliders.Count <= 0)
        {
            noColliders.Invoke();
        }
    }
}
