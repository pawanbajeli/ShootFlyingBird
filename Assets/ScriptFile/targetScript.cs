
using UnityEngine;

public class targetScript : MonoBehaviour
{
    //Start is called before the first frame update
    private GameManager GameManage;
    private AudioSource Gun_sound;
    //public ParticleSystem spawnEffect;
    void Start()
    {   //reference to the game manager script
        GameManage = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject obj = GameObject.FindWithTag("gun_sound");
        Gun_sound = obj.GetComponent<AudioSource>();
        Destroy(gameObject, 1.5f);
    }

    void OnMouseDown()
    {
        //Debug.Log("Target hit ho gya h");
        GameManage.incrementScore();
        Gun_sound.Play();
        //spawnEffect.Play();
        Destroy(gameObject);
    }
}
