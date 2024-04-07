using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.VisualScripting.Member;

public class Pistol : MonoBehaviour
{
    public ParticleSystem particles;
    public AudioClip GunShotClip;
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
        if (audiosource != null) audiosource.clip = GunShotClip;
    }

    private void StartShoot()
    {
        particles.Play();
        audiosource.Play();
        
    }

    private void StopShoot()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
