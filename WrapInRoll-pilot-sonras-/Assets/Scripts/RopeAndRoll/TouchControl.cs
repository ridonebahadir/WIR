using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

    [Header("Sound")]
    public AudioClip[] audioClip;
    public AudioSource audioSource;

   public float time;
    public bool play;
    int turn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (play&&time<0.3f)
        {

            time += Time.deltaTime/10;
            
        }
       
        if (time>0.3f)
        {
            audioSource.Stop();
            play = false;
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Fruit")
        {
            if (play)
            {
                time = 0;
                return;
            }
            else
            {
                play = true;
                StartCoroutine(playEngineSound());
               
            }
            
           
        }
    }


    IEnumerator playEngineSound()
    {
        while (play)
        {
            audioSource.clip = audioClip[turn];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            if (turn < audioClip.Length)
            {
                turn++;

            }
            else
            {
                turn = 0;
            }
        }


    }
}
