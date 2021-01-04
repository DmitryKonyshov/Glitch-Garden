using System;
using UnityEngine;

public class DefendersSpawner : MonoBehaviour
{
    Defender defender;
    private GameObject defenderParent;
    private const string DEFENDER_PARENET_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENET_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENET_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttempToPlaceDefenderAt(GetSqareClicked());
    }

    public void SetSelectorDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStartCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetSqareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
}
