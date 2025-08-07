using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private TMP_InputField myTextField;

    private Image bgImage;

    private void Awake()
    {
        myTextField = GetComponent<TMP_InputField>();
        bgImage = GetComponent<Image>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public char GetLetter()
    {
        return myTextField.text.Length == 0 ? ' ' : myTextField.text[0];
    }

    public void PushColor(Color newColor)
    {
        bgImage.color = newColor;
    }
}
