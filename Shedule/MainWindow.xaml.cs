using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
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
            faculty = Action.GetFaculty();
            specialties = Action.GetSpecialties();
            groups = Action.GetGroups();
            FillFacultyComboBox();
            
            mondayStack.Children.Add(GetFormattedTextBlock());
            mondayStack.Children.Add(GetFormattedTextBlock());
            mondayStack.Children.Add(GetFormattedTextBlock());
            mondayStack.Children.Add(GetFormattedTextBlock());
            thursdayStack.Children.Add(GetFormattedTextBlock());
            thursdayStack.Children.Add(GetFormattedTextBlock());


            DislayCurrentDay();
        }

        StackPanel GetFormattedTextBlock()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            Rectangle rectangle = new Rectangle();
            rectangle.Stroke = new SolidColorBrush(Color.FromRgb(238, 110, 115));
            rectangle.Fill = new SolidColorBrush(Color.FromRgb(238, 110, 115));
            rectangle.Width = 5;

            Thickness margin = rectangle.Margin;
            margin = new Thickness(10, 5, 0, 5);
            rectangle.Margin = margin;

            TextBlock textBlock = new TextBlock();
            textBlock.Foreground = Brushes.White;
            textBlock.FontSize = 14;
            textBlock.Inlines.Add(new Bold(new Run("Менеджмент проектів ПЗ\n")));
            textBlock.Inlines.Add("nст.викл. Новікова О.С.\nауд.40 лекція");


            margin = textBlock.Margin;
            margin = new Thickness(10, 5, 0, 5);
            textBlock.Margin = margin;

            stackPanel.Children.Add(rectangle);
            stackPanel.Children.Add(textBlock);
            return stackPanel;
        }

        public void DislayCurrentDay()
        {
            string dayOfWeek = currentDate.DayOfWeek.ToString();
            switch (dayOfWeek)
            {
                case "Monday":
                    BrushDays(mondayCanvas, tuesdayCanvas);
                    break;
                case "Tuesday":
                    BrushDays(tuesdayCanvas, wednesdayCanvas);
                    break;
                case "Wednesday":
                    BrushDays(wednesdayCanvas, thursdayCanvas);
                    break;
                case "Thursday":
                    BrushDays(thursdayCanvas, fridayCanvas);
                    break;
                case "Friday":
                    BrushDays(fridayCanvas, sundayCanvas);
                    break;
                case "Sunday":
                    BrushDays(sundayCanvas, mondayCanvas);
                    break;
            }
        }

        void BrushDays(Grid thisDay, Grid nextDay)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(115, 238, 110));
            SolidColorBrush brushNextDay = new SolidColorBrush(Color.FromRgb(238, 110, 115));

            thisDay.Background = brush;
            nextDay.Background = brushNextDay;
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
