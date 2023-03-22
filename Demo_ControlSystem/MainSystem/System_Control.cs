using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ControlSystem.MainSystem
{
    /// <summary>
    /// 宣告委派
    /// </summary>
    /// <param name="Level"></param>
    delegate void SYSChangePermission(string _state);
    delegate void SYSChangeModel(string _state);
    delegate void SYSChangeControl(string _state);


    class System_Control
    {
        #region 實作物件
        internal System_List SYSLIST = new System_List();
        internal Permissions PERMISS = new Permissions();
        #endregion

        #region 事件宣告
        /// <summary>
        /// 當權限等級切換時觸發(委派)
        /// </summary>
        public event SYSChangePermission SYSOnSysLevelChanging;
        public event SYSChangeModel SYSOnSysModelChanging;
        public event SYSChangeControl SYSOnSysControlChanging;
        #endregion

        #region 狀態更新欄位
        /// <summary>
        /// 權限等級欄位(R)
        /// </summary>
        private string _levelState = "***"; //對內訊號
        public string LevelState 
        {
            get { return _levelState; }
            private set { _levelState = value; SYSOnSysLevelChanging(_levelState); } 
        }

        /// <summary>
        /// 控制狀態欄位(R/W)
        /// </summary>
        private string _sYSState = "***"; //對內訊號
        public string SYSState
        {
            get { return _sYSState; }
            set { _sYSState = value; SYSOnSysModelChanging(_sYSState); }
        }

        /// <summary>
        /// 自動模式(啟動/停止)欄位(R/W)
        /// </summary>
        private string _sYSControlState = "***"; //對內訊號
        public string SYSControState
        {
            get { return _sYSControlState; }
            set { _sYSControlState = value; SYSOnSysControlChanging(_sYSControlState); }
        }
        #endregion

        /// <summary>
        /// 建構子
        /// </summary>
        public System_Control()
        {
            ISystem_EventLoad();
            IPermission_EventLoad();
        }

        #region Event 管理(匯入)

        /// <summary>
        /// 控制系統 Event
        /// </summary>
        public void ISystem_EventLoad()
        {
            SYSLIST.OnSysModelChanging += ChangeSysModelState;
            SYSLIST.OnSysControlChanging += ChangeSysControlState;
            //委派方法
            //thr_control.L_GrabRobot.OnChangeLoopStep += ChangeGLoopStep;
            
        }

        /// <summary>
        /// 權限 Event
        /// </summary>
        public void IPermission_EventLoad()
        {
            PERMISS.OnSysLevelChanging += ChangePermissionLevel;
            //委派方法
            //PERMISS.Permission_Level = PermissionList.Level_0_Guest;
        }

        #endregion

        #region 相關Event觸發(方法)

        /// <summary>
        /// 當系統狀態改變事件觸發
        /// </summary>
        /// <param name="State"></param>
        public void ChangeSysModelState(SysModel State)
        {
            //label2.Text = "SysModel : " + State.ToString();
            CheckSysModel(State);

        }
        /// <summary>
        /// 當系統控制狀態改變事件觸發
        /// </summary>
        /// <param name="State"></param>
        private void ChangeSysControlState(SysControl State)
        {

            CheckSysControl(State);

        }
        /// <summary>
        /// 當系統層級改變事件觸發
        /// </summary>
        /// <param name="Level"></param>
        private void ChangePermissionLevel(PermissionList Level)
        {
            /*
            if (Level == PermissionList.Level_0_Guest) { _levelState = "Guest"; }
            if (Level == PermissionList.Level_1_Operator) { _levelState = "Operator"; }
            if (Level == PermissionList.Level_2_Engineer) { _levelState = "Engineer"; }
            if (Level == PermissionList.Level_3_SeniorEngineer) { _levelState = "SeniorEngineer"; }
            if (Level == PermissionList.Level_10_Designer) { _levelState = "Designer"; }
            */
            
            if (Level == PermissionList.Level_0_Guest) { LevelState = "Guest"; }
            if (Level == PermissionList.Level_1_Operator) { LevelState = "Operator"; }
            if (Level == PermissionList.Level_2_Engineer) { LevelState = "Engineer"; }
            if (Level == PermissionList.Level_3_SeniorEngineer) { LevelState = "SeniorEngineer"; }
            if (Level == PermissionList.Level_10_Designer) { LevelState = "Designer"; }
            

            //SYSOnSysLevelChanging();

            //label9.Text = "Permission : " + _num;
            CheckPermission(Level);

        }

        #endregion


        #region 系統狀態執行辦法
        /// <summary>
        /// 確認目前系統模式並處理之
        /// </summary>
        /// <param name="State"></param>
        private void CheckSysModel(SysModel State)
        {
            switch (State)
            {
                case SysModel.System_PowerOn:
                    SysPowerOn();
                    break;

                case SysModel.Initial_Run:
                    SysInitial();
                    break;

                case SysModel.Manual:
                    SysManual();
                    break;

                case SysModel.Prepare_Run:
                    SysPrepare();
                    break;

                case SysModel.Auto:
                    SysAuto();
                    break;

                case SysModel.AtoM_Run:
                    SysAutoToManual();
                    break;

            }
        }

        /// <summary>
        /// 確認目前系統模式並處理之
        /// </summary>
        /// <param name="State"></param>
        private void CheckSysControl(SysControl State)
        {
            switch (State)
            {
                case SysControl.Auto_Start:
                    autoLoopStart();
                    break;

                case SysControl.Auto_Stop:
                    autoLoopStop();
                    break;

            }
        }

        /// <summary>
        /// 確認目前權限並處理之
        /// </summary>
        /// <param name="State"></param>
        private void CheckPermission(PermissionList Level)
        {
            switch (Level)
            {
                case PermissionList.Level_0_Guest:


                    break;

                case PermissionList.Level_1_Operator:


                    break;

                case PermissionList.Level_2_Engineer:


                    break;

                case PermissionList.Level_3_SeniorEngineer:


                    break;

                case PermissionList.Level_10_Designer:


                    break;
            }
        }

        #endregion

        #region 系統控制方法巨集

        /// <summary>
        /// 系統狀態執行方法(PowerOn)
        /// </summary>
        private void SysPowerOn()
        {

        }
        /// <summary>
        /// 系統狀態執行方法(Initial)
        /// </summary>
        private void SysInitial()
        {

        }
        /// <summary>
        /// 系統狀態執行方法(Prepare)
        /// </summary>
        private void SysPrepare()
        {

        }
        /// <summary>
        /// 系統狀態執行方法(AutoToManual)
        /// </summary>
        private void SysAutoToManual()
        {

        }
        /// <summary>
        /// 系統狀態執行方法(Manual)
        /// </summary>
        private void SysManual()
        {
            /*
            btn_Auto.Enabled = true;
            btn_Manual.Enabled = false;
            btn_Start.Enabled = false;
            btn_Start.BackColor = Color.DarkGreen;
            btn_Stop.Enabled = false;
            btn_Stop.BackColor = Color.DarkRed;
            thr_control.End_thread();
            */
        }

        /// <summary>
        /// 系統狀態執行方法(Auto)
        /// </summary>
        private void SysAuto()
        {
            /*
            btn_Auto.Enabled = false;
            btn_Manual.Enabled = true;
            btn_Start.Enabled = true;
            btn_Start.BackColor = Color.LimeGreen;
            btn_Stop.Enabled = false;
            btn_Stop.BackColor = Color.DarkRed;
            thr_control.Run_thread();
            */
        }

        /// <summary>
        /// 自動流程啟動
        /// </summary>
        private void autoLoopStart()
        {
            /*
            thr_control.L_GrabRobot.GR_loopStop = false;
            thr_control.L_PushRobot.PR_loopStop = false;
            thr_control.L_Other.Other_loopStop = false; ;
            */
        }

        /// <summary>
        /// 自動流程暫停
        /// </summary>
        private void autoLoopStop()
        {
            /*
            thr_control.L_GrabRobot.GR_loopStop = true;
            thr_control.L_PushRobot.PR_loopStop = true;
            thr_control.L_Other.Other_loopStop = true;
            */
        }


        #endregion






    }
}
