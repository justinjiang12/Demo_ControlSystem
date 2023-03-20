using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ControlSystem.LoopControl
{
    public delegate void LOOPSTEP_DO(ushort num, bool state);

    public abstract class LoopStep
    {
        #region 委派專用欄位
        public event LOOPSTEP_DO e_Signal_output_1;
        #endregion

        #region 外部實作欄位

        //步序數據
        public int Other_step { get { return _step; } set { _step = value; } } //對外訊號(R/W)
        protected int _step = 0; //對內訊號
        //步序速度
        public int Other_loopSpeed { get { return _loopSpeed; } set { _loopSpeed = value; } }//對外訊號(R/W)
        protected int _loopSpeed = 100; //對內訊號
        //步序停止訊號
        public bool Other_loopStop { get { return _loopStop; } set { _loopStop = value; } }//對外訊號(R/W)
        protected bool _loopStop; //對內訊號
        //步序數據狀態
        public string Other_StepNum { get { return _StepNum; } set { _StepNum = value; } }//對外訊號(R)
        protected string _StepNum = "0"; //對內訊號

        #endregion


        #region 內部(for Other Loop)交握欄位
        public bool _signal_Output_1 { get { return Output_1; } private set { Output_1 = value; } }//訊號(R)
        protected bool Output_1 = false; //訊號
        public bool _signal_Output_2 { get { return Output_2; } private set { Output_2 = value; } }//訊號(R)
        protected bool Output_2 = false; //訊號
        public bool _signal_Output_3 { get { return Output_3; } private set { Output_3 = value; } }//訊號(R)
        protected bool Output_3 = false; //訊號
        public bool _signal_Output_4 { get { return Output_4; } private set { Output_4 = value; } }//訊號(R)
        protected bool Output_4 = false; //訊號
        public bool _signal_Output_5 { get { return Output_5; } private set { Output_5 = value; } }//訊號(R)
        protected bool Output_5 = false; //訊號

        public bool _signal_Input_1 { get { return Input_1; } set { Input_1 = value; } }//訊號(W/R)
        protected bool Input_1 = false; //訊號
        public bool _signal_Input_2 { get { return Input_2; } set { Input_2 = value; } }//訊號(W/R)
        protected bool Input_2 = false; //訊號
        public bool _signal_Input_3 { get { return Input_3; } set { Input_3 = value; } }//訊號(W/R)
        protected bool Input_3 = false; //訊號
        public bool _signal_Input_4 { get { return Input_4; } set { Input_4 = value; } }//訊號(W/R)
        protected bool Input_4 = false; //訊號
        public bool _signal_Input_5 { get { return Input_5; } set { Input_5 = value; } }//訊號(W/R)
        protected bool Input_5 = false; //訊號


        #endregion

        /// <summary>
        /// 類別執行緒主要控制
        /// </summary>
        public void LoopRun()
        {
            //基本參數初始化
            _loopStop = true; //步序暫停(關閉)
            _step = 0; //步序歸零
            //迴圈內部執行步序方法
            while (true)
            {
                LoopCase();  //步序內容              
            }
        }

        /// <summary>
        /// 步序方法
        /// </summary>
        public abstract void LoopCase();

        /// <summary>
        /// 訊號初始化
        /// </summary>
        public void ResetData()
        {
            Other_StepNum = "0";
        }
    }
}
