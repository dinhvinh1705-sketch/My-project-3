using UnityEngine;
using System.Collections;

public class ShootEffect : MonoBehaviour
{
    [SerializeField] GameObject effect;

    public void ShowEffect()
    {
        effect.SetActive(true);
        StartCoroutine(HideEffect());
    }

    IEnumerator HideEffect()
    {
        yield return new WaitForSeconds(1f);

        effect.SetActive(false);
    }
}
