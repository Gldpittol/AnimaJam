using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    public float delay1;
    public float delay2;
    public Image Credits1;
    public Image Credits2;
    public string sceneToLoad;
    public float fadeSpeed = 2f;
        private void Awake()
        {
            StartCoroutine(CreditsCoroutine());
        }
    
        public IEnumerator CreditsCoroutine()
        {
            Credits1.color = new Color(1, 1, 1, 0);
            Credits2.color = new Color(1, 1, 1, 0);
            while (Credits1.color.a < 1)
            {
                Credits1.color = new Color(1, 1, 1, Credits1.color.a + Time.deltaTime / fadeSpeed / 2);
                yield return null;
            }
            yield return new WaitForSeconds(delay1 - fadeSpeed * 2);

            while (Credits1.color.a > 0)
            {
                Credits1.color = new Color(1, 1, 1,  Credits1.color.a - Time.deltaTime / fadeSpeed / 2);
                yield return null;
            }
            Credits1.color = new Color(1, 1, 1, 0);
            while (Credits2.color.a < 1)
            {
                Credits2.color = new Color(1, 1, 1, Credits2.color.a + Time.deltaTime / fadeSpeed / 2);
                yield return null;
            }
            yield return new WaitForSeconds(delay2 - fadeSpeed * 2);
            while (Credits2.color.a > 0)
            {
                Credits2.color = new Color(1, 1, 1,  Credits2.color.a - Time.deltaTime / fadeSpeed / 2);
                yield return null;
            }
            Credits1.color = new Color(1, 1, 1, 0);

            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
}
