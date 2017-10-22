using System.Collections;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    //public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (rend.enabled)
        {
            rend.sharedMaterial.SetTextureOffset(textureName, uvOffset);
        }
    }
}