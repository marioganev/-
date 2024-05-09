using System.Globalization;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        double width_d;
        double hight_d;
        double perimeter_b;
        double hight_b;



        Dictionary<string, int> integers = new Dictionary<string, int>();
        Dictionary<string, double> plochka = new Dictionary<string, double>();
        public Form1()
        {
            InitializeComponent();
            integers.Add("Кора светло синя 25 х 33 см", 11);
            integers.Add("Кора синя 25 х 33 см ", 11);
            integers.Add("Кора бежова 25 х 33 см", 11);
            integers.Add("Каскада сив 20 х 30 см ", 8);
            integers.Add("Kриси светло бежов 20 х 30 см", 14);
            integers.Add("Силва синя 20 х 25 см", 14);
            integers.Add("Силва зелена 20 х 25 см", 14);
            integers.Add("Верона бежова 25 х 40 см", 17);
            integers.Add("Хавана охра 25 х 40 см ", 19);
            plochka.Add("Кора светло синя 25 х 33 см", 0.0825);
            plochka.Add("Кора синя 25 х 33 см ", 0.0825);
            plochka.Add("Кора бежова 25 х 33 см", 0.0825);
            plochka.Add("Каскада сив 20 х 30 см ", 0.06);
            plochka.Add("Kриси светло бежов 20 х 30 см", 0.06);
            plochka.Add("Силва синя 20 х 25 см", 0.05);
            plochka.Add("Силва зелена 20 х 25 см", 0.05);
            plochka.Add("Верона бежова 25 х 40 см", 0.10);
            plochka.Add("Хавана охра 25 х 40 см ", 0.10);

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int intValue = integers[(string)comboBox1.SelectedItem];

            label9.Text = intValue.ToString() + " лв";
            if (comboBox1.SelectedIndex > -1)
            {

                var imageName = string.Format("{0}.jpg", comboBox1.SelectedItem);
                var file = System.IO.Path.Combine(Application.StartupPath, "Resources", imageName);
                pictureBox1.Image = Image.FromFile(file);
            }
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            perimeter_b = double.Parse(textBox1.Text);
            hight_b = double.Parse(textBox2.Text);
            width_d = double.Parse(textBox3.Text);
            hight_d = double.Parse(textBox4.Text);
            double bathsize = perimeter_b * hight_b;
            double doorsize = width_d * hight_d;
            double a = bathsize - doorsize;
            double b = plochka[(string)comboBox1.SelectedItem];
            int rezerva = int.Parse(textBox5.Text);
            int c = (int)(a / b);
            int d = c + rezerva;
            label13.Text = d.ToString();
            label13.AutoSize = true;
            int price = integers[(string)comboBox1.SelectedItem];
            double m = price * b * c;
            label11.AutoSize = true;
            label11.Text = m.ToString("0.00") + " лв";

        }

        
    }

}
