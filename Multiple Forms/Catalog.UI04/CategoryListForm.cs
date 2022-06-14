using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catalog.UI04
{
    public partial class CategoryListForm : Form
    {
        private List<Category> _categoryRepository;

        // Dependency Inversion 
        // Veri kaynağını (bu senaryoda List<Category> tipindeki reppsitory)bu sınıfta
        // yeni instance olarak oluşturmuyıorum, instance dışarıdan bana gönderiliyor.

        // Bu sınıf işini yapabilmesi için CategoryRepository'e bağımlı(dependent) durumda
        // Repository sınıfını dışarıdan alıyor olmak bu bağımmlılığı terse çevirmek 
        //(depndent Inversiton) anlamına gelitor....
        public CategoryListForm(List<Category> categoryRepository)
        {
            InitializeComponent();

            _categoryRepository = categoryRepository;
        }

        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            // data bind veri bağlama 
            grdCategories.DataSource = _categoryRepository;
        }

        private void grdCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //            MessageBox.Show(@$"Id:{grdCategories.CurrentRow.Cells[0].Value.ToString()}
            //Kategori Adı: {grdCategories.CurrentRow.Cells[1].Value.ToString()}
            //Açıklama:{grdCategories.CurrentRow.Cells[2].Value.ToString()}");

            var showData = (Category)grdCategories.CurrentRow.DataBoundItem;
            MessageBox.Show(@$"ID: {showData.Id}
Category Açıklama: {showData.Description}
Name: {showData.Name}
");
        }
    }
}


