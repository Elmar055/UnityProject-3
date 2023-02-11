using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // rigitbody object variable for later use
    private Rigidbody playerRb;
    // animator object variable for later use
    private Animator playerAnim;
    // death effect object
    public ParticleSystem explosionParticle;
    // landslide effect
    public ParticleSystem dirtParticle;
    // jump sound
    public AudioClip jumpSound;
    //death sound
    public AudioClip crashSound;
    // to manage sound effects
    private AudioSource playerAudio;
    public float jumpForce = 10f;
    public float gravityModifier; // gravity value
    public bool isOnGround = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // to give rigidbody component to playerRb
        playerRb = GetComponent<Rigidbody>();
        // to give animator component to playerAnim
        playerAnim = GetComponent<Animator>();
        // to give AudioSource component to playerAudio
        playerAudio = GetComponent<AudioSource>();
        // to give gravity force
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // for jumping
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;

            // to give jump animation
            playerAnim.SetTrigger("Jump_trig");
            // end landslide effect
            dirtParticle.Stop();
            // to give jumpsound
            playerAudio.PlayOneShot(jumpSound,1f);
        }
        
    }

    // use this method whem collision happen
    private void OnCollisionEnter(Collision collision)
    {
        // if player and ground collise (using tag)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // start landslide effect
            dirtParticle.Play();
        }
        // if player and obstacle collise (using tag)
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            // to give death animation using animator conditions
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);

            // to give death effect
            explosionParticle.Play();
            // stop landslide effect
            dirtParticle.Stop();
            // use death audio
            playerAudio.PlayOneShot(crashSound);
            Debug.Log("Game Over");
        }
    }
}
