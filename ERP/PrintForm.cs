using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ERP
{
    public partial class PrintForm : Telerik.WinControls.UI.ShapedForm{
    
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(PrintForm));
        public PrintForm()
        {
            InitializeComponent();
        }
        

        private string replace(string html,Hashtable hs) {
            foreach (DictionaryEntry val in hs)
            {
                var value = val.Value;
                if (value is DateTime) {
                    value = ((DateTime)value).ToShortDateString();
                }
                html = html.Replace("${" + val.Key + "}", Convert.ToString(value));
            }
            return html;
        }

        public int SalesId { get; set; }
        private void PrintForm_Load(object sender, EventArgs e)
        {

            if (SalesId != 0)
            {
                log.Debug("打印"+SalesId);
                var bs = File.ReadAllBytes((AppDomain.CurrentDomain.BaseDirectory + "\\print.html"));
                string html = UTF8Encoding.UTF8.GetString(bs);

                Hashtable hs = new Hashtable();
                DataSet ds = Data.DataUtil.ExecuteDataSet(string.Format(@"SELECT sales.id,
sales.bill_id,
sales.store_id,
sales.user_id,
sales.customer_name,
sales.phone,
sales.address,
sales.remarks,
sales.product_count,
sales.need_pay,
sales.front_pay,
sales.actually_pay,
sales.paymet_method1,
sales.paymet_method2,
sales.status,
sales.create_time,
sales.create_user,
sales.modfied_user,
sales.modfied_time,
sales.delivery_number,
sales.delivery_pay,
sales.delivery_date,
sales.delivery_remarks,store.name as store_name
,users.name as user_name,sales.remarks
FROM sales left join  store on store.id = store_id 
left join users on users.id = user_id
where sales.id = {0};
SELECT product_name,dimensions,color,count,actually_pay,guide_price,discount FROM salesdetail where sales_id = {0} ; 
", SalesId));
                var saleInfo = ds.Tables[0].Rows[0];
                foreach (DataColumn col in saleInfo.Table.Columns) {
                    var val = saleInfo[col];
                    hs.Add(col.ColumnName, val);
                }
                hs.Add("send_date", DateTime.Now);
                string tmphtml = "<tr><td height='26'  colspan='2' class=''>{0}</td><td colspan='2' class=''>{1}</td><td class=''>{2}</td><td class=''>{3}</td><td class=''>{4}</td></tr>";
                StringBuilder sb = new StringBuilder();
                
                decimal sum = 0;
                foreach (DataRow dr in ds.Tables[1].Rows) {
                    object[] val = dr.ItemArray;
                    var actually_pay = (decimal)dr["actually_pay"];
                    val[4] = Convert.ToInt32(actually_pay);
                    sum += actually_pay;
                    sb.Append(string.Format(tmphtml,val));
                }
                hs.Add("rows", sb.ToString());
                
                hs.Add("sum",Convert.ToInt32(sum));
                html = replace(html, hs);
                MemoryStream ms = new MemoryStream(UTF8Encoding.UTF8.GetBytes(html));
                this.webBrowser1.DocumentStream = ms;
            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Print();
            this.Close();
        }
    }
}
