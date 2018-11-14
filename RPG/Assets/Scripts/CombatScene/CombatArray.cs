using System.Collections;
using System.Collections.Generic;


public class CombatArray<T>{
	
	public ArrayList array;
	private HeapSort<T> hp;
	private Queue combatqueve; 
	private int count;
	private pair<T> pp;
	public CombatArray(int t)
	{
		count = 0;
		array = new ArrayList();
		hp = new HeapSort<T>();
		combatqueve = new Queue();

		pp = new pair<T>();
	}
	
	public void insert(T obt,int prio)
	{
		pair<T> newPair = new pair<T>(obt, prio);
		array.Add(newPair);

		hp.sort(array);
		
	}
	public T getObjet(int i)
	{
		pair<T> o = (pair<T>) array[i];
		return o.getGo();
	}

	public T getTurn()
	{
		if(combatqueve.Count!=0)
		{
			pair<T> d = (pair<T>)combatqueve.Dequeue();
			return d.getGo();
		}
		else
		{
			return pp.getGo();
		}

	}

	public void createcombatsequece()
	{
		if(combatqueve.Count!=0)
			combatqueve = new Queue();

		combatqueve.Enqueue(array[0]);
		for (int i =0;i<array.Count;i++)
		{
			if(2 * i + 1< array.Count)
			combatqueve.Enqueue(array[2*i+1]);
			if (2 * i + 2 < array.Count )
				combatqueve.Enqueue(array[2 * i + 2]);
		}
	}
}

public class pair<T>
{
	T go;
	int val;
	public pair(T ob, int v)
	{
		this.go = ob;
		this.val = v;
	}
	public pair()
	{
		
		this.val = 0;
	}
	public int getVal()
	{
		return (int) val;
	}
	public T getGo()
	{
		return go;
	}
}
public class HeapSort<T>
{
	public void sort(ArrayList arr)
	{
		int n = arr.Count;

		// Build heap (rearrange array) 
		for (int i = n / 2 - 1; i >= 0; i--)
			heapify(arr, n, i);

		// One by one extract an element from heap 
		for (int i = n - 1; i >= 0; i--)
		{
			// Move current root to end 
			pair<T> temp = (pair<T>) arr[0];
			arr[0] = arr[i];
			arr[i] = temp;

		//	// call max heapify on the reduced heap 
			heapify(arr, i, 0);
		}
	}

	// To heapify a subtree rooted with node i which is 
	// an index in arr[]. n is size of heap 
	void heapify(ArrayList arr, int n, int i)
	{
		int largest = i; // Initialize largest as root 
		int l = 2 * i + 1; // left = 2*i + 1 
		int r = 2 * i + 2; // right = 2*i + 2 

		// If left child is larger than root 
		pair<T> lr = (pair<T>)arr[largest];
		pair<T> rr;
		if (l<arr.Count)
		{
			 rr = (pair<T>)arr[l];
			if (l < n && rr.getVal() < lr.getVal())
				largest = l;
		}
	
	
		if (r < arr.Count)
		{
			 rr = (pair<T>)arr[r];
			if (r < n && rr.getVal() < lr.getVal())
				largest = r;
		}
		// If right child is larger than largest so far 
		

		// If largest is not root 
		if (largest != i)
		{
			pair<T> swap = (pair<T>)arr[i];
			arr[i] = arr[largest];
			arr[largest] = swap;

			// Recursively heapify the affected sub-tree 
			heapify(arr, n, largest);
		}
	}
}

