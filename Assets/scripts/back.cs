﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnMouseDown()
    {
        Debug.Log("hi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}
