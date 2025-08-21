using UnityEngine;
using System.Collections.Generic;

public class WordMaster : MonoBehaviour
{
    public List<string> words = new List<string>();
    public bool shuffleOnPlay = false;

    [ContextMenu("Read and Filter File")]
    public void ReadAndFilterFile()
    {
        TextAsset importedWords = Resources.Load<TextAsset>("WordsV1");

        if (importedWords == null)
        {
            print("File not found! :(");
            return;
        }

        string[] lines = importedWords.text.Split(' ', ',', '\n');
        words.Clear();

        foreach (string word in lines)
        {
            if (word.Length != 5) 
            { 
                continue; 
            }

            if (HasSpecialCharacter(word)) 
            {
                continue; 
            }

            string capitalWord = word.ToUpper();

            if (words.Contains(capitalWord)) 
            {
                continue;
            }

            words.Add(capitalWord);
        }
    }

    public bool HasSpecialCharacter(string word)
    {
        foreach (char letter in word)
            if (!char.IsLetter(letter)) return true;
        return false;
    }

    [ContextMenu("Shuffle Words")]
    public void ShuffleWords()
    {
        List<string> newList = new List<string>();
        int limit = words.Count;

        for (int i = 0; i < words.Count; i++)
        {
            int randomIndex = Random.Range(0, words.Count);
            newList.Add(words[randomIndex]);
            words.RemoveAt(randomIndex);
        }

        words = newList;
    }

    [ContextMenu("Pop Word")]
    public string PopWord()
    {
        string newWord = words[0];
        words.RemoveAt(0);
        words.Add(newWord);
        return newWord;
    }
}
