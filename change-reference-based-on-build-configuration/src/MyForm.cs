using System;
using System.Windows.Forms;
using testLibrary;

namespace change_reference_based_on_build_configuration
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var testClass = new MyTestClass();

            var message = string.Format("Version {0} of external assembly", testClass.MyVersion());
            
            MessageBox.Show(message, "Information", MessageBoxButtons.OK);
        }
    }
}
