using UnityEngine;

public class Row : MonoBehaviour
{
    private Cell[] myCells;

    private void Awake()
    {
        myCells = GetComponentsInChildren<Cell>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public string GetWord()
    {
        string word = "";

        foreach (Cell cell in myCells)
        {
            word += cell.GetLetter();
        }
        return word;
    }

    public void PushColor(int index, Color newColor)
    {
        myCells[index].PushColor(newColor);
    }
}
