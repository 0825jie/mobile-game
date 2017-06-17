﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTool : MonoBehaviour {  

	private static LineRenderer GetLineRenderer(Transform t)  
	{  
		LineRenderer lr = t.GetComponent<LineRenderer>();  
		if (lr == null)  
		{  
			lr = t.gameObject.AddComponent<LineRenderer>();  
		}  
		lr.SetWidth(0.1f, 0.1f);  
		return lr;  
	}  

	public static void DrawLine(Transform t, Vector3 start, Vector3 end)  
	{  
		LineRenderer lr = GetLineRenderer(t);  
		lr.SetVertexCount(2);  
		lr.SetPosition(0, start);  
		lr.SetPosition(1, end);  
	}  

	//绘制空心扇形    
	public static void DrawSector(Transform t, Vector3 center, float angle, float radius)  
	{  
		LineRenderer lr = GetLineRenderer(t);  
		int pointAmount = 100;//点的数目，值越大曲线越平滑    
		float eachAngle = angle / pointAmount;  
		Vector3 forward = t.forward;  

		lr.SetVertexCount(pointAmount);  
		lr.SetPosition(0, center);  
		lr.SetPosition(pointAmount - 1, center);  

		for (int i = 1; i < pointAmount - 1; i++)  
		{  
			Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;  
			lr.SetPosition(i, pos);  
		}  
	}  

	//绘制空心圆    
	public static void DrawCircle(Transform t, Vector3 center, float radius)  
	{  
		LineRenderer lr = GetLineRenderer(t);  
		int pointAmount = 100;//点的数目，值越大曲线越平滑    
		float eachAngle = 360f / pointAmount;  
		Vector3 forward = t.forward;  

		lr.SetVertexCount(pointAmount + 1);  

		for (int i = 0; i <= pointAmount; i++)  
		{  
			Vector3 pos = Quaternion.Euler(0f, eachAngle * i, 0f) * forward * radius + center;  
			lr.SetPosition(i, pos);  
		}  
	}  

	//绘制空心长方形  
	//以长方形的底边中点为攻击方位置(从俯视角度来看)  
	public static void DrawRectangle(Transform t, Vector3 bottomMiddle, float length, float width)  
	{  
		LineRenderer lr = GetLineRenderer(t);  
		lr.SetVertexCount(5);  

		lr.SetPosition(0, bottomMiddle - t.right * (width / 2));  
		lr.SetPosition(1, bottomMiddle - t.right * (width / 2) + t.forward * length);  
		lr.SetPosition(2, bottomMiddle + t.right * (width / 2) + t.forward * length);  
		lr.SetPosition(3, bottomMiddle + t.right * (width / 2));  
		lr.SetPosition(4, bottomMiddle - t.right * (width / 2));  
	}  

	//绘制空心长方形2D  
	//distance指的是这个长方形与Transform t的中心点的距离  
//	public static void DrawRectangle2D(Transform t, float distance, float length, float width)  
//	{  
//		LineRenderer lr = GetLineRenderer(t);  
//		lr.SetVertexCount(5);  
//
//		if (MathTool.IsFacingRight(t))  
//		{  
//			Vector2 forwardMiddle = new Vector2(t.position.x + distance, t.position.y);  
//			lr.SetPosition(0, forwardMiddle + new Vector2(0, width / 2));  
//			lr.SetPosition(1, forwardMiddle + new Vector2(length, width / 2));  
//			lr.SetPosition(2, forwardMiddle + new Vector2(length, -width / 2));  
//			lr.SetPosition(3, forwardMiddle + new Vector2(0, -width / 2));  
//			lr.SetPosition(4, forwardMiddle + new Vector2(0, width / 2));  
//		}  
//		else  
//		{  
//			Vector2 forwardMiddle = new Vector2(t.position.x - distance, t.position.y);  
//			lr.SetPosition(0, forwardMiddle + new Vector2(0, width / 2));  
//			lr.SetPosition(1, forwardMiddle + new Vector2(-length, width / 2));  
//			lr.SetPosition(2, forwardMiddle + new Vector2(-length, -width / 2));  
//			lr.SetPosition(3, forwardMiddle + new Vector2(0, -width / 2));  
//			lr.SetPosition(4, forwardMiddle + new Vector2(0, width / 2));  
//		}  
//	}  


	public static GameObject go;  
	public static MeshFilter mf;  
	public static MeshRenderer mr;  
	public static Shader shader;  
	private static GameObject CreateMesh(List<Vector3> vertices)  
	{  
		int[] triangles;  
		Mesh mesh = new Mesh();  

		int triangleAmount = vertices.Count - 2;  
		triangles = new int[3 * triangleAmount];  

		//根据三角形的个数，来计算绘制三角形的顶点顺序（索引）      
		//顺序必须为顺时针或者逆时针      
		for (int i = 0; i < triangleAmount; i++)  
		{  
			triangles[3 * i] = 0;//固定第一个点      
			triangles[3 * i + 1] = i + 1;  
			triangles[3 * i + 2] = i + 2;  
		}  

		if (go == null)  
		{  
			go = new GameObject("mesh");  
			go.transform.position = new Vector3(0, 0.1f, 0);//让绘制的图形上升一点，防止被地面遮挡  
			mf = go.AddComponent<MeshFilter>();  
			mr = go.AddComponent<MeshRenderer>();  
			shader = Shader.Find("Unlit/Color");  
		}  

		mesh.vertices = vertices.ToArray();  
		mesh.triangles = triangles;  

		mf.mesh = mesh;  
		mr.material.shader = shader;  
		mr.material.color = Color.red;  

		return go;  
	}  

	//绘制实心扇形    
	public static void DrawSectorSolid(Transform t, Vector3 center, float angle, float radius)  
	{  
		int pointAmount = 100;//点的数目，值越大曲线越平滑    
		float eachAngle = angle / pointAmount;  
		Vector3 forward = t.forward;  

		List<Vector3> vertices = new List<Vector3>();  
		vertices.Add(center);  

		for (int i = 1; i < pointAmount - 1; i++)  
		{  
			Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;  
			vertices.Add(pos);  
		}  

		CreateMesh(vertices);  
	}  

	//绘制实心圆    
	public static void DrawCircleSolid(Transform t, Vector3 center, float radius)  
	{  
		int pointAmount = 100;//点的数目，值越大曲线越平滑    
		float eachAngle = 360f / pointAmount;  
		Vector3 forward = t.forward;  

		List<Vector3> vertices = new List<Vector3>();  

		for (int i = 0; i <= pointAmount; i++)  
		{  
			Vector3 pos = Quaternion.Euler(0f, eachAngle * i, 0f) * forward * radius + center;  
			vertices.Add(pos);  
		}  

		CreateMesh(vertices);  
	}  

	//绘制实心长方形  
	//以长方形的底边中点为攻击方位置(从俯视角度来看)  
	public static void DrawRectangleSolid(Transform t, Vector3 bottomMiddle, float length, float width)  
	{  
		List<Vector3> vertices = new List<Vector3>();  

		vertices.Add(bottomMiddle - t.right * (width / 2));  
		vertices.Add(bottomMiddle - t.right * (width / 2) + t.forward * length);  
		vertices.Add(bottomMiddle + t.right * (width / 2) + t.forward * length);  
		vertices.Add(bottomMiddle + t.right * (width / 2));  

		CreateMesh(vertices);  
	}  

	//绘制实心长方形2D  
	//distance指的是这个长方形与Transform t的中心点的距离  
//	public static void DrawRectangleSolid2D(Transform t, float distance, float length, float width)  
//	{  
//		List<Vector3> vertices = new List<Vector3>();  
//
//		if (MathTool.IsFacingRight(t))  
//		{  
//			Vector3 forwardMiddle = new Vector3(t.position.x + distance, t.position.y);  
//			vertices.Add(forwardMiddle + new Vector3(0, width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(length, width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(length, -width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(0, -width / 2));  
//		}  
//		else  
//		{  
//			//看不到颜色但点击mesh可以看到形状  
//			Vector3 forwardMiddle = new Vector3(t.position.x - distance, t.position.y);  
//			vertices.Add(forwardMiddle + new Vector3(0, width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(-length, width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(-length, -width / 2));  
//			vertices.Add(forwardMiddle + new Vector3(0, -width / 2));  
//		}  
//
//		CreateMesh(vertices);  
//	}  
//
}  