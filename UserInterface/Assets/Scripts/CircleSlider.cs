/*
 * Knob control
 * 
 * Michael T. Miyoshi
 * 
 * (school project)
 * 
 * from: 
 *  https://www.youtube.com/watch?v=yRKJdUAWn5A
 *  
 * The tutorial does some neat things with filling in an indicator showing
 * the (volume) control level.  The tutorial just rotated the knob indicator.  
 * I decided to rotate the knob too.  (My indicator needs work.)
 * 
 * The knob was taken from an image at istockphoto.com:
 *  https://www.istockphoto.com/photos/volume-knob?mediatype=photography&phrase=volume%20knob&sort=mostpopular
 * Edited it in Gimpshop to have the knob by itself and the notches by
 * themselves.  Would need to do lots of work to do the indicator lights.
 * 
 * I need to change the code so the knowb will go around
 * all the way and continue back at zero or go to 360 from 0.  (Done.) 
 * The commented if statement is what limits the angle of the knob.  The 
 * commented angle assignment is what limits the transform.
 * 
 * The Quaternion uses degree angle.  The 135f is an adjustment for where
 * the knob indicators starts.  The angle zero is to the right 
 * (Vector3.forward?).
 * 
 */

using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Transform knob;
    //[SerializeField] Image fill;
    //[SerializeField] Text valText;
    Vector3 mousePos;

    public void onHandleDrag()
    {
        //Debug.Log("HandleDrag");
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;
        //if(angle <=225 || 315 <= angle)
        {
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            //Quaternion r = Quaternion.AngleAxis(angle, Vector3.forward);
            handle.rotation = r;
            knob.rotation = r;
            //angle = ((315 <= angle) ? (angle - 360) : angle) + 45;
            //fill.fillAmount = 0.75f - (angle / 360f);
            //valText.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString();
        }
        Debug.Log("Angle: " + angle);
    }
}
