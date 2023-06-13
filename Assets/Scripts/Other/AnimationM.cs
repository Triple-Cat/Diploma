using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationM : MonoBehaviour
{
    Animator anim;
    private float CurrentTime = 0;
    private float CouldownTime = 10f;
    int rand;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (CurrentTime <= 0)
        {
            rand = Random.Range(0, 100);
            StartCoroutine("ChooseAndPlay");
            CurrentTime = CouldownTime;
        }
        else
        {
            CurrentTime -= Time.deltaTime;
        }
    }
    IEnumerable ChooseAndPlay()
    {
        if (rand >= 50)
        {
            anim.SetTrigger("WarpUp");
        }
        else
        {
            anim.SetTrigger("Think");
        }
        return null;
    }
}

