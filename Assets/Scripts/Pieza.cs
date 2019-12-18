using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pieza : MonoBehaviour {

    ControladorNivel c;
    bool podemosMover = true;
    Rotacion rotador;


    IEnumerator Start ()
    {
        c = ControladorNivel.controlador;
        rotador = new Rotacion();
        rotador.getRotByType(name);

        bool salir = false;

        while (!salir)
        {
            transform.position += Vector3.down;

            if (nosPodemosMover())
            {
                actualizarTablero();
            }
            else
            {


                transform.position -= Vector3.down;
                podemosMover = false;

                if (isGameOver())
                {
                    c.terminamosPartida();
                    salir = true;
                }
                else
                { 
                    c.generadorPiezas.instanciar();
                    c.comprobamosFilas();
                    //c.comprobamosFilas();
                }


                break;//La pieza deja de moverse.
            }

            yield return new WaitForSeconds(0.7f);
        }
            
    }
	
	// Update is called once per frame
	void Update () {

        if (!podemosMover)
            return;

        //Movimiento
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            moverAux(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            moverAux(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            moverAux(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            moverAux(Vector3.back);

        //Moviento Especial de mover la pieza hasta abajo
        if (Input.GetKeyDown(KeyCode.Space))
            movimientoEspecial();

        //Rotacion
        if (Input.GetKeyDown(KeyCode.W))
        {
            rotador.rotateLeft(transform);
            if (nosPodemosMover())
                actualizarTablero();
            else
            {
                rotador.rotateRight(transform);

            }
        }

        /*
       if (Input.GetKeyDown(KeyCode.E))
        {
            if( (transform.eulerAngles.y >= 0) )
            {
                rotarAux(new Vector3(0, -90, 0));
            }
            else
            {
                rotarAux(new Vector3(0, 90, 0));
            }

        }
        */


    }

    private void movimientoEspecial()
    {
        transform.position += Vector3.down;
        if (nosPodemosMover())
        {
            actualizarTablero();
            movimientoEspecial();
        }
        else
        {
            transform.position -= Vector3.down;
            return;
        }
    }


    private void moverAux(Vector3 v)
    {
        transform.position += v;
        if (nosPodemosMover())
            actualizarTablero();
        else
            transform.position -= v;
    }

    private void rotarAux(Vector3 v)
    {
        transform.Rotate(v);
        if (nosPodemosMover())
            actualizarTablero();
        else
            transform.Rotate(-v);
    }

    //Comprueba que todas las cubos de la pieza esten dentro del tablero del juego.
    bool todoDentro()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            Vector3 t = transform.GetChild(i).position;
            Vector3Int p = new Vector3Int(t);

            if (!c.isDentroTablero(p))
                return false;
        }
        return true;
    }

    bool isGameOver()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 t = transform.GetChild(i).position;
            Vector3Int p = new Vector3Int(t);

            if (c.isFueraPorArriba(p))
                return true;
        }
        return false;
    }

    bool nosPodemosMover()
    {
        if (!todoDentro())
        {
            return false;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 t = transform.GetChild(i).position;
            Vector3Int v = new Vector3Int(t);
            if (c.tablero[v.x, v.y, v.z] != null &&
                // Para comprobar si ese bloque pertenece a la misma pieza que se va a mover
                c.tablero[v.x, v.y, v.z].parent != transform)
                return false;    
        }

        return true;
    }

    void actualizarTablero()
    {
        for (int i = 0; i < c.tamanoTablero.x; i++)
        {
            for (int j = 0; j < c.tamanoTablero.y; j++)
            {
                for (int k = 0; k < c.tamanoTablero.z; k++)
                {
                    if (c.tablero[i, j, k] != null &&
                        c.tablero[i, j, k].parent == transform)

                        c.tablero[i, j, k] = null;
                }
            }
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform t = transform.GetChild(i);
            Vector3Int v = new Vector3Int(t.position);
            c.tablero[v.x, v.y, v.z] = t;
        }
    }





}
