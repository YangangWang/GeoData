namespace testwinform
{
    internal class WellBaseTreeColumn
    {
        public string ColWID { get; private set; }
        public string ColBZJH { get; private set; }
        public string ColHZJH { get; private set; }
        public string ColMQJLB { get; private set; }
        public string ColDYDM { get; private set; }
        public string ColTCRQ { get; private set; }
        public string COlKGZT { get; private set; }

        #region *** Singleton Pattern ***

        private static WellBaseTreeColumn _instance;
        private static readonly object _lock = new object();
        private WellBaseTreeColumn()
        {
            InitColumnNames();
        }

        public static WellBaseTreeColumn Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new WellBaseTreeColumn();

                return _instance;
            }
        }

        #endregion

        private void InitColumnNames()
        {
            ColWID = "WID";
            ColBZJH = "BZJH";
            ColHZJH = "HZJH";
            ColMQJLB = "MQJLB";
            ColDYDM = "DYDM";
            ColTCRQ = "TCRQ";
            COlKGZT = "KGZT";
        }
    }
}
