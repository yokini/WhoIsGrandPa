using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pathflip : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject detect = null;

    [SerializeField] private GameObject Card_Back;

    public void OnMouseDown()
    {

       

     Card_Back.SetActive(true);
            
    if(gameObject.tag == "red")
        {
            SceneManager.LoadScene("tiptoe");
        }

    }
    
    void Start()
    {
        Card_Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


      

    }
}
