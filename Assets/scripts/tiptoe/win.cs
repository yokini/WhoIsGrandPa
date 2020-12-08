using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class win : MonoBehaviour
{ 
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject g4;
    public GameObject g5;
    public GameObject g6;
    public GameObject g7;
    public GameObject g8;
    public GameObject g9;
    public GameObject g10;
    public GameObject g11;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (g1.activeInHierarchy && g2.activeInHierarchy && g3.activeInHierarchy && g4.activeInHierarchy && g5.activeInHierarchy && g6.activeInHierarchy && g7.activeInHierarchy && g8.activeInHierarchy && g9.activeInHierarchy && g10.activeInHierarchy && g11.activeInHierarchy  == true)
        {
            Debug.Log("win");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
  
    }
}
