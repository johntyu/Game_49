using UnityEngine;
using System.Collections;

public class MiniMapViewPlaneMaker : MonoBehaviour {

	private ProjectCameraViewToMiniMap cameraPoints;
	Vector2[] vertices2D;

	void Start () {
		cameraPoints = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ProjectCameraViewToMiniMap>();
	}

	void Update(){
		vertices2D = cameraPoints.ReturnPoints();
		CreatePolygon();
	}
	
	void CreatePolygon(){
		
		// Use the triangulator to get indices for creating triangles
		Triangulator tr = new Triangulator(vertices2D);
		int[] indices = tr.Triangulate();
		
		// Create the Vector3 vertices
		Vector3[] vertices = new Vector3[vertices2D.Length];
		for (int i=0; i<vertices.Length; i++) {
			vertices[i] = new Vector3(vertices2D[i].x, 0.0f, vertices2D[i].y);
		}
		
		// Create the mesh
		Mesh msh = new Mesh();
		msh.vertices = vertices;
		msh.triangles = indices;
		msh.RecalculateNormals();
		msh.RecalculateBounds();

		// Set up game object with mesh;
		MeshFilter filter = gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;
		filter.mesh = msh;
		
	}
}