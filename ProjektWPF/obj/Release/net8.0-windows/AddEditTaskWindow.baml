   M S B A M L   `   `   `  ����   
ProjektWPF"    ProjektWPF.AddEditTaskWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Zadanie��$	��500��$	��400�� � WindowStartupLocation$ CenterOwner=�.��� $��10q� � RowDefinitions �� $��* ��� $
��Auto �.+��� .+��� $��Nazwa:���� ���� *	Task.Name+�� $��Opis:��$��0,5,0,0q���  �� AcceptsReturn$
 True��$��60������ *Task.Description+�� $��
Kategoria:��$��0,5,0,0q���  �� DisplayMemberPath$
 Name������ *
Categories+ �� SelectedItem �� *Task.Category+�� $��Pilnosc:��$��0,5,0,0q���  �� SelectedValue �� *Task.Priority+.@��� $��Niski��
 � Tag$ 0���� $��Sredni��$ 1���� $��Wysoki��$ 2���� $��Data rozpoczęcia:��$��0,5,0,0q�(  "System.Windows.Controls.DatePicker     SelectedDate �� *Task.StartDate+�� $��Termin wykonania:��$��0,5,0,0q�   �� *Task.DueDate+�� $��
Ukończone��$��0,5,0,0q�	 d� 	IsChecked	 �� *Task.IsCompleted+�� $��Podzadania:��$��	10,10,0,0q��� $	��100��$��0,5,0,0q����� *Task.SubTasks+���� .R�]� .+��� $
��Left=����� *Name+�� -   $��Usuń��$��Right=�$��5,0,0,0q� �� �� 
 �� Orientation$
 
Horizontal=�$��0,5,0,0q�.+��� -    ��Name$ SubtaskNameBox��$	��200���� -   $��Dodaj��$��60��$��5,0,0,0q��� $��1��$
 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� $��Zapisz��$��80��$��5q� �� 	IsDefault$
 True������ *SaveCommand+�� $��Anuluj��$��80��$��5q� �� IsCancel$
 True��