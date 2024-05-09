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
            integers.Add("���� ������ ���� 25 � 33 ��", 11);
            integers.Add("���� ���� 25 � 33 �� ", 11);
            integers.Add("���� ������ 25 � 33 ��", 11);
            integers.Add("������� ��� 20 � 30 �� ", 8);
            integers.Add("K���� ������ ����� 20 � 30 ��", 14);
            integers.Add("����� ���� 20 � 25 ��", 14);
            integers.Add("����� ������ 20 � 25 ��", 14);
            integers.Add("������ ������ 25 � 40 ��", 17);
            integers.Add("������ ���� 25 � 40 �� ", 19);
            plochka.Add("���� ������ ���� 25 � 33 ��", 0.0825);
            plochka.Add("���� ���� 25 � 33 �� ", 0.0825);
            plochka.Add("���� ������ 25 � 33 ��", 0.0825);
            plochka.Add("������� ��� 20 � 30 �� ", 0.06);
            plochka.Add("K���� ������ ����� 20 � 30 ��", 0.06);
            plochka.Add("����� ���� 20 � 25 ��", 0.05);
            plochka.Add("����� ������ 20 � 25 ��", 0.05);
            plochka.Add("������ ������ 25 � 40 ��", 0.10);
            plochka.Add("������ ���� 25 � 40 �� ", 0.10);

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int intValue = integers[(string)comboBox1.SelectedItem];

            label9.Text = intValue.ToString() + " ��";
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
            label11.Text = m.ToString("0.00") + " ��";

        }

        
    }

}
