using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OGT.DataLoader.Entity;
using OGT.Entity;
using System.Windows.Forms;
using OGT.Common.WPF.Controls.DbLoginControl.Model;
using OGT.DDLHelper;
using OGT.LogCurveProcess.Correction;
using OGT.LogCurveProcess.Histogram.Model;
using OGT.LogCurveProcess.Correction.Model;

namespace OGT.GeoDataFactory.DataProcessControl
{
    public class SaveData
    {
        //保存小层匹配数据
        public void SaveReseroirData(DataTable dataTable, DateTime dataBaseTime)
        {
            OGT.Common.WinForm.Utility.ShowLoadingWaitForm("正在保存...");
            List<DZ_XCZHSJ> entities = new List<DZ_XCZHSJ>();

            List<DZ_XCZHSJ> findEntities = new List<DZ_XCZHSJ>();

            DataTable _dt = dataTable;



            //if (findEntities.Count > 0)
            //{
            string messge = "是否更新和保存数据";
            string caption = "用户提示";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(messge, caption, button);
            if (result == DialogResult.Yes)
            {
                if (_dt != null)
                {
                    foreach (DataRow dr in _dt.Rows)
                    {
                        DZ_XCZHSJ entity = new DZ_XCZHSJ();

                        string whereStr = string.Format("XCID={0}", Convert.ToInt32(dr["XCID"]));

                        DZ_XCZHSJ findEntiry1 = new DZ_XCZHSJ();
                        if (findEntiry1.IsAttached())
                            findEntiry1.Detach();

                        DZ_XCZHSJ findEntity = EntityHelper.FindEntity<DZ_XCZHSJ>(whereStr);
                        if (findEntity != null)
                        {
                            findEntity.WIDID = Convert.ToInt32(dr["WID"]);
                            findEntity.XCIDID = Convert.ToInt32(dr["XCID"]);
                            if (dr["YXHD"].ToString() != "")

                                findEntity.YXHD = Convert.ToDecimal(dr["YXHD"]);
                            if (dr["YXHD1"].ToString() != "")
                                findEntity.YXHD1 = Convert.ToDecimal(dr["YXHD1"]);
                            if (dr["KXD"].ToString() != "")
                                findEntity.KXD = Convert.ToDecimal(dr["KXD"]);
                            if (dr["STL"].ToString() != "")
                                findEntity.STL = Convert.ToDecimal(dr["STL"]);
                            if (dr["BHD"].ToString() != "")
                                findEntity.BHD = Convert.ToDecimal(dr["BHD"]);
                            if (dr["NZHL"].ToString() != "")
                                findEntity.NZHL = Convert.ToDecimal(dr["NZHL"]);

                            findEntity.JSJL = Convert.ToString(dr["JSJL"]);
                            findEntity.YX = Convert.ToString(dr["YX"]);
                            findEntity.CJX = Convert.ToString(dr["CJX"]);
                            findEntity.BZ = Convert.ToString(dr["BZ"]);
                            findEntity.XGRQ = dataBaseTime;
                            findEntity.FAMC = Convert.ToString(dr["FCFAMC"]);

                            findEntities.Add(findEntity);

                        }
                        else
                        {
                            entity.WIDID = Convert.ToInt32(dr["WID"]);
                            entity.XCIDID = Convert.ToInt32(dr["XCID"]);
                            if (dr["YXHD"].ToString() != "")
                                entity.YXHD = Convert.ToDecimal(dr["YXHD"]);
                            if (dr["YXHD1"].ToString() != "")
                                entity.YXHD1 = Convert.ToDecimal(dr["YXHD1"]);
                            if (dr["KXD"].ToString() != "")
                                entity.KXD = Convert.ToDecimal(dr["KXD"]);
                            if (dr["STL"].ToString() != "")
                                entity.STL = Convert.ToDecimal(dr["STL"]);
                            if (dr["BHD"].ToString() != "")
                                entity.BHD = Convert.ToDecimal(dr["BHD"]);
                            if (dr["NZHL"].ToString() != "")
                                entity.NZHL = Convert.ToDecimal(dr["NZHL"]);


                            entity.JSJL = Convert.ToString(dr["JSJL"]);
                            entity.YX = Convert.ToString(dr["YX"]);
                            entity.CJX = Convert.ToString(dr["CJX"]);
                            entity.BZ = Convert.ToString(dr["BZ"]);
                            entity.XGRQ = dataBaseTime;
                            entity.FAMC = Convert.ToString(dr["FCFAMC"]);
                            entities.Add(entity);

                        }

                    }

                }

                EntityHelper.SaveEntityArray<DZ_XCZHSJ>(findEntities, false);
                EntityHelper.SaveEntityArray<DZ_XCZHSJ>(entities, true);


            }
            //}

            //else
            //{
            //    EntityHelper.SaveEntityArray<DZ_XCZHSJ>(entities, true);
            //    MessageBox.Show("保存成功");

            //}
            OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
        }

        //保存小层劈分数据
        public void SaveSplitterData(DataTable dataTable, DateTime dataBaseTime)
        {
            OGT.Common.WinForm.Utility.ShowLoadingWaitForm("正在保存...");
            List<DZ_XCFCSJ> entities = new List<DZ_XCFCSJ>();
            List<DZ_XCFCSJ> findEntities = new List<DZ_XCFCSJ>();

            DataTable datable = dataTable;

            string messge = "是否保存数据";
            string caption = "用户提示";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(messge, caption, button);
            if (result == DialogResult.Yes)
            {
                foreach (DataRow dr in datable.Rows)
                {
                    string whereStr = string.Format("WID={0} and XCMC='{1}' and XCDS1={2} and XCDS2={3} and FCFAMC='{4}'", Convert.ToInt32(dr["井ID"]), Convert.ToString(dr["小层名称"]), Convert.ToDecimal(dr["顶界深度"]), Convert.ToDecimal(dr["底界深度"]), Convert.ToString(dr["分层方案名称"]));
                    DZ_XCFCSJ entity = new DZ_XCFCSJ();
                    DZ_XCFCSJ findEntity = EntityHelper.FindEntity<DZ_XCFCSJ>(whereStr);
                    if (findEntity == null)
                    {

                        entity.WIDID = Convert.ToInt32(dr["井ID"]);
                        entity.XCMC = Convert.ToString(dr["小层名称"]);
                        entity.XCDS1 = Convert.ToDecimal(dr["顶界深度"]);
                        entity.XCDS2 = Convert.ToDecimal(dr["底界深度"]);
                        entity.FCFAMC = Convert.ToString(dr["分层方案名称"]);
                        entity.XGRQ = dataBaseTime;
                        entities.Add(entity);
                        //EntityHelper.SaveEntity<DZ_XCFCSJ>(entity);

                    }

                }

                EntityHelper.SaveEntityArray<DZ_XCFCSJ>(entities, true);

            }
            OGT.Common.WinForm.Utility.CloseLoadingWaitForm();
        }

        //保存小层插值数据
        public void SaveInterprotationData(DataTable dataTable)
        {

        }

        public DateTime GetDataBaseTime()
        {
            string timeStr = "select to_char(sysdate, 'yyyy-mm-dd hh24:mi:ss') from dual";
            DataTable timeTable = EntityHelper.FindDataTable(timeStr);
            string time1 = timeTable.Rows[0][0].ToString();
            DateTime time = Convert.ToDateTime(timeTable.Rows[0][0].ToString());
            return time;

        }

    }
}
