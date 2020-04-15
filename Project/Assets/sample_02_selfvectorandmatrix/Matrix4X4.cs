using System;

namespace VecAndMtr
{
    public class Matrix4X4
    {
        #region 常量
        public static int ELEMENT_COUNT = 16;
        #endregion

        #region 成员属性
        private float[] elements = new float[ELEMENT_COUNT];
        public float m11
        {
            get
            {
                return elements[0];
            }
            set
            {
                elements[0] = value;
            }
        }
        public float m12
        {
            get
            {
                return elements[1];
            }
            set
            {
                elements[1] = value;
            }
        }
        public float m13
        {
            get
            {
                return elements[2];
            }
            set
            {
                elements[2] = value;
            }
        }
        public float m14
        {
            get
            {
                return elements[3];
            }
            set
            {
                elements[3] = value;
            }
        }
        public float m21
        {
            get
            {
                return elements[4];
            }
            set
            {
                elements[4] = value;
            }
        }
        public float m22
        {
            get
            {
                return elements[5];
            }
            set
            {
                elements[5] = value;
            }
        }
        public float m23
        {
            get
            {
                return elements[6];
            }
            set
            {
                elements[6] = value;
            }
        }
        public float m24
        {
            get
            {
                return elements[7];
            }
            set
            {
                elements[7] = value;
            }
        }
        public float m31
        {
            get
            {
                return elements[8];
            }
            set
            {
                elements[8] = value;
            }
        }
        public float m32
        {
            get
            {
                return elements[9];
            }
            set
            {
                elements[9] = value;
            }
        }
        public float m33
        {
            get
            {
                return elements[10];
            }
            set
            {
                elements[10] = value;
            }
        }
        public float m34
        {
            get
            {
                return elements[11];
            }
            set
            {
                elements[11] = value;
            }
        }
        public float m41
        {
            get
            {
                return elements[12];
            }
            set
            {
                elements[12] = value;
            }
        }
        public float m42
        {
            get
            {
                return elements[13];
            }
            set
            {
                elements[13] = value;
            }
        }
        public float m43
        {
            get
            {
                return elements[14];
            }
            set
            {
                elements[14] = value;
            }
        }
        public float m44
        {
            get
            {
                return elements[15];
            }
            set
            {
                elements[15] = value;
            }
        }
        #endregion


        #region 构造函数
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
            if (data.Length != ELEMENT_COUNT) throw new IndexOutOfRangeException("构造4*4矩阵需要16个float!");
            for (int i = 0; i < ELEMENT_COUNT; i++)
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
        #endregion


        #region 公共方法
        /// <summary>
        /// 拷贝其他矩阵到本身
        /// </summary>
        /// <param name="mtr"></param>
        public void CopyFrom(Matrix4X4 mtr)
        {
            for (int i = 0; i < ELEMENT_COUNT; i++)
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
            for (int i = 0; i < ELEMENT_COUNT; i++)
            {
                mtr.elements[i] = elements[i];
            }
        }

        /// <summary>
        ///重置矩阵为单位矩阵
        /// </summary>
        public void Indentity()
        {
            for (int i = 0; i < ELEMENT_COUNT; i++)
            {
                elements[i] = 0.0f;
            }
            elements[0] = 1.0f;
            elements[5] = 1.0f;
            elements[10] = 1.0f;
            elements[15] = 1.0f;
        }

        /// <summary>
        /// 转置
        /// </summary>
        public void Transpose()
        {
            //第一行
            float m11 = elements[0];
            float m12 = elements[1];
            float m13 = elements[2];
            float m14 = elements[3];
            //第二行
            float m21 = elements[4];
            float m22 = elements[5];
            float m23 = elements[6];
            float m24 = elements[7];
            //第三行
            float m31 = elements[8];
            float m32 = elements[9];
            float m33 = elements[10];
            float m34 = elements[11];
            //第四行
            float m41 = elements[12];
            float m42 = elements[13];
            float m43 = elements[14];
            float m44 = elements[15];

            //转置第一行
            this.m11 = m11;
            this.m12 = m21;
            this.m13 = m31;
            this.m14 = m41;
            //转置第二行
            this.m21 = m12;
            this.m22 = m22;
            this.m23 = m32;
            this.m24 = m42;
            //转置第三行
            this.m31 = m13;
            this.m32 = m23;
            this.m33 = m33;
            this.m34 = m43;
            //转置第四行
            this.m41 = m14;
            this.m42 = m24;
            this.m43 = m34;
            this.m44 = m44;
        }

