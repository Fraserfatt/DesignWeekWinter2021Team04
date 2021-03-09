using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCycle : MonoBehaviour
{

    public AudioSource ambient;
    

    // Start is called before the first frame update

    private void Awake()
    {
        ambient = GetComponent<AudioSource>();
    }

    void Start()
    {
        ambient.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
