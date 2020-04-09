using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerFootsteps, playerAttack, playerHurt;
    static AudioSource audioSrc;

    void Start()
    {
        playerFootsteps = Resources.Load<AudioClip>("run");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "run":
                audioSrc.PlayOneShot(playerFootsteps);
                break;
            case"attack":
                audioSrc.PlayOneShot(playerAttack);
                break;

            case "hurt":
                audioSrc.PlayOneShot(playerHurt);
                break;




        }

    }
}
