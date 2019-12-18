using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rotacion 
{
    public bool isActive;
    int rotAngel = 0;
    Vector3[][] rotation;
    
    

    public void rotateLeft(Transform t)
    {
        
        rotAngel = getRotAngle(rotAngel + 90);
        rotate(t, rotAngel / 90);
    }

    public void rotateRight(Transform t)
    {
        rotAngel = getRotAngle(rotAngel - 90);
        rotate(t, rotAngel / 90);
    }

    private int getRotAngle(int angle)
    {
        if (angle < 0)
            return 360 + angle;
        else if (angle > 270)
            return 0;
        return angle;
    }

    //Rotamos los bloques segun el tipo de rotacion que toque.
    private void rotate(Transform t, int pos)
    {
        for (int i = 0; i < t.childCount; i++)
        {
           t.GetChild(i).localPosition = rotation[pos][i];
        }
    }

    //Para optener los patrones de rotacion correspondientes a cada tipo de pieza.
    public void getRotByType(string type)
    {
        if (type.Contains("I"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (3,0,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (2,1,0),
                new Vector3 (2,0,0),
                new Vector3 (2,-1,0),
                new Vector3 (2,-2,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type.Contains("T"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (2, 0, 0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type.Contains("L"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (0,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, -1, 0),
                new Vector3 (2, -1, 0),
                new Vector3 (2,0,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type.Contains("L2"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (2,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (1,1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, -1, 0),
                new Vector3 (2,1,0)
            };
            Vector3[] rot180 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, -1, 0),
                new Vector3 (2, -1, 0),
                new Vector3 (0,0,0)
            };
            Vector3[] rot270 = new Vector3[] {
                new Vector3 (0,-1,0),
                new Vector3 (1, 0, 0),
                new Vector3 (1, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot180, rot270 };
        }
        else if (type.Contains("Z1"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (1,0,0),
                new Vector3 (2,0,0),
                new Vector3 (0,-1,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (0,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (0, 1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type.Contains("Z2"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3 (1,0,0),
                new Vector3 (0,0,0),
                new Vector3 (2,-1,0),
                new Vector3 (1,-1,0)
            };
            Vector3[] rot90 = new Vector3[] {
                new Vector3 (2,0,0),
                new Vector3 (1, 0, 0),
                new Vector3 (2,1, 0),
                new Vector3 (1,-1,0)
            };
            rotation = new Vector3[][] { rot0, rot90, rot0, rot90 };
        }
        else if (type.Contains("O"))
        {
            Vector3[] rot0 = new Vector3[] {
                new Vector3(0,0,0),
                new Vector3(1,0,0),
                new Vector3(1,1,0),
                new Vector3(0,1,0)
            };
            rotation = new Vector3[][] { rot0, rot0, rot0, rot0 };
        }
    }
}