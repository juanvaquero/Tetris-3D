using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Vector3Int
{
    public int x, y, z;

    public Vector3Int(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3Int(float x, float y ,float z)
    {
        this.x = Mathf.RoundToInt(x);
        this.y = Mathf.RoundToInt(y);
        this.z = Mathf.RoundToInt(z);
    }

    public Vector3Int(Vector3 v)
    {
        this.x = Mathf.RoundToInt(v.x);
        this.y = Mathf.RoundToInt(v.y);
        this.z = Mathf.RoundToInt(v.z);
    }

    public String toString()
    {
        return "( " + x + " , " + y + " , " + z + " )";
    }

}


public class ControladorNivel : MonoBehaviour {

    public int puntuacion;
    public int puntuacionLinea;
    public int multiplicadorPuntuacion;

    public bool pausar;

    public Instanciador generadorPiezas;
    public static ControladorNivel controlador;
    public Vector3Int tamanoTablero;
    public Transform[,,] tablero;

    public GameObject gameOverUI;


    public void Awake()
    {
        
        if (controlador != null)
            Destroy(gameObject);
        else
            controlador = this;

        tablero = new Transform[tamanoTablero.x, tamanoTablero.y, tamanoTablero.z];


    }


    public bool isFilaCompletaInX(Vector3Int p)
    {
        for(int i = 0; i< tamanoTablero.x; i++)
        {
            if(tablero[i, p.y, p.z] == null)
            {
                return false;
            }
        }

        return true;
    }

    public bool isFilaCompletaInZ(Vector3Int p)
    {

        for (int i = 0; i < tamanoTablero.z; i++)
        {
            if (tablero[p.x, p.y, i] == null)
            {
                return false;
            }
        }

        return true;
    }

    public bool isDentroTablero(Vector3Int p)
    {

        if (p.x >= 0 && p.z >= 0 && p.y >= 0 && p.x < tamanoTablero.x && p.z < tamanoTablero.z && p.y < tamanoTablero.y)
            return true;

        return false;
    }

    public bool isFueraPorArriba(Vector3Int p)
    {
        return p.y >= tamanoTablero.y;
    }


    public void borrarFilaEnX(Vector3Int p)
    {
        for(int i = 0; i < tamanoTablero.x; i++)
        {
          Destroy(tablero[i, p.y, p.z].gameObject);
        }

        bajarFilaEnX(new Vector3Int(p.x, p.y + 1, p.z));
    }

    public void borrarFilaEnZ(Vector3Int p)
    {
        for (int i = 0; i < tamanoTablero.z; i++)
        {
            Destroy(tablero[p.x, p.y, i].gameObject);
        }

        bajarFilaEnZ(new Vector3Int(p.x,p.y+1,p.z));
    }


    public void  bajarFilaEnX(Vector3Int v)
    {
        //TODO se puede mejorar esto en eficiencia, ya que comprueba subiendo hasta el final de arriba del todo.
        if (v.y >= tamanoTablero.y)
        {
           // comprobamosFilas();
            return;
        }

        for (int i = 0; i< tamanoTablero.x; i++)
        {
            if(tablero[i,v.y,v.z] != null)
            {
                //bajamos el cubo en una unidad.
                tablero[i, v.y, v.z].position += Vector3.down;
                //Actualizamos los valores de nuestra estructura.

                tablero[i, v.y - 1, v.z] = tablero[i, v.y, v.z];
                tablero[i, v.y, v.z] = null; 
            }
        }

        bajarFilaEnX(new Vector3Int(v.x, v.y + 1, v.z));
    }

    public void bajarFilaEnZ(Vector3Int v)
    {
        //TODO se puede mejorar esto en eficiencia, ya que comprueba subiendo hasta el final de arriba del todo.
        if (v.y >= tamanoTablero.y)
        {
           // comprobamosFilas();
            return;
        }

        for (int i = 0; i < tamanoTablero.z; i++)
        {
            if (tablero[v.x, v.y, i] != null)
            {
                //bajamos el cubo en una unidad.
                tablero[v.x, v.y, i].position += Vector3.down;
                //Actualizamos los valores de nuestra estructura.
                tablero[v.x, v.y-1, i] = tablero[v.x, v.y, i];
                tablero[v.x, v.y, i] = null;
            }
        }

        bajarFilaEnZ(new Vector3Int(v.x, v.y + 1, v.z));
    }

    //TODO creo que puedo hacerlo mas eficiente.
    public void comprobamosFilas()
    {
        for(int i = 0; i <tamanoTablero.y; i++)
        {
            for (int j = 0; j < tamanoTablero.x; j++)
            {
                Vector3Int v1 = new Vector3Int(j,i,0);
                if (isFilaCompletaInZ(v1))
                {
                    borrarFilaEnZ(v1);

                    //Actualizar puntuacion
                    puntuacion += puntuacionLinea * multiplicadorPuntuacion;
                    GetComponent<ControladorUI>().actualizarPuntuacion(puntuacion);
                    //Actualizar multiplicador
                    multiplicadorPuntuacion++;
                    GetComponent<ControladorUI>().actualizarMultiplicador(multiplicadorPuntuacion);
                }
            }

            for (int k = 0; k < tamanoTablero.z; k++)
            {
                Vector3Int v2 = new Vector3Int(0, i, k);
                if (isFilaCompletaInX(v2))
                {
                    borrarFilaEnX(v2);

                    //Actualizar puntuacion
                    puntuacion += puntuacionLinea * multiplicadorPuntuacion;
                    GetComponent<ControladorUI>().actualizarPuntuacion(puntuacion);
                    //Actualizar multiplicador
                    multiplicadorPuntuacion++;
                    GetComponent<ControladorUI>().actualizarMultiplicador(multiplicadorPuntuacion);
                }

            }
        }
    }

    public void terminamosPartida()
    {
        gameOverUI.SetActive(true);
       
    }

}
