using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        EnemyManager.Instance.RegisterEnemy(this);
    }

    public void ColorChange()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }


    public void Highlight()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
