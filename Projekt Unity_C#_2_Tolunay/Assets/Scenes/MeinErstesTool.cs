using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MeinErstesTool : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;
    [MenuItem("NBPS/MeinErstesTool")]
    public static void ShowExample()
    {
        MeinErstesTool wnd = GetWindow<MeinErstesTool>();
        wnd.titleContent = new GUIContent("MeinErstesTool");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
        // button erstelln
        var myButton = new Button() { text = "My Button" };

        //Style festlegen
        myButton.style.width = 160;
        myButton.style.height= 30;
        //Button zum Root hinzufügen
        root.Add(myButton);
    }
    private void GeneratePrefab()
    {
        Debug.Log("Spawn Prefab");
        var go = ObjectFactory.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = new Vector3(UnityEngine.Random.Range(-10, 10), 0, 0);
    }
    void AssignBuilderEvents()
    {
        var myBtn = rootVisualElement.Q<Button>("BtnGenPrefab");
        myBtn.clicked += GeneratePrefab;
    }

}
