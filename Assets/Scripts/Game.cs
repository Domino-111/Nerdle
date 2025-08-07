using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "bilbo";
    public Row activeRow;

    public Color hot = new Color(0, 0, 0, 1);
    public Color warm = new Color(0, 0, 0, 1);
    public Color cold = new Color(0, 0, 0, 1);

    void Start()
    {
        GuessWord();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GuessWord();
        }
    }

    public void GuessWord()
    {
        string guess = activeRow.GetWord();
        if (guess.Contains(" ") || guess.Length != 5)
        {
            print("Invalid input");
            // Invalid input UI display?
            return;
        }

        guess.ToUpper();

        print($"Comparing the word '{word}' with the word '{guess}'");

        for (int i = 0; i < 5; i++)
        {
            print($"Comparing: {word[i]} and {guess[i]}");

            if (word[i] == guess[i])
            {
                print($"<color=green>They are the same</color>");
                activeRow.PushColor(i, hot);
            }

            else if (word.Contains(guess[i]))
            {
                print($"<color=yellow>The letter is in the word but wrong position</color>");
                activeRow.PushColor(i, warm);
            }

            else
            {
                print($"<color=black>The letter is not in the word</color>");
                activeRow.PushColor(i, cold);
            }
        }
    }
}
