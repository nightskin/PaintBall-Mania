using UnityEngine;
using UnityEngine.UI;

public class ModulateBG: MonoBehaviour
{
    public float transition = 0.1f;
    
    Image target;
    Color[] colors;
    Color startColor;
    int index = 0;
    
    void Start()
    {
        target = GetComponent<Image>();
        colors = new Color[6];
        colors[0] = new Color(1, 0, 0, 1); //red
        colors[1] = new Color(1, 1, 0, 1); //yellow
        colors[2] = new Color(0, 0, 1, 1); // blue
        colors[3] = new Color(0, 1, 0, 1); // green
        colors[4] = new Color(1, 0.5f, 0, 1); //orange
        colors[5] = new Color(1, 0, 1, 1); //purple

        float r = Random.Range(0, 1.0f);
        float g = Random.Range(0, 1.0f);
        float b = Random.Range(0, 1.0f);

        startColor = new Color(r, g, b, 1);
        target.color = startColor;
    }
    
    void Update()
    {
        if(target.color != colors[index])
        {
            target.color = Color.Lerp(target.color, colors[index], transition);
        }
        else
        {
            if (index < 5)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }




}
