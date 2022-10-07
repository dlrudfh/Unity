using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinfo : MonoBehaviour
{
    [SerializeField]
    private GameObject status;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            status.SetActive(!status.activeSelf);

        }
    }
}
