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
        List<Canvas> days = new List<Canvas>();
        List<TextBox> modayTxtBox = new List<TextBox>();
        List<TextBox> tuesdayTxtBox = new List<TextBox>();
        List<TextBox> wednesdayTxtBox = new List<TextBox>();
        List<TextBox> thursdayTxtBox = new List<TextBox>();
        List<TextBox> fridayTxtBox = new List<TextBox>();

        public Sсhedule schedule;
        public List<Faculty> faculty;
        public List<Specialti> specialties;
        public List<Group> groups;
        public List<Ring> rings;

        public string selectedGroup;

        public MainWindow()
        {
            InitializeComponent();

            currentDate = DateTime.Now;

           //test, schedule doen't work
            //string codeGroup = "СП-12-1д";
            //schedule = Action.GetSchedule(codeGroup);

            //rings = Action.GetListRings();

            faculty = Action.GetFaculty();
            FillFacultyComboBox();
            specialties = Action.GetSpecialties();
            groups = Action.GetGroups();


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

        #region Filling ComboBoxes Faculty - Speciality(Faculty) - Groups(Speciality)
        public void FillFacultyComboBox()
        {
            foreach(var item in faculty)
            {
                facultyComboBox.Items.Add(item.title);
            }
        }

        public void FillSpecialtiesComboBox(List<Specialti> specialtiesForCertainFaculty)
        {
            if(DepartmentComboBox.Items.Count!=0)
            {
                DepartmentComboBox.Items.Clear();
            }
            foreach(var item in specialtiesForCertainFaculty)
            {
                DepartmentComboBox.Items.Add(item.title);
            }
        }

        public void FillGroupsComboBox(List<Group> groupsForCertainSpecialties)
        {
            if(groupComboBox.Items.Count!=0)
            {
                groupComboBox.Items.Clear();
            }
            foreach(var item in groupsForCertainSpecialties)
            {
                groupComboBox.Items.Add(item.title);
            }
        }
        #endregion

        #region ComboBox SelectionChanged Events (FacultyCB, DepartmentCB, GroupsCB)
        private void facultyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (facultyComboBox.SelectedIndex != -1)
            {
                int index = faculty.FindIndex(item => item.title == facultyComboBox.SelectedValue.ToString());
                string facultyId = faculty[index].id;

                List<Specialti> specialtiesForThisFaculty = specialties.FindAll(item => item.faculty == facultyId);
                FillSpecialtiesComboBox(specialtiesForThisFaculty);
            }
        }

        private void DepartmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex != -1)
            {
                int index = specialties.FindIndex(item => item.title == DepartmentComboBox.SelectedValue.ToString());
                string specialtiID = specialties[index].id;

                List<Group> groupsForThisSpeciality = groups.FindAll(item => item.specialty == specialtiID);
                FillGroupsComboBox(groupsForThisSpeciality);
            }
        }

        private void groupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupComboBox.SelectedIndex != -1)
            {
                selectedGroup = groupComboBox.SelectedValue.ToString();
            }
        }
        #endregion
    }
}
