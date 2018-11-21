using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
namespace ERP
{
    public class BaseForm : Telerik.WinControls.UI.ShapedForm
    {
        private string tableName;

        private BaseForm()
        {
            Load += BaseForm_Load;
        }

        public BaseForm(string tableName)
        {

            Load += BaseForm_Load;
            this.tableName = tableName;
        }

        public int Id { get; set; }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                RadButton saveBtn = (RadButton)this.Controls.Find("saveBtn", true)[0];
                saveBtn.Click += saveBtn_Click;
            }
            catch { }
            try
            {
                RadButton closeBtn = (RadButton)this.Controls.Find("closeBtn", true)[0];
                closeBtn.Click += closeBtn_Click;
            }
            catch { }

            LoadInfo();
            if (Id == 0)
            {
                
            }
            else {
                Data.DataUtil.BindForm(this, tableName, Id);
                BindEnd();
            }
            
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            List<DictionaryEntry> list = Data.DataUtil.GetFormInfo(this);
            try
            {
                if (this.Id == 0)
                {

                    Create(list);
                    MessageBox.Show("提交成功！");
                    this.Close();
                }
                else
                {
                    list.Add(new DictionaryEntry("id", Id));
                    Update(list);
                    MessageBox.Show("修改成功！");
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
          
        }
        public virtual List<DictionaryEntry> Add(List<DictionaryEntry> list)
        {
            return list;
        }
        public virtual void Create(List<DictionaryEntry> list){
            Data.DataUtil.Add(this.tableName, this.Add(list));
        }
        public virtual List<DictionaryEntry> Save(List<DictionaryEntry> list)
        {
            return list;
        }
        public virtual void Update(List<DictionaryEntry> list)
        {
             Data.DataUtil.Update(this.tableName, this.Save(list));
        }
        public virtual void LoadInfo() { 
        
        }
        public virtual void BindEnd()
        {

        }
    }
}
