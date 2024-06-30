using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int speed = 3;
    bool playerRight = true;
    bool moving = false;
    public Animator anim;
    public Button Talk;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerMove = speed * Time.deltaTime;
        if (moving != false && playerRight == true)
        {
            playerMove *= 1;
        }
        else if (moving != false && playerRight == false)
        {
            playerMove *= -1;
        }
        if (moving != false)
        {
            anim.SetBool("Move", true);
            this.transform.Translate(new Vector3(playerMove, 0, 0));
        }
        else if (moving == false)
        {
            anim.SetBool("Move", false);
        }
    }

    public void ButtonDown_Left()
    {
        playerRight = false;
        moving = true;
        rend.flipX = true;
    }

    public void ButtonUp_Left()
    {
        moving = false;
    }

    public void ButtonDown_Right()
    {
        playerRight = true;
        moving = true;
        rend.flipX = false;
    }

    public void ButtonUp_Right()
    {
        moving = false;
    }
}
