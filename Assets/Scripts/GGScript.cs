using UnityEngine;

public class GGScript : MonoBehaviour {

    public static float objectSpeed = -0.5f;
    public static bool paused = false;

    void Update()
    {
        if(!paused)
        {
            transform.Translate(0, 0, objectSpeed);
        }
    }
}
