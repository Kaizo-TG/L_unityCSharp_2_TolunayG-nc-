using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsoncolorÜbung : MonoBehaviour
{
    public Renderer kugel; 
    public Button zufallsFarbeButton;
    public Button speichernButton;
    public Button ladenButton;

    string dateipfad;

    void Start()
    {
        // speicherort der Farbe
        dateipfad = Application.persistentDataPath + "/farbe.txt";

        // Buttons verbinden
        zufallsFarbeButton.onClick.AddListener(ZufallsFarbeAnwenden);
        speichernButton.onClick.AddListener(FarbeSpeichern);
        ladenButton.onClick.AddListener(FarbeLaden);
    }

    void ZufallsFarbeAnwenden()
    {
        // Random Farbe 
        Color neueFarbe = new Color(Random.value, Random.value, Random.value);
        kugel.material.color = neueFarbe;
    }

    void FarbeSpeichern()
    {
        // Farbe in string umwandeln
        string farbText = ColorUtility.ToHtmlStringRGB(kugel.material.color);
        File.WriteAllText(dateipfad, farbText);
    }

    void FarbeLaden()
    {
        if (File.Exists(dateipfad))
        {
            string farbText = File.ReadAllText(dateipfad);
            Color geladeneFarbe;

            if (ColorUtility.TryParseHtmlString("#" + farbText, out geladeneFarbe))
            {
                kugel.material.color = geladeneFarbe;
            }
        }
    }
}

