using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game instance;
    [SerializeField] private GameObject boardManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public BoardManager GetBoard()
    {
        return boardManager.GetComponent<BoardManager>();
    }
}
