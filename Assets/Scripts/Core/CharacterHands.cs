using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHands : MonoBehaviour
{
    public Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponent<Animator>();

        if (Globe.characterIndex == 1)
        {
            myAnimator.runtimeAnimatorController = Resources.Load("Animator/hammer_side_cover_ninja") as RuntimeAnimatorController;
        }
    }
}