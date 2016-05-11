using System;
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
        List<List<ScheduleItem>> schedule = new List<List<ScheduleItem>>();
        List<TextBox> modayTxtBox = new List<TextBox>();
        List<TextBox> tuesdayTxtBox = new List<TextBox>();
        List<TextBox> wednesdayTxtBox = new List<TextBox>();
        List<TextBox> thursdayTxtBox = new List<TextBox>();
        List<TextBox> fridayTxtBox = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();

            schedule.Add(new List<ScheduleItem>());
            schedule[0].Add(new ScheduleItem("1", "Безпека програм та даних", "лекція", "ауд.40"));
            schedule[0].Add(new ScheduleItem("2", "Безпека програм та даних", "лаба", "оц-3"));

            schedule.Add(new List<ScheduleItem>());
            schedule[1].Add(new ScheduleItem("1", "Програмування інтернет", "лекція", "ауд.40"));
            schedule[1].Add(new ScheduleItem("2", "Програмування інтернет", "лаба", "оц-3"));
            schedule[1].Add(new ScheduleItem("3", "Аналіз вимог до ПЗ", "лекція", "ауд.40"));

            schedule.Add(new List<ScheduleItem>());
            schedule[2].Add(new ScheduleItem("1", "Архітектура та проектування ПЗ", "лекція", "ауд.40"));
            schedule[2].Add(new ScheduleItem("2", "Архітектура та проектування ПЗ", "лаба", "оц-3"));
            schedule[2].Add(new ScheduleItem("3", "Аналіз вимог до ПЗ", "лаба", "ауд.40"));

            schedule.Add(new List<ScheduleItem>());
            schedule[3].Add(new ScheduleItem("1", "Безпека програм та даних", "лекція", "ауд.40"));
            schedule[3].Add(new ScheduleItem("2", "Безпека програм та даних", "лаба", "оц-3"));
            schedule[3].Add(new ScheduleItem("3", "Програмування інтернет", "лекція", "ауд.40"));

            schedule.Add(new List<ScheduleItem>());
            schedule[4].Add(new ScheduleItem("1", "Аналіз вимог до ПЗ", "лекція", "ауд.40"));
            schedule[4].Add(new ScheduleItem("2", "Архітектура та проектування ПЗ", "лекція", "оц-3"));
            schedule[4].Add(new ScheduleItem("3", "Аналіз вимог до ПЗ", "лаба", "оц-3"));

            currentDate = DateTime.Now;

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

            faculties.Add("MФ");
            faculties.Add("ФАСУВ");
            faculties.Add("ФБВР");
            faculties.Add("ФЕЕ");
            faculties.Add("ФЕУ");

            days.Add(mondayCanvas);
            days.Add(tuesdayCanvas);
            days.Add(wednesdayCanvas);
            days.Add(thursdayCanvas);
            days.Add(fridayCanvas);
            days.Add(sundayCanvas);

            facultyComboBox.ItemsSource = faculties;

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
            string faculty = "";
            if (facultyComboBox.SelectedIndex != -1)
            {
                faculty = facultyComboBox.SelectedValue.ToString();

                switch (faculty)
                {
                    case "МФ":
                        departments.Clear();

                        break;
                    case "ФАСУВ":
                        departments.Clear();
                        departments.Add("ПЗАС");
                        departments.Add("АУТП");
                        departments.Add("МН");
                        departments.Add("ЕС");
                        break;
                    case "ФБВР":
                        departments.Clear();

                        break;
                    case "ФЕЕ":
                        departments.Clear();

                        break;
                    case "ФЕУ":
                        departments.Clear();

                        break;
                }
            }
            DepartmentComboBox.ItemsSource = departments;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string department = "";
            if (DepartmentComboBox.SelectedIndex != -1)
            {
                department = DepartmentComboBox.SelectedValue.ToString();
                switch (department)
                {
                    case "ПЗАС":
                        groups = new List<string>();
                        groups.Add("СП-12-1с");
                        groups.Add("СП-12-1м");
                        groups.Add("СП-12-1");
                        groups.Add("СП-13-1");
                        groups.Add("СП-13-2");
                        groups.Add("СП-14-1");
                        groups.Add("СП-14-2");
                        groups.Add("СП-15-1");
                        groups.Add("СП-15-2");

                        break;
                    case "АУТП":
                        groups = new List<string>();
                        groups.Add("АУТП-12-1с");
                        groups.Add("АУТП-12-1м");
                        groups.Add("АУТП-12-1");
                        groups.Add("АУТП-13-1");
                        groups.Add("АУТП-13-2");
                        groups.Add("АУТП-14-1");
                        groups.Add("АУТП-14-2");
                        groups.Add("АУТП-15-1");
                        groups.Add("АУТП-15-2");

                        break;
                    case "МН":
                        groups = new List<string>();
                        groups.Add("МН-12-1с");
                        groups.Add("МН-12-1м");
                        groups.Add("МН-12-1");
                        groups.Add("МН-13-1");
                        groups.Add("МН-13-2");
                        groups.Add("МН-14-1");
                        groups.Add("МН-14-2");
                        groups.Add("МН-15-1");
                        groups.Add("МН-15-2");

                        break;
                    case "ЭС":
                        groups = new List<string>();
                        groups.Add("ЭС-12-1с");
                        groups.Add("ЭС-12-1м");
                        groups.Add("ЭС-12-1");
                        groups.Add("ЭС-13-1");
                        groups.Add("ЭС-13-2");
                        groups.Add("ЭС-14-1");
                        groups.Add("ЭС-14-2");
                        groups.Add("ЭС-15-1");
                        groups.Add("ЭС-15-2");

                        break;
                }
                groupComboBox.ItemsSource = groups;

            }
        }

        private void groupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string group = "";
            if (groupComboBox.SelectedIndex != -1)
            {
                group = groupComboBox.SelectedValue.ToString();
                if (group == "СП-12-1")
                {
                    for (int i = 0; i < schedule[0].Count; i++)
                    {
                        modayTxtBox[i].Visibility = Visibility.Visible;
                        modayTxtBox[i].Text = schedule[0][i].ScheduleItemToString();
                    }
                    for (int i = 0; i < schedule[1].Count; i++)
                    {
                        tuesdayTxtBox[i].Visibility = Visibility.Visible;
                        tuesdayTxtBox[i].Text = schedule[1][i].ScheduleItemToString();
                    }
                    for (int i = 0; i < schedule[2].Count; i++)
                    {
                        wednesdayTxtBox[i].Visibility = Visibility.Visible;
                        wednesdayTxtBox[i].Text = schedule[2][i].ScheduleItemToString();
                    }
                    for (int i = 0; i < schedule[3].Count; i++)
                    {
                        thursdayTxtBox[i].Visibility = Visibility.Visible;
                        thursdayTxtBox[i].Text = schedule[3][i].ScheduleItemToString();
                    }
                    for (int i = 0; i < schedule[4].Count; i++)
                    {
                        fridayTxtBox[i].Visibility = Visibility.Visible;
                        fridayTxtBox[i].Text = schedule[4][i].ScheduleItemToString();
                    }
                }
            }
        }

    }
}
