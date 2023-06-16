
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    #region Constants
    private const float splineOffset = 0.5f;
    #endregion

    #region Fields
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;
    #endregion
    #region MoneBehaviour Callbacks
    
    private void Awake()
    {
        UpdateVerticies();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVerticies();
    }
    #endregion

    #region privateMethods
    private void UpdateVerticies()
    {
        for(int i = 0; i<points.Length; i++)
        {
            Vector2 _vertex  = points[i].localPosition;

            Vector2 _towardsCenter  = (_vertex).normalized;
            float _colliderRadius = 0.2f*points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            try
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * _colliderRadius));
            }
            catch
            {
                spriteShape.spline.SetPosition(i, (_vertex - _towardsCenter * (_colliderRadius * splineOffset)));
            }
            Vector2 _lt = spriteShape.spline.GetLeftTangent(i);
            Vector2 _newRt = Vector2.Perpendicular(_towardsCenter) * _lt.magnitude;
            Vector2 _newLt = Vector2.zero - _newRt;

            spriteShape.spline.SetRightTangent(i, _newRt);
            spriteShape.spline.SetLeftTangent(i, _newLt);
        }
    }
    #endregion
}
