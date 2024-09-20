using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�ʐ����t���L���[
/// </summary>
/// <typeparam name="T">�f�[�^�^</typeparam>
public class CapacityQueue<T> : IEnumerable<T>
{
    /// <summary>
    /// �L���[
    /// </summary>
    private Queue<T> queue;

    /// <summary>
    /// �e��
    /// </summary>
    private int capacity;

    /// <summary>
    /// �J�E���g
    /// </summary>
    public int Count => queue.Count;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="queueCapacity">�e��</param>
    public CapacityQueue(int queueCapacity)
    {
        capacity = queueCapacity;

        queue = new Queue<T>(capacity);
    }

    /// <summary>
    /// �����
    /// </summary>
    /// <param name="item">���͒l</param>
    public void Enqueue(T item)
    {
        queue.Enqueue(item);

        // �e�ʂ��I�[�o�[���Ă�������o��
        if(Count > capacity)
        {
            Dequeue();
        }
    }

    /// <summary>
    /// ���o��
    /// </summary>
    /// <returns>�o�͒l</returns>
    public T Dequeue() => queue.Dequeue();

    public IEnumerator<T> GetEnumerator() => queue.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => queue.GetEnumerator();
}
