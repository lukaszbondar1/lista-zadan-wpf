   M S B A M L   `   `   `  ����E  AProjektWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjektWPF
ProjektWPF  5   	       ProjektWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjektWPF     5   	     � Title$  Lista zadań��5   	   $	��600��6   $
��1000��6*    � DataContext 5	         ProjektWPF.MainViewModel  5
   
   .��5      ]� .+�5   
   c� $	��Top=�6   .@�5      �� $��Dodaj zadanie��6   ��6-   �� *AddTaskCommand+�� 5      $��Filtruj��6   ��6'   �� *FilterCommand+�� 5      $	��200��6   $��10,0,0,0q�6"   ��5      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $��Bottom=�6   .@�5      �� ��6   �� *TaskSummary+5      � 5   
    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5#      �� $��0��6   $��5q�6)   .+�5$      �� $��	Kategorie��6   $
��Bold"�6-   $��0 10 0 0q�6f   ��6?   �� *AddCategoryCommand+6f   �� 5%       �� DisplayMemberPath$
 Name��5'      ��5%      �� *
Categories+ �� SelectedItem 5&      �� *SelectedCategory+5'      5(      �� 5+      $��1��6   $��10q�6'   ��5,      �� *FilteredTasks+��5-      �� 5.      .R�5/      9�  9� 
IsExpanded$ False��6;   $��0 5 0 0q�6N   ��6#   �� *Name+.��50      �� .+�51   "   �� $��Italic$�6I   $��0 0 0 5q�6\   ��6,   �� *Description+6\   � 52   "   .+�53   &   �� $��Kategoria: ��60   $
��Bold"�6C   �� 54   &   $	��5,0q�6O   ��60   �� *Category.Name+6O   �� 55   &   $�� | Pilność: ��60   $
��Bold"�6D   $
��10,0q�6V   �� 56   &   ��60   �� *
Priority+�� 57   &   $�� | Termin: ��60   $
��Bold"�6C   $
��10,0q�6U   �� 58   &   ��60   �� *	DueDate+59   #   �� 5;   "   ��6/   �� *
SubTasks+��5<   &   �� 5=   *   .R�5>   .   ��  �� Orientation$ 
Horizontal=�69   $	��0,2q�6R   .+�5?   2   �� $��0,0,5,0q�6X    d� 	IsChecked 6;   �� *IsDone+6X   �� 5@   2   ��6<   �� *Name+5A   /   5B   +   5D   #   �� 5G   "   $��Edytuj��6)   $��0,10,0,0q�6:   $��Right=�6L   ��5H   !   �� *DataContext.EditTaskCommand+	 �� RelativeSource	 �� 
 �� AncestorType

 Window��5I   !   �� �� 5J   "   $��Usuń��6)   $��0,10,0,0q�68   $��Right=�6J   ��5K   !   �� *DataContext.DeleteTaskCommand+	 �� 

 Window��5L   !   �� 5O      5P      5Q      5S      5U      5V      5W      