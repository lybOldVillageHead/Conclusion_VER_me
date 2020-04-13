using System;

namespace VecAndMtr
{
    public class Matrix4X4
    {
        private float[] elements = new float[16];

        /// <summary>
        /// 构造函数
        /// </summary>
        public Matrix4X4()
        {
            this.Indentity();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">长度16float数组</param>
        public Matrix4X4(float[] data)
        {
            if (data.Length != 16) throw new IndexOutOfRangeException();
            for (int i = 0; i < 16; i++)
            {
                elements[i] = data[i];
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="mtr">矩阵</param>
        public Matrix4X4(Matrix4X4 mtr)
        {
            this.CopyFrom(mtr);
        }

        /// <summary>
        /// 拷贝其他矩阵到本身
        /// </summary>
        /// <param name="mtr"></param>
        public void CopyFrom(Matrix4X4 mtr)
        {
            for (int i = 0; i < 16; i++)
            {
                elements[i] = mtr.elements[i];
            }
        }

        /// <summary>
        /// 拷贝本身到一个矩阵
        /// </summary>
        /// <param name="mtr"></param>
        public void CopyTo(ref Matrix4X4 mtr)
        {
            for (int i = 0; i < 16; i++)
            {
                mtr.elements[i] = elements[i];
            }
        }

        /// <summary>
        ///重置矩阵为单位矩阵
        /// </summary>
        public void Indentity()
        {
            for (int i = 0; i < 16; i++)
            {
                elements[i] = 0.0f;
            }
            elements[0] = 1.0f;
            elements[5] = 1.0f;
            elements[10] = 1.0f;
            elements[15] = 1.0f;
        }

        /// <summary>
        /// 重置矩阵为单位矩阵
        /// </summary>
        /// <param name="mtr"></param>
        public static void Identity(Matrix4X4 mtr)
        {
            mtr.Indentity();
        }

        /// <summary>
        /// 设置一列
        /// </summary>
        /// <param name="colIndex">[0,3]列</param>
        /// <param name="vec">Vector3对象</param>
        public void SetCol(int colIndex, Vector3 vec)
        {
            if (colIndex < 0 || colIndex > 3) throw new IndexOutOfRangeException(); ;
            elements[0 * 4 + colIndex] = vec.x;
            elements[1 * 4 + colIndex] = vec.y;
            elements[2 * 4 + colIndex] = vec.z;
            elements[3 * 4 + colIndex] = vec.w;
        }


        /// <summary>
        ///  获取列装载的 Vector3对象
        /// </summary>
        /// <param name="colIndex">[0,3]列</param>
        /// <returns>Vector3对象</returns>
        public Vector3 GetCol(int colIndex)
        {
            if (colIndex < 0 || colIndex > 3) throw new IndexOutOfRangeException();
            float tx = elements[0 * 4 + colIndex];
            float ty = elements[1 * 4 + colIndex];
            float tz = elements[2 * 4 + colIndex];
            float tw = elements[3 * 4 + colIndex];
            return new Vector3(tx, ty, tz, tw);
        }

        /// <summary>
        ///  设置一行
        /// </summary>
        /// <param name="rowIndex">[0,3]行</param>
        /// <param name="vec">Vector3对象</param>
        public void SetRow(int rowIndex, Vector3 vec)
        {
            if (rowIndex < 0 || rowIndex > 3) throw new IndexOutOfRangeException(); ;
            elements[rowIndex * 4 + 0] = vec.x;
            elements[rowIndex * 4 + 1] = vec.y;
            elements[rowIndex * 4 + 2] = vec.z;
            elements[rowIndex * 4 + 3] = vec.w;
        }


        /// <summary>
        /// 获取行装载的 Vector3对象
        /// </summary>
        /// <param name="rowIndex">[0,3]行</param>
        /// <returns>Vector3对象</returns>
        public Vector3 GetRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex > 3) throw new IndexOutOfRangeException();
            float tx = elements[rowIndex * 4 + 0];
            float ty = elements[rowIndex * 4 + 1];
            float tz = elements[rowIndex * 4 + 2];
            float tw = elements[rowIndex * 4 + 3];
            return new Vector3(tx, ty, tz, tw);
        }


        /// <summary>
        /// 转置
        /// </summary>
        public void Transpose()
        {




        }







    }

}
