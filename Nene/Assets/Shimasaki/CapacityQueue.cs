using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 容量制限付きキュー
/// </summary>
/// <typeparam name="T">データ型</typeparam>
public class CapacityQueue<T> : IEnumerable<T>
{
    /// <summary>
    /// キュー
    /// </summary>
    private Queue<T> queue;

    /// <summary>
    /// 容量
    /// </summary>
    private int capacity;

    /// <summary>
    /// カウント
    /// </summary>
    public int Count => queue.Count;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="queueCapacity">容量</param>
    public CapacityQueue(int queueCapacity)
    {
        capacity = queueCapacity;

        queue = new Queue<T>(capacity);
    }

    /// <summary>
    /// 入れる
    /// </summary>
    /// <param name="item">入力値</param>
    public void Enqueue(T item)
    {
        queue.Enqueue(item);

        // 容量をオーバーしていたら取り出し
        if(Count > capacity)
        {
            Dequeue();
        }
    }

    /// <summary>
    /// 取り出し
    /// </summary>
    /// <returns>出力値</returns>
    public T Dequeue() => queue.Dequeue();

    public IEnumerator<T> GetEnumerator() => queue.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => queue.GetEnumerator();
}
