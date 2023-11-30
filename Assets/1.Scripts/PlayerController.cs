using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 3;
    bool playerRight = true;
    bool moving = false;
    public Animator anim;
    public GameObject Talk;

    // Start is called before the first frame update
    void Start()
    {

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
        transform.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
    }

    public void ButtonUp_Left()
    {
        moving = false;
    }


    public void ButtonDown_Right()
    {
        playerRight = true;
        moving = true;
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    public void ButtonUp_Right()
    {
        moving = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "NPC")
        {
            Talk.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "NPC")
        {
            Talk.SetActive(false);
        }
    }

}
