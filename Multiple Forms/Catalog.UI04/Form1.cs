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
    public partial class Form1 : Form
    {
        //0x1234
        private List<Category> Categories = new List<Category>();//0x1234
        private List<Product> Products = new List<Product>();//0x1234

        public Form1()
        {
            InitializeComponent();
        }

        private void menuItemNewCategory_Click(object sender, EventArgs e)
        {
            // Kategori oluşturma formunu görüntülemeyi burada yapılacak kodlamayla sağlayacağım

            var categoryForm = new CategoryEditForm(Categories); // 0x1234 adreini gönderdim
            categoryForm.Owner = this;
            categoryForm.Show();
           
        }

        private void menuItemAllCategories_Click(object sender, EventArgs e)
        {
            var categoryListForm = new CategoryListForm(Categories);
            categoryListForm.Owner = this; // Form ile  ilgili ihtiyaç duyulabilir.
            categoryListForm.Show();
        }

        private void menuItemNewProduct_Click(object sender, EventArgs e)
        {
            var productForm = new ProductEditForm(Categories,Products);
            productForm.Owner = this;
            productForm.Show();
        }

        private void menuItemAllProducts_Click(object sender, EventArgs e)
        {
            var prouctListForm = new ProductListForm(Categories, Products);
            prouctListForm.Owner = this;
            prouctListForm.Show();
            
        }
    }
}
