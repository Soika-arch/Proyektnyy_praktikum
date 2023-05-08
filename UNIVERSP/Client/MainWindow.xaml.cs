using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dynamic data = new ExpandoObject();
            var worksp = new dynamic[9];
            for (int i = 0; i < 9; i++)
            {
                dynamic sma = new ExpandoObject(); sma.nazva = "Spivrobitnyk" + " " + (i * (4 - 1));
                dynamic ssa = new ExpandoObject(); ssa.nazva = "Spivrobitnyk" + " " + (i * (4 - 2));
                dynamic sar = new ExpandoObject(); sar.nazva = "Spivrobitnyk" + " " + (i * (4 - 3));
                dynamic sa = new ExpandoObject(); sa.nazva = "Spivrobitnyk" + " " + (i * (4 - 4));

                dynamic gr = new ExpandoObject(); gr.nazva = "Group" + " " + (i * 1);
                gr.cd = new dynamic[] { sma, ssa, sar, sa };
                worksp[i] = gr;
            }
            dynamic dwm = new ExpandoObject(); dwm.nazva = "Contract praci Rector"; dwm.cd = new dynamic[] { worksp[1], worksp[2] };
            dynamic dwa = new ExpandoObject(); dwa.nazva = "Contract praci ProRector"; dwa.cd = new dynamic[] { worksp[3], worksp[4] };
            dynamic dsa = new ExpandoObject(); dsa.nazva = "Contract praci Dekan"; dsa.cd = new dynamic[] { worksp[5], worksp[6] };
            dynamic darh = new ExpandoObject(); darh.nazva = "Contract praci Teacher"; darh.cd = new dynamic[] { worksp[7], worksp[8] };


            dynamic br = new ExpandoObject(); br.nazva = "Two days work in week"; br.cd = new dynamic[] { dwm, dwa, dsa, darh };
            dynamic or = new ExpandoObject(); or.nazva = "Everyday day work"; or.cd = new dynamic[] { dwm, dwa, dsa, darh };
            var dsw = new dynamic[] { br, or };
            data.spivrobitnykiv = dsw;

            var st_u = new dynamic[7];
            for (int i = 0; i < 7; i++)
            {
                dynamic stpz= new ExpandoObject(); stpz.nazva = "Student " + " " + (i * (2 - 1));
                dynamic stel = new ExpandoObject(); stel.nazva = "Student " + " " + (i * (2 - 2));
                
                dynamic gr = new ExpandoObject(); gr.nazva = "Group" + " " + (i * 1);
                gr.cd = new dynamic[] { stpz, stel };
                st_u[i] = gr;
            }
            dynamic kse = new ExpandoObject(); kse.nazva = "Kafedra Software Engineering"; kse.cd = new dynamic[] { st_u[1], st_u[2] };
            dynamic ke = new ExpandoObject(); ke.nazva = "Kafedra Electrician"; ke.cd = new dynamic[] { st_u[3], st_u[4] };
            dynamic knm = new ExpandoObject(); knm.nazva = "Kafedra Nano Micro Technologik"; knm.cd = new dynamic[] { st_u[5], st_u[6] };


            dynamic bud = new ExpandoObject(); bud.nazva = "Budjet"; bud.cd = new dynamic[] { kse, ke , knm};
            dynamic con = new ExpandoObject(); con.nazva = "Contract"; con.cd = new dynamic[] { kse, ke , knm};
            var dst = new dynamic[] { bud, con };
            data.student = dst;

            DataContext = data;
        }
        private void TreeView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var obj = (sender as TreeView).SelectedItem as ExpandoObject;
            if (obj == null) return;
            if (obj.Where(x => x.Key == "cd").Count() == 0)
                new Dovidnik_Spivrobitnykiv(obj).Show();
                new Dovidnik_Students(obj).Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((FrameworkElement)sender).Tag;
            if ((tag as string) == null) return;
            var cls = tag + "";
            var type = Type.GetType("Client." + cls);
            if (type == null) return;
            var window = Activator.CreateInstance(type) as Window;
            window.ShowDialog();

        }

    }
}
