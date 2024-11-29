using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deagle : MonoBehaviour
{

    [SerializeField] int bulletsLeft;
    [SerializeField] int bulletsMax;

    [SerializeField] AudioClip fireSFX;
    [SerializeField] AudioClip emptyFireSFX;
    [SerializeField] AudioClip reloadSFX;

    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject muzzleflash;

    [SerializeField] GameObject bulletTrail;
    
    [SerializeField] TextMeshProUGUI ammoCounter;
    bool hasPressed;
    [SerializeField] float gunRange;

    // Start is called before the first frame update
    void Start()
    {
        bulletsLeft = bulletsMax;
        SetAmmoCount();
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if ()
        {

            fire();

            hasPressed = true;
           

        }
        else

        if ()
        {
            reload();
            hasPressed = true;

        }
        else
        {
            hasPressed = false;
        }
        */
    }

    
    public void reload()
    {
        bulletsLeft = bulletsMax;
        PlayAudioClip(reloadSFX);
        SetAmmoCount();
        ammoCounter.color = Color.white;
    }

    public void fire()
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft--;
            SetAmmoCount();
            PlayAudioClip(fireSFX);
            muzzleflash.GetComponent<ParticleSystem>().Play();
            RaycastHit hit;
            if (Physics.Raycast(muzzle.transform.position, transform.forward, out hit, gunRange))
            {
                //Debug.DrawRay(muzzle.transform.position, transform.forward * 500f, Color.red);
                //IF hit is enemy deal damage

                SpawnBulletTrail(hit.point - muzzle.transform.position);

                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<ExplodeCube>().Explode();
                }

            } else
            {
                SpawnBulletTrail(muzzle.transform.forward.normalized * gunRange);
                //SpawnBulletTrail(muzzle.transform.position + (muzzle.transform.forward.normalized * gunRange));

            }

            


        }
        else
        {
            
            PlayAudioClip(emptyFireSFX);
            SetAmmoCount();
            ammoCounter.color = Color.red;
        }
    }

    void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    
    void SpawnBulletTrail(Vector3 hitPos)
    {
        GameObject bulletTrailEffect = Instantiate(bulletTrail, muzzle.transform.position, Quaternion.identity);

        LineRenderer lineRenderer = bulletTrailEffect.GetComponent<LineRenderer>();
        bulletTrailEffect.transform.position = muzzle.transform.position;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, hitPos);
        Destroy(bulletTrailEffect, 1f);
    }

    void SetAmmoCount()
    {
        if (ammoCounter != null)
        {
            ammoCounter.SetText(bulletsLeft + "/" + bulletsMax);
        }
    }
}

