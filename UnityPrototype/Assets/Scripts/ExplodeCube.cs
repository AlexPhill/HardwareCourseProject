using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExplodeCube : MonoBehaviour
{

    [SerializeField] int cubesPerAxis;
    [SerializeField] float force;
    [SerializeField] float radius;
    [SerializeField] GameObject cubeDeathGameObject;
    //[SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathAudio;
    public ScoreController scoreCounter;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Explode()
    {

        AudioSource.PlayClipAtPoint(deathAudio, this.gameObject.transform.position);
        if (scoreCounter != null)
        {
            scoreCounter.IncreaseScore(500);
        }

        print("INCREASE SCORE");

        for (int x = 0; x < cubesPerAxis; x++)
        {
            for (int y = 0; y < cubesPerAxis; y++)
            {
                for(int z = 0; z < cubesPerAxis; z++)
                {
                    CreateCube(new Vector3(x, y, z));   
                }
            }
        }
        Destroy(gameObject);
    }

    void CreateCube(Vector3 coordinates )
    {



        GameObject cube = Instantiate(cubeDeathGameObject);

        Renderer rd = cube.GetComponent<Renderer>();

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.GetComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);

        Destroy(cube, 2f);



    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reflected")
        {
            Explode();
        }
        if (other.tag == "Fish")
        {
            Explode();
        }
    }
}
