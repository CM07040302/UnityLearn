using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationThrust =1f;
    [SerializeField] float mainThrust =1000f;
    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();

        ProcessRotation();
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)){
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);

        }

    }
    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.Play();}
        }
        else
        {
            audioSource.Stop();

        }
    }
    void ApplyRotation(float rotationThrust){
        transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);

    }

    }
