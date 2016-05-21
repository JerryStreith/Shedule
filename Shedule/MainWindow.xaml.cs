using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
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

/*
 * 1. показывать какая сейчас текущая пара
 */

namespace Shedule
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime currentDate;
        List<string> faculties = new List<string>();
        List<string> departments = new List<string>();
        List<string> groups = new List<string>();
        List<Canvas> days = new List<Canvas>();
        List<TextBox> modayTxtBox = new List<TextBox>();
        List<TextBox> tuesdayTxtBox = new List<TextBox>();
        List<TextBox> wednesdayTxtBox = new List<TextBox>();
        List<TextBox> thursdayTxtBox = new List<TextBox>();
        List<TextBox> fridayTxtBox = new List<TextBox>();

        public List<SсheduleItem> schedule;
        public List<Ring> rings;

        public MainWindow()
        {
            InitializeComponent();

            currentDate = DateTime.Now;

            //test, schedule doen't work
            //string codeGroup = "СП-12-1д";
            //schedule = Action.GetSchedule(codeGroup);

            rings = Action.GetListRings();

            modayTxtBox.Add(msh1);
            modayTxtBox.Add(msh2);
            modayTxtBox.Add(msh3);
            modayTxtBox.Add(msh4);
            modayTxtBox.Add(msh5);

            tuesdayTxtBox.Add(tush1);
            tuesdayTxtBox.Add(tush2);
            tuesdayTxtBox.Add(tush3);
            tuesdayTxtBox.Add(tush4);
            tuesdayTxtBox.Add(tush5);

            wednesdayTxtBox.Add(wsh1);
            wednesdayTxtBox.Add(wsh2);
            wednesdayTxtBox.Add(wsh3);
            wednesdayTxtBox.Add(wsh4);
            wednesdayTxtBox.Add(wsh5);

            thursdayTxtBox.Add(thsh1);
            thursdayTxtBox.Add(thsh2);
            thursdayTxtBox.Add(thsh3);
            thursdayTxtBox.Add(thsh4);
            thursdayTxtBox.Add(thsh5);

            fridayTxtBox.Add(frsh1);
            fridayTxtBox.Add(frsh2);
            fridayTxtBox.Add(frsh3);
            fridayTxtBox.Add(frsh4);
            fridayTxtBox.Add(frsh5);

            days.Add(mondayCanvas);
            days.Add(tuesdayCanvas);
            days.Add(wednesdayCanvas);
            days.Add(thursdayCanvas);
            days.Add(fridayCanvas);
            days.Add(sundayCanvas);

            DislayCurrentDay();
        }

        public void GenerateSchedules()
        {

        }

        public void DislayCurrentDay()
        {
            SolidColorBrush brush, brushNextDay;
            string dayOfWeek = currentDate.DayOfWeek.ToString();
            switch (dayOfWeek)
            {
                case "Monday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    mondayCanvas.Background = brush;
                    break;
                case "Tuesday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    tuesdayCanvas.Background = brush;
                    break;
                case "Wednesday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    wednesdayCanvas.Background = brush;
                    brushNextDay = new SolidColorBrush(Color.FromRgb(115, 238, 110));
                    thursdayCanvas.Background = brushNextDay;
                    break;
                case "Thursday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    thursdayCanvas.Background = brush;
                    brushNextDay = new SolidColorBrush(Color.FromRgb(115, 238, 110));
                    fridayCanvas.Background = brushNextDay;
                    break;
                case "Friday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    fridayCanvas.Background = brush;
                    break;
                case "Sunday":
                    brush = new SolidColorBrush(Color.FromRgb(238, 110, 115));
                    fridayCanvas.Background = brush;
                    break;
            }
        }

        private void facultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (facultyComboBox.SelectedIndex != -1)
            {
                //выбираем факультет
            }
        }

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex != -1)
            {
                //по выбраному факультеты выбираем группу
            }
        }

        private void groupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupComboBox.SelectedIndex != -1)
            {
                //по выбранной группе получаем расписание на всю неделю
            }
        }

    }
}
