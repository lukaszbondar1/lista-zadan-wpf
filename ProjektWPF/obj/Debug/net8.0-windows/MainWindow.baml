   M S B A M L   `   `   `  ����E  AProjektWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjektWPF
ProjektWPF  5   	       ProjektWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjektWPF     5   	     � Title$  Lista zadań��5   	   $	��600��6   $
��1000��6*    � DataContext 5	         ProjektWPF.MainViewModel  5
   
    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value��%�  '��       '�� R    '�� 1    �� 5   
   " ��6   .�5      ��  � �� �#FF40816+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ 5q�6'   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   $ 5��5      $
 10,5q�5      ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   ��  � �� �#E91E636?   5       5"      5$      5%      �� 5'   
   " ��6   .�5(      ��  � ��$ 5q�6'   �� 5)       � ��$	 6,3q�6(   �� 5*       � �� �#FF40816,   �� 5+       � ��$	 1.5q�60   �� 5,       � ��$ 14(�6)   5-      �� 5/   
   " ��6   .�50      ��  � ��$ 5q�6'   �� 51       � �� �#DDDDDD6,   �� 52       � ��$ 1q�60   53      54      .��57      ]� .+�5:   
   c� $	��Top=�6   $��62��6'   .@�5;      �� $��Dodaj zadanie��6   ��6-   �� *AddTaskCommand+�� 5<      $��Filtruj��6   ��6'   �� *FilterCommand+�� 5=      -   5        $��
Statystyki��5=      $	��100��6*   $��5q�66   5>      �� 5?      -   5        $��Pokaż cytat motywacyjny��5?      $��8q�5@      $��10q�5A      5B      �� 5C      $	��200��6   $��10,0,0,0q�6"   ��5D      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5E      �� 5H   
   $��Bottom=�6   .@�5I      �� ��6   �� *TaskSummary+5J      � 5L   
   $	��479��6    � ColumnDefinitions 5M      �� 5N      $	��200 �6#   �� 5O      $��* �6#   .+�5S      �� $��0��6   $��5q�6)   .+�5T      �� $��	Kategorie��6   $
��Bold"�6-   $��0 10 0 0q�6f   ��6?   �� *AddCategoryCommand+6f   �� 5U       �� DisplayMemberPath$
 Name��5W      ��5U      �� *
Categories+ �� SelectedItem 5V      �� *SelectedCategory+5W      5X      �� 5[      $��1��6   $��10q�6'   ��5\      �� *FilteredTasks+��5]      �� 5^      .R�5_      9�  9� 
IsExpanded$ False��6;   $��0 5 0 0q�6N   ��6#   �� *Name+.��5`      �� .+�5a   "   �� $��Italic$�6I   $��0 0 0 5q�6\   ��6,   �� *Description+6\   � 5b   "   .+�5c   &   �� $��Kategoria: ��60   $
��Bold"�6C   �� 5d   &   $	��5,0q�6O   ��60   �� *Category.Name+6O   �� 5e   &   $�� | Pilność: ��60   $
��Bold"�6D   $
��10,0q�6V   �� 5f   &   ��60   �� *
Priority+�� 5g   &   $�� | Termin: ��60   $
��Bold"�6C   $
��10,0q�6U   �� 5h   &   ��60   �� *	DueDate+5i   #   �� 5k   "   ��6/   �� *
SubTasks+��5l   &   �� 5m   *   .R�5n   .   ��  �� Orientation$ 
Horizontal=�69   $	��0,2q�6R   .+�5o   2   �� $��0,0,5,0q�6X    d� 	IsChecked 6;   �� *IsDone+6X   �� 5p   2   ��6<   �� *Name+5q   /   5r   +   5t   #   �� 5w   "   $��Edytuj��6)   $��0,10,0,0q�6:   $��Right=�6L   ��5x   !   �� *DataContext.EditTaskCommand+ �� RelativeSource ��  �� AncestorType
 Window��5y   !   �� �� 5z   "   $��Usuń��6)   $��0,10,0,0q�68   $��Right=�6J   ��5{   !   �� *DataContext.DeleteTaskCommand+ �� 
 Window��5|   !   �� 5      5�      5�      5�      5�      5�      5�      