        /// <summary>
        /// 设置一列
        /// </summary>
        /// <param name="colIndex">[0,3]列</param>
        /// <param name="vec">Vector3对象</param>
        public void SetCol(int colIndex, Vector3 vec)
        {
            if (colIndex < 0 || colIndex > 3) throw new IndexOutOfRangeException("4*4矩阵注入列，colIndex区间为[0,3]"); ;
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
            if (colIndex < 0 || colIndex > 3) throw new IndexOutOfRangeException("4*4矩阵取得列，colIndex区间为[0,3]"); ;
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
            if (rowIndex < 0 || rowIndex > 3) throw new IndexOutOfRangeException("4*4矩阵取得行，rowIndex区间为[0,3]"); ;
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
            if (rowIndex < 0 || rowIndex > 3) throw new IndexOutOfRangeException("4*4矩阵取得行，rowIndex区间为[0,3]"); ;
            float tx = elements[rowIndex * 4 + 0];
            float ty = elements[rowIndex * 4 + 1];
            float tz = elements[rowIndex * 4 + 2];
            float tw = elements[rowIndex * 4 + 3];
            return new Vector3(tx, ty, tz, tw);
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <returns></returns>
        public Matrix4X4 Mutiply(Matrix4X4 mtr)
        {
            float m11 = this.m11 * mtr.m11 + this.m12 * mtr.m21 + this.m13 * mtr.m31 + this.m14 * mtr.m41;
            float m12 = this.m11 * mtr.m12 + this.m12 * mtr.m22 + this.m13 * mtr.m32 + this.m14 * mtr.m42;
            float m13 = this.m11 * mtr.m13 + this.m12 * mtr.m23 + this.m13 * mtr.m33 + this.m14 * mtr.m43;
            float m14 = this.m11 * mtr.m14 + this.m12 * mtr.m24 + this.m13 * mtr.m34 + this.m14 * mtr.m44;
            //第二行
            float m21 = this.m21 * mtr.m11 + this.m22 * mtr.m21 + this.m23 * mtr.m31 + this.m24 * mtr.m41;
            float m22 = this.m21 * mtr.m12 + this.m22 * mtr.m22 + this.m23 * mtr.m32 + this.m24 * mtr.m42;
            float m23 = this.m21 * mtr.m13 + this.m22 * mtr.m23 + this.m23 * mtr.m33 + this.m24 * mtr.m43;
            float m24 = this.m21 * mtr.m14 + this.m22 * mtr.m24 + this.m23 * mtr.m34 + this.m24 * mtr.m44;
            //第三行
            float m31 = this.m31 * mtr.m11 + this.m32 * mtr.m21 + this.m33 * mtr.m31 + this.m34 * mtr.m41;
            float m32 = this.m31 * mtr.m12 + this.m32 * mtr.m22 + this.m33 * mtr.m32 + this.m34 * mtr.m42;
            float m33 = this.m31 * mtr.m13 + this.m32 * mtr.m23 + this.m33 * mtr.m33 + this.m34 * mtr.m43;
            float m34 = this.m31 * mtr.m14 + this.m32 * mtr.m24 + this.m33 * mtr.m34 + this.m34 * mtr.m44;
            //第四行
            float m41 = this.m41 * mtr.m11 + this.m42 * mtr.m21 + this.m43 * mtr.m31 + this.m44 * mtr.m41;
            float m42 = this.m41 * mtr.m12 + this.m42 * mtr.m22 + this.m43 * mtr.m32 + this.m44 * mtr.m42;
            float m43 = this.m41 * mtr.m13 + this.m42 * mtr.m23 + this.m43 * mtr.m33 + this.m44 * mtr.m43;
            float m44 = this.m41 * mtr.m14 + this.m42 * mtr.m24 + this.m43 * mtr.m34 + this.m44 * mtr.m44;
            //转置第一行
            this.m11 = m11;
            this.m12 = m21;
            this.m13 = m31;
            this.m14 = m41;
            //转置第二行
            this.m21 = m12;
            this.m22 = m22;
            this.m23 = m32;
            this.m24 = m42;
            //转置第三行
            this.m31 = m13;
            this.m32 = m23;
            this.m33 = m33;
            this.m34 = m43;
            //转置第四行
            this.m41 = m14;
            this.m42 = m24;
            this.m43 = m34;
            this.m44 = m44;
            return new Matrix4X4(new float[16] { m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44 });
        }



        #endregion

        #region 静态方法
        /// <summary>
        /// 重置矩阵为单位矩阵
        /// </summary>
        /// <param name="mtr"></param>
        public static void Identity(Matrix4X4 mtr)
        {
            mtr.Indentity();
        }

        /// <summary>
        /// 转置
        /// </summary>
        public static void Transpose(Matrix4X4 mtr)
        {
            //第一行
            float m11 = mtr.elements[0];
            float m12 = mtr.elements[1];
            float m13 = mtr.elements[2];
            float m14 = mtr.elements[3];
            //第二行
            float m21 = mtr.elements[4];
            float m22 = mtr.elements[5];
            float m23 = mtr.elements[6];
            float m24 = mtr.elements[7];
            //第三行
            float m31 = mtr.elements[8];
            float m32 = mtr.elements[9];
            float m33 = mtr.elements[10];
            float m34 = mtr.elements[11];
            //第四行
            float m41 = mtr.elements[12];
            float m42 = mtr.elements[13];
            float m43 = mtr.elements[14];
            float m44 = mtr.elements[15];

            //转置第一行
            mtr.elements[0] = m11;
            mtr.elements[1] = m21;
            mtr.elements[2] = m31;
            mtr.elements[3] = m41;
            //转置第二行
            mtr.elements[4] = m12;
            mtr.elements[5] = m22;
            mtr.elements[6] = m32;
            mtr.elements[7] = m42;
            //转置第三行
            mtr.elements[8] = m13;
            mtr.elements[9] = m23;
            mtr.elements[10] = m33;
            mtr.elements[11] = m43;
            //转置第四行
            mtr.elements[12] = m14;
            mtr.elements[13] = m24;
            mtr.elements[14] = m34;
            mtr.elements[15] = m44;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="a">a矩阵</param>
        /// <param name="b">b矩阵</param>
        /// <returns></returns>
        public static Matrix4X4 Mutiply(Matrix4X4 a, Matrix4X4 b)
        {
            float m11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31 + a.m14 * b.m41;
            float m12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32 + a.m14 * b.m42;
            float m13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33 + a.m14 * b.m43;
            float m14 = a.m11 * b.m14 + a.m12 * b.m24 + a.m13 * b.m34 + a.m14 * b.m44;
            //第二行
            float m21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31 + a.m24 * b.m41;
            float m22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32 + a.m24 * b.m42;
            float m23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33 + a.m24 * b.m43;
            float m24 = a.m21 * b.m14 + a.m22 * b.m24 + a.m23 * b.m34 + a.m24 * b.m44;
            //第三行
            float m31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31 + a.m34 * b.m41;
            float m32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32 + a.m34 * b.m42;
            float m33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33 + a.m34 * b.m43;
            float m34 = a.m31 * b.m14 + a.m32 * b.m24 + a.m33 * b.m34 + a.m34 * b.m44;
            //第四行
            float m41 = a.m41 * b.m11 + a.m42 * b.m21 + a.m43 * b.m31 + a.m44 * b.m41;
            float m42 = a.m41 * b.m12 + a.m42 * b.m22 + a.m43 * b.m32 + a.m44 * b.m42;
            float m43 = a.m41 * b.m13 + a.m42 * b.m23 + a.m43 * b.m33 + a.m44 * b.m43;
            float m44 = a.m41 * b.m14 + a.m42 * b.m24 + a.m43 * b.m34 + a.m44 * b.m44;
            return new Matrix4X4(new float[16] { m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44 });
        }

        /// <summary>
        /// 矩阵乘法运算符重载
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix4X4 operator * (Matrix4X4 a, Matrix4X4 b)
        {
            float m11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31 + a.m14 * b.m41;
            float m12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32 + a.m14 * b.m42;
            float m13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33 + a.m14 * b.m43;
            float m14 = a.m11 * b.m14 + a.m12 * b.m24 + a.m13 * b.m34 + a.m14 * b.m44;
            //第二行
            float m21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31 + a.m24 * b.m41;
            float m22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32 + a.m24 * b.m42;
            float m23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33 + a.m24 * b.m43;
            float m24 = a.m21 * b.m14 + a.m22 * b.m24 + a.m23 * b.m34 + a.m24 * b.m44;
            //第三行
            float m31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31 + a.m34 * b.m41;
            float m32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32 + a.m34 * b.m42;
            float m33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33 + a.m34 * b.m43;
            float m34 = a.m31 * b.m14 + a.m32 * b.m24 + a.m33 * b.m34 + a.m34 * b.m44;
            //第四行
            float m41 = a.m41 * b.m11 + a.m42 * b.m21 + a.m43 * b.m31 + a.m44 * b.m41;
            float m42 = a.m41 * b.m12 + a.m42 * b.m22 + a.m43 * b.m32 + a.m44 * b.m42;
            float m43 = a.m41 * b.m13 + a.m42 * b.m23 + a.m43 * b.m33 + a.m44 * b.m43;
            float m44 = a.m41 * b.m14 + a.m42 * b.m24 + a.m43 * b.m34 + a.m44 * b.m44;
            return new Matrix4X4(new float[16] { m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44 });
        }

        #endregion




    }


}
