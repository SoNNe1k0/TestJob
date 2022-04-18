using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int stt = -1;
        String[] a = new String[99];
        String[] b = new String[99];
        String[] c = new String[99];
        String[] d = new String[99];
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddRow()
        {
            List<User> items = new List<User>();
            for (int i = 0; i <=stt; i++)
            {
                items.Add(new User() { masv = a[i], name = b[i], phone = c[i], date = d[i] });
            }
            ViewUser.ItemsSource = items;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ViewUser.ItemsSource);
            view.Filter = UserFilter;
        }
        private void save()
        {
            stt = stt + 1;
                a[stt] = Txt1.Text;
                b[stt] = Txt2.Text;
                c[stt] = Txt3.Text;
                d[stt] = txt4.Text;

        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            if (Txt1.Text == "" || Txt2.Text == "" || Txt3.Text == "" || txt4.Text == "")
            {
                MessageBox.Show("Không bỏ trống thông tin");
            }
            else
            {
                save();
                AddRow();
                CollectionViewSource.GetDefaultView(ViewUser.ItemsSource).Refresh();
                Txt1.Text = "";
                Txt2.Text = "";
                Txt3.Text = "";
                txt4.Text = "";
                Txt1.Focus();
            }
        }
        private void edit()
        {  
            int k = ViewUser.SelectedIndex;
            a[k] = Txt1.Text;
            b[k] = Txt2.Text;
            c[k] = Txt3.Text;
            d[k] = txt4.Text;
        }

        private void EditB_Click(object sender, RoutedEventArgs e)
        {
            User item = (User)ViewUser.SelectedItem;
            if (item != null)
            {
                if (Txt1.Text == "" || Txt2.Text == "" || Txt3.Text == "" || txt4.Text == "")
                {
                    MessageBox.Show("Không bỏ trống thông tin cần chỉnh sửa thông tin");
                }
                else
                {   
                    edit();
                    Txt1.Text = "";
                    Txt2.Text = "";
                    Txt3.Text = "";
                    txt4.Text = "";
                    Txt1.Focus();
                    AddRow();
                }
            }
            else
            {
                MessageBox.Show("Yêu cầu lựa chọn dòng cần chỉnh sửa");
            }
        }
        private void delete()
        {
            int k = ViewUser.SelectedIndex;
            if (k==stt)
            {
                a[k] = "";
                b[k] = "";
                c[k] = "";
                d[k] = "";
            }
            else
            {
                for (int i = k; i <= stt+1; i++)
                {
                    a[k] = a[k+1];
                    b[k] = b[k+1];
                    c[k] = c[k+1];
                    d[k] = d[k+1];
                }
            }
            stt = stt - 1;
            AddRow();
        }
        private void DelB_Click(object sender, RoutedEventArgs e)
        {
            User item = (User)ViewUser.SelectedItem;
            if (item != null) 
            {
                delete();
                Txt1.Text = "";
                Txt2.Text = "";
                Txt3.Text = "";
                txt4.Text = "";
                Txt1.Focus();
            }
            else
            {
                MessageBox.Show("Yêu cầu lựa chọn dòng cần xóa");
            }           
        }

        private void filtertxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ViewUser.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(filtertxt.Text))
                return true;
            else
                return ((item as User).name.IndexOf(filtertxt.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }
        private void ViewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
    public class User
    {
        public string masv { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string date { get; set; }    

    }
}
