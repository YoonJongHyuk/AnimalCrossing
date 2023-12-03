using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject TalkCamera;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Talk;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonDown()
    {
        MainCamera.SetActive(false);
        TalkCamera.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Talk.SetActive(false);
    }


    public void TalkButton_Down()
    {
        MainCamera.SetActive(true);
        TalkCamera.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Talk.SetActive(true);
    }


}
