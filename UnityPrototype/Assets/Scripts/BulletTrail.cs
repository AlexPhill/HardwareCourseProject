using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    public float i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.widthMultiplier = Mathf.Lerp(lineRenderer.widthMultiplier, 0, 0.25f);

    }

    
}
