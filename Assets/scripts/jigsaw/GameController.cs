using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public int level;
    public int row, col, countStep;
    public int rowBlank, colBlank;
    public int sizeRow, sizeCol;
    int countPoint = 0;
    int countImageKey = 0;
    int countComplete = 0;

    public bool startControl=false;
    public bool checkComplete;
    public bool gameIsComplete;

    GameObject temp;

    public List<GameObject> ImageKeyList;
    public List<GameObject> ImageOfPictureList;
    public List<GameObject> CheckPointList;

    GameObject[,] ImageKeyMatrix;
    GameObject[,] ImageOfPictureMatrix;
    GameObject[,] CheckPointMatrix;
  


    // Start is called before the first frame update
    void Start()
    {
        ImageKeyMatrix = new GameObject[sizeRow, sizeCol];
        ImageOfPictureMatrix = new GameObject[sizeRow, sizeCol];
        CheckPointMatrix = new GameObject[sizeRow, sizeCol];


        ImageOfLevel();
            
            CheckPointManager();
        ImageKeyManager();

        for (int r = 0; r < sizeRow; r++)
        {
            for (int c = 0; c < sizeCol; c++)
            {

               if( ImageOfPictureMatrix[r, c].name.CompareTo("blank") == 0)
                {
                    Debug.Log("ok");
                    rowBlank = r;
                    colBlank = c;
                    break;

                }
           //     countPoint++;
            }

        }

    }

    void CheckPointManager()
    {
        for (int r = 0; r < sizeRow; r++)
        {
            for (int c = 0; c < sizeCol; c++)
            {

                CheckPointMatrix[r, c] = CheckPointList[countPoint];
                countPoint++;
            }

        }


    }
   
    void ImageKeyManager()
    {
        for (int r = 0; r < sizeRow; r++)
        {
            for (int c = 0; c < sizeCol; c++)
            {

                ImageKeyMatrix[r, c] = ImageKeyList[countImageKey];
                countImageKey++;
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
       if(startControl)
        {
            startControl = false;
            if (countStep == 1)
            {
                if (ImageOfPictureMatrix[row, col] != null && ImageOfPictureMatrix[row, col].name.CompareTo("blank") != 0)
                {
                    if(rowBlank != row && colBlank == col)
                    {

                        if (Mathf.Abs(row - rowBlank) == 1)
                        {
                            SortImage();
                            countStep = 0; //reset
                        }
                        else
                        {
                            countStep = 0; //reset
                        }
                    }
                    else if (rowBlank == row && colBlank != col)
                    {

                        if (Mathf.Abs(col - colBlank) == 1)
                        {
                            SortImage();
                            countStep = 0;
                        }
                        else
                        {
                            countStep = 0; //reset
                        }
                    }
                    else if ((rowBlank == row && colBlank == col) || (rowBlank != row && colBlank != col))
                            {
                    countStep = 0;
                    }
                }
                else
                {
                  countStep = 0;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if(checkComplete)
        {

            checkComplete = false;
            for(int r=0; r<sizeRow; r++)
            {
                for(int c=0; c<sizeCol; c++)
                {
                    if(ImageKeyMatrix[r,c].gameObject.name.CompareTo(ImageOfPictureMatrix[r, c].gameObject.name)==0)
                    {
                        countComplete++;
                    }
                    else
                    {
                        break;
                    }
                }

            }

            if (countComplete == CheckPointList.Count)
            {

                gameIsComplete = true;

                Debug.Log("Complete");
                //  SceneManager.LoadScene("nextscene");

            }
            else
            {
                countComplete = 0;
            }
        }
    

    }



    void SortImage()
    {
        temp = ImageOfPictureMatrix[rowBlank, colBlank];
        ImageOfPictureMatrix[rowBlank, colBlank] = null;
        ImageOfPictureMatrix[rowBlank, colBlank] = ImageOfPictureMatrix[row, col];
        ImageOfPictureMatrix[row, col] = null;
        ImageOfPictureMatrix[row, col] = temp;

        ImageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().target=CheckPointMatrix[rowBlank, colBlank];
        ImageOfPictureMatrix[row, col].GetComponent<ImageController>().target = CheckPointMatrix[row, col];
        ImageOfPictureMatrix[rowBlank, colBlank].GetComponent<ImageController>().StartMove = true;
        ImageOfPictureMatrix[row, col].GetComponent<ImageController>().StartMove = true;

        rowBlank = row;
        colBlank = col;
    }

    void ImageOfLevel()
    {
        ImageOfPictureMatrix[0, 0] = ImageOfPictureList[0];
        ImageOfPictureMatrix[0, 1] = ImageOfPictureList[2];
        ImageOfPictureMatrix[0, 2] = ImageOfPictureList[5];
        ImageOfPictureMatrix[1, 0] = ImageOfPictureList[4];
        ImageOfPictureMatrix[1, 1] = ImageOfPictureList[1];
        ImageOfPictureMatrix[1, 2] = ImageOfPictureList[7];
        ImageOfPictureMatrix[2, 0] = ImageOfPictureList[3];
        ImageOfPictureMatrix[2, 1] = ImageOfPictureList[6];
        ImageOfPictureMatrix[2, 2] = ImageOfPictureList[8];

    }
}
