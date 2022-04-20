using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utils;

public class FieldOfView : MonoBehaviour
{

    public int raycount;
    public float fov;
    public float ViewDistance;

    private float startingAngle = 0f;
    private Vector3 origin;
    private Mesh mesh;
    public LayerMask touchLayer;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        mesh.name = "FieldOfView1";

        GetComponent<MeshFilter>().mesh = mesh;

        origin = Vector3.zero;
        float angle = fov / 2;
        float angleIncrease = fov / raycount;

        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= raycount; i++)
        {
            Vector3 vertex = origin + UtilsMath.AngleToVector(angle) * ViewDistance; ;
            //TODO 
            /*RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsMath.AngleToVector(angle), ViewDistance);
            if(raycastHit2D.collider == null)
            {
                vertex = origin + UtilsMath.AngleToVector(angle) * ViewDistance;
            }
            else
            {
                vertex = raycastHit2D.point.normalized;
            }*/
            vertices[vertexIndex] = vertex;

            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        /*
        raycount = raycount == 0 ? 10 : raycount;
        fov = fov == 0f ? 90f : fov;
        ViewDistance = ViewDistance == 0f ? 10f : ViewDistance;*/
    }
    
    /*void LateUpdate()
    {
        
        mesh.Clear();

        float angle = startingAngle;
        float angleIncrease = fov / raycount;

        Vector3[] vertices = new Vector3[raycount + 1 + 1]; // number of ray + the origin + right zero
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;

        int verticeIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycast = Physics2D.Raycast(origin, UtilsMath.AngleToVector(angle), ViewDistance);
            if (raycast.collider == null)
            {
                // No hit
                vertex = origin + UtilsMath.AngleToVector(angle) * ViewDistance;
            }
            else
            {
                // Hit object
                vertex = raycast.point; 
            }
            vertices[verticeIndex] = vertex;

            if(i > 0){ 
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = verticeIndex - 1;
                triangles[triangleIndex + 2] = verticeIndex;
                triangleIndex += 3;
            }

            verticeIndex++;
            angle -= angleIncrease;
        }

        mesh.SetVertices(vertices);
        mesh.SetUVs(0,uv);
        mesh.SetTriangles(triangles, 0);
        

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }*/

    public void SetDirection(float direction)
    {
        startingAngle = direction + (fov / 2f);
    }

    public void SetOrigin(Vector3 position)
    {
        this.origin = position;
    }
}
