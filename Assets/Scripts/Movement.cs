
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust = 6f;

    [SerializeField] private float rotationThrust = 100f;
    // we put Rigidbody into a variable
    private Rigidbody _rb;
    private AudioSource _audioSource;
   
    void Start()
    {
        //we assign this value to the variable
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.AddRelativeForce(0,mainThrust,0 * Time.deltaTime);
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }
    }
    

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            ApplyRotation(rotationThrust);

        else if (Input.GetKey(KeyCode.D))
            ApplyRotation(-rotationThrust);
    }

     void ApplyRotation(float rotationThisFrame)
    {
        _rb.freezeRotation = true;//freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * (rotationThisFrame * Time.deltaTime));
        _rb.freezeRotation = false;// we are unfreezing so the physics can take over
    }
}
