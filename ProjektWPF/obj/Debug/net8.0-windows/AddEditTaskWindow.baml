   M S B A M L   `   `   `  ����  
ProjektWPF"    ProjektWPF.AddEditTaskWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Zadanie��5   	   $	��600��6   $	��400��6&    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� .+�5      �� $��Nazwa:��6   �� 5      ��6   �� *	Task.Name+�� 5      $��Opis:��6   $��0,5,0,0q�6%   �� 5       �� AcceptsReturn$
 True��68   $��60��6M   ��6   �� *Task.Description+6M   �� 5      $��
Kategoria:��6   $��0,5,0,0q�6*   �� 5       �� SelectedValuePath$ Id��5       �� DisplayMemberPath$
 Name��5      ��5      �� *
Categories+ �� SelectedValue 5      �� *Task.CategoryId+�� 5      $��Pilnosc:��6   $��0,5,0,0q�6(   �� 5       6   �� *Task.Priority+.@�5      �� $��Niski��6   
 � Tag$ 0��6/   �� 5      $��Sredni��6   $ 1��60   �� 5      $��Wysoki��6   $ 2��60   5      �� 5!      $��Data rozpoczęcia:��6   $��0,5,0,0q�61   (  "System.Windows.Controls.DatePicker  5"         SelectedDate 6   �� *Task.StartDate+�� 5$      $��Termin wykonania:��6   $��0,5,0,0q�61     5%       6   �� *Task.DueDate+�� 5'      $��
Ukończone��6   $��0,5,0,0q�6R   	 d� 	IsChecked	 6+   �� *Task.IsCompleted+6R   �� 5*      $��Podzadania:��6   $��	10,10,0,0q�6+   �� 5+      $	��100��6<   $��0,5,0,0q�6I   ��6   �� *Task.SubTasks+��5,      �� 5-      .R�5.      ]� .+�5/      �� $
��Left=�6>   ��6(   �� *Name+6>   �� 50      -   5        $��Usuń��50   %   $��Right=�64   $��5,0,0,0q�6K    52      �� 53      54      56      �� 5:      
 �� Orientation$
 
Horizontal=�6   $��0,5,0,0q�62   .+�5;      �� -   5         ��Name$ SubtaskNameBox��5;   &   $	��200��6   6&   �� 5<      -   5        $��Dodaj��5<      $��60��6)   $��5,0,0,0q�64   5=      5>      5@      �� 5B   
   $��1��6   $
 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5C      �� $��Zapisz��6   $��80��6&   $��5q�61    �� 	IsDefault$
 True��6<   ��6M   �� *SaveCommand+�� 5D      $��Anuluj��6   $��80��6&   $��5q�61    �� IsCancel$
 True��6<   5E      5F      5G      