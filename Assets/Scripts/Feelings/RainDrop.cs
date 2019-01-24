using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainDrop : MonoBehaviour
{

    public float MinSpeed;
    public float MaxSpeed;

    public float MinTime;
    public float MaxTime;

    public float TargetAlpha;
    public float AppearTime;

    private RectTransform _rectTransform;
    private Image _image;

    private Vector2 _pos;
    private float _speed;

    IEnumerator Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        _pos = new Vector2(Random.value, Random.value);

        _speed = Random.Range(MinSpeed, MaxSpeed);

        _rectTransform.anchorMin = _rectTransform.anchorMax = _pos;


        float f = 0;
        var color = _image.color;
        while(f < AppearTime)
        {
            f += Time.deltaTime;
            color.a = f / AppearTime * TargetAlpha;
            _image.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));

        f = AppearTime;
        color = _image.color;
        while (f > 0)
        {
            f -= Time.deltaTime;
            color.a = f / AppearTime * TargetAlpha;
            _image.color = color;
            yield return null;
        }

        Destroy(gameObject);
    }

    void Update()
    {
        _pos.y -= _speed * Time.deltaTime;

        _rectTransform.anchorMin = _rectTransform.anchorMax = _pos;
    }
}
