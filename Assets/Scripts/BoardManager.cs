using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    [SerializeField] private GameObject[] peices;
    private static int width = 16;
    private static int height = 13;
    GameObject[][] board = new GameObject[height][];
    GameObject selected;

	void Start () {
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new GameObject[width];
        }
        PlaceBoard();
  	}

    void PlaceBoard()
    {
        ColorType[] possibleColors = {ColorType.BLUE, ColorType.GREEN, ColorType.ORANGE, ColorType.PURPLE, ColorType.RED, ColorType.WHITE, ColorType.YELLOW};
        for (int y = 1; y < height; y++)
        {
            for(int x = 1; x < width; x++)
            {
                int random;
                GameObject randomToAdd;
                ColorType randomToAddColorType;

                do
                {
                    random = Random.Range(0, peices.Length - 1);
                    randomToAdd = peices[random];
                    randomToAddColorType = possibleColors[random];
                } while ((x >= 3 &&
                         board[y][x-1].GetComponent<HasColorType>().getColorType() == randomToAddColorType &&
                         board[y][x-2].GetComponent<HasColorType>().getColorType() == randomToAddColorType)
                         ||
                         (y >= 3 &&
                         board[y-1][x].GetComponent<HasColorType>().getColorType() == randomToAddColorType &&
                         board[y-2][x].GetComponent<HasColorType>().getColorType() == randomToAddColorType));
  
                board[y][x] = randomToAdd;
                Instantiate(randomToAdd, new Vector3(x*.8f, y*.8f), Quaternion.identity);
            }
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            int minDistanceXIndex = 1;
            int minDistanceYIndex = 1;
            for (int y = 1; y < height; y++)
            {
                for (int x = 1; x < width; x++)
                {
                    if (Vector3.Distance(mousePosition, board[y][x].transform.position) < 
                            Vector3.Distance(mousePosition, board[minDistanceYIndex][minDistanceXIndex].transform.position))
                        {
                            minDistanceXIndex = x;
                            minDistanceYIndex = y;
                        }
                }
            }
            selected = board[minDistanceYIndex][minDistanceXIndex];
        }

    }



}
