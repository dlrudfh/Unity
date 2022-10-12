using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinfo : MonoBehaviour
{
    [SerializeField]
    private GameObject status;
    [SerializeField]
    private GameObject skill;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            status.SetActive(!status.activeSelf);
        }
        else if (Input.GetKeyDown("k"))
        {
            skill.SetActive(!skill.activeSelf);
        }
    }
}
