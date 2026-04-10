using UnityEngine;

public class PsycheSkinApplier : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    [Header("Default")] // default is set to blue skin
    [SerializeField] private RuntimeAnimatorController defaultController;
    [SerializeField] private Sprite defaultSprite;

    [Header("Red")]
    [SerializeField] private RuntimeAnimatorController redController;
    [SerializeField] private Sprite redSprite;

    [Header("Green")]
    [SerializeField] private RuntimeAnimatorController greenController;
    [SerializeField] private Sprite greenSprite;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Set the color of the Psyche spacecraft using user's pick
    private void Start()
    {
        switch (GameLevels.Instance.GetSkin())
        {
            case "red":
                if (animator != null && redController != null)
                    animator.runtimeAnimatorController = redController;

                if (spriteRenderer != null && redSprite != null)
                    spriteRenderer.sprite = redSprite;
                break;

            case "green":
                if (animator != null && greenController != null)
                    animator.runtimeAnimatorController = greenController;

                if (spriteRenderer != null && greenSprite != null)
                    spriteRenderer.sprite = greenSprite;
                break;

            default: // default is set to blue skin
                if (animator != null && defaultController != null)
                    animator.runtimeAnimatorController = defaultController;

                if (spriteRenderer != null && defaultSprite != null)
                    spriteRenderer.sprite = defaultSprite;
                break;
        }
    }
}
