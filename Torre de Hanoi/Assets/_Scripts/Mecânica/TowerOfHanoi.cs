using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerOfHanoi : MonoBehaviour
{
    private int maxTowerPieces = 8;
    private int minTowerPieces = 3;
    private int currentTowerPieces = 4;
    [SerializeField] private List<CakeLayer> towerPieces;

    [SerializeField] private Tower[] towers;

    [SerializeField] private TextMeshProUGUI currentMovesText;
    [SerializeField] private TextMeshProUGUI currentMovesTextBackground;
    [HideInInspector] public int currentMoves = 0;
    [HideInInspector] public int minMoves;

    public TextMeshProUGUI endText;
    public GameObject ending;

    public AudioClip endingSong;

    private void Start()
    {        
        InitializeGame();
    }

    public void InitializeGame()
    {
        towers[0].ResetList();
        towers[1].ResetList();
        towers[2].ResetList();

        minMoves = (int)(Mathf.Pow(2.0f, currentTowerPieces) - 1.0f);

        currentMoves = 0;
        currentMovesText.text = string.Format("{0}/{1}", currentMoves.ToString("000"), minMoves.ToString("000"));
        currentMovesTextBackground.text = currentMovesText.text;

        for (int i = 0; i < currentTowerPieces; i++)
        {
            towerPieces[maxTowerPieces - currentTowerPieces + i].gameObject.SetActive(true);
            towers[0].PopulateList(towerPieces[maxTowerPieces - currentTowerPieces + i]);
        }
    }

    public void AddPiece()
    {
        if(currentTowerPieces < maxTowerPieces)
        {
            currentTowerPieces++;
            InitializeGame();
        }
    }

    public void RemovePiece()
    {
        if(currentTowerPieces > minTowerPieces)
        {
            towerPieces[maxTowerPieces - currentTowerPieces].gameObject.SetActive(false);
            currentTowerPieces--;            
            InitializeGame();
        }
    }

    public void MakeMove()
    {
        currentMoves++;
        currentMovesText.text = string.Format("{0}/{1}", currentMoves.ToString("000"), minMoves.ToString("000"));
        currentMovesTextBackground.text = currentMovesText.text;
    }

    public int GetCurrentTowerPieces()
    {
        return currentTowerPieces;
    }
}
