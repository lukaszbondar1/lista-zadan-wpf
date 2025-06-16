using ProjektWPF.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjektWPF.Controls
{
    public partial class FilterControl : UserControl
    {
        public FilterControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Category> Categories
        {
            get => (ObservableCollection<Category>)GetValue(CategoriesProperty);
            set => SetValue(CategoriesProperty, value);
        }

        public static readonly DependencyProperty CategoriesProperty =
            DependencyProperty.Register(nameof(Categories), typeof(ObservableCollection<Category>), typeof(FilterControl), new PropertyMetadata(null));


        public Category? SelectedCategory
        {
            get => (Category?)GetValue(SelectedCategoryProperty);
            set => SetValue(SelectedCategoryProperty, value);
        }

        public static readonly DependencyProperty SelectedCategoryProperty =
            DependencyProperty.Register(nameof(SelectedCategory), typeof(Category), typeof(FilterControl), new PropertyMetadata(null));


        public IEnumerable<PriorityLevel> PriorityLevels
        {
            get => (IEnumerable<PriorityLevel>)GetValue(PriorityLevelsProperty);
            set => SetValue(PriorityLevelsProperty, value);
        }

        public static readonly DependencyProperty PriorityLevelsProperty =
            DependencyProperty.Register(nameof(PriorityLevels), typeof(IEnumerable<PriorityLevel>), typeof(FilterControl), new PropertyMetadata(null));


        public PriorityLevel? SelectedPriority
        {
            get => (PriorityLevel?)GetValue(SelectedPriorityProperty);
            set => SetValue(SelectedPriorityProperty, value);
        }

        public static readonly DependencyProperty SelectedPriorityProperty =
            DependencyProperty.Register(nameof(SelectedPriority), typeof(PriorityLevel?), typeof(FilterControl), new PropertyMetadata(null));


        public List<StatusOption> StatusOptions
        {
            get => (List<StatusOption>)GetValue(StatusOptionsProperty);
            set => SetValue(StatusOptionsProperty, value);
        }

        public static readonly DependencyProperty StatusOptionsProperty =
            DependencyProperty.Register(nameof(StatusOptions), typeof(List<StatusOption>), typeof(FilterControl), new PropertyMetadata(null));


        public StatusOption? SelectedStatusOption
        {
            get => (StatusOption?)GetValue(SelectedStatusOptionProperty);
            set => SetValue(SelectedStatusOptionProperty, value);
        }

        public static readonly DependencyProperty SelectedStatusOptionProperty =
            DependencyProperty.Register(nameof(SelectedStatusOption), typeof(StatusOption), typeof(FilterControl), new PropertyMetadata(null));


        public DateTime? DueBefore
        {
            get => (DateTime?)GetValue(DueBeforeProperty);
            set => SetValue(DueBeforeProperty, value);
        }

        public static readonly DependencyProperty DueBeforeProperty =
            DependencyProperty.Register(nameof(DueBefore), typeof(DateTime?), typeof(FilterControl), new PropertyMetadata(null));


        public ICommand ApplyCommand
        {
            get => (ICommand)GetValue(ApplyCommandProperty);
            set => SetValue(ApplyCommandProperty, value);
        }

        public static readonly DependencyProperty ApplyCommandProperty =
            DependencyProperty.Register(nameof(ApplyCommand), typeof(ICommand), typeof(FilterControl), new PropertyMetadata(null));


        public ICommand ResetCommand
        {
            get => (ICommand)GetValue(ResetCommandProperty);
            set => SetValue(ResetCommandProperty, value);
        }

        public static readonly DependencyProperty ResetCommandProperty =
            DependencyProperty.Register(nameof(ResetCommand), typeof(ICommand), typeof(FilterControl), new PropertyMetadata(null));
    }

    public class StatusOption
    {
        public string Name { get; set; } = string.Empty;
        public bool? Value { get; set; }
    }
}

