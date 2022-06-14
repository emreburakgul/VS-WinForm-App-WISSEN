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
    public partial class CategoryEditForm : Form
    {
        private Form1 _form1;

        // SOLID prensiblerinin S harfini uylualamaya öalışıyorumç.
        // Sinle responsibilty=> Tek sorumluluk
        // Projedeki From1 eski haliyle hem ana from görevini hmnde veri kaydetme
        // görevini üstlenmşlti, bu uygun bşr yaklaşım değildi

        //NotFiniteNumberException:Responsitory pattern tam amlanmıyla uygukmak
        //için farklı bir nesne geliştirmek gerekiyor. Şimdilik List<Category> tipindeki bir koleksiyon da
        //(çpok benzer bir yapıya sahip  olduğu için ) respository görevini görelilir..

        private List<Category> _categoriRepository;

        public CategoryEditForm(List<Category>categoriesReponsitory)
        {
            InitializeComponent();

            _categoriRepository = categoriesReponsitory;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(), // ID değerini kullanıcı değil sistem belirler
                // bu sebeple ekrandan okumadık
                Name = txtCategoryName.Text.Trim(),
                Description = txtCategoryDescription.Text.Trim()

            };


            // Design Patterns
            // GoF 23 design pattern(sigleton,factory)
            // Belli başlı tekrar eden problemlere çözüm üretir.

            // Architectural Patterns
            //(Respnsitoy pattern, unit of work pattern)
            // (Active Record Pattern: mesela bu şablon SOLID prensiblerini karşılamaz)


            // SOLID prensibleri
            // İyi OOP yazma kodları
            // S: Single- Responsibility Principle ** 
            // O: Open-Closed Priciple
            // L: Liskov's Subtition Principle
            // I: Interface Segragation Principle
            // D: Dependency Inversion Principle

            // Kaydetme işlemi artık bu şekilde gerçekleşiyor
            _categoriRepository.Add(category);
            //0x1234.Add(category)


            txtCategoryName.Clear();
            txtCategoryDescription.Clear();

            var dialogResult = MessageBox.Show(
                "Kayıt başarıyla gerçekleştirildi, yeni kayıt yapmak istiyor musunuz?",
                "Kayıt başarılı",
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }
    }
}
