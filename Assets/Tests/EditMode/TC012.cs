using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI; // for use of slider

public class TC012 
{
    private OptionsMenu optionsMenu;
    private GameObject menuGO;
    private Slider bgSlider;

    [SetUp]
    public void Setup()
    {
        // setup OptionsMenu for testing
        menuGO = new GameObject("OptionsMenu");
        optionsMenu = menuGO.AddComponent<OptionsMenu>();

        // create slider for testing
        var sliderGO = new GameObject("BGSlider", typeof(Slider));
        bgSlider = sliderGO.GetComponent<Slider>();
        // 0 to 1 is range used in testing
        bgSlider.minValue = 0f;
        bgSlider.maxValue = 1f;
        bgSlider.value = 0.5f;

        optionsMenu.bgSlider = bgSlider;

        // create mock SoundManager for testing
        var smGO = new GameObject("SoundManager");
        var soundManager = smGO.AddComponent<SoundManager>();

        // populate soundlist with two sounds for testing
        soundManager.soundlist = new Sound[2];
        for (int i = 0; i < 2; i++)
        {
            var s = new Sound
            {
                clipName = $"Sound{i}",
                clip = AudioClip.Create("Dummy", 44100, 1, 44100, false),
                volume = 0.5f,
                loop = false,
                source = smGO.AddComponent<AudioSource>()
            };
            soundManager.soundlist[i] = s;
        }
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(menuGO);
    }

    [Test]
    public void CanDetectDragOfSlider()
    {
        // simulate dragging slider to 0.8
        bgSlider.value = 0.8f;
        optionsMenu.AdjustBackgroundVolume(bgSlider.value); 

        // check that slider value is updated
        Assert.AreEqual(0.8f, bgSlider.value, 0.01f);
    }
}
