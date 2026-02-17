using System.Runtime.InteropServices;
using UnityEngine;

public class AudioHapticsManager : MonoBehaviour
{
    public static AudioHapticsManager Instance { get; private set; }

    void Awake() 
    { 
        if (Instance == null) Instance = this; 
        else Destroy(gameObject); 
    } 

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void TriggerIOSHaptic();

    [DllImport("__Internal")]
    private static extern void TriggerAndroidHaptic(int duration);
#endif

    public void LightTap()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        TriggerIOSHaptic();
        TriggerAndroidHaptic(30);
#endif
    }
